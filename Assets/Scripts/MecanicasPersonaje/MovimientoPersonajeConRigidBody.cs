using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonajeConRigidBody : MonoBehaviour
{
    public float speed = 5;
    private Rigidbody2D playerRb;
    private Vector2 moveInput;
    [SerializeField]
    private int vidaMax;
    private int vida;
    private float porIncVel;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        porIncVel = 1f;
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
        playerRb.MovePosition(playerRb.position + moveInput * speed * Time.fixedDeltaTime * porIncVel);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       /* if (collision.gameObject.CompareTag("Enemigo"))
        {
            Debug.Log("Jugador atacado");
        }*/
    }

    /*private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemigo"))
        {
            Debug.Log("Jugador atacado");
        }
    }*/

    public void setVidaMax(int vidaMax)
    {
        this.vidaMax = vidaMax;
    }

    public int getVidaMax()
    {
        return vidaMax;
    }

    public void setVida(int vida)
    {
        this.vida = vida;
    }

    public int getVida()
    {
        return vida;
    }

    public void aumentarVel(float inc)
    {
        porIncVel += inc;
    }


}
