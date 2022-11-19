using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;

public class ControladorCPU : MonoBehaviour
{
    private float _carga;
    private const float MAXCARGA = 300;
    private float _porcentaje;

    [SerializeField]
    private TextMeshProUGUI _porcentajeTexto;
    [SerializeField]
    private Image _imagenCPU;
    [SerializeField]
    private Animator _controladorAnimacion;

    [SerializeField]
    private ControladorDigito[] _puntuacion;
    private int _puntuacionActual;

    [SerializeField]
    private ControladorDigito[] _segundos;
    private float _segundosActual;

    [SerializeField]
    private ControladorDigito[] _piso;
    private int _pisoActual;

    [SerializeField]
    private ControladorItem[] _items;

    private int _itemSelec;

    [SerializeField]
    private ControladorCorazon[] _corazones;
    private int _vida;

    [SerializeField]
    private GeneradorEnemigos[] _portales;

    [SerializeField]
    private AudioSource _reproductor;
    private int _loopActual = 0;

    [SerializeField]
    private AudioClip[] _loops;

    private int _nivel;

    // Start is called before the first frame update
    void Start()
    {
        _puntuacionActual = 0;
        _segundosActual = 30;
        _pisoActual = 0;
        _itemSelec = 0;
        cambiarItemSelec(_itemSelec);
        cambiarVida(2);
        _nivel = 0;
        iniciarJuego();
        _carga = 0;
        iniciarPortales(_nivel);
        _reproductor.clip = _loops[_loopActual];
    }

    // Update is called once per frame
    void Update()
    {
        _controladorAnimacion.SetFloat("porcentaje", _porcentaje);
        _imagenCPU.color = new Color(1f, 1f - (_porcentaje / 100.0f), 1f - (_porcentaje / 100.0f), 1f);
        _porcentajeTexto.text = _porcentaje.ToString("0.00") + "%";
        _porcentajeTexto.color = new Color(1f, 1f - (_porcentaje / 100.0f), 1f - (_porcentaje / 100.0f), 1f);
        actualizarTiempo();
        comprobarMusica();

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            cambiarItemSelec((_itemSelec + 1) % 3);
        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (_itemSelec == 0)
                cambiarItemSelec(2);
            else
                cambiarItemSelec(_itemSelec - 1);
        }
    }

    void actualizarTiempo()
    {
        _segundosActual -= Time.deltaTime;
        if (_segundosActual <= 0)
        {
            aumentarPiso();
        }
        int segundos = (int)_segundosActual;
        for (var i = 0; i < 2; i++)
        {
            _segundos[i].cambiarA(segundos % 10);
            segundos /= 10;
        }
    }

    void aumentarPiso()
    {
        _pisoActual++;
        int piso = (int)_pisoActual;
        for (var i = 0; i < 2; i++)
        {
            _piso[i].cambiarA(piso % 10);
            piso /= 10;
        }
        resetearTiempo();
        aumentarNivel();
    }

    void disminuirPiso()
    {
        _pisoActual--;
        int piso = (int)_pisoActual;
        for (var i = 0; i < 2; i++)
        {
            _piso[i].cambiarA(piso % 10);
            piso /= 10;
        }
    }

    void resetearTiempo()
    {
        _segundosActual = 30f;
    }

    public void aumentarPuntuacion(int num)
    {
        _puntuacionActual += num;
        int aux = _puntuacionActual;
        for (var i = 0; i < 5; i++)
        {
            _puntuacion[i].cambiarA(aux % 10);
            aux /= 10;
        }
    }

    public void cambiarItem(int pos, ControladorItem.Items item)
    {
        _items[pos].cambiarItem(item);
    }

    public void cambiarItemSelec(int item)
    {
        _items[_itemSelec].seleccionado(false);
        _itemSelec = item;
        _items[_itemSelec].seleccionado(true);
    }

    public void cambiarVida(int vida)
    {
        _vida = vida;
        for (var i = 0; i < 3; i++)
            _corazones[i].activo(!(i > _vida));
    }

    public void recibirVida(int cantidad)
    {
        _vida += cantidad;
        if (_vida < 0)
        {
            morir();
        }
        if (_vida > 2)
        {
            _vida = 2;
        }
        cambiarVida(_vida);
    }

    public void morir()
    {
        Debug.Log("Has muerto");
    }

    public void iniciarJuego()
    {

    }

    public void aumentarNivel()
    {

    }

    public bool cojerItem(Item item)
    {
        ControladorItem.Items itemRecogido = item.obtenerItem();
        if (itemRecogido == ControladorItem.Items.Moneda)
        {
            aumentarPuntuacion(10);
            restarCarga(Item.CARGAITEM);
            Destroy(item.gameObject);
        }
        else if (itemRecogido == ControladorItem.Items.Pocion)
        {
            recibirVida(1);
            restarCarga(Item.CARGAITEM);
            Destroy(item.gameObject);
        }
        else
        {
            for (var i = 0; i < 3; i++)
            {
                if (_items[i].obtenerItem() == ControladorItem.Items.Nada)
                {
                    _items[i].cambiarItem(itemRecogido);
                    Destroy(item.gameObject);
                    restarCarga(Item.CARGAITEM);
                    anyadirCarga(item._cargaEquipado);
                    return true;
                }
            }
        }
        return false;
    }

    public void anyadirCarga(float carga)
    {
        _carga += carga;
        _porcentaje = (_carga / MAXCARGA) * 100.0f;
    }

    public void restarCarga(float carga)
    {
        _carga -= carga;
        _porcentaje = (_carga / MAXCARGA) * 100.0f;
    }

    public void iniciarPortales(int nivel)
    {
        for (var i = 0; i < 5; i++)
        {
            _portales[i].nivel(nivel);
            _portales[i].activar();
        }
    }

    public void comprobarMusica()
    {
        if (_porcentaje < 100 / 8 && _loopActual != 0)
        {
            _loopActual = 0;
            _reproductor.clip = _loops[_loopActual];
            _reproductor.Play();
        }
        else if (_porcentaje < 2 * 100 / 8 && _porcentaje > 100 / 8  && _loopActual != 1)
        {
            _loopActual = 1;
            _reproductor.clip = _loops[_loopActual];
            _reproductor.Play();
        }
        else if (_porcentaje < 3 * 100 / 8 && _porcentaje >  2 * 100 / 8  && _loopActual != 2)
        {
            _loopActual = 2;
            _reproductor.clip = _loops[_loopActual];
            _reproductor.Play();
        }
        else if (_porcentaje < 4 * 100 / 8 && _porcentaje > 3 * 100 / 8 && _loopActual != 3)
        {
            _loopActual = 3;
            _reproductor.clip = _loops[_loopActual];
            _reproductor.Play();
        }
        else if (_porcentaje < 5 * 100 / 8 && _porcentaje > 4 * 100 / 8 && _loopActual != 4)
        {
            _loopActual = 4;
            _reproductor.clip = _loops[_loopActual];
            _reproductor.Play();
        }
        else if (_porcentaje < 6 * 100 / 8 && _porcentaje > 5 * 100 / 8 && _loopActual != 5)
        {
            _loopActual = 5;
            _reproductor.clip = _loops[_loopActual];
            _reproductor.Play();
        }
        else if (_porcentaje < 7 * 100 / 8 && _porcentaje > 6 * 100 / 8 && _loopActual != 6)
        {
            _loopActual = 6;
            _reproductor.clip = _loops[_loopActual];
            _reproductor.Play();
        }
        else if (_loopActual != 7 && _porcentaje > 7 * 100 / 8)
        {
            _loopActual = 7;
            _reproductor.clip = _loops[_loopActual];
            _reproductor.Play();
        }
    }
}
