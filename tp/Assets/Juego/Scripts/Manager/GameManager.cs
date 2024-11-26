
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;

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
        gameUI.OnStartGame(); 
    }



    public void StartHealthLogic()
{
    // solo ejecuta la logica si el servidor es el que la llama
    if (!isServer) return;

    // buscar el HealthController
    HealthController playerHealth = FindObjectOfType<HealthController>();
    
    if (playerHealth != null)
    {
        // activa la logica de salud (solo en el servidor)
        playerHealth.StartGame();

        // activar el Slider (solo en el servidor)
        HeroKnight hero = playerHealth.GetComponentInParent<HeroKnight>();
        if (hero != null)
        {
            Slider healthSlider = hero.GetComponentInChildren<Slider>();
            if (healthSlider != null)
            {
                healthSlider.gameObject.SetActive(true); 
                Debug.Log("slider activado ");
            }
            else
            {
                Debug.LogError("no se encontro el Slider dentro de HeroKnight");
            }
        }
        else
        {
            Debug.LogError("no se encontro HeroKnight");
        }
    }
    else
    {
        Debug.LogError("no se encontr un HealthController en la escena");
    }
}


    public void ClearLocalPlayer()
    {
        localPlayer = null;
        Debug.Log("local player cleared.");
    }
}
