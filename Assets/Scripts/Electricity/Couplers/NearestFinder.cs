using Parasite;
using UnityEngine;

namespace Electricity.Couplers
{
    [RequireComponent(typeof(ConeSensor))]
    public class NearestFinder : Finder
    {
        private ConeSensor _sensor;

        private void Awake()
        {
            _sensor = GetComponent<ConeSensor>();
        }
        
        public override bool Find(out Electric found)
        {
            var hasFound = _sensor.Check(out var target);
            
            found = hasFound ? target.GetComponent<Electric>() : null;
            
            return hasFound;
        }
    }
}