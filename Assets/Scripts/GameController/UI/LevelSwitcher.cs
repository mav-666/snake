using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameController.UI
{
    public class LevelSwitcher : MonoBehaviour
    {
        [Serializable]
        private class Level
        {
            [SerializeField] public Sprite preview;
            [SerializeField] public string name;
            [SerializeField] public int index;
        }

        [SerializeField] private GameManager gameManager;
        [SerializeField] private Level[] levels;
        
        
        
        private int _selected;
        
        public void PlaySelected()
        {
            gameManager.SetLevel(levels[_selected].index);
        }

        public void Next()
        {
            
        }

        public void Previous()
        {
            
        }
        
    }
}