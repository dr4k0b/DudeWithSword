using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float deacceleration;

    [HideInInspector]
    public Vector3 source;

    private float speed;
    private Rigidbody rb;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (speed < 0)
        {
            speed = 0;
        }
        rb.linearVelocity = (transform.position - source).normalized * speed;
        speed -= deacceleration;
    }
    public void setKnockback(Vector3 position,float knockback)
    {
        source = position;
        speed = knockback;
    }
}
