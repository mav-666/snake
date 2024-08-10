using System;
using System.Collections.Generic;
using UnityEngine;

namespace Electricity.Couplers
{
    public abstract class Finder : MonoBehaviour
    {
        private Dictionary<GameObject, Connectable> _cached;

        protected virtual void Awake()
        {
            _cached = new Dictionary<GameObject, Connectable>();
        }

        public abstract bool Find(out Connectable found);

        public bool Find(out Electric found)
        {
            var hasFound = Find(out Connectable connectable);

            found = hasFound ? connectable.Electric : null;
            
            return hasFound;
        }
        
        protected void FindInCache(GameObject target, out Connectable found)
        {
            if (_cached.TryGetValue(target, out found))
                return;
            
            found = target.GetComponent<Connectable>();
            _cached.Add(target, found);
        }
    }
}