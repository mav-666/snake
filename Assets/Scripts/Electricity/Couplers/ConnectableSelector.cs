using Snake;
using UnityEngine;

namespace Electricity.Couplers
{
    [RequireComponent(typeof(Finder))]
    public class ConnectableSelector : MonoBehaviour
    {
        private Finder _finder;
        private Connectable _lastConnectable;
        private bool _hasLastFound;

        private SegmentMobility _segmentMobility;
        
        private void Awake()
        {
            _finder = GetComponent<Finder>();
            _segmentMobility = GetComponent<SegmentMobility>();
        }

        private void Update()
        {
            if(_segmentMobility.CanNotMove)
                if (_hasLastFound)
                {
                    _lastConnectable.Deselect();
                    _hasLastFound = false;
                }
                else 
                    return;

            var hasFound = _finder.Find(out Connectable connectable);

            if (!hasFound && _hasLastFound)
                _lastConnectable.Deselect();

            if (hasFound && connectable != _lastConnectable)
            {
                connectable.Select();
                
                if(_hasLastFound)
                    _lastConnectable.Deselect();
            }
            
            _lastConnectable = connectable;
            _hasLastFound = hasFound;
        }
    }
}