using UnityEngine;

namespace Platformer397
{
    public class MiniMapController : MonoBehaviour
    {

        [SerializeField] private Transform playerTransform;

        private void Start() {

            if (playerTransform != null) { return; }

            playerTransform = GameObject.FindWithTag("Player").transform;

        }

        private void FixedUpdate() {
            
            transform.position = new Vector3(playerTransform.position.x, transform.position.y, playerTransform.position.z);

        }

    }
}
