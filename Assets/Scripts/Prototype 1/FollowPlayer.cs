using UnityEngine;

namespace PrototypeOne
{
    public class FollowPlayer : MonoBehaviour
    {
        public GameObject player;
        [SerializeField] private Vector3 offset = new Vector3(0, 2.27f, 0.37f); // firstperson
        //  [SerializeField] private Vector3 offset = new Vector3(0, 5, -7); // thirdperson
        void LateUpdate()
        {
            transform.position = player.transform.position + offset;
        }
    }
}