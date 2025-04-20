using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 7f;
    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Двигаем персонажа влево и вправо
        float moveInput = Input.GetAxis("Horizontal"); // A/D или стрелки ←/→
        rb.linearVelocity = new Vector3(moveInput * speed, rb.linearVelocity.y, 0);

        // Прыжок (если стоим на земле)
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, 0);
            isGrounded = false; // Пока не коснёмся земли, нельзя прыгать
        }
    }

    // Проверяем, стоит ли персонаж на земле
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    public void JumpAfterKill()
    {
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z); // Подбрасываем игрока
    }

}