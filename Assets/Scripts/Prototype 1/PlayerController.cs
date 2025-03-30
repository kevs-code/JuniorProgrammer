using UnityEngine;
using TMPro;
using System.Collections.Generic;

namespace PrototypeOne
{
    public class PlayerController : MonoBehaviour
    {
        // [SerializeField] private float speed = 30.0f;
        [SerializeField] private float horsePower = 3000f;
        [SerializeField] private float turnSpeed = 360f;
        // [SerializeField] private GameObject centerOfMass;
        [SerializeField] private TextMeshProUGUI speedometerText;
        [SerializeField] private TextMeshProUGUI rpmText;
        [SerializeField] private float speed;
        [SerializeField] private float rpm;
        // [SerializeField] private List<WheelCollider> allWheels;
        [SerializeField] private int wheelsOnGround;
        private Rigidbody playerRb;
        public float horizontalInput;
        public float forwardInput;

        private void Awake()
        {
            playerRb = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            // playerRb.centerOfMass = centerOfMass.transform.position;
        }

        void FixedUpdate()
        {
            // if (IsOnGround()) { }

                horizontalInput = Input.GetAxis("Horizontal");
                forwardInput = Input.GetAxis("Vertical");
                // Moves the car forward based on vertical input
                // transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
                playerRb.AddRelativeForce(Vector3.forward * forwardInput * horsePower);

                // Rotates the car based on horizontal input
                transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);

                speed = Mathf.RoundToInt(playerRb.velocity.magnitude * 2.237f); // 3.6 for kph
                speedometerText?.SetText($"Speed: {speed}mph");
                rpm = Mathf.Round((speed % 30) * 40);
                rpmText?.SetText($"RPM: {rpm}");
            
        }
        /*
        bool IsOnGround()
        {
            wheelsOnGround = 0;
            foreach (WheelCollider wheel in allWheels)
            {
                if (wheel.isGrounded)
                {
                    wheelsOnGround++;
                }
            }
            if (wheelsOnGround == 4)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        */
    }
}