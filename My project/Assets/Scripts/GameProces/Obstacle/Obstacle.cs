using UnityEngine;


namespace GameProces
{
    public class Obstacle : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _distance;
        private Vector2 _startPosition;

        void Start()
        {
            _startPosition = transform.position;
        }

        void FixedUpdate()
        {
            transform.Translate(Vector2.up * _speed * Time.deltaTime);

            if (Vector2.Distance(_startPosition, transform.position) >= _distance)
                Destroy(gameObject);

        }
    }
}