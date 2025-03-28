using UnityEngine;

namespace ChallengeThree
{
    public class PlayerControllerX : MonoBehaviour
    {
        private float gravityModifier = 1f;
        private Rigidbody playerRb;
        private AudioSource playerAudio;

        public bool gameOver = true;
        public float floatForce = 2.5f;
        public float yLowerRange = 2f;
        public float yUpperRange = 14f;
        public ParticleSystem explosionParticle;
        public ParticleSystem fireworksParticle;

        public AudioClip moneySound;
        public AudioClip explodeSound;
        public AudioClip bounceSound;

        // Start is called before the first frame update
        void Start()
        {
            Physics.gravity *= gravityModifier;
            playerAudio = GetComponent<AudioSource>();
            playerRb = GetComponent<Rigidbody>();
            // Apply a small upward force at the start of the game
            playerRb.AddForce(Vector3.up * floatForce, ForceMode.Impulse);

        }

        // Update is called once per frame
        void Update()
        {
            if (transform.position.y < yLowerRange)
            {
                transform.position = new Vector3(transform.position.x, yLowerRange, transform.position.z);
                playerRb.AddForce(Vector3.up * floatForce * 5, ForceMode.Impulse);
                playerAudio.PlayOneShot(bounceSound, 1.0f);
            }
            if (transform.position.y > yUpperRange)
            {
                transform.position = new Vector3(transform.position.x, yUpperRange, transform.position.z);
            }

            // While space is pressed and player is low enough, float up
            if (Input.GetKey(KeyCode.Space) && !gameOver && transform.position.y <= yUpperRange - 1)
            {
                playerRb.AddForce(Vector3.up * floatForce, ForceMode.Impulse);
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            // if player collides with bomb, explode and set gameOver to true
            if (other.gameObject.CompareTag("Bomb"))
            {
                explosionParticle.Play();
                playerAudio.PlayOneShot(explodeSound, 1.0f);
                gameOver = true;
                Debug.Log("Game Over!");
                Destroy(other.gameObject);
            }

            // if player collides with money, fireworks
            else if (other.gameObject.CompareTag("Money"))
            {
                fireworksParticle.Play();
                playerAudio.PlayOneShot(moneySound, 1.0f);
                Destroy(other.gameObject);

            }

        }

    }
}