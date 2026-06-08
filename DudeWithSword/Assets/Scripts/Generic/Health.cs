using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth;
    public Material flash;
    public float flashTime;

    [HideInInspector]
    public float health;
    [HideInInspector]
    public bool Dead;

    private Material original;
    private MeshRenderer meshRenderer;
    private AudioManager audioManager;
    void Start()
    {
        health = maxHealth;
        meshRenderer = GetComponent<MeshRenderer>();
        audioManager = GetComponent<AudioManager>();
        original = meshRenderer.material;
    }

    void Update()
    {
        if (health <= 0)
        {
            Dead = true;
        }
    }

    public void Damage(float damage)
    {
        if (!Dead)
        {
            health -= damage;
            audioManager.Play("Hit");
            StartCoroutine(hurtFlash());
        }
    }

    IEnumerator hurtFlash()
    {
        meshRenderer.material = flash;
        yield return new WaitForSeconds(flashTime);
        meshRenderer.material = original;
    }
}
