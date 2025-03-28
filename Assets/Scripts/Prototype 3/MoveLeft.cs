using UnityEngine;

namespace PrototypeThree
{
    public class MoveLeft : MonoBehaviour
    {
        private float speed = 10f;
        private PlayerController playerControllerScript;
        private float leftBound = -15f;

        private void Start()
        {
            playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        }

        private void Update()
        {
            if (playerControllerScript.gameOver == false)
            {
                transform.Translate(Vector3.left * Time.deltaTime * speed);
            }

            if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
            {
                Destroy(gameObject);
            }
        }
    }
}