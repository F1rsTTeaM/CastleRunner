using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public GameObject enemyObject; // Ссылка на основного врага

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerRespawn playerRespawn = other.GetComponent<PlayerRespawn>();

            if (playerRespawn != null && playerRespawn.IsEnemyBelow(transform))
            {
                PlayerMovement player = other.GetComponent<PlayerMovement>();
                if (player != null)
                {
                    player.JumpAfterKill(); // Подбрасываем игрока
                }

                Destroy(enemyObject); // Удаляем врага
            }
        }
    }
}