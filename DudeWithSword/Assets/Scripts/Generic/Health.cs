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
    void Start()
    {
        health = maxHealth;
        meshRenderer = GetComponent<MeshRenderer>();
        original = meshRenderer.material;
    }

    void Update()
    {
        if(health <= 0)
        {
            Dead = true;
        }
    }

    public void Damage(float damage)
    {
        if (!Dead)
        {
            health -= damage;
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
