using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraKontrolleri : MonoBehaviour
{
    Transform pelaaja;          //Pelaajan transform komponentti

    Vector3 turvavali;          //Kameran ja pelaajan väli
    Vector3 liikkumisSuunta;    //Suunta johon pelaaja liikkuu

    Rigidbody pelaajanMassa;    //Pelaajan rigidbody komponentti

    void Start()
    {
        //Etsitään pelaaja, pelaajan rigidbody ja määritetään pelaajan ja kameran väli
        pelaaja = GameObject.FindGameObjectWithTag("Pelaaja").transform;
        turvavali = transform.position - pelaaja.position;

        pelaajanMassa = pelaaja.GetComponent<Rigidbody>();
    }

    void Update()
    {
        //Liikutetaan kamera pelaajan sijaintiin ja lisätään siihen turvaväli sekä suunta johon pelaaja liikkuu
        liikkumisSuunta = pelaajanMassa.velocity * 0.4f;
        transform.position = pelaaja.position + turvavali + liikkumisSuunta;
    }
}
