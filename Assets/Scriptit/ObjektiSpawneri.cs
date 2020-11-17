using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjektiSpawneri : MonoBehaviour
{
    Transform autonSijainti;    //Auton transform komponentti

    void Awake()
    {
        //Etsitään autonsijainti objekti, luodaan pelikenttä ja auto autonsijainti-objektin kohdalle
        Instantiate(TallennettuData.valittuKenttä, Vector3.zero, Quaternion.identity);
        autonSijainti = GameObject.Find("AutonSijainti").transform;
        Instantiate(TallennettuData.valittuAuto, autonSijainti.position, autonSijainti.rotation);
    }
}
