using UnityEngine;

namespace ChallengeFive
{
    public class DestroyObjectX : MonoBehaviour
    {
        void Start()
        {
            Destroy(gameObject, 2); // destroy particle after 2 seconds
        }
    }
}