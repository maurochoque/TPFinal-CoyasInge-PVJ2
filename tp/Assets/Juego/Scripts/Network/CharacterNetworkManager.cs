using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Mirror;

public class CharacterNetworkManager : NetworkManager
{
    public List<HeroKnight> players = new List<HeroKnight>();

    public override void OnServerAddPlayer(NetworkConnectionToClient conn){
        base.OnServerAddPlayer(conn);

        HeroKnight hero = conn.identity.GetComponent<HeroKnight>();

        players.Add(hero);

        hero.SetNickName("Player "+ players.Count);

        if(!SceneManager.GetActiveScene().name.Equals("JuegoPrincipal")) return;
        Debug.Log(players.Count >=1);
        if(players.Count >= 1){
            GameManager.GetInstance().StartGame();
        }
    }

    public override void OnServerDisconnect(NetworkConnectionToClient conn){
        HeroKnight hero = conn.identity.GetComponent<HeroKnight>();
        if (hero != null)
        {
            players.Remove(hero);
        }
        Debug.Log($"Desconectando jugador. Quedan: {players.Count}");
        base.OnServerDisconnect(conn);
    }

    public override void OnStopServer()
    {
        players.Clear();
        base.OnStopServer();
    }
}
