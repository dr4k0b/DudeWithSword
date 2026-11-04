using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public float lerp = 0.1f;

    [HideInInspector]
    public Vector3 offset;
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, player.position + offset, lerp);
    }
}
