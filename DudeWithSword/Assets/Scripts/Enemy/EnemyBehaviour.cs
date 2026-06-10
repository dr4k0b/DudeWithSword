using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    public Animator stateMachine;

    public float idleRadius;
    public float detectRadius;
    public float idleWait;

    private Vector3 spawn;

    private bool setPath;
    private bool chase;

    private NavMeshAgent agent;
    private GlobalInformation g;
    void Start()
    {
        spawn = transform.position;
        agent = GetComponent<NavMeshAgent>();
        g = GlobalInformation.instance;
    }

    private void Update()
    {
        stateMachine.SetFloat("Distance", Vector3.Distance(transform.position, g.player.position));
    }

    public void Idle()
    {
        if ((agent.remainingDistance <= 0.1f || agent.pathStatus == NavMeshPathStatus.PathPartial) && !setPath)
        {
            StartCoroutine(IdleWait());
        }
    }

    public void Chase()
    {
        agent.SetDestination(g.player.position);
    }

    IEnumerator IdleWait()
    {
        setPath = true;

        yield return new WaitForSeconds(idleWait);

        if (chase)
        {
            setPath = false;
           yield break;
        }

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
