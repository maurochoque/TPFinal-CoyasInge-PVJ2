using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameCountDown : MonoBehaviour
{
    public TextMeshProUGUI txt;

    public void StartCountDown(){
        StartCoroutine(StarCountDownRoutine());
    }

    IEnumerator StarCountDownRoutine(){
        UpdateText("Loading...");
        yield return new WaitForSeconds(1f);
        yield return new WaitForSeconds(0.5f);
        UpdateText("3");
        yield return new WaitForSeconds(0.5f);
        UpdateText("2");
        yield return new WaitForSeconds(0.5f);
        UpdateText("1");
        yield return new WaitForSeconds(0.5f);
        UpdateText("Fight!!!");
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
    
    public void UpdateText(string text){
        txt.text = text;
    }
}
