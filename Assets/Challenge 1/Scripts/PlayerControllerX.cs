﻿using UnityEngine;

namespace ChallengeOne
{
    public class PlayerControllerX : MonoBehaviour
    {
        public float speed = 15f;
        public float rotationSpeed = 120f;
        public float verticalInput;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void FixedUpdate()
        {
            // get the user's vertical input
            verticalInput = Input.GetAxis("Vertical");

            // move the plane forward at a constant rate
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

            // tilt the plane up/down based on up/down arrow keys
            transform.Rotate(Vector3.right * verticalInput * rotationSpeed * Time.deltaTime);
        }
    }
}