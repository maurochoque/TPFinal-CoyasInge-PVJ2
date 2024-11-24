using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Mirror;

public class CharacterSelect : MonoBehaviour
{
    public GameObject[] skin;
    public int select;

    private void Awake() {
        select = PlayerPrefs.GetInt("Select", 0);
        foreach(GameObject player in skin){
            player.SetActive(false);
        }

        skin[select].SetActive(true);
    }

    public void CambiarNext(){
        skin[select].SetActive(false);
        select++;
        if(select == skin.Length){
            select = 0;
        }

        skin[select].SetActive(true);
    }

    public void CambiarPrevio(){
        skin[select].SetActive(false);
        select--;
        if(select == -1){
            select = skin.Length - 1;
        }

        skin[select].SetActive(true);
    }

    public void Iniciarserver(){
        PlayerPrefs.SetInt("Select", select);
        NetworkManager.singleton.StartHost();
        gameObject.SetActive(false);
    }

    public void JoinServer(){
        PlayerPrefs.SetInt("Select", select);
        NetworkManager.singleton.StartClient();
        gameObject.SetActive(false);
    }
}
