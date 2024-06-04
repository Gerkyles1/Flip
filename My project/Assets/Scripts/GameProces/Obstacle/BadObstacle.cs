using UnityEngine;

namespace GameProces
{
    public class BadObstacle : Obstacle
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {

            if (collision.tag == "Player" && !Score._isGameOver)
            {
                GameObject vfx = (GameObject)Resources.LoadAll("Prefabs/VFX")[0];
                Destroy(Instantiate(vfx, collision.transform.position, collision.transform.rotation), 5f);
                collision.gameObject.SetActive(false);
                Score._instance.SetGameOverTrue();
            }

        }
    }
}