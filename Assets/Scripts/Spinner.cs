using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 120f;
    [SerializeField] private float floatSpeed = 0.5f;
    [SerializeField] private float floatAmplitude = 0.35f;

    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f, Space.World);

        float offsetY = Mathf.PingPong(Time.time * floatSpeed, floatAmplitude);
        transform.position = new Vector3(initialPosition.x, initialPosition.y + offsetY, initialPosition.z);
    }
}
