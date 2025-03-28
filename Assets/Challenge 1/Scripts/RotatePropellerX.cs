using UnityEngine;

namespace ChallengeOne
{
    public class RotatePropellerX : MonoBehaviour
    {
        float rotateSpeed = 720f;

        void Update()
        {
            float rotation = rotateSpeed * Time.deltaTime;
            transform.Rotate(0, 0, rotation);
        }
    }
}