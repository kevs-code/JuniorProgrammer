using UnityEngine;

namespace PrototypeThree
{
    public class PlayerController : MonoBehaviour
    {
        private Rigidbody playerRb;
        public float jumpForce = 700f; // 7
        public float gravityModifier = 1.5f;
        public bool isOnGround = true;
        public bool gameOver = false;
        private Animator playerAnim;

        void Start()
        {
            playerRb = GetComponent<Rigidbody>();
            playerAnim = GetComponent<Animator>();
            Physics.gravity *= gravityModifier;
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
            {
                playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isOnGround = false;
                playerAnim.SetTrigger("Jump_trig");
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
                playerAnim.SetBool("Death_b", true);
                playerAnim.SetInteger("DeathType_int", 1);
            }
        }
    }
}