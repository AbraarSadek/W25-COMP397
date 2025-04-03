using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//namespace Platformer397
namespace Platformer397 {

    //Class EnemyNavigation
    public class EnemyNavigation : MonoBehaviour, iObserber {

        private NavMeshAgent agent;

        [SerializeField] private PlayerController player;
        
        [SerializeField] private List<Transform> waypoints  = new List<Transform>();
        [SerializeField] private float distanceThreshold = 0f;
        private int index = 0;
        private Vector3 destination;

        //Enemy Sensing Stats
        [SerializeField] private LayerMask mask; //The layer that corresponds to the player
        [SerializeField] private int viewDistance = 10; 
        [SerializeField] private EnemyStates states = EnemyStates.Patrolling;

        //Awake Method
        private void Awake() {

            agent = GetComponent<NavMeshAgent>(); //Get the NavMeshAgent component from the GameObject and assign it to the agent variable

            destination = waypoints[index].position; //Set the destination to the first waypoint in the waypoints list and assign it to the destination variable

            player = GameObject.FindWithTag("Player").GetComponent<PlayerController>(); //Find the GameObject with the tag "Player" and get the PlayerController component and assign it to the player variable>

        } //End of Awake Method

        //OnEnable Method
        private void OnEnable() {
            
            player.AddObserber(this);

        } //End of OnEnable Method

        //OnDisable Method
        private void OnDisable() {

            player.RemoveObserber(this);

        } //End of OnDisable Method

        //Start Method
        private void Start() {

            agent.destination = destination; //Set the NavMeshAgent's destination to the destination

        } //End of Start Method

        //Update Method - Start is called once before the first execution of Update after the MonoBehaviour is created
        void Update() {
        
            //var destination = GameObject.FindWithTag("Player").transform.position;  
            //agent.destination = destination;

            switch (states) {
            
                case EnemyStates.Patrolling:
                    //If Statement - To Make Enemy Patrol
                    if (Vector3.Distance(destination, transform.position) < distanceThreshold) {
                        index = (index + 1) % waypoints.Count; //Increment the index and assign it to the index variable
                        destination = waypoints[index].position; //Set the destination to the next waypoint in the waypoints list and assign it to the destination variable
                        
                    } //End of If Statement
                    break;
                case EnemyStates.Chasing:
                    //Start Chasing The Player While The Player Is Within The View Distance
                    destination = player.gameObject.transform.position;
                    break;
                default:
                    Debug.LogError("State not configured.", this);
                    break;
            
            }
            agent.destination = destination; //Set the NavMeshAgent's destination to the destination
        } //End of Update Method

        //FixedUpdate Method
        private void FixedUpdate() {

            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, viewDistance, mask)) {

                if (hit.transform.gameObject.CompareTag("Player"))
                {
                    states = EnemyStates.Chasing;
                }
                Debug.Log("Hit: " + hit.transform.gameObject.name);
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);
            } else {
                states = EnemyStates.Patrolling;
                Debug.Log("Did not hit anything");
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * viewDistance, Color.yellow);

            }

        } //End of FixedUpdate Method

        //OnDrawGizmos Method
        private void OnDrawGizmos() {

            //If Statement
            if (waypoints.Count > 0) {
                Gizmos.color = Color.red;
                //For Loop
                for (int i = 0; i < waypoints.Count; i++) {
                    Gizmos.DrawSphere(waypoints[i].position, distanceThreshold);
                    //Nested If Statement
                    if (i > 0)
                    {
                        Gizmos.DrawLine(waypoints[i - 1].position, waypoints[i].position);
                    } //End of Nested If Statement
                } //End of For Loop
            } //End of If Statement

        } //End of OnDrawGizmos Method

        //OnNotify Method
        public void OnNotify() {
            Debug.Log($"Notify by the subject.");
        } //End of OnNotify Method

    } //End of Class EnemyNavigation

} //End of namespace Platformer397
