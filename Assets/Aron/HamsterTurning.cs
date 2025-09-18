using UnityEngine;

public class HamsterTurning : MonoBehaviour
{
    
    [SerializeField] private float turnSpeedX;
    [SerializeField] private float turnSpeedY;
    [SerializeField] private float turnSpeedZ;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(new Vector3(turnSpeedX, turnSpeedY, turnSpeedZ));
    }
}
