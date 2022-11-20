using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Inicio : MonoBehaviour
{
    [SerializeField]
    Image fondo;

    IEnumerator intro()
    {
        while (true)
        {
            if (fondo.color.r <= 1.0f)
            {
                fondo.color = new Color(fondo.color.r + 0.5f * Time.deltaTime, fondo.color.g + 0.5f * Time.deltaTime, fondo.color.b + 0.5f * Time.deltaTime);
            }
            else
            {
                break;
            }
            yield return null;
            Debug.Log("Fin");
        }
        Debug.Log("Fin");
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("PantallaInicio");
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(intro());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
