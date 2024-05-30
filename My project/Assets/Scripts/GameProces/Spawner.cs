using UnityEngine;

namespace GameProces
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private GameObject[] _obstaclePrefabs;
        [SerializeField] private int _maxObstacleCount = 5;
        [SerializeField] private float _spawnTime = 2f;
        [SerializeField] private float _spawnChanceAddObstacle = 0.3f;
        public float SpawnChanceAddObstacle { get => _spawnChanceAddObstacle; set => _spawnChanceAddObstacle = value; }


        private int _spawnedObstacleWaves = 0;


        private void Start()
        {
            InvokeRepeating(nameof(SpawnObstacle), 1f, _spawnTime);
        }

        
        private void SpawnObstacle()
        {
            if (Score._isGameOver)
                return;
            Instantiate(_obstaclePrefabs[Random.Range(0, _obstaclePrefabs.Length)], transform.position, Quaternion.identity).transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));
            
            for (int i = 1; i < _maxObstacleCount; i++)
            {
                if (Random.Range(0, 1f) > _spawnChanceAddObstacle)
                    continue;

                GameObject spawnedObstacle = Instantiate(_obstaclePrefabs[Random.Range(0, _obstaclePrefabs.Length)], transform.position, Quaternion.identity);

                spawnedObstacle.transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));

                if (_spawnedObstacleWaves / 30 > _maxObstacleCount)
                    _maxObstacleCount++;


            }
            _spawnedObstacleWaves++;
        }

    }
}