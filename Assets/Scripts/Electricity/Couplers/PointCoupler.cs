using System;
using System.Collections.Generic;
using DG.Tweening;
using Electricity.Couplers.Electrons;
using UnityEditor;
using UnityEngine;
#if UNITY_EDITOR

#endif

namespace Electricity.Couplers
{
    public class PointCoupler : FindingCoupler
    {
        [SerializeField] private float transmitDuration;
        
        [SerializeField, HideInInspector] private PointElectronPool electronPool;
        
        private Transform[] _points; 
        private Transform[] _pointsReverse;
        private readonly List<PointElectron> _activeElectrons = new();
            
#if UNITY_EDITOR
        private void OnValidate()
        {
            electronPool = FindFirstObjectByType<PointElectronPool>();
            EditorUtility.SetDirty(this);
        }
#endif

        protected void Init(Transform[] points)
        {
            _points = new Transform[points.Length + 2];
            _pointsReverse = new Transform[_points.Length];
            
            points.CopyTo(_points, 1);
            _points.CopyTo(_pointsReverse, 0);
            Array.Reverse( _pointsReverse);
        }

        public override void FindA()
        {
            base.FindA();
            
            if(!IsConnectedA)
                return;
            
            _pointsReverse[^1] = A.transform;
            _pointsReverse.CopyTo(_points, 0);
            Array.Reverse(_points);
        }

        public override void FindB()
        {
            base.FindB();
            
            if(!IsConnectedB)
                return;
            
            _points[^1] = B.transform;
            _points.CopyTo(_pointsReverse, 0);
            Array.Reverse(_pointsReverse);
        }

        public override void BreakA()
        {
            base.BreakA();
            FadeElectrons();
        }

        public override void BreakB()
        {
            base.BreakB();
            FadeElectrons();
        }

        private void FadeElectrons()
        {
            foreach (var electron in _activeElectrons)
            {
                DOTween.Kill(electron.transform);
                electron.Fade();
            }
            _activeElectrons.Clear();
        }
        
        protected override void TransmitFromA()
        {
            TransmitElectron(_points, () => B.ReceiveSignal(this));
        }

        protected override void TransmitFromB()
        {
            TransmitElectron(_pointsReverse, () => A.ReceiveSignal(this));
        }

        private void TransmitElectron(Transform[] points, Func<bool> receiveSignal)
        {
            var electron = electronPool.Get(false);
            electron.Init(points, transmitDuration, () => electronPool.Release(electron), GetHashCode());

            electron.OnReachedEnd += () =>
            {
                if (receiveSignal.Invoke())
                    Release(electron);
                else
                    electron.Fade();
            };

            _activeElectrons.Add(electron);
            electron.gameObject.SetActive(true);
        }

        private void Release(PointElectron electron)
        {
            _activeElectrons.Remove(electron);
            electronPool.Release(electron);
        }
    }
}