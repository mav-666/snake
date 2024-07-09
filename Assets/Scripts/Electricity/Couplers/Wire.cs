using System.Linq;
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
        [SerializeField] private bool isHigh;
        [SerializeField, HideInInspector] private SplineElectronPool electronPool;

        private SplineComputer _spline;

#if UNITY_EDITOR
        private void OnValidate()
        {
            var findObjectsByType = FindObjectsByType<SplineElectronPool>(FindObjectsSortMode.None);
            if(findObjectsByType.Length == 0)
                return;
            
            electronPool = findObjectsByType
                .First(pool => pool.ElectronType == (isHigh ? SplineElectronPool.ElectronLayer.Above : SplineElectronPool.ElectronLayer.Floor));
            EditorUtility.SetDirty(this);
        }

        [ContextMenu("Swap")]
        private void Swap()
        {
            var temp = a;
            a = b;
            b = temp;
            EditorUtility.SetDirty(this);
        }

        [ContextMenu("FindNearestElectric")]
        private void FindNearestElectric()
        {
            var allElectric = FindObjectsByType<Electric>(FindObjectsSortMode.None);
            
            var spline = GetComponent<SplineComputer>();
            
            a = allElectric.OrderBy(electric => Vector3.Distance(electric.transform.position, spline.GetPoint(0).position)).First();
            b = allElectric.OrderBy(electric => Vector3.Distance(electric.transform.position, spline.GetPoint(spline.pointCount - 1).position)).First();

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
           
            electron.Init(_spline, transmitDuration,
                () => electronPool.Release(electron),
                () =>
                    {
                        if (b.ReceiveSignal(this))
                            electronPool.Release(electron);
                        else
                            electron.Fade();
                    });
        }

        protected override void TransmitFromB()
        {
            var electron = electronPool.Get(false);
            
            electron.Init(_spline, transmitDuration, 
                () => electronPool.Release(electron),
                () =>
                    {
                        if (a.ReceiveSignal(this))
                            electronPool.Release(electron);
                        else
                            electron.Fade();
                    }, true);
        }
    }
}