using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Персонаж
    public Vector3 offset = new Vector3(0, 2, -5); // Смещение камеры

    void LateUpdate()
    {
        if (target == null) return;

        // Желаемая позиция камеры
        Vector3 desiredPosition = target.position + offset;

        // Плавное перемещение к позиции персонажа
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime);
    }
}