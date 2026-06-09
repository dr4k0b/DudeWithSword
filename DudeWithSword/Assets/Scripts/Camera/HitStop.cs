using Unity.VisualScripting;
using UnityEngine;
using System.Collections;

public class HitStop : MonoBehaviour
{
    public static HitStop instance;
    private bool waiting;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void Stop(float duration)
    {
        if (waiting)
        {
            return;
        }
        Time.timeScale = 0.0f;
        StartCoroutine(Wait(duration));
    }
    IEnumerator Wait(float duration)
    {
        waiting = true;
        yield return new WaitForSecondsRealtime(duration);
        Time.timeScale = 1.0f;
        waiting = false;
    }
}
