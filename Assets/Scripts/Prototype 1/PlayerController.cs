using UnityEngine;

namespace PrototypeOne
{
    public class PlayerController : MonoBehaviour
    {
        public float speed = 20.0f;
        public float turnSpeed = 45.0f;
        public float horizontalInput;
        public float forwardInput;

        void Update()
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