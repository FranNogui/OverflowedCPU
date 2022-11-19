using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorDigito : MonoBehaviour
{
    [SerializeField]
    private Sprite[] _numeros;
    private SpriteRenderer _imagen;

    public void Start()
    {  
        _imagen = GetComponent<SpriteRenderer>();
    }

    // Cambiar a un numero
    public void cambiarA(int num)
    {
        _imagen.sprite = _numeros[num];
    }
}
