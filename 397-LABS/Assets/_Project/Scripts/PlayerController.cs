using UnityEngine;

//namespace Platformer397
namespace Platformer397 {

    //PlayerController Method
    public class PlayerController : MonoBehaviour {

        [SerializeField] private InputReader input;

        //Start Method
        private void Start () {

            Debug.Log("[Start]");
            input.EnablePlayerActions();

        } //End of Start Method

        //OnEnable Method
        private void OnEnable () {

            Debug.Log("[OnEnable]");
            input.Move += GetMovement; 

        } //End of OnEnable Method

        //OnDisable Method
        private void OnDisable() {

            Debug.Log("[OnDisable]");
            input.Move -= GetMovement;

        } //End of OnDisable Method

        //GetMovement Method
        private void GetMovement(Vector2 move) {

            Debug.Log("Input Is Working: " + move);

        } //End of GetMovement Method

        //Destroy Method
        //private void OnDestroy() {

        //    Debug.Log("[OnDestroy]");

        //} //End of Destroy Method

    } //End of PlayerController Method

} //End of namespace Platformer397
