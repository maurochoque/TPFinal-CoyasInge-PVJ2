using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Mirror;

public class Lobby : MonoBehaviour
{
    [SerializeField] Button btnStartLobby;
    [SerializeField] Button btnExitLobby;

    private void Start() {
        if(NetworkServer.active){
            btnStartLobby.gameObject.SetActive(true);
            btnStartLobby.onClick.AddListener(() => StartGame());
        }else{
            btnStartLobby.gameObject.SetActive(false);
        }

        btnExitLobby.onClick.AddListener(() => ExitLobby());
    }

    private void StartGame(){
        NetworkManager.singleton.ServerChangeScene("JuegoPrincipal");
    }

    private void ExitLobby(){
        if(NetworkServer.active && NetworkClient.isConnected){
            NetworkManager.singleton.StopHost();
        }else if(NetworkClient.isConnected){
            NetworkManager.singleton.StopClient();
        }
    }
}