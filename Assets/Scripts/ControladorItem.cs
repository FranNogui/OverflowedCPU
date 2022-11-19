using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorItem : MonoBehaviour
{
    public enum Items {Flecha, Arco, Guantes, Bomba, Escudo, Botas, Pocion, Moneda, Nada};
    private Items _itemActual;

    [SerializeField]
    private SpriteRenderer _imagen;

    [SerializeField]
    private Sprite _flecha;
    [SerializeField]
    private Sprite _arco;
    [SerializeField]
    private Sprite _guantes;
    [SerializeField]
    private Sprite _bomba;
    [SerializeField]
    private Sprite _escudo;
    [SerializeField]
    private Sprite _botas;

    [SerializeField]
    private Sprite _selec;
    [SerializeField]
    private Sprite _noSelec;

    private SpriteRenderer _seleccion;

    private float _carga;

    public void Start()
    {
        _seleccion = GetComponent<SpriteRenderer>();
        _itemActual = Items.Nada;
        _carga = 0;
    }

    public void cambiarItem(Items item)
    {
        _itemActual = item;
        switch(item)
        {
            case Items.Flecha:
                _imagen.sprite = _flecha;
                break;
            case Items.Arco:
                _imagen.sprite = _arco;
                break;
            case Items.Guantes:
                _imagen.sprite = _guantes;
                break;
            case Items.Bomba:
                _imagen.sprite = _bomba;
                break;
            case Items.Escudo:
                _imagen.sprite = _escudo;
                break;
            case Items.Botas:
                _imagen.sprite = _botas;
                break;
            default:
                _imagen.sprite = null;
                break;
        }
        
    }

    public Items obtenerItem()
    {
        return _itemActual;
    }

    public void seleccionado(bool seleccionado)
    {
        if (seleccionado)
            _seleccion.sprite = _selec;
        else
            _seleccion.sprite = _noSelec;
    }


    public void asignarCarga(float carga)
    {
        _carga = carga;
    }
    public float obtenerCarga()
    {
        return _carga;
    }
}
