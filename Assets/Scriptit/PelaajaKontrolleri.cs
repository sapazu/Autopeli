using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelaajaKontrolleri : MonoBehaviour
{
    [Tooltip("Autoon lisättävän voiman määrä")]
    public float Voima = 10;            //Lisättävän voiman määrä
    float nopeus;                       //Auton nopeus metreinä sekunnissa

    Rigidbody massa;                    //Pelaajan rigidbody komponentti

    Vector3 liikkumisSuunta;            //Suunta johon voimaa lisätään

    public Transform VoimanSijainti;    //Sijainti johon voimaa lisätään

    AudioSource audioLahde;             //Audiosource joka toistaa ääniefektin

    TrailRenderer renkaanJalki;         //Renkaanjälki spawneri

    void Start()
    {
        //Määritä pelaajan komponentit
        massa = GetComponent<Rigidbody>();
        audioLahde = GetComponent<AudioSource>();
        renkaanJalki = GameObject.Find("RenkaanJalki").GetComponent<TrailRenderer>();
    }

    void Update()
    {
        //Määritä liikkumissuunta Unityn input systeemin avulla
        liikkumisSuunta.x = Input.GetAxisRaw("Horizontal");
        liikkumisSuunta.z = Input.GetAxisRaw("Vertical");

        //Soita auton töötti välilyöntiä painaessa
        if (Input.GetKeyDown(KeyCode.Space))
        {
            audioLahde.Play();
        }
    }

    void FixedUpdate()
    {
        //Lisää voimaa pelaajan rigidbodyyn
        massa.angularDrag = 3;
        massa.AddForceAtPosition(liikkumisSuunta.normalized * Voima, VoimanSijainti.position);
        nopeus = massa.velocity.magnitude;

        //Jos pelaaja kääntyy tarpeeksi, laitetaan renkaanjälki näkyväksi
        float kaantyminen = (massa.GetPointVelocity(transform.forward) - massa.velocity).magnitude;
        if (kaantyminen > 10)
        {
            renkaanJalki.emitting = true;
        }
        else
        {
            renkaanJalki.emitting = false;
        }
    }
}
