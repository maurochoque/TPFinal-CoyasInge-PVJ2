using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class MenuInicial : MonoBehaviour
{
    [SerializeField] Button startHost;
    [SerializeField] Button joinHost;

    private void Start() {
        startHost.onClick.AddListener(()=> StartLobby());
        joinHost.onClick.AddListener(()=> JoinLobby());
    }

    private void Update() {
        Debug.Log(NetworkServer.active);
    }

    private void StartLobby()=>NetworkManager.singleton.StartHost();

    private void JoinLobby()=>NetworkManager.singleton.StartClient();

    public void Salir()
    {
        print("Saliendo..");
        Application.Quit();
    }

    public void Jugar()
    {
        SceneManager.LoadScene("MenuInicio");
    }
}
