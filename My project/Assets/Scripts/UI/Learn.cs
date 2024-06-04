using UnityEngine;
using UnityEngine.UI;

namespace UIscripts
{
    public class Learn : MonoBehaviour
    {
        [SerializeField] private Sprite[] images;
        [SerializeField] private Image displayImage;
        [SerializeField] private Button nextButton;
        [SerializeField] private Button previousButton;

        private int currentIndex = 0;

        void Start()
        {
            if (images.Length > 0)
            {
                displayImage.sprite = images[currentIndex];
            }

            nextButton.onClick.AddListener(ShowNextImage);
            previousButton.onClick.AddListener(ShowPreviousImage);

            UpdateButtonStates();
        }

        void ShowNextImage()
        {
            if (currentIndex < images.Length - 1)
            {
                currentIndex++;
                displayImage.sprite = images[currentIndex];
            }


            UpdateButtonStates();
        }

        void ShowPreviousImage()
        {
            if (currentIndex > 0)
            {
                currentIndex--;
                displayImage.sprite = images[currentIndex];
            }

            UpdateButtonStates();
        }

        void UpdateButtonStates()
        {
            previousButton.interactable = currentIndex > 0;
            nextButton.interactable = currentIndex < images.Length - 1;
        }


    }
}