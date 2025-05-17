using UnityEngine;

public class PlatformMoving : MonoBehaviour
{
    public float speed = 2f;
    public Transform pointA;
    public Transform pointB;

    private Vector3 target;
    private Rigidbody rb;

    void Start()
    {
        target = pointB.position;
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 newPos = Vector3.MoveTowards(transform.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);

        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            target = (target == pointA.position) ? pointB.position : pointA.position;
        }
    }
}