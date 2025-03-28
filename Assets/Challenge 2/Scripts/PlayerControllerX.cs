using UnityEngine;

namespace ChallengeTwo
{
    public class PlayerControllerX : MonoBehaviour
    {
        public GameObject dogPrefab;
        public float countdownTimer = 1f;
        private float countdown = 0f;

        void Update()
        {
            countdown += Time.deltaTime;
            // On spacebar press, send dog
            if (Input.GetKeyDown(KeyCode.Space) && countdown >= countdownTimer)
            {
                Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
                countdown = 0f;
            }
        }
    }
}