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
    private float posY;
    private float posX;
    private float longX;
    private float longY;
    void Start()
    {
        posY = transform.position.y;
        posX = transform.position.x;
        longX = transform.localScale.x;
        longY = transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        System.Random r = new System.Random();
        if (generadorHorizontal)
        {
            float puntoGeneracionX = r.Next((int)(posX - longX/2), (int)(posX + longX/2));
            GenerarEnemigoHorizontal(puntoGeneracionX);
        }
        else
        {
            float puntoGeneracionY = r.Next((int)(posY - longY / 2), (int)(posY + longY / 2));
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
