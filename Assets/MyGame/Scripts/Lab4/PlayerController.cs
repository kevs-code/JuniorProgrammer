using System.Collections;
using UnityEngine;

namespace Lab4
{
    public class PlayerController : MonoBehaviour
    {
        private Rigidbody playerRb;
        private bool hasPowerUp = false;
        private float powerUpStrength = 20f;
        private float powerUpDuration = 15f;
        public float verticalInput;
        public float horizontalInput;
        public float speed = 10f;
        public float xRange = 10f;
        public float zRange = 3.5f;
        public GameObject projectilePrefab;

        private void Start()
        {
            playerRb = GetComponent<Rigidbody>();
        }

        void Update()
        {
            MovePlayer();
            ConstrainPlayerPosition();

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log($"Missile Fired: {projectilePrefab.name}");
                // Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("PowerUp"))
            {
                hasPowerUp = true;
                Debug.Log("Has PowerUp!");
                Destroy(other.gameObject);
                StartCoroutine(PowerupCooldown());
                // powerupIndicator.SetActive(true);
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                Debug.Log($"Contact {other.gameObject.name}");
                Rigidbody enemyRigidbody = other.gameObject.GetComponent<Rigidbody>();
                Vector3 awayFromPlayer = other.gameObject.transform.position - transform.position;
                // Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);

                if (hasPowerUp) // if have powerup hit enemy with powerup force
                {

                    Debug.Log($"Bosh {other.gameObject.name}");
                    enemyRigidbody.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
                }

            }
        }

        IEnumerator PowerupCooldown()
        {
            yield return new WaitForSeconds(powerUpDuration);
            hasPowerUp = false;
            Debug.Log("PowerUp ends!");
            // powerupIndicator.SetActive(false);
        }

        private void MovePlayer()
        {
            verticalInput = Input.GetAxis("Vertical");
            horizontalInput = Input.GetAxis("Horizontal");

            float rightTranslation = horizontalInput * Time.deltaTime * speed;
            float forwardTranslation = verticalInput * Time.deltaTime * speed;

            Vector3 forwardMove = Vector3.forward * forwardTranslation;
            Vector3 rightMove = Vector3.right * rightTranslation;

            playerRb.MovePosition(playerRb.position + rightMove + forwardMove);
            // transform.Translate(Vector3.right * translation);
            // transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
        }

        private void ConstrainPlayerPosition()
        {
            if (transform.position.x < -xRange)
            {
                transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
            }
            if (transform.position.x > xRange)
            {
                transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
            }

            if (transform.position.z < -zRange)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
            }

            if (transform.position.z > zRange)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
            }
        }
    }
}