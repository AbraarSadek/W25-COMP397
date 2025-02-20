using UnityEngine;

//namespace Platformer397
namespace Platformer397 {

    //Added - 1/22/25
    [RequireComponent (typeof(Rigidbody))]

    //PlayerController Method
    public class PlayerController : Subject {

        //Player Movement Variables - 1/15/25
        [SerializeField] private InputReader input;

        //Player Movement Variables - 1/22/25
        [SerializeField] private Rigidbody rb;
        private Vector3 movement;

        [SerializeField] private float moveSpeed = 200f;
        [SerializeField] private float rotationSpeed = 200f;

        [SerializeField] private Transform mainCam;

        //Awake Method - 1/22/25
        private void Awake() {

            rb = GetComponent<Rigidbody> ();
            rb.freezeRotation = true;
            mainCam = Camera.main.transform;
            
        } //End of Awake Method

        //Start Method
        private void Start () {

            //Debug.Log("[Start]");
            input.EnablePlayerActions();

            NotifyObserbers();

        } //End of Start Method

        //OnEnable Method
        private void OnEnable () {

            //Debug.Log("[OnEnable]");
            input.Move += GetMovement; 

        } //End of OnEnable Method

        //OnDisable Method
        private void OnDisable() {

            //Debug.Log("[OnDisable]");
            input.Move -= GetMovement;

        } //End of OnDisable Method

        //FixedUpdate Method - 1/22/25
        private void FixedUpdate() {

            UpdateMovement();

        } //End of FixedUpdate Method

        //UpdateMovement Method - 1/22/25
        private void UpdateMovement() {

            //Var Data Type - Auto Identifies Data Type - Needs To Be Initialized 
            var adjustedDirection = Quaternion.AngleAxis(mainCam.eulerAngles.y, Vector3.up) * movement;

            //Else-If Statement
            if (adjustedDirection.magnitude > 0f) {

                //Handels the rotation and movement
                HandelMovement(adjustedDirection);
                HandelRotation(adjustedDirection);

            } else {

                //Not change the rotation and movement, but need to apply rigidbody Y movement for gravity
                rb.linearVelocity = new Vector3(0f, rb.linearVelocity.y, 0f);

            } //End of Else-If Statement

        } //End of UpdateMovement Method

        //HandelMovement Method - 1/22/25
        private void HandelMovement(Vector3 adjustedDirection) {

            var velocity = adjustedDirection * moveSpeed * Time.fixedDeltaTime;
            rb.linearVelocity = new Vector3(velocity.x, rb.linearVelocity.y, velocity.z);

        } //End of HandelMovement Method

        //HandelRotation Method - 1/22/25
        private void HandelRotation(Vector3 adjustedDirection) {

            var targetRotation = Quaternion.LookRotation(adjustedDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        } //End of HandelRotation Method

        //GetMovement Method
        private void GetMovement(Vector2 move) {

            //Debug.Log("Input Is Working: " + move);

            //Added - 1/22/25
            movement.x = move.x;
            movement.z = move.y;

        } //End of GetMovement Method

        //Destroy Method
        //private void OnDestroy() {

        //    Debug.Log("[OnDestroy]");

        //} //End of Destroy Method

    } //End of PlayerController Method

} //End of namespace Platformer397
