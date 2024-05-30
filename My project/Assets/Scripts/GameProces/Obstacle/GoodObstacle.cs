using GameProces;
using UnityEngine;

public class GoodObstacle : Obstacle
{
    [SerializeField] private int _scorePoint = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !Score._isGameOver)
        {
            Score._instance.AddToScore(_scorePoint);
            Score._instance._audioSourceInstance.PlayGoodObstacle();
            Destroy(gameObject);

        }
    }
}
