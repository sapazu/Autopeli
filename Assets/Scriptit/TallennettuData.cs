using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TallennettuData : MonoBehaviour
{
    public static GameObject valittuAuto;
    public static GameObject valittuKenttä;

    public void ValitseAuto(GameObject _auto)
    {
        valittuAuto = _auto;
        Debug.Log(valittuAuto);
    }

    public void ValitseKenttä(GameObject _kenttä)
    {
        valittuKenttä = _kenttä;
        Debug.Log(valittuKenttä);
    }

    public void LataaPeliScene()
    {
        //Lataa peli-scene jos auto ja kenttä on valittu
        if(valittuAuto == null || valittuKenttä == null)
        {
            return;
        }
        SceneManager.LoadScene("PeliScene");
    }
}
