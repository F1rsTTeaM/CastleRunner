using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 7f;
    private Rigidbody rb;
    private bool isGrounded;
    private bool facingRight = true; // Следим за направлением взгляда

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Движение влево-вправо
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector3(moveInput * speed, rb.linearVelocity.y, 0);

        // Поворот игрока
        if (moveInput > 0 && !facingRight)
        {
            Rotate(90f); // Вправо
            facingRight = true;
        }
        else if (moveInput < 0 && facingRight)
        {
            Rotate(-90f); // Влево
            facingRight = false;
        }

        // Прыжок (если персонаж на земле и нажата одна из клавиш)
        if (IsJumpKeyPressed() && isGrounded)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, 0);
            isGrounded = false;
        }
    }

    void Rotate(float yRotation)
    {
        transform.rotation = Quaternion.Euler(-90f, yRotation, 0f);
    }

    // Проверка всех клавиш для прыжка
    private bool IsJumpKeyPressed()
    {
        return Input.GetKeyDown(KeyCode.Space) ||
               Input.GetKeyDown(KeyCode.W) ||
               Input.GetKeyDown(KeyCode.UpArrow);
    }

    // Проверка земли
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    // Дополнительный прыжок (например, после убийства врага)
    public void JumpAfterKill()
    {
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
    }
}