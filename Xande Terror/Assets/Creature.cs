using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.UIElements;
public enum MonsterAI
{
    Break, Patrol, Chase
}
[RequireComponent(typeof(NavMeshAgent))]

public class Creature : MonoBehaviour
{
    public static Creature Instance;
    public Transform[] patrolPoint;
    public UnityEvent OnPatrolling, OnChasing, OnBreak;
    public Collider detectArea;
    public NavMeshAgent agent;
    public bool isAngel;
    public bool seekPlayer;
    [Header("Identifier")]
    public Transform playerPos, vision;
    RaycastHit hit;
    public GameObject chaseObj;

    [Header("StateMachine")]
    MonsterAI monsterAI;
    int pointsToPatrol;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        OnPatrolling.Invoke();
    }
 

    private void Update()
    {
        print(monsterAI);
        if (isAngel)
        {
            if (seekPlayer)
            {
                agent.SetDestination(playerPos.position);
                return;
            }
        }
        if (Physics.Linecast(vision.position, playerPos.position, out hit))
        {
            if (hit.distance >= 10)
            {
                return;
            }
            if (hit.collider.CompareTag("Player"))
            {
                print(hit.collider.name);
                if (!monsterAI.Equals(MonsterAI.Chase))
                {
                    SetMonsterAI(MonsterAI.Chase);
                }
                agent.SetDestination(playerPos.position);
            }
            
        }
        if (monsterAI.Equals(MonsterAI.Chase))
        {
            if (!hit.collider.CompareTag("Player"))
            {
                monsterAI = MonsterAI.Patrol;
                NextPointFixedPoint();
            }
        }
        if (isAngel)
        {
            agent.speed = 6;
        }
        if (MemoriesCounter.memoriesCount >= 4)
        {
            chaseObj.SetActive(true);

            isAngel = true;
            seekPlayer = true;
            agent.speed = 6;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PatrolPoint"))
        {
            NextPointFixedPoint();
            print(pointsToPatrol);
        }
    }
    public void NextPointFixedPoint()
    {
        if (isAngel)
        {
            return;
        }
        agent.SetDestination(patrolPoint[pointsToPatrol].position);
        pointsToPatrol++;
        if (pointsToPatrol >= patrolPoint.Length)
        {
            pointsToPatrol = 0;
        }
    }
    public void SetMonsterAI(MonsterAI state)
    {
        monsterAI = state;
        switch (monsterAI)
        {
            case MonsterAI.Break:

                OnBreak.Invoke();
                break;
            case MonsterAI.Patrol:
                NextPointFixedPoint();
                OnPatrolling.Invoke();
                break;
            case MonsterAI.Chase:
                OnChasing.Invoke();
                break;
        }
    }
}