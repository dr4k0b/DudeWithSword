using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    public float idleRadius;
    public float detectRadius;
    public float idleWait;

    private Vector3 spawn;
    private bool setPath;
    private NavMeshAgent agent;

    void Start()
    {
        spawn = transform.position;
        agent = GetComponent<NavMeshAgent>();
    }

    public void Idle()
    {
        if ((agent.remainingDistance <= 0.1f || agent.pathStatus == NavMeshPathStatus.PathPartial) && !setPath)
        {
            StartCoroutine(IdleWait());
        }
    }

    IEnumerator IdleWait()
    {
        setPath = true;

        yield return new WaitForSeconds(idleWait);
        agent.SetDestination(spawn + new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f)) * Random.Range(0.0f, idleRadius));

        setPath = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(spawn, idleRadius);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectRadius);
    }
}
