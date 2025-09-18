using UnityEngine;

public class LauncherMove : MonoBehaviour
{

    [SerializeField] private int timeBeforeLaunch;

    private int timeCounter = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timeCounter++;

        if (timeCounter >= timeBeforeLaunch)
        {
            transform.position += new Vector3(0, .1f, 0);
        }
    }
}
