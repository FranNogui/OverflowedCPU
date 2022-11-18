using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorBotones : MonoBehaviour
{
    [SerializeField]
    private GameObject _osMenuPanel;

    // Update is called once per frame
    void Update() {}

    // Callback del boton del menu del OS
    public void OSMenuBotonPulsado()
    { _osMenuPanel.SetActive(!_osMenuPanel.activeSelf); }

    // Callback del boton apagar
    public void ApagarBotonPulsado()
    { Application.Quit(); }
}
