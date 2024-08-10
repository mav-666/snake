using Parasite;
using UnityEngine;

namespace Electricity.Couplers
{
    [RequireComponent(typeof(ConeSensor))]
    public class NearestFinder : Finder
    {
        private ConeSensor _sensor;

        protected override void Awake()
        {
            base.Awake();
            _sensor = GetComponent<ConeSensor>();
        }
        
        public override bool Find(out Connectable found)
        {
            var hasFound = _sensor.Check(out var target);

            if (hasFound)
                FindInCache(target, out found);
            else
                found = null;
            
            return hasFound;
        }
    }
}