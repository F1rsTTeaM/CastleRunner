using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // ��������
    public Vector3 offset = new Vector3(0, 2, -5); // �������� ������
    public float smoothSpeed = 5f;

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}