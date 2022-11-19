using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorCorazon : MonoBehaviour
{
    [SerializeField]
    private Sprite _activo;

    [SerializeField]
    private Sprite _inactivo;

    private SpriteRenderer _imagen;

    public void Start()
    {
        _imagen = GetComponent<SpriteRenderer>();
    }

    public void activo(bool activo)
    {
        if (activo)
            _imagen.sprite = _activo;
        else
            _imagen.sprite = _inactivo;

    }
}
