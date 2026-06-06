using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerAudio : MonoBehaviour
{
    private AudioManager am;
    void Start()
    {
        am = GetComponent<AudioManager>();
    }

    public void PlayStepSound()
    {
        am.Play("Walk");
    }
}
