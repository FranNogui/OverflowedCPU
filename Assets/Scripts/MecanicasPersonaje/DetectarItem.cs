using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectarItem : MonoBehaviour
{
    private List<GameObject> itemsDisponibles;
    private int numItems;
    private ControladorCPU _CPU;
    public DisparoJugador _disparo;
    [SerializeField]
    private MovimientoPersonajeConRigidBody player;
    // Start is called before the first frame update
    void Start()
    {
        itemsDisponibles = new List<GameObject>();
        numItems = 0;
        _CPU = GameObject.Find("ControladorCPU").GetComponent<ControladorCPU>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            if(itemsDisponibles.Count > 0)
            CogerItem();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Item"))
        {
            Debug.Log("Item detectado");
            numItems++;
            itemsDisponibles.Add(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Item"))
        {
            Debug.Log("Item demasiado lejos");
            numItems--;
            itemsDisponibles.Remove(other.gameObject);
        }
    }

    private void CogerItem()
    {
        GameObject item = itemsDisponibles[0];
        numItems--;
        itemsDisponibles.Remove(item);
        ControladorItem.Items tipoItem = item.GetComponent<Item>().obtenerItem();
        if (_CPU.cogerItem(item.GetComponent<Item>()))
        {
            if (tipoItem == ControladorItem.Items.Botas)
            {
                player.aumentarVel(0.2f);
            }
            else if (tipoItem == ControladorItem.Items.Guantes)
            {
                _disparo.porcentajeDisparo -= 0.2f ;
            }
        }
        else
        {
            itemsDisponibles.Add(item);
            numItems++;
        }
    }
}
