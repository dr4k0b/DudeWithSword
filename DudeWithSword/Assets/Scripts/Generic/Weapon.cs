using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public string target;
    public float hitStop;
    public float damage;

    public Transform knockbackSource;

    private CinemachineImpulseSource impulseSource;
    private bool waiting;
    void Start()
    {
        impulseSource = GetComponent<CinemachineImpulseSource>();
    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == target)
        {
            Stop(hitStop);
            CameraShakeManager.instance.CameraShake(other.GetComponent<CinemachineImpulseSource>());

            other.GetComponent<Health>().Damage(damage);
            other.GetComponent<Knockback>().setKnockback(knockbackSource.position, 5);
        }
    }

    private void Stop(float duration)
    {
        if (!waiting)
        {
            Time.timeScale = 0.0f;
            StartCoroutine(Wait(duration));
        }
    }
    IEnumerator Wait(float duration)
    {
        waiting = true;
        yield return new WaitForSecondsRealtime(duration);
        Time.timeScale = 1.0f;
        waiting = false;
    }
}
