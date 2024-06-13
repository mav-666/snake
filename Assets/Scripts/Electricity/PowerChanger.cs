using Parasite;
using UnityEngine;

namespace Electricity
{
    public class PowerChanger : MonoBehaviour, ISignalExecutor
    {
        [SerializeField] private PowerSensor[] powerSensors;
        
        public void ExecuteOn()
        {
            foreach (var powerSensor in powerSensors)
                powerSensor.PowerUp();
        }

        public void ExecuteOff()
        {
            foreach (var powerSensor in powerSensors)
                powerSensor.PowerDown();
        }
    }
}