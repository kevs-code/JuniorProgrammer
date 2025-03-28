using UnityEngine;

namespace Lab3
{
    public class PlayerController : MonoBehaviour
    {
        private Rigidbody playerRb;
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