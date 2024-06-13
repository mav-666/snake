namespace Parasite
{
    public class UpdateSensor : SensorHandler
    {
        private void Update()
        {
            if(_sensor.Check(out _))
                FoundTarget();
            else
                LostTarget();
        }
    }
}