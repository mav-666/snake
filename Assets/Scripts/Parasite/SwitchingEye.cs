using UnityEngine;

namespace Parasite
{
    [RequireComponent(typeof(PowerSensor))]
    public class SwitchingEye : MonoBehaviour
    {
        [SerializeField] private ParasiteEye positiveEye;
        [SerializeField] private ParasiteEye negativeEye;

        [SerializeField] private GameObject positive;
        [SerializeField] private GameObject negative;
        
        private PowerSensor _powerSensor;

        private void Awake()
        {
            _powerSensor = GetComponent<PowerSensor>();
        }
        
        private void OnEnable()
        {
            _powerSensor.OnPowerLevelAchieve += negativeEye.Close;
            _powerSensor.OnPowerLevelLose += positiveEye.Close;
            
            negativeEye.OnClose += CloseNegative;
            positiveEye.OnClose += ClosePositive;
        }

        private void OnDisable()
        {
            _powerSensor.OnPowerLevelAchieve -= negativeEye.Close;
            _powerSensor.OnPowerLevelLose -= positiveEye.Close;
            
            negativeEye.OnClose -= CloseNegative;
            positiveEye.OnClose -= ClosePositive;
        }

        private void CloseNegative()
        {
            negative.SetActive(false);
            positive.SetActive(true);
            positiveEye.Open();
        }

        private void ClosePositive()
        {
            positive.SetActive(false);
            negative.SetActive(true);
            negativeEye.Open();
        }
    }
}