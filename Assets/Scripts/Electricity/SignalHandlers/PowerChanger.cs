using Parasite;
using UnityEngine;

namespace Electricity.SignalHandlers
{
    public class PowerChanger : SignalExecutor
    {
        [SerializeField] private PowerSensor[] powerSensors;
        
        public override void ExecuteOn()
        {
            foreach (var powerSensor in powerSensors)
                powerSensor.PowerUp();
        }

        public override void ExecuteOff()
        {
            foreach (var powerSensor in powerSensors)
                powerSensor.PowerDown();
        }
    }
}