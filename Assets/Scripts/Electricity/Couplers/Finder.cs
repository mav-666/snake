using UnityEngine;

namespace Electricity.Couplers
{
    public abstract class Finder : MonoBehaviour
    {
        public abstract bool Find(out Electric found);
    }
}