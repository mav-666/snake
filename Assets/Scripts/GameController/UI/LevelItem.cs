using DG.Tweening;
using Graphic.Animation;
using UnityEngine;
using UnityEngine.UI;

namespace GameController.UI
{
    [RequireComponent(typeof(Button))]
    public class LevelItem : MonoBehaviour
    {
        [SerializeField] private Image preview;
        [SerializeField] private Image notAvailable;

        private GameManager _gameManager;
        private int _levelIndex;
        
        private bool _isOpened;
        
        public void Init(GameManager gameManager, Sprite previewSprite, int index, bool isOpened = true)
        {
            _gameManager = gameManager;
            _levelIndex = index;
            _isOpened = isOpened;
            preview.sprite = previewSprite;

            if (!isOpened)
                HideImage();
        }

        private void HideImage()
        {
            preview.color = Color.HSVToRGB(0, 0, 0.5f);
            notAvailable.gameObject.SetActive(true);
            GetComponent<TweenAnimation>().Animation.Kill();
        }
        
        private void Start()
        {
            if(_isOpened)
                GetComponent<Button>().onClick.AddListener(SetScene);
        }
        
        private void SetScene()
        {
            _gameManager.SetLevel(_levelIndex);
        }
    }
}