using UnityEngine;

namespace PrototypeThree
{
    public class PlayerController : MonoBehaviour
    {
        private Rigidbody playerRb;
        public float jumpForce = 7f;
        public float gravityModifier = 1f;
        public bool isOnGround = true;
        public bool gameOver = false;

        void Start()
        {
            playerRb = GetComponent<Rigidbody>();
            Physics.gravity *= gravityModifier;
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
            {
                playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isOnGround = false;
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                isOnGround = true;
            }
            else if (collision.gameObject.CompareTag("Obstacle"))
            {
                gameOver = true;
                Debug.Log("Game Over!");
            }
        }
    }
}