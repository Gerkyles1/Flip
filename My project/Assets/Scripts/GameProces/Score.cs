using UnityEngine;
using UnityEngine.UI;

namespace GameProces
{
    public class Score : MonoBehaviour
    {
        [SerializeField] private Text _scoreText;
        [SerializeField] private Text _bestScoreText;
        [SerializeField] private GameObject _restartButton;
        [SerializeField] public AudioController _audioSourceInstance;

        private int _multiplyByPlayerParts = 1;
        public static bool _isGameOver { get; private set; } = false;
        public static Score _instance;

        private static int _score = 0;

        private const string MAX_SCORE_KEY = "BestScore";
        void Awake()
        {
            if (_instance == null)
                _instance = this;

            else if (_instance != this)
                Destroy(gameObject);

            _bestScoreText.text = "Best score: " + GetHighScore();

        }

        public void AddToScore(int count)
        {
            _score += count * _multiplyByPlayerParts;
            _scoreText.text = "Score: " + _score;
            if(_score > GetHighScore())
                _bestScoreText.text = "Best score: " + _score;

        }
        public void SetGameOverTrue()
        {
            _isGameOver = true;
            _audioSourceInstance.PlayGameOver();
            UpdateHighScore(_score);
            _restartButton.SetActive(true);

        }
        public void Restart()
        {
            _isGameOver = false;
            _score = 0;
            _scoreText.text = "Score: " + _score;


        }



        public void UpdateHighScore(int score)
        {
            int highScore = PlayerPrefs.GetInt(MAX_SCORE_KEY, 0); 

            if (score > highScore)
            {
                PlayerPrefs.SetInt(MAX_SCORE_KEY, score); 
                PlayerPrefs.Save(); 
            }
        }

        public int GetHighScore()
        {
            return PlayerPrefs.GetInt(MAX_SCORE_KEY, 0); 
        }

        public void SetMultiplyByPlayerParts(int mul)
        {
            _multiplyByPlayerParts = mul;
        }

    }
}