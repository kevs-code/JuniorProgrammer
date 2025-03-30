using UnityEngine;

namespace PrototypeTwo
{
    public class DestroyOutOfBounds : MonoBehaviour
    {
        private float topBound = 30f;
        private float lowerBound = -10f;
        // public GameObject objectPool;
        void Update()
        {
            if (transform.position.z > topBound)
            {
                Destroy(gameObject); // missile
            }
            else if (transform.position.z < lowerBound)
            {
                Debug.Log("Game Over!");
                Destroy(gameObject); // animal
                // could object pool
                // gameObject.SetActive(false);
                // gameObject.transform.parent = objectPool.transform;
            }
        }
    }
}