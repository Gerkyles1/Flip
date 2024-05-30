using GameProces;
using UnityEngine;
using UnityEngine.UI;

namespace UIscripts
{
    public class LevelSettings : MonoBehaviour
    {
        [SerializeField] private Text _playerPartsText;
        [SerializeField] private Text _chanceSpawnAdditionalObstacleText;
        [SerializeField] private Spawner _spawner;
        [SerializeField] private Player _player;
        [SerializeField] private GameObject _scoreInstance;

        private int _playerParts = 3;
        private float _chanceSpawnAdditionalObstacle = 0.03f;


        public void ChangePlayerParts(int changeNumber)
        {
            int newCount = _playerParts + changeNumber;
            if (newCount > 0 && newCount <= 6)
            {
                _playerParts = newCount;
                _playerPartsText.text = _playerParts.ToString();

            }

        }
        public void ChangeChanceSpawn(float changeNumber)
        {
            float newCount = _chanceSpawnAdditionalObstacle + changeNumber;
            if (newCount >= 0 && newCount <= 1)
            {
                _chanceSpawnAdditionalObstacle += changeNumber;
                _chanceSpawnAdditionalObstacleText.text = (int)(_chanceSpawnAdditionalObstacle * 100) + "%";
            }
        }

        public void StartPlay()
        {
            _spawner.SpawnChanceAddObstacle = _chanceSpawnAdditionalObstacle;
            _player.PlayerPartCount = _playerParts;
            Score._instance = _scoreInstance.GetComponent<Score>();
            Score._instance.SetMultiplyByPlayerParts(_playerParts);



        }
    }
}