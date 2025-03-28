using UnityEngine;

namespace Lab4
{
    public class MoveDown : MonoBehaviour
    {
        public float speedForce = 500f;
        private Rigidbody _rigidBody;
        private float lowerBound = -5;    
        private void Start()
        {
            _rigidBody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            // transform.Translate(Vector3.forward * speed * Time.deltaTime);
            _rigidBody.AddForce(Vector3.back * speedForce * Time.deltaTime);

            if (transform.position.z < lowerBound)
            {
                Destroy(gameObject);
            }
        }
    }
}