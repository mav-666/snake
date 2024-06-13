namespace Parasite
{
    public class NegativePowerSensor : PowerSensor
    {
        public override void PowerUp()
        {
            _powerLevel--;
        }

        public override void PowerDown()
        {
            _powerLevel++;
        }

        protected override bool CheckRequiredPowerLevel()
        {
            return _powerLevel < 0;
        }
    }
}