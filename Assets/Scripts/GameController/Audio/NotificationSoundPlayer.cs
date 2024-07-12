using UnityEngine;

namespace GameController.Audio
{
    public class NotificationSoundPlayer : SingleSoundPlayer
    {
        protected override void InitSound(bool isOn)
        {
            base.InitSound(isOn);
            _temp.spatialBlend = 0;
        }

        protected override void Release(AudioSource temp)
        {
            _temp.spatialBlend = 1;
            base.Release(temp);
        }
    }
}