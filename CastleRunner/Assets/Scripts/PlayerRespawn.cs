using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public Transform respawnPoint; // ����� ����������� ������
    public Transform feetPosition; // ����� ��� ����������
    public float groundCheckDistance = 0.1f; // ���������� ��������

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            // ���� ����� ������, �� �������
            if (IsEnemyBelow(other.transform))
            {
                return;
            }

            // ���� ���� �� ����������� (������, ����� �� ������) � ������� ������
            Respawn();
        }
    }

    public void Respawn()
    {
        transform.position = respawnPoint.position; // ������������� ������ � ����� ��������
    }

    public bool IsEnemyBelow(Transform enemyTransform)
    {
        return feetPosition.position.y > enemyTransform.position.y + 0.2f;
    }
}