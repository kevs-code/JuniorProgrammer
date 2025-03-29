using UnityEngine;

namespace Lab4
{
    public class MoveDown : MonoBehaviour
    {
        public float speed = 15f;
        // public float speedForce = 500f;
        private Rigidbody _rigidBody;
        private float lowerBound = -5;    
        private void Start()
        {
            _rigidBody = GetComponent<Rigidbody>();
            
            if (gameObject.CompareTag("Projectile") || gameObject.CompareTag("PowerUp"))
            {
                speed = 5f;
            }
        }

        private void Update()
        {
            // _rigidBody.AddForce(Vector3.forward * -speed);
            _rigidBody.AddForce(Vector3.back * speed);

            if (transform.position.z < lowerBound)
            {
                Destroy(gameObject);
            }
        }
    }
}