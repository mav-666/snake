using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameController.Audio
{
    public class MusicSoundPlayer : LoopSoundPlayer
    {
        [SerializeField] private LevelMusic levelMusic;
        
        private static bool _isPlaying;
        
        private bool _isOn;
        
        public override void On()
        {
            if(_isPlaying)
                return;
            
            _isPlaying = true;
            _isOn = true;
            base.On();
        }

        public override void Off()
        {
            _isPlaying = false;
            _isOn = false;
            base.Off();
        }
        
        protected override void Release()
        {
            base.Release();
            Destroy(gameObject);
        }

        private void OnEnable()
        {
            SceneManager.sceneLoaded += InitMusicByScene;
        }
        
        private void OnDisable()
        {
            SceneManager.sceneLoaded -= InitMusicByScene;
        }

        private void InitMusicByScene(Scene scene, LoadSceneMode mode)
        {
            if (_isPlaying == false)
                InitMusic();    
            else if(_isOn && _temp.clip != levelMusic.GetMusicBy(scene.buildIndex))
                Off();
            else if(!_isOn)
                Destroy(gameObject);
        }

        private void InitMusic()
        {
            audioClip = levelMusic.GetMusicBy(SceneManager.GetActiveScene().buildIndex);
            transform.SetParent(transform.root.parent);
            DontDestroyOnLoad(this);
        }
    }
}