using UnityEngine;

public class GlobalInformation : MonoBehaviour
{
    public static GlobalInformation instance;

    public Transform player;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
