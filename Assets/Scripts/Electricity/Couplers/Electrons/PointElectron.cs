using System;
using DG.Tweening;
using UnityEngine;

namespace Electricity.Couplers.Electrons
{
    public class PointElectron : Electron
    {
        public event Action OnReachedEnd;
        
        private Transform[] _points;
        
        private float _absoluteDistance;
        private float _absoluteDuration;
        
        private int _currentPoint;

        private bool _isStopped;
        
        public void Init(Transform[] points, float duration, Action onFail, int shipID)
        {
            base.Init(onFail, shipID);
            
            _points = points;
            _currentPoint = 0;
            _absoluteDuration = duration;
            _isStopped = false;
            CalcAbsoluteDistance();
            OnReachedEnd = null;
           

            var trans = transform;
            trans.position = _points[0].position;
            trans.localScale = _points[0].lossyScale;
            
            NextPoint(_points[1]);
        }

        private void CalcAbsoluteDistance()
        {
            _absoluteDistance = 0;
            for (var i = 0; i < _points.Length-1; i++)
                _absoluteDistance += Vector3.Distance(_points[i].position, _points[i+1].position);
        }
        
        private void NextPoint(Transform target)
        {
            var targetPos = target.position;

            var duration = _absoluteDuration * (Vector3.Distance(transform.position, targetPos) / _absoluteDistance);
            transform.DOMove(targetPos, duration).SetEase(Ease.Linear).OnComplete(ReachPoint);
            transform.DOScale(target.lossyScale, duration).SetEase(Ease.Linear);
        }

        private void ReachPoint()
        {
            if(_isStopped)
                Fade();
            if (++_currentPoint >= _points.Length)
                ReachEnd();
            else
                NextPoint(_points[_currentPoint]);
        }

        private void ReachEnd()
        {
            OnReachedEnd?.Invoke();
        }
        
        protected override void Stop()
        {
            _isStopped = true;
            DOTween.Kill(transform);
        }
    }
}