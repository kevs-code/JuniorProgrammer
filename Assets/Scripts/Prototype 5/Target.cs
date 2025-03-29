using UnityEngine;

namespace PrototypeFive
{
    public class Target : MonoBehaviour
    {
        private float minSpeed = 12f;
        private float maxSpeed = 16f;
        private float maxTorque = 10f;
        private float xRange = 4f;
        private float ySpawnPos = -6f;
        private Rigidbody targetRb;
        private GameManager gameManager;
        public int pointValue = 5;
        public ParticleSystem explosionParticle;

        void Start()
        {
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            targetRb = GetComponent<Rigidbody>();
            targetRb.AddForce(RandomForce(), ForceMode.Impulse);
            targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
            RandomSpawnPosition();
        }

        private void OnMouseDown()
        {
            if (gameManager.isGameActive)
            {
                Destroy(gameObject);
                Instantiate(explosionParticle, transform.position,
                    explosionParticle.transform.rotation);
                gameManager.UpdateScore(pointValue);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            Destroy(gameObject);
            if (!gameObject.CompareTag("Bad"))
            {
                gameManager.GameOver();
            }
        }

        private Vector3 RandomForce()
        {
            return Vector3.up * Random.Range(minSpeed, maxSpeed);
        }

        private float RandomTorque()
        {
            return Random.Range(-maxTorque, maxTorque);
        }

        private void RandomSpawnPosition()
        {
            transform.position = new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
        }
    }
}