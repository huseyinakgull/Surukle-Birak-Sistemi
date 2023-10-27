using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EtkinlikKontrol : MonoBehaviour
{
    public Button Ilerle_Butonu;
    public static bool btndurum = false;
    public static bool vidadurum = false;
    public static bool civatadurum = false;
    public static bool pimdurum = false;
    public static bool saplamadurum = false;

    void Update()
    {
     if(btndurum == true)
        {
            Ilerle_Butonu.gameObject.SetActive(true);
        }
        else
        {
            Ilerle_Butonu.gameObject.SetActive(false);
        }
    }
    public static bool ButonuAc(bool butondurum)
    {
        Debug.Log("Veri geldi. [BUTONUAC] -> " + butondurum);
        btndurum = butondurum;
        return btndurum;
    }
}
