using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorAtaque : MonoBehaviour
{
    MovimientoPersonajeConRigidBody movPer;
    private ControladorCPU _CPU;
    private bool _cooldown;

    // Start is called before the first frame update
    void Start()
    {
        movPer = GetComponentInParent<MovimientoPersonajeConRigidBody>();
        _CPU = GameObject.Find("ControladorCPU").GetComponent<ControladorCPU>();
        _cooldown = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemigo") && !_cooldown)
        {
            Debug.Log("Jugador atacado");
            int da�o = other.gameObject.GetComponent<MovimientoEnemigoConRigidBody>().getAtaque();
            Da�arJugador(da�o);
            _CPU.recibirVida(-1);
            _CPU.restarCarga(20);
            _CPU.enemigosVivos.Remove(other.gameObject);
            Destroy(other.gameObject);
            StartCoroutine(cooldown());
        }
    }

    IEnumerator cooldown()
    {
        _cooldown = true;
        yield return new WaitForSeconds(0.5f);
        _cooldown = false;
    }

    private void Da�arJugador(int da�o)
    {
        movPer.setVida(movPer.getVida() - da�o);
        if (movPer.getVida() <= 0)
        {
            Debug.Log("Matar jugador");
        }
    }
}
