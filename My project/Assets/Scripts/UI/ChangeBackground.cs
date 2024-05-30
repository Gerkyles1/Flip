using UnityEngine;
using UnityEngine.UI;

namespace UIscripts
{
    public class ChangeBackground : MonoBehaviour
    {
        [SerializeField] private Image _backgroundToChange;
        void Start()
        {
            Button button = GetComponent<Button>();

            button.onClick.AddListener(() =>
            {
                _backgroundToChange.color = Color.white;
                _backgroundToChange.sprite = button.image.sprite;
            });
        }
        public void SetDefault()
        {
            _backgroundToChange.color = Color.black;
            _backgroundToChange.sprite = null;
        }


    }

}
