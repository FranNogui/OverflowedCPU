using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static ControladorItem;

public class Item : MonoBehaviour
{
    private ControladorItem.Items _item;
    private SpriteRenderer _imagen;
    public const float CARGAITEM = 10;
    public float _cargaEquipado;
    [SerializeField]
    private ControladorCPU _CPU;

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
    private Sprite _pocion;
    [SerializeField]
    private Sprite _moneda;

    // Start is called before the first frame update
    void Start()
    {
        _imagen = GetComponent<SpriteRenderer>();
        _CPU = GameObject.Find("ControladorCPU").GetComponent<ControladorCPU>();
        _CPU.anyadirCarga(CARGAITEM);

        float rand = Random.value;
        rand *= 100;

        if (rand < 10)
        { _item = ControladorItem.Items.Guantes; _cargaEquipado = 30; }
        else if (rand < 20)
        { _item = ControladorItem.Items.Botas; _cargaEquipado = 20; }
        else if (rand < 30)
        { _item = ControladorItem.Items.Pocion; _cargaEquipado = 0; }
        else
        { _item = ControladorItem.Items.Moneda; _cargaEquipado = 0; }

        switch (_item)
        {
            case ControladorItem.Items.Flecha:
                _imagen.sprite = _flecha;
                break;
            case ControladorItem.Items.Arco:
                _imagen.sprite = _arco;
                break;
            case ControladorItem.Items.Guantes:
                _imagen.sprite = _guantes;
                break;
            case ControladorItem.Items.Bomba:
                _imagen.sprite = _bomba;
                break;
            case ControladorItem.Items.Escudo:
                _imagen.sprite = _escudo;
                break;
            case ControladorItem.Items.Botas:
                _imagen.sprite = _botas;
                break;
            case ControladorItem.Items.Pocion:
                _imagen.sprite = _pocion;
                break;
            case ControladorItem.Items.Moneda:
                _imagen.sprite = _moneda;
                break;
        }
        StartCoroutine(destruirse());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public ControladorItem.Items obtenerItem()
    {
        return _item;
    }

    IEnumerator destruirse()
    {
        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);
    }
}
