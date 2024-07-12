using Electricity.Couplers;
using GameController;
using GameController.Audio;
using UnityEngine;

namespace Electricity
{
    public class Battery : Electric
    {
        [SerializeField] private float frequency;
        [SerializeField] private bool enabledOnStart;
        [SerializeField] private SoundPlayer soundPlayer;
        private Timer _timer;

        protected override void Awake()
        {
            base.Awake();
            _timer = new Timer();
        }

        private void Start()
        {
            if (!enabledOnStart)
                return;

            _timer.Start(frequency);
        }

        private void Update()
        {
            if (_timer.Update(Time.deltaTime))
            {
                SendSignal();
                _timer.Start(frequency);
            }
        }

        public void TurnOn()
        {
            SendSignal();
            _timer.Start(frequency);
        }

        public void TurnOff()
        {
            _timer.Stop();
        }

        protected override bool SendSignal()
        {
            soundPlayer.On();
            return base.SendSignal();
        }

        public override bool ReceiveSignal(Coupler sender)
        {
            base.ReceiveSignal(sender);
            
            return false;
        }
    }
}