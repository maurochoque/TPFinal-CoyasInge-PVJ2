using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class GameManager : NetworkBehaviour 
{
    public static GameManager instance;

    public enum GameState{
        None, GamePause, GameStart, GameOver
    }    

    public GameState gameState = GameState.None;

    //[HideInInspector]
    public HeroKnight localPlayer;
    //public CinemachineVirtualCamera vCam;
    public GameUI gameUI;

    public static GameManager GetInstance(){
        return instance;
    }

    private void Awake() {
        instance = this;
    }

    [Server]
    public void StartGame()
    {
        RpcStartGame();
    }

    [ClientRpc]
    private void RpcStartGame()
    {
        Debug.Log("Starting game on client...");
        gameUI.OnStartGame(); // Llama a la UI para actualizar el cliente
    }

    public void ClearLocalPlayer()
    {
        localPlayer = null;
        Debug.Log("Local player cleared.");
    }

    /*[Server]
    public void StartGame() {
        RpcStartGame();
    }

    [ClientRpc]
    private void RpcStartGame(){
        gameUI.OnStartGame();
    }*/
}
