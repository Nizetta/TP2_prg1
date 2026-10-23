using System.Collections;

using UnityEngine;
using UnityEngine.AI;

public class EnemyIA : MonoBehaviour
{
    public enum AIState {Patrol, Attack,Chase}
    [SerializeField] private AIState currentState=AIState.Patrol;
    [SerializeField] private float radiusDetection;
    [SerializeField] private float radiusAttack;


    [SerializeField] private Transform[] controlPoints;
    [SerializeField] private float waitTime=1f;

    [SerializeField] private float attackCooldown= 3f;

    private int currentPointIndex;
    private bool isWaiting;
    private bool isAttacking=false;

    private Transform playertransform;
    private NavMeshAgent agent;

    private HealthSystem healthSystemPlayer;

    private Attack attack;
   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject player=GameObject.FindGameObjectWithTag("Player");
        
        if(player != null)
        {
            playertransform=player.GetComponent<Transform>();
            healthSystemPlayer=player.GetComponent<HealthSystem>();
        }else
        {
            Debug.Log("no encontro player");
        }
        
    }
    private void Awake()
    {
        agent=GetComponent<NavMeshAgent>();
        attack=GetComponent<Attack>();

    }

    private void Update()
    {
        float distanceToPlayer=Vector3.Distance(transform.position,playertransform.position);
        switch (currentState)
        {
            case AIState.Patrol:
                Patrol(distanceToPlayer);
                break;
            case AIState.Chase:
                Chase(distanceToPlayer);
                break;
            case AIState.Attack:
                Attack(distanceToPlayer);
                break;
        }
    }

    private void Patrol(float distance)
    {
        if(distance<=radiusDetection)
        {
            currentState=AIState.Chase;
            return;
        }
        // bool var3=agent.pathPending;
        // float var2=agent.remainingDistance;
        // float var1=agent.stoppingDistance;

        if(!agent.pathPending && agent.remainingDistance<=agent.stoppingDistance)
        {
            if(!isWaiting)
            {
               StartCoroutine(WaitandMove());
            }
        }
    }
    private void Chase(float distance)
    {
        agent.SetDestination(playertransform.position);
        if(distance<=radiusAttack)
        {
            currentState=AIState.Attack;
            return;
        }
        if (distance > radiusDetection * 1.2f)
        {
            currentState = AIState.Patrol;
            GoNext();
            return;
        }
    }
    private void Attack(float distance)
    {
        if(distance>radiusAttack && !isAttacking)
        {
            currentState=AIState.Chase;
            return;
        }

        if (!isAttacking)
        {
           StartCoroutine(AttackColldown());
        }
    }


    private IEnumerator AttackColldown(){
        isAttacking=true;
        agent.isStopped=true;
        Ataque();
        yield return new WaitForSeconds(attackCooldown);
        agent.isStopped=false;
        isAttacking=false;
    }

    private void Ataque()
    {
        if (healthSystemPlayer != null)
        {
            attack.Melee();
        }
        Debug.Log("ataque");
    }

    private IEnumerator WaitandMove()
    {
        isWaiting=true;
        yield return new WaitForSeconds(waitTime);
        
        if (controlPoints.Length > 0)
        {
            currentPointIndex = (currentPointIndex + 1) % controlPoints.Length;
            GoNext();
        }
        isWaiting=false;
    }

    private void GoNext()
    {
        if(controlPoints.Length==0)return;
        agent.SetDestination(controlPoints[currentPointIndex].position);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color=Color.yellow;
        Gizmos.DrawWireSphere(transform.position,radiusDetection);
        Gizmos.color=Color.blue;
        Gizmos.DrawWireSphere(transform.position,radiusAttack);
    }

    
}

