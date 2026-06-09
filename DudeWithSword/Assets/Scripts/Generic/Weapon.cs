using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public string target;
    public float hitStop;
    public float damage;
    public float knockback;

    public Transform knockbackSource;

    private CinemachineImpulseSource impulseSource;
    void Start()
    {
        impulseSource = GetComponent<CinemachineImpulseSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == target)
        {
            HitStop.instance.Stop(hitStop);
            CameraShakeManager.instance.CameraShake(other.GetComponent<CinemachineImpulseSource>());

            other.GetComponent<Health>().Damage(damage);
            other.GetComponent<Knockback>().setKnockback(knockbackSource.position, knockback);
        }
    }
}
