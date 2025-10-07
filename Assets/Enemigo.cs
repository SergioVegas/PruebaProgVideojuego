using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Enemigo : MonoBehaviour
{
    //[SerializeField] private GameObject _enemyMinPosX, _enemyMinPosY;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _enemyLimitPositionXPositive = 5 ;
    [SerializeField] private float _enemyLimitPositionXNegative = -5;
    public SpawnerEnemyyy spawner;

    void Start()
    { 
        OnMove();
    }

    void Update()
    {
        if (transform.position.x <= _enemyLimitPositionXPositive && _rb.linearVelocityX>0)
        {
            _rb.linearVelocityX = 5;
        }
        else if(transform.position.x >= _enemyLimitPositionXPositive && _rb.linearVelocityX > 0)
        {
            _rb.linearVelocityX = -5;
        }
        else if (transform.position.x >= _enemyLimitPositionXNegative && _rb.linearVelocityX < 0)
        {
            _rb.linearVelocityX = -5;
        }
        else if (transform.position.x <= _enemyLimitPositionXNegative && _rb.linearVelocityX < 0)
        {
            _rb.linearVelocityX = 5;
            transform.position = new Vector3(transform.position.x, transform.position.y - 1.0f);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
       if(collision.gameObject.layer == 6)//El numero es la layer en la que esta el player
        {
            GameOver();
        }
        if (collision.gameObject.layer == 8) 
        {    
            Destroy(collision.gameObject);
            spawner.Push(gameObject);
        }
    }

    private void GameOver()
    {
        _rb.AddForceY(-120f);
        Debug.Log("Te has muerto");
    }

    /* private void OnTriggerEnter2D(Collider2D collider)
{

}*/
    public void OnMove()
    {
        _rb.linearVelocity = new Vector3(1,0,0)*5;
    }
}
