using System.Collections;
using UnityEngine;

namespace ChallengeFour
{
    public class PlayerControllerX : MonoBehaviour
    {
        private Rigidbody playerRb;
        private float speed = 500;
        private float speedBoost = 250;
        private GameObject focalPoint;
        private float normalStrength = 10; // how hard to hit enemy without powerup
        private float powerupStrength = 25; // how hard to hit enemy with powerup

        public bool hasPowerup;
        public GameObject powerupIndicator;
        public int powerUpDuration = 5;
        public ParticleSystem boostParticle;

        void Start()
        {
            playerRb = GetComponent<Rigidbody>();
            focalPoint = GameObject.Find("Focal Point");
        }

        void Update()
        {
            // Add force to player in direction of the focal point (and camera)
            float verticalInput = Input.GetAxis("Vertical");
            playerRb.AddForce(focalPoint.transform.forward * verticalInput * speed * Time.deltaTime);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerRb.AddForce(focalPoint.transform.forward * speedBoost * Time.deltaTime, ForceMode.Impulse);
                boostParticle.Play();
            }
            // Set powerup indicator position to beneath player
            powerupIndicator.transform.position = transform.position + new Vector3(0, -0.6f, 0);

        }

        // If Player collides with powerup, activate powerup
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Powerup"))
            {
                hasPowerup = true;
                Destroy(other.gameObject);
                StartCoroutine(PowerupCooldown());
                powerupIndicator.SetActive(true);
            }
        }

        // Coroutine to count down powerup duration
        IEnumerator PowerupCooldown()
        {
            yield return new WaitForSeconds(powerUpDuration);
            hasPowerup = false;
            powerupIndicator.SetActive(false);
        }

        // If Player collides with enemy
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                Rigidbody enemyRigidbody = other.gameObject.GetComponent<Rigidbody>();
                Vector3 awayFromPlayer = other.gameObject.transform.position - transform.position;
                // Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);

                if (hasPowerup) // if have powerup hit enemy with powerup force
                {
                    enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
                }
                else // if no powerup, hit enemy with normal strength 
                {
                    enemyRigidbody.AddForce(awayFromPlayer * normalStrength, ForceMode.Impulse);
                }


            }
        }
    }
}
