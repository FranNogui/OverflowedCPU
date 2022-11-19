using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectarItem : MonoBehaviour
{
    private List<GameObject> itemsDisponibles;
    private int numItems;
    // Start is called before the first frame update
    void Start()
    {
        itemsDisponibles = new List<GameObject>();
        numItems = 0;
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
        if (other.CompareTag("Enemigo"))
        {
            Debug.Log("Item demasiado lejos");
            numItems--;
            itemsDisponibles.Remove(other.gameObject);
        }
    }

    private void CogerItem()
    {
        Destroy(itemsDisponibles[numItems - 1]);
    }
}
