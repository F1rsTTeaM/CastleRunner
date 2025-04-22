using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public Transform respawnPoint; // Точка возрождения игрока
    public Transform feetPosition; // Точка под персонажем
    public float groundCheckDistance = 0.1f; // Расстояние проверки

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Если игрок сверху, не умираем
            if (IsEnemyBelow(other.transform))
            {
                return;
            }

            // Если враг не уничтожился (значит, игрок не сверху) — убиваем игрока
            Respawn();
        }
    }

    public void Respawn()
    {
        transform.position = respawnPoint.position; // Телепортируем игрока в точку респауна
    }

    public bool IsEnemyBelow(Transform enemyTransform)
    {
        return feetPosition.position.y > enemyTransform.position.y + 0.2f;
    }
}