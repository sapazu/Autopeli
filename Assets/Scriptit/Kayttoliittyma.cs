using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Kayttoliittyma : MonoBehaviour
{
    public int keratytKolikot;  //Kerättyjen kolikoiden määrä
    int kolikoidenMaara;        //Pelissä olevien kolikoiden määrä

    float aika;                 //Kuinka kauan peliä on pelattu
    public float skaala;        //Kolikko tekstin skaala, käytetään animoinnissa

    Text kolikkoTeksti;         //KolikkoTeksti objektin Text-komponentti
    Text ajastinTeksti;         //AjastinTeksti objektin Text-komponentti

    void Start()
    {
        //Etsitään teksti komponentit ja lasketaan kolikoiden määrä
        kolikkoTeksti = GameObject.Find("KolikkoTeksti").GetComponent<Text>();
        ajastinTeksti = GameObject.Find("AjastinTeksti").GetComponent<Text>();
        kolikoidenMaara = GameObject.FindGameObjectsWithTag("Kolikko").Length;
        skaala = 1;
    }

    void Update()
    {
        //Lisätään peliaikaa jos kaikkia kolikoita ei ole kerätty
        if(keratytKolikot != kolikoidenMaara)
        {
            aika += Time.deltaTime;
        }
        //Päivitetään teksti komponenttien sisältö
        kolikkoTeksti.text = "Kolikoiden määrä: " + keratytKolikot + "/" + kolikoidenMaara;
        ajastinTeksti.text = aika.ToString("F1") + "s";

        AnimoiTeksti();
    }

    void AnimoiTeksti()
    {
        //Pienennetään kolikkotekstin kokoa lineaarisesti
        skaala += Time.deltaTime * 4;
        kolikkoTeksti.rectTransform.localScale = Vector3.Lerp(Vector3.one * 1.5f, Vector3.one, skaala);
    }
}
