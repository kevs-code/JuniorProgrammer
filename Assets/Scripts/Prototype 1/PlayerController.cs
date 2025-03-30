using UnityEngine;

namespace PrototypeOne
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float speed = 30.0f;
        [SerializeField] private float turnSpeed = 50.0f;
        public float horizontalInput;
        public float forwardInput;

        void FixedUpdate()
        {
            horizontalInput = Input.GetAxis("Horizontal");
            forwardInput = Input.GetAxis("Vertical");
            // Moves the car forward based on vertical input
            transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
            // Rotates the car based on horizontal input
            transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
        }
    }
}