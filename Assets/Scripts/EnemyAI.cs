using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;
    [SerializeField] float rotationSpeed = 5f;

    NavMeshAgent navMeshAgent;
    EnemyHealth enemyHealth;

    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        enemyHealth = GetComponent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(enemyHealth.IsDead()) {
            enabled = false;
            navMeshAgent.enabled = false;
            return;
        }

        distanceToTarget = Vector3.Distance(target.position, transform.position);

        if(isProvoked) {
            EngageTarget();
        } else if (distanceToTarget <= chaseRange) {
            isProvoked = true;
            
        } 




    }

    public void OnDamageTaken() {
        isProvoked = true;
    }

    private void EngageTarget() {

        FaceTarget();

        if (distanceToTarget >= navMeshAgent.stoppingDistance) {
            GetComponent<Animator>().SetTrigger("move");
            ChaseTarget();
        }

        if(distanceToTarget <= navMeshAgent.stoppingDistance) {
            AttackTarget();
        } 
        
    }

    private void ChaseTarget() {
        GetComponent<Animator>().SetBool("attacking", false);
        navMeshAgent.SetDestination(target.position);

    }

    private void AttackTarget() {
        GetComponent<Animator>().SetBool("attacking", true);
    }
    
    private void FaceTarget() {
        Vector3 direction = (target.position - transform.position).normalized; //Get direction from target to position
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z)); //Get the look rotation 
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }

    void OnDrawGizmosSelected() {

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

}
