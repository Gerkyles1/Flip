using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UIscripts
{
    public class MeinMenu : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI _bestScoreText;
        [SerializeField] Button _muteButton;
        [SerializeField] AudioSource _audioSource;
        [SerializeField] GameObject _muteImage;

        void Start()
        {
            _bestScoreText.text = "Best Score: " + PlayerPrefs.GetInt("BestScore", 0);
            _muteImage.SetActive(false);
            _muteButton.onClick.AddListener(MuteButtonEvent);

        }
        void MuteButtonEvent()
        {
            _audioSource.mute = !_audioSource.mute;
            _muteImage.SetActive(_audioSource.mute);

        }
    }
}