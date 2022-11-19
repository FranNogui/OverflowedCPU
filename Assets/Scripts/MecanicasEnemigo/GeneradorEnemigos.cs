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
    private GameObject enemigo4;

    [SerializeField]
    private GameObject circulo;
    [SerializeField]
    private GameObject triangulo;
    [SerializeField]
    private GameObject cuadrado;
    [SerializeField]
    private GameObject pentagono;

    private bool generadorHorizontal;
    public int tiempoEsperaMin;
    public int tiempoEsperaMax;
    private System.Random generadorNumero;
    private float posY;
    private float posX;
    private float longX;
    private float longY;
    private float tiempo;
    private bool activo;

    [SerializeField]
    private ControladorCPU _CPU;

    void Start()
    {
        posY = transform.position.y;
        posX = transform.position.x;
        longX = transform.localScale.x;
        longY = transform.localScale.y;
        tiempo = 0f;
        generadorNumero = new System.Random();
        activo = false;
        _CPU = GameObject.Find("ControladorCPU").GetComponent<ControladorCPU>();
    }

    // Update is called once per frame
    void Update()
    {
        int tiempoEspera = generadorNumero.Next(tiempoEsperaMin, tiempoEsperaMax);
        tiempo = tiempo + 1f * Time.deltaTime;
        if(tiempo >= tiempoEspera && activo)
        {
            tiempo = 0f;
            GenerarEnemigo();
        }
    }

    private void GenerarEnemigo()
    {
        /*if (generadorHorizontal)
        {
            float puntoGeneracionX = generadorNumero.Next((int)(posX - longX / 2), (int)(posX + longX / 2));
            GenerarEnemigoHorizontal(puntoGeneracionX);
        }
        else
        {
            float puntoGeneracionY = generadorNumero.Next((int)(posY - longY / 2), (int)(posY + longY / 2));
            GenerarEnemigoVertical(puntoGeneracionY);
        }*/
        GenerarEnemigoCentral();
    }

    private void GenerarEnemigoHorizontal(float puntoGeneracionX)
    {
        float rand = UnityEngine.Random.value;
        rand *= 100;
        if (rand < 100 / 4)
            Instantiate(enemigo1, new Vector2(puntoGeneracionX, posY), transform.rotation);
        else if (rand < 2 * 100 / 4)
            Instantiate(enemigo2, new Vector2(puntoGeneracionX, posY), transform.rotation);
        else if (rand < 3 * 100 / 4)
            Instantiate(enemigo3, new Vector2(puntoGeneracionX, posY), transform.rotation);
        else
            Instantiate(enemigo4, new Vector2(puntoGeneracionX, posY), transform.rotation);
        _CPU.anyadirCarga(20);
    }

    private void GenerarEnemigoCentral()
    {
        GameObject creado;
        float rand = UnityEngine.Random.value;
        rand *= 100;
        if (rand < 100 / 4)
            creado = Instantiate(enemigo1, transform.position, transform.rotation);
        else if (rand < 2 * 100 / 4)
            creado = Instantiate(enemigo2, transform.position, transform.rotation);
        else if (rand < 3 * 100 / 4)
            creado = Instantiate(enemigo3, transform.position, transform.rotation);
        else
            creado = Instantiate(enemigo4, transform.position, transform.rotation);
        _CPU.anyadirCarga(20);
        _CPU.enemigosVivos.Add(creado);
    }

    private void GenerarEnemigoVertical(float puntoGeneracionY)
    {
        float rand = UnityEngine.Random.value;
        rand *= 100;
        if (rand < 100 / 4)
            Instantiate(enemigo1, new Vector2(posX, puntoGeneracionY), transform.rotation);
        else if (rand < 2 * 100 / 4)
            Instantiate(enemigo2, new Vector2(posX, puntoGeneracionY), transform.rotation);
        else if (rand < 3 * 100 / 4)
            Instantiate(enemigo3, new Vector2(posX, puntoGeneracionY), transform.rotation);
        else
            Instantiate(enemigo4, new Vector2(posX, puntoGeneracionY), transform.rotation);
        _CPU.anyadirCarga(20);
    }

    public void activar()
    {
        activo = true;
    }

    public void desactivar()
    {
        activo = false;
    }

    public void nivel(int nivel)
    {
        switch (nivel)
        {
            case 0:
                enemigo1 = circulo;
                enemigo2 = circulo;
                enemigo3 = circulo;
                enemigo4 = circulo;
                tiempoEsperaMin = 5;
                tiempoEsperaMax = 10;
                break;
            case 1:
                enemigo1 = circulo;
                enemigo2 = circulo;
                enemigo3 = circulo;
                enemigo4 = triangulo;
                tiempoEsperaMin = 5;
                tiempoEsperaMax = 10;
                break;
            case 2:
                enemigo1 = circulo;
                enemigo2 = circulo;
                enemigo3 = circulo;
                enemigo4 = triangulo;
                tiempoEsperaMin = 4;
                tiempoEsperaMax = 6;
                break;
            case 3:
                break;
            default:
                break;
        }
    }
}
