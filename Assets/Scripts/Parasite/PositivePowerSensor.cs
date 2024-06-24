namespace Parasite
{
    public class PositivePowerSensor : PowerSensor
    {
        public override void PowerUp()
        {
            powerLevel++;
        }

        public override void PowerDown()
        {
            powerLevel--;
        }

        protected override bool CheckRequiredPowerLevel()
        {
            return powerLevel > 0;
        }
    }
}