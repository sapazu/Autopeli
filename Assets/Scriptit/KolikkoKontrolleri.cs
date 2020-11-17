using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KolikkoKontrolleri : MonoBehaviour
{
    public Vector3 pyoriminen;  //Pyörimisnopeus

    void Update()
    {
        //Pyöritetään kolikkoa
        transform.Rotate(pyoriminen * Time.deltaTime, Space.World);
    }

    void OnTriggerEnter(Collider _pelaaja)
    {
        //Jos kolikko osuu pelaajaan, kolikko tuhotaan ja kerättyjen kolikoiden arvoon lisätään +1
        if (_pelaaja.CompareTag("Pelaaja"))
        {
            GameObject.Find("PeliManageri").GetComponent<Kayttoliittyma>().keratytKolikot += 1;
            GameObject.Find("PeliManageri").GetComponent<Kayttoliittyma>().skaala = 0;
            Destroy(gameObject);
        }
    }
}
