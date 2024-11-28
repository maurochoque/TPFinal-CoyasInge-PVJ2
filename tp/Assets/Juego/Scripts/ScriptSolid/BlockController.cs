using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    public GameObject escudo;
    private AnimationController anim;

    private void Start() {
        anim = GetComponent<AnimationController>();
    }

    public void Bloquear(){
        if(Input.GetKeyDown("k")){
            gameObject.layer = LayerMask.NameToLayer("Escudo");
            anim.TriggerIdleBlock(true);
            escudo.SetActive(true);
        }else if(Input.GetKeyUp("k")){
            gameObject.layer = LayerMask.NameToLayer("Player");
            anim.TriggerIdleBlock(false);
            escudo.SetActive(false);
        }
    }
}
