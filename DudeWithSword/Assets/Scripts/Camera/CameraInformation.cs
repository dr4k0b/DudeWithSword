using Unity.Cinemachine;
using UnityEngine;

public class CameraInformation : MonoBehaviour
{
    public static CameraInformation instance;

    public CinemachineCamera camera;
    public FollowPlayer followPlayer;

    public CameraTransition current { get; private set; }
    public CameraTransition startCamera;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            NextCamera(startCamera);
        }
    }
    public void NextCamera(CameraTransition transition)
    {
        if (current)
            current.priority = false;

        current = transition;
        current.priority = true;
    }
}
