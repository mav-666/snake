using UnityEngine;

namespace Parasite
{
    [RequireComponent(typeof(OpeningEye))]
    [RequireComponent(typeof(PowerSensor))]
    public class PoweredEye : MonoBehaviour
    {
        private OpeningEye _parasiteEye;
        private PowerSensor _powerSensor;
        
        private void Awake()
        {
            _powerSensor = GetComponent<PowerSensor>();
            _parasiteEye = GetComponent<OpeningEye>();
        }

        private void OnEnable()
        {
            _powerSensor.OnPowerLevelAchieve += _parasiteEye.Open;
            _powerSensor.OnPowerLevelLose += _parasiteEye.Close;
        }

        private void OnDisable()
        {
            _powerSensor.OnPowerLevelAchieve -= _parasiteEye.Open;
            _powerSensor.OnPowerLevelLose -= _parasiteEye.Close;
        }
    }
}