using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Lobby : MonoBehaviour
{
    [SerializeField] Button btnStartLobby;
    [SerializeField] Button btnExitLobby;
    public int select;

    private void Start() {
        btnStartLobby.onClick.AddListener(() => StartGame());
    }

    private void StartGame(){
        select = PlayerPrefs.GetInt("Select", 0);
        PlayerPrefs.SetInt("Select", select);
        //NetworkManager.singleton.ServerChangeScene("JuegoPrincipal");
    }

    /*private void ExitLobby(){
        if(NetworkServer.active && NetworkClient.isConnected){
            NetworkManager.singleton.StopHost();
        }else if(NetworkClient.isConnected){
            NetworkManager.singleton.StopClient();
        }
    }*/
}