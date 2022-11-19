using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEnemigoConRigidBody : MonoBehaviour
{
    // Start is called before the first frame update
    public float rangoDeAlerta;
    public LayerMask capaDelJugador;
    public bool estarAlerta;
    public Transform posJugador;
    public float speed;
    //private Rigidbody2D enemyrb;
    private Vector2 vectorJugador;
    //private NavMeshAgent navMeshAgent;
    [SerializeField]
    private int vidaMax;
    private int vida;
    [SerializeField]
    private int ataque;

    private void Awake()
    {
        //navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        //enemyrb = GetComponent<Rigidbody2D>();
        vida = vidaMax;
    }

    // Update is called once per frame
    void Update()
    {
        //estarAlerta = Physics.CheckSphere(transform.position, rangoDeAlerta, capaDelJugador);
        if (estarAlerta)
        {
            //transform.LookAt(posJugador);
            vectorJugador = new Vector2(posJugador.position.x, posJugador.position.y);
            //transform.LookAt(vectorJugador);
            transform.position = Vector2.MoveTowards(transform.position,vectorJugador, speed * Time.deltaTime);
            //navMeshAgent.SetDestination(vectorJugador);

        }
    }

    private void FixedUpdate()
    {
        //estarAlerta = Physics.CheckSphere(transform.position, rangoDeAlerta, capaDelJugador);
      /*  if (estarAlerta)
        {
            vectorJugador = new Vector2(posJugador.position.x, transform.position.y);
            //enemyrb.MovePosition(enemyrb.position - vectorJugador * speed * Time.fixedDeltaTime);
            enemyrb.AddForce(vectorJugador);
        }*/
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangoDeAlerta);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Atacando jugador");
        }*/
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Atacando jugador onTrigger");
        }
        if (other.CompareTag("Proyectil"))
        {
            Debug.Log("Enemigo atacado");
            int daño = other.gameObject.GetComponent<MovimientoBala>().getDaño();
            Destroy(other.gameObject);
            
            DañarEnemigo(daño);
        }
    }

    private void DañarEnemigo(int daño)
    {
        vida = vida - daño;
        if(vida <= 0)
        {
            MatarEnemigo();
        }
    }

    private void MatarEnemigo()
    {
        Destroy(this.gameObject);
    }

    public void setAtaque(int ataque)
    {
        this.ataque = ataque;
    }

    public int getAtaque()
    {
        return ataque;
    }
}
