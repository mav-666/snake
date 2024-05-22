using Dreamteck.Splines;
using Electricity.Couplers.Electrons;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Electricity.Couplers
{
    public class Wire : Coupler
    {
        [SerializeField] private Electric a;
        [SerializeField] private Electric b;
        [SerializeField] private float transmitDuration;
        [SerializeField, HideInInspector] private SplineElectronPool electronPool;

        private SplineComputer _spline;

#if UNITY_EDITOR
        private void OnValidate()
        {
            electronPool = FindFirstObjectByType<SplineElectronPool>();
            EditorUtility.SetDirty(this);
        }
#endif

        private void Start()
        {
            _spline = GetComponent<SplineComputer>();
            
            Init(a, b);
        }
        
        protected override void TransmitFromA()
        {
            var electron = electronPool.Get(false);
           
            electron.Init(_spline, transmitDuration, () =>
            {
                if (b.ReceiveSignal(this))
                    electronPool.Release(electron);
                else
                    electron.Fade(() => electronPool.Release(electron));
            });
        }

        protected override void TransmitFromB()
        {
            var electron = electronPool.Get(false);
            
            electron.Init(_spline, transmitDuration, () =>
            {
                if (a.ReceiveSignal(this))
                    electronPool.Release(electron);
                else
                    electron.Fade(() => electronPool.Release(electron));
            }, true);
        }
    }
}