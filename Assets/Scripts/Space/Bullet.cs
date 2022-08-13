using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private Rigidbody2D rb;

    private void FixedUpdate()
    {
        rb.velocity = Vector2.right * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")){
            gameObject.SetActive(false);
        }
    }
}
