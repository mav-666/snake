using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace GameController.UI
{
    public class ScrollItems : Selectable
    {
        [SerializeField] private Scrollbar scrollbar;
        [SerializeField] private Transform content;
        [SerializeField] private float lerp;

        private float[] _targets;
        private Selectable[] _selectables;

        [SerializeField] private int _currentIndex;
        private float _currentTarget;
        
        protected override void Start()
        {
            base.Start();
            _selectables = GetComponentsInChildren<Selectable>();

            _targets =  new float[content.transform.childCount];
            var distance = 1f / (_targets.Length - 1f);

            for (var i = 0; i < _targets.Length; i++)
                _targets[i] = distance * i;
            
            scrollbar.value = 0;
            SelectCurrent();
        }

        public void Next()
        {
            if (_currentIndex + 1 >= _targets.Length)
                return;
            
            _currentTarget = _targets[++_currentIndex];
            SelectCurrent();
        }

        public void Previous()
        {
            if (_currentIndex - 1 <= -1)
                return;
            
            _currentTarget = _targets[--_currentIndex];
            SelectCurrent();
        }

        public override void OnSelect(BaseEventData eventData)
        {
            SelectCurrent();
        }

        private void SelectCurrent()
        {
            _selectables[_currentIndex+1].Select();
        }
        
        private void Update()
        {
            scrollbar.value = Mathf.Lerp(scrollbar.value, _currentTarget, lerp);
        }
    }
}