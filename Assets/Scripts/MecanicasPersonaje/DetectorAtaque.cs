using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorAtaque : MonoBehaviour
{
    MovimientoPersonajeConRigidBody movPer;
    // Start is called before the first frame update
    void Start()
    {
        movPer = GetComponentInParent<MovimientoPersonajeConRigidBody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemigo"))
        {
            Debug.Log("Jugador atacado");
            int daño = other.gameObject.GetComponent<MovimientoEnemigoConRigidBody>().getAtaque();
            DañarJugador(daño);
        }
    }

    private void DañarJugador(int daño)
    {
        movPer.setVida(movPer.getVida() - daño);
        if (movPer.getVida() <= 0)
        {
            Debug.Log("Matar jugador");
        }
    }
}
