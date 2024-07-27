using UnityEngine;
using UnityEngine.UI;

namespace GameController.UI
{
    public class ScrollItems : MonoBehaviour
    {
        [SerializeField] private Scrollbar scrollbar;
        [SerializeField] private Transform content;
        [SerializeField] private float lerp;

        private float[] _targets;
        private Selectable[] _selectables;

        private int _currentIndex;
        private float _currentTarget;
        

        private void Start()
        {
            _selectables = GetComponentsInChildren<Selectable>();

            _targets =  new float[content.transform.childCount];
            var distance = 1f / (_targets.Length - 1f);

            for (var i = 0; i < _targets.Length; i++)
                _targets[i] = distance * i;
            
            scrollbar.value = 0;
            
            EnableCurrent();
        }

        public void Next()
        {
            if (_currentIndex + 1 >= _targets.Length)
                return;
            
            DisableCurrent();
            _currentTarget = _targets[++_currentIndex];
            EnableCurrent();
        }

        public void Previous()
        {
            if (_currentIndex - 1 <= -1)
                return;
            
            DisableCurrent();
            _currentTarget = _targets[--_currentIndex];
            EnableCurrent();
        }

        private void DisableCurrent()
        {
            _selectables[_currentIndex].interactable = false;
        }
        
        private void EnableCurrent()
        {
            _selectables[_currentIndex].interactable = true;
        }
        
        private void Update()
        {
            scrollbar.value = Mathf.Lerp(scrollbar.value, _currentTarget, lerp);
        }

        
    }
}