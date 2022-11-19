using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoBala : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float daño;
    public Vector2 posEnemigo;
    public Vector2 posJugador;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate((posEnemigo - posJugador) * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemigo"))
        {
            Debug.Log("Dañando enemigo");
        }
        /*if (collision.CompareTag("Finish"))
        {
            Debug.Log("Destruyendo bala");
            Destroy(collision.gameObject);
        }*/
    }
}
