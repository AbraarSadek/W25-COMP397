using UnityEngine;
using UnityEngine.AI;

//namespace Platformer397
namespace Platformer397 {

    //Class EnemyNavigation
    public class EnemyNavigation : MonoBehaviour {

        private NavMeshAgent agent;

        //Awake Method
        private void Awake() {

            agent = GetComponent<NavMeshAgent>();

        } //End of Awake Method

        //Update Method - Start is called once before the first execution of Update after the MonoBehaviour is created
        void Update() {
        
            var destination = GameObject.FindWithTag("Player").transform.position;  
            agent.destination = destination;

        } //End of Update Method

    } //End of Class EnemyNavigation

} //End of namespace Platformer397
