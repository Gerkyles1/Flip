using System.Collections.Generic;
using UnityEngine;

namespace GameProces
{
    public class Player : MonoBehaviour
    {

        [SerializeField] private GameObject _playerPartPrefab;
        [SerializeField] private float _distance;
        [SerializeField] private float _rotationSpeed;
        private List<GameObject> _playerParts = new List<GameObject>();

        [SerializeField] private int _playerPartCount;
        public int PlayerPartCount
        {
            get => _playerPartCount;

            set
            {
                _playerPartCount = value;
                CleanPlayerParts();
                SpawnPlayerParts();
            }

        }

        private bool _rotateClockwise = true;


        void Start()
        {
            CleanPlayerParts();
            SpawnPlayerParts();
        }

        void Update()
        {

            if (Input.GetMouseButtonDown(0))
            {
                _rotateClockwise = !_rotateClockwise;
                Score._instance._audioSourceInstance.PlayFlip();
            }
        }
        private void FixedUpdate()
        {

            if (Score._isGameOver)
                return;

            RotateObject();
            
        }

        private void SpawnPlayerParts()
        {
            float angleStep = 360f / _playerPartCount;

            for (int i = 0; i < _playerPartCount; i++)
            {
                float angle = i * angleStep;
                float angleRad = angle * Mathf.Deg2Rad;
                Vector2 spawnPosition = new Vector2(Mathf.Cos(angleRad), Mathf.Sin(angleRad)) * _distance;
                _playerParts.Add(Instantiate(_playerPartPrefab, spawnPosition, Quaternion.identity, transform));
            }
        }

        private void RotateObject()
        {
            float rotationDirection = _rotateClockwise ? -1 : 1;
            transform.Rotate(0, 0, _rotationSpeed * Time.deltaTime * rotationDirection);
        }
        private void CleanPlayerParts()
        {
            if (_playerParts != null)
            {
                foreach (GameObject part in _playerParts)
                {
                    if (part != null)
                        Destroy(part);
                }
                _playerParts.Clear();
            }
        }
    }
}