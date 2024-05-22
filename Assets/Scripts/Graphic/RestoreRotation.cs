using UnityEngine;

namespace Graphic
{
    public class RestoreRotation : MonoBehaviour
    {
        private Quaternion _restore;

        private void Start()
        {
            _restore = transform.parent.localRotation;
        }

        private void Update()
        {
            var parentRotation = transform.parent.localRotation;

            transform.localRotation =
                Quaternion.Inverse(parentRotation)
                * _restore
                * transform.localRotation;

            _restore = parentRotation;
        }
    }
}