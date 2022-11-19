using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorBotones : MonoBehaviour
{
    [SerializeField]
    private GameObject _osMenuPanel;
    [SerializeField]
    private GameObject _menuInfoPanel;

    // Update is called once per frame
    void Update() {}

    // Callback del boton del menu del OS
    public void OSMenuBotonPulsado()
    { _osMenuPanel.SetActive(!_osMenuPanel.activeSelf); }

    // Callback del boton apagar
    public void ApagarBotonPulsado()
    { Application.Quit(); }


    // Callback del bot�n de cerrar de la pantalla de menu info
    public void MenuInfoHeaderQuitPulsado()
    { _menuInfoPanel.SetActive(false); }


    // Callback del boton del menu del exe del juego
    public void MenuInfoExePulsado()
    { _menuInfoPanel.SetActive(true); }

    public void IniciarJuegoPulsado(){
        SceneManager.LoadScene("EscenaJuego");    
    }
}
