using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Daño : MonoBehaviour
{
    public float vida;
    public BarraDeVida barra;
    private Animator anim;

    HeroKnight heroKnight;
    
    void Start()
    {
        anim = GetComponent<Animator>();
    barra.InicializarBarraVida(vida);

    heroKnight = FindObjectOfType<HeroKnight>();
    if (heroKnight == null)
    {
        Debug.LogError("No se encontró un objeto con el script HeroKnight en la escena.");
    }
        /*var heroKnight= new HeroKnight();
        anim = GetComponent<Animator>();
        barra.InicializarBarraVida(vida);
        bool isBlocking = heroKnight.m_isBlocking;*/
    }

    public void TomarDano(float danio)
    {
        anim.SetTrigger("Hurt");
        vida -= danio;
        barra.CambiarVidaActual(vida);
        if(heroKnight.m_isBlocking==true)
        {
            vida-=0;
        }
        if(vida <= 0f)
        {
            anim.SetTrigger("Death");
            AudioManager.instance.Reproducir(11);
            gameObject.SetActive(false);
        }
    }

    public float InformeVida()
    {
        return vida;
    }
}
