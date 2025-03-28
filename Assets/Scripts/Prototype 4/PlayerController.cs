using System;
using System.Collections;
using UnityEngine;

namespace PrototypeFour
{
    public class PlayerController : MonoBehaviour
    {
        private GameObject focalPoint;
        private Rigidbody playerRb;
        private float powerUpStrength = 15f;
        public float speed = 5f;
        public bool hasPowerUp;
        public GameObject powerUpIndicator;

        void Start()
        {
            playerRb = GetComponent<Rigidbody>();
            focalPoint = GameObject.Find("FocalPoint");
        }

        void Update()
        {
            float forwardInput = Input.GetAxis("Vertical");
            playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);
            powerUpIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("PowerUp"))
            {
                hasPowerUp = true;
                Destroy(other.gameObject);
                StartCoroutine(PowerUpCountdownRoutine());
                powerUpIndicator.gameObject.SetActive(true);
            }
        }

        IEnumerator PowerUpCountdownRoutine()
        {
            yield return new WaitForSeconds(7f);
            hasPowerUp = false;
            powerUpIndicator.gameObject.SetActive(false);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
            {
                Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
                Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);

                Debug.Log("Collided with " + collision.gameObject.name
                    + " with powerup set to " + hasPowerUp);
                
                enemyRigidbody.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
            }
        }
    }
}