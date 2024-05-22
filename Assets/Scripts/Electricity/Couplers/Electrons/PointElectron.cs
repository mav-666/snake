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
        
        public void Init(Transform[] points, float duration)
        {
            _points = points;
            _currentPoint = 0;
            _absoluteDuration = duration;
            CalcAbsoluteDistance();
            OnReachedEnd = null;
            ResetColor();

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
            if (++_currentPoint >= _points.Length)
                ReachEnd();
            else
                NextPoint(_points[_currentPoint]);
        }

        private void ReachEnd()
        {
            OnReachedEnd?.Invoke();
        }
    }
}