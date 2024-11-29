using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovimientoEnemigo : MonoBehaviour
{
    public LayerMask suelo;
    public Transform controlador, ground; 
    private Rigidbody2D rigid;
    public Animator anim;
    public float speed_walk;
    public float rango_ataque;
    public int danioGolpe;
    public float distancia;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = FindObjectOfType<Animator>(); 
    }

    private void Update() {
        rigid.velocity = new Vector2(speed_walk * transform.right.x, rigid.velocity.y);
        RaycastHit2D pared = Physics2D.Raycast(ground.position, transform.right, distancia, suelo);
        anim.SetBool("walk", true);
        if(pared){
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        }
    }

    /*private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){        
            //dano.TomarDano(danioGolpe);
            //AudioManager.instance.Reproducir(15);
            if(player.barravida.value > 10){
                player.CmdTakeDamage(10);
            }
            if(player.barravida.value <= 10)
            {
                player.Morir();
                //AudioManager.instance.Reproducir(4);
                SceneManager.LoadScene("MenuDerrota");
            }
        }else if(other.CompareTag("Escudo"))
        {
            AudioManager.instance.Reproducir(2);
            print("Bloqueo");
        }
    }*/

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controlador.position, rango_ataque);
        Gizmos.DrawLine(ground.position, ground.position + ground.transform.right * distancia);
    }
}
