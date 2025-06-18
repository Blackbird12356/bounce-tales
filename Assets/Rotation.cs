using UnityEngine;

public class Rotation : MonoBehaviour
{
    [Header("Rotation Speed (degrees per second)")]
    public float rotationSpeed = 4f;

    [Header("Rotation Axis")]
    public Vector3 rotationAxis = new Vector3(0, 0, 1); // По умолчанию вращение по оси Z

    void Update()
    {
        transform.Rotate(rotationAxis.normalized * rotationSpeed * Time.deltaTime);
    }
}
