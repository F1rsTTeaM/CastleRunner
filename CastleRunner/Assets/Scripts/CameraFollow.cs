using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // ��������
    public Vector3 offset = new Vector3(0, 2, -5); // �������� ������

    void LateUpdate()
    {
        if (target == null) return;

        // �������� ������� ������
        Vector3 desiredPosition = target.position + offset;

        // ������� ����������� � ������� ���������
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime);
    }
}