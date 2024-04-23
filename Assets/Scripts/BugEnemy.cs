using UnityEngine;
using UnityEngine.AI;

public class BugEnemy : MonoBehaviour
{
    public Transform target;
    public float chaseDistance = 10f;
    public GameObject explosionEffectPrefab;

    private NavMeshAgent agent;
    private bool hasTarget = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Body").transform;
    }

    void Update()
    {
        if (hasTarget && Vector3.Distance(transform.position, target.position) <= chaseDistance)
        {
            agent.SetDestination(target.position);
        }
    }

    public void SetTargetActive(bool isActive)
    {
        hasTarget = isActive;
        if (!isActive)
        {
            agent.SetDestination(RandomNavmeshLocation(20f)); // Roam randomly
        }
    }

    Vector3 RandomNavmeshLocation(float radius)
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += transform.position;
        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;
        if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
        {
            finalPosition = hit.position;
        }
        return finalPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
