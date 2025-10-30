using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D _rb;
    public float speed = 10f;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void SetDirection(Vector2 direction)
    {
        _rb.linearVelocity = direction.normalized * speed;
    }
}
