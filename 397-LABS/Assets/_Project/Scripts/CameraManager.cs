using Unity.Cinemachine;
using UnityEngine;

namespace Platformer397 {
    
    public class CameraManager : MonoBehaviour {

        //Referances to the Cinemachine Virtual Camera and the Transform of our player
        [SerializeField] private CinemachineCamera freeLookCam;
        [SerializeField] private Transform player;

        //In Awake, Lock the mouse into to lock the mouse into the Game View in Unity and turn the cursor invisible
        //Awake Method
        private void Awake() {

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            if (player != null) {return; }
            player = GameObject.FindGameObjectWithTag("Player").transform;
           

        } //End of Awake Method

        //On Enable, I want to associate the transform of the player into the target of our cinemchine camera
        //OnEnable Method
        private void OnEnable() {

            freeLookCam.Target.TrackingTarget = player;

        } //End of OnEnable Method

    } //End of class CameraManager : MonoBehaviour

} //End of namespace Platformer397

