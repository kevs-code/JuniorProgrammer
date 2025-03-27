using UnityEngine;

namespace ChallengeOne
{
    public class RotatePropellerX : MonoBehaviour
    {
        float rotateSpeed = 720f;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            float rotation = rotateSpeed * Time.deltaTime;
            transform.Rotate(0, rotation, 0);
        }
    }
}