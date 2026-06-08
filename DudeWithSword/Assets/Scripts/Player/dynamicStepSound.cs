using UnityEngine;

public class dynamicStepSound : MonoBehaviour
{
    private AudioManager am;
    public MovementController movementController;

    private float maxVolume;
    void Start()
    {
        am = GetComponent<AudioManager>();

        maxVolume = am.Volume("Walk");
    }

    public void PlayStep()
    {
        am.SetVolume("Walk", maxVolume * (movementController.movement.magnitude / movementController.maxSpeed));
        am.SetPitch("Walk", Random.Range(0.7f, 1.0f));
        am.Play("Walk");
    }
}
