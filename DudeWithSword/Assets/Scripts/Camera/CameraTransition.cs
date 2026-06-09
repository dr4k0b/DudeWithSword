using Unity.Cinemachine;
using UnityEngine;

public class CameraTransition : MonoBehaviour
{
    public Vector3 offset;
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
            ci.camera.transform.localPosition = Vector3.Lerp(ci.camera.transform.localPosition, offset, transition);
            ci.camera.transform.LookAt(ci.followPlayer.transform);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ci.NextCamera(this);
        }
    }
}
