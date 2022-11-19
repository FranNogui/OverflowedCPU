using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorEnemigos : MonoBehaviour
{
    private List<GameObject> enemigos;
    private int num_enemigos;
    // Start is called before the first frame update
    void Start()
    {
        enemigos = new List<GameObject>();
        num_enemigos = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemigo"))
        {
            Debug.Log("Enemigo detectado");
            num_enemigos++;
            enemigos.Add(other.gameObject);
            Debug.Log("" + enemigos[num_enemigos - 1].name);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemigo"))
        {
            Debug.Log("Enemigo desaparecido");
            enemigos.Remove(other.gameObject);
            num_enemigos--;
        }
    }

    private List<GameObject> VerEnemigos()
    {
        return enemigos;
    }

    private void clearEnemigos()
    {
        enemigos.Clear();
        num_enemigos = 0;
    }
}
