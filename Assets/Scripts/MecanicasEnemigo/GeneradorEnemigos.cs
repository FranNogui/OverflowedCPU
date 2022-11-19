using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GeneradorEnemigos : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject enemigo1;
    [SerializeField]
    private GameObject enemigo2;
    [SerializeField]
    private GameObject enemigo3;
    [SerializeField]
    private bool generadorHorizontal;
    public int tiempoEsperaMin;
    public int tiempoEsperaMax;
    private System.Random generadorNumero;
    private float posY;
    private float posX;
    private float longX;
    private float longY;
    private float tiempo;
    void Start()
    {
        posY = transform.position.y;
        posX = transform.position.x;
        longX = transform.localScale.x;
        longY = transform.localScale.y;
        tiempo = 0f;
        generadorNumero = new System.Random();
    }

    // Update is called once per frame
    void Update()
    {
        int tiempoEspera = generadorNumero.Next(tiempoEsperaMin, tiempoEsperaMax);
        tiempo = tiempo + 1f * Time.deltaTime;
        if(tiempo >= tiempoEspera)
        {
            tiempo = 0f;
            GenerarEnemigo();
        }
    }

    private void GenerarEnemigo()
    {
        if (generadorHorizontal)
        {
            float puntoGeneracionX = generadorNumero.Next((int)(posX - longX / 2), (int)(posX + longX / 2));
            GenerarEnemigoHorizontal(puntoGeneracionX);
        }
        else
        {
            float puntoGeneracionY = generadorNumero.Next((int)(posY - longY / 2), (int)(posY + longY / 2));
            GenerarEnemigoVertical(puntoGeneracionY);
        }
    }

    private void GenerarEnemigoHorizontal(float puntoGeneracionX)
    {
        Instantiate(enemigo1, new Vector2(puntoGeneracionX, posY), transform.rotation);
    }

    private void GenerarEnemigoVertical(float puntoGeneracionY)
    {
        Instantiate(enemigo1, new Vector2(posX, puntoGeneracionY), transform.rotation);
    }
}
