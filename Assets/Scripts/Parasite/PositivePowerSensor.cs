namespace Parasite
{
    public class PositivePowerSensor : PowerSensor
    {
        public override void PowerUp()
        {
            _powerLevel++;
        }

        public override void PowerDown()
        {
            _powerLevel--;
        }

        protected override bool CheckRequiredPowerLevel()
        {
            return _powerLevel > 0;
        }
    }
}