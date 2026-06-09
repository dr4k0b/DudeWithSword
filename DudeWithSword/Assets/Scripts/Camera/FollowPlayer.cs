using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public float lerp;
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, player.position, lerp);
    }
}
