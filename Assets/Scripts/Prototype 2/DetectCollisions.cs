using UnityEngine;

namespace PrototypeTwo
{
    public class DetectCollisions : MonoBehaviour
    {
        // public GameObject objectPool;
        private void OnTriggerEnter(Collider other)
        {
            Destroy(gameObject);
            // could object pool
            // gameObject.SetActive(false);
            // gameObject.transform.parent = objectPool.transform;
            Destroy(other.gameObject); // missile
        }
    }
}