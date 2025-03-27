using UnityEngine;

namespace PrototypeTwo
{
    public class DetectCollisions : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}