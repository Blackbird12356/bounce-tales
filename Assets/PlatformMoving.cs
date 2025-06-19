using UnityEngine;

public class PlatformMoving : MonoBehaviour
{
    [Header("Motion settings")]
    [SerializeField] private float distance = 3f;   // ������ ������ �� ��������� �����
    [SerializeField] private float speed = 2f;   // �������� � �������
    [SerializeField] private bool vertical = true; // true = Y, false = X

    private Vector3 startPos;   
    private Vector3 endPos;     
    private bool forward = true;

    private void Start()
    {
        startPos = transform.position;
        Vector3 offset = vertical ? Vector3.up * distance : Vector3.right * distance;
        endPos = startPos + offset;
    }

    private void Update()
    {       
        Vector3 target = forward ? endPos : startPos;
        transform.position =
            Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (transform.position == target)
            forward = !forward;
    }

}
