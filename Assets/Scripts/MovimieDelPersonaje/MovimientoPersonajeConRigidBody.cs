using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonajeConRigidBody : MonoBehaviour
{
    public float speed = 5;
    private Rigidbody2D playerRb;
    private Vector2 moveInput;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveInput = new Vector2(moveX, moveY).normalized;
        //playerRb.MovePosition(playerRb.position + moveInput * speed);
    }

    private void FixedUpdate()
    {
        playerRb.MovePosition(playerRb.position + moveInput * speed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       /* if (collision.gameObject.CompareTag("Enemigo"))
        {
            Debug.Log("Jugador atacado");
        }*/
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemigo"))
        {
            Debug.Log("Jugador atacado");
        }
    }
}
