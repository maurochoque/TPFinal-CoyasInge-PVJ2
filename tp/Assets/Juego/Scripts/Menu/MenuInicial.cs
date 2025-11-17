using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class MenuInicial : MonoBehaviour
{
    [SerializeField] Button btnStartLobby;
    //private int select;

    private void Start()
    {
        btnStartLobby.onClick.AddListener(() => StartGame());
        btnStartLobby.onClick.AddListener(() => ExitGame());
    }

    private void Update() {
        //Debug.Log(NetworkServer.active);
    }

    private void StartGame()
    {
        //select = PlayerPrefs.GetInt("Select", 0);
        //PlayerPrefs.SetInt("Select", select);
        NetworkManager.singleton.StartHost();
        NetworkManager.singleton.ServerChangeScene("Nivel1");
    }

    public void ExitGame()
    {
        print("Saliendo..");
        Application.Quit();
    }

    /*public void Jugar()
    {
        SceneManager.LoadScene("MenuInicio");
    }*/
}
