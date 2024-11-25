using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Cinemachine;
using System.Linq;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private Transform puntoSpawn;
    [SerializeField] private GameObject[] enemigos;
    [SerializeField] private float tiempo_enemigos;

    //[SerializeField] private Slider slider;
    //[SerializeField] private GameObject canva;
    //[SerializeField] private CinemachineConfiner2D vCam;
    //[SerializeField] public PolygonCollider2D pol;
    private float cont = 15;
    private bool band;

    private void Start() {
        //vCam = FindObjectOfType<CinemachineConfiner2D>();
        //pol = GetComponent<PolygonCollider2D>();
        //slider.value = cont;
    }

    private void Update() {
        if(band){
            if(cont == 0){
                //pol.enabled = false;
                //slider.enabled = false;
                //vCam.m_BoundingShape2D = null;
                CancelInvoke("CrearEnemigo");
                band = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            InvokeRepeating("CrearEnemigo", 1f, tiempo_enemigos);
            band = true;
            //pol.enabled = true;
            //slider.enabled = true;
            //vCam.m_BoundingShape2D = pol;
        }
    }

    public void CrearEnemigo() {
        int numEnemigo = Random.Range(0, enemigos.Length);

        Instantiate(enemigos[numEnemigo], new Vector2(puntoSpawn.position.x, puntoSpawn.position.y), Quaternion.identity);
        cont--;
    }
}
