using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2f;
    public Transform pointA;
    public Transform pointB;

    private Vector3 target;
    private bool movingRight = true;

    void Start()
    {
        target = pointB.position;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            if (target == pointA.position)
            {
                target = pointB.position;
                if (!movingRight) Rotate(90f);
                movingRight = true;
            }
            else
            {
                target = pointA.position;
                if (movingRight) Rotate(-90f);
                movingRight = false;
            }
        }
    }

    void Rotate(float yAngle)
    {
        transform.rotation = Quaternion.Euler(0, yAngle, 0);
    }
}
