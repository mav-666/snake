using UnityEngine;

namespace Electricity.SignalHandlers
{
    public class ActivationOnSignal : SignalExecutor
    {
        [SerializeField] private GameObject[] gameObjects;
        
        public override void ExecuteOn()
        {
            foreach (var gObj in gameObjects)
                gObj.SetActive(true);
        }

        public override void ExecuteOff()
        {
            foreach (var gObj in gameObjects)
                gObj.SetActive(false);
        }
    }
}