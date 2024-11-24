using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    public GameObject hudUI;
    public GameCountDown countDownUI;
    //public GameSelectCharacter selectCharacter;

    IEnumerator Start() {
        while(GameManager.GetInstance() == null || GameManager.GetInstance().localPlayer == null){
            yield return null;
        }
    }

    public void OnStartGame(){
        countDownUI.StartCountDown();
    }
}
