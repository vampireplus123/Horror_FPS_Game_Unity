using UnityEngine;
using UnityEngine.AI;

public abstract class GenericEnemy : MonoBehaviour
{
    [SerializeField] int EnemiesHealth = 100;
    [SerializeField] Transform Target;

    [SerializeField] float DetectPlayerRange;

    [SerializeField] float fleeThreshold;
    private NavMeshAgent agent;

    void Awake()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
    }
    protected virtual void DetectPlayer(){}

    protected virtual void ChasingPlayer()
    {
        agent.SetDestination(Target.position);
    }
    
    protected virtual void RunAway()
    {
        Vector3 directionAwayFromPlayer = (transform.position - Target.position).normalized;
        Vector3 fleeTarget = transform.position + directionAwayFromPlayer * 10f; // chạy cách 10m

        NavMeshHit hit;
        if (NavMesh.SamplePosition(fleeTarget, out hit, 10f, NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position);
        }
    }
    public int HealReamining()
    {
        int currentHealth;
        currentHealth = EnemiesHealth;
        return currentHealth;
    }

} 
