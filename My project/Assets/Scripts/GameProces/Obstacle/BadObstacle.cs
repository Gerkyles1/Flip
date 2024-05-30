using GameProces;
using UnityEngine;

public class BadObstacle : Obstacle
{
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player" && !Score._isGameOver)
        {
            GameObject vfx = (GameObject)Resources.LoadAll("Prefabs/VFX")[0];
            Instantiate(vfx, collision.transform.position, collision.transform.rotation);
            Destroy(collision.gameObject);
            Score._instance.SetGameOverTrue();
        }

    }
}
