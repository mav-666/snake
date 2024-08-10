using System;
using UnityEngine;

namespace GameController.Audio
{
    [CreateAssetMenu]
    public class LevelMusic : ScriptableObject
    {
        [Serializable]
        public class IndexMusic
        {
            [SerializeField] private int sceneIndex;
            [SerializeField] private AudioClip music;
            
            public int SceneIndex => sceneIndex;
            public AudioClip Music => music;
        }

        [SerializeField] private IndexMusic[] indexMusic;
        [SerializeField] private AudioClip defaultMusic;

        public AudioClip GetMusicBy(int sceneIndex)
        {
            var music = defaultMusic;
            
            foreach (var pair in indexMusic)
                if (sceneIndex >= pair.SceneIndex)
                    music = pair.Music;

            return music;
        }
    }
}