using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoJugador : MonoBehaviour
{
    [SerializeField]
    private Transform jugador;
    [SerializeField]
    private GameObject bala;
    [SerializeField]
    private int tiempoEspera;
    private float tiempo;
    private Transform enemigoCercano;
    private DetectorEnemigos detectorEnemigos;
    private MovimientoBala movBala;
    // Start is called before the first frame update
    void Start()
    {
        detectorEnemigos = GetComponent<DetectorEnemigos>();
        tiempo = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        tiempo = tiempo + 1f * Time.deltaTime;
        if (tiempo >= tiempoEspera)
        {
            tiempo = 0;
            if (detectorEnemigos.VerEnemigos().Count != 0)
            {
                List<GameObject> enemigos = detectorEnemigos.VerEnemigos();
                enemigoCercano = enemigos[0].transform;
                for (int i = 1; i < enemigos.Count; i++)
                {
                    Vector2 distanciaCercano = enemigoCercano.position - jugador.position;
                    Vector2 distanciaNuevo = enemigos[i].transform.position - jugador.position;
                    if (Mathf.Abs(distanciaNuevo.x + distanciaNuevo.y) < Mathf.Abs(distanciaCercano.x + distanciaNuevo.y))
                    {
                        enemigoCercano = enemigos[i].transform;
                    }
                }
                Disparar();
            }
        }
        
        
    }

    private void Disparar()
    {
        movBala = bala.GetComponent<MovimientoBala>();
        movBala.posEnemigo = enemigoCercano.position;
        movBala.posJugador = jugador.position;
        Instantiate(bala, jugador.position, jugador.rotation);
    }
}
