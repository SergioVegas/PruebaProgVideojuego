using UnityEngine;
using UnityEngine.InputSystem;

public class Bala : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.linearVelocity = new Vector2(0,3);

    }
}

