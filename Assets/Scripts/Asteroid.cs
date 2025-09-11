using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float minSpeed = 1f;
    public float maxSpeed = 5f;
    public float rotationSpeed = 50f;

    private Vector3 moveDirection;
    private float speed;

    void Start()
    {
        moveDirection = new Vector3(
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f),
            0f
        ).normalized;

        
        speed = Random.Range(minSpeed, maxSpeed);
    }

    void Update()
    {
        Vector3 movement = moveDirection * (speed * Time.deltaTime);
        transform.Translate(movement, Space.World);

        float rotationThisFrame = rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.forward * rotationThisFrame);
    }

}
