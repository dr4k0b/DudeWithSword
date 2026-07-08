using Unity.Cinemachine;
using UnityEngine;

public class CameraTransition : MonoBehaviour
{
    [Range(0.0f, 1.0f)]
    public float sideAngle;
    [Range(-1.0f, 1.0f)]
    public float topAngle;

    public float distance;

    public float transition;


    public bool priority;

    private CameraInformation ci;
    void Start()
    {
        ci = CameraInformation.instance;
    }

    void FixedUpdate()
    {
        if (priority)
        {
            ci.camera.transform.localPosition = Vector3.Lerp(ci.camera.transform.localPosition, offset(), transition);
            ci.camera.transform.LookAt(ci.followPlayer.transform);
        }
    }


    private Vector3 offset()
    {
        Vector3 side = new Vector3(Mathf.Cos(sideAngle * 2 * Mathf.PI) * Mathf.Cos(topAngle * (Mathf.PI / 2)), Mathf.Sin(topAngle * (Mathf.PI / 2)), Mathf.Sin(sideAngle * 2 * Mathf.PI) * Mathf.Cos(topAngle * (Mathf.PI / 2)));
        Vector3 top = new Vector3(0, topAngle, 0);

        return (side).normalized * distance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ci.NextCamera(this);
        }
    }
}
