using System;
using System.Reflection;
using Dreamteck.Splines;
using UnityEngine.Rendering.Universal;

namespace Electricity.Couplers.Electrons
{
    public class SplineElectron : Electron
    {
        private static readonly FieldInfo TargetSortingLayersField = typeof(Light2D).GetField("m_ApplyToSortingLayers", BindingFlags.NonPublic | BindingFlags.Instance);
        
        private SplineFollower _follower;
        private Light2D _light2d;

        private int[] _maskAll;
        private int[] _excluded;

        protected override void Awake()
        {
            base.Awake();
            _follower = GetComponent<SplineFollower>();
            _light2d = GetComponent<Light2D>();
            
            _maskAll = TargetSortingLayersField.GetValue(_light2d) as int[];
            _excluded = new int[_maskAll.Length-1];
            Array.Copy(_maskAll, _excluded, _excluded.Length);
        }

        public void Init(SplineComputer spline, float duration, Action onReach, bool isHigh = false, bool isBackward = false)
        {
            _follower.followDuration = duration;
            _follower.spline = spline;
            
            ResetColor();
            
            if(isHigh)
                IncludeAllLayers();
            else
                ExcludeLayer();

            if (isBackward)
                ResetBackward(onReach);
            else
                ResetForward(onReach);
            
            
        }

        private void IncludeAllLayers()
        {
            TargetSortingLayersField.SetValue(_light2d, _maskAll);
        }

        private void ExcludeLayer()
        {
            TargetSortingLayersField.SetValue(_light2d, _excluded);
        }
        
        private void ResetBackward(Action onReach)
        {
            _follower.onBeginningReached = null;
            _follower.onBeginningReached += _ => onReach();
            gameObject.SetActive(true);
            _follower.direction = Spline.Direction.Backward;
            _follower.Restart(1);
        }
        
        private void ResetForward(Action onReach)
        {
            _follower.onEndReached = null;
            _follower.onEndReached += _ => onReach();
            gameObject.SetActive(true);
            _follower.direction = Spline.Direction.Forward;
            _follower.Restart();
        }
    }
}