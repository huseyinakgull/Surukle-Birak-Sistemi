using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class surukle_birak_sistemi : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler // Sürükleme eklentileri, UnityEngine.EventSystem'den çekiyor.
{
    private RectTransform rectTransform; // kordinat
    private Image image; // resim
    public GameObject Yanlýþ_Yazýsý;
    public string Nesne_Ýsmi;
    public GameObject dogruCollider;
    public GameObject yanlisCollider;
    public GameObject yanlisCollider2;
    public GameObject yanlisCollider3;
    public int Yanlýþ_Gözükme_Süresi;
    private bool sürüklemeTamamlandý = false;

    public void OnBeginDrag(PointerEventData eventData)
    {
        sürüklemeTamamlandý = false; 
        image.color = new Color32(255, 255, 255, 170);
    }

    public void OnDrag(PointerEventData eventData) 
    {
        if (sürüklemeTamamlandý == false)
        {
            rectTransform.anchoredPosition += eventData.delta; // kordinatýnýn güncellenmesi
        }
        else
        {
            Debug.Log("Þu anda sürüklenemez.");
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (sürüklemeTamamlandý)
        {
            return;
        }
        image.color = new Color32(255, 255, 255, 255);
        bool dogruSürüklendi = IsPointerOverCollider(eventData, dogruCollider);
        bool yanlisSürüklendi = IsPointerOverCollider(eventData, yanlisCollider);
        bool yanlisSürüklendi2 = IsPointerOverCollider(eventData, yanlisCollider2);
        bool yanlisSürüklendi3 = IsPointerOverCollider(eventData, yanlisCollider3);
        if (dogruSürüklendi)
        {
            // image.color = new Color32(0, 255, 0, 255);
            Debug.Log("Doðru sürüklendi." + " " + "Nesne: " + Nesne_Ýsmi);
            if(Nesne_Ýsmi == "Cývata")
            {
                EtkinlikKontrol.civatadurum = true;
                Debug.Log("Civata Durumu: " + EtkinlikKontrol.civatadurum);
            }
            else if(Nesne_Ýsmi == "Vida")
            {
                EtkinlikKontrol.vidadurum = true;
                Debug.Log("Vida Durumu: " + EtkinlikKontrol.vidadurum);
            }
            else if(Nesne_Ýsmi == "Pim")
            {
                EtkinlikKontrol.pimdurum = true;
                Debug.Log("Pim Durumu: " + EtkinlikKontrol.pimdurum);
            }
            else if(Nesne_Ýsmi == "Saplama")
            {
                EtkinlikKontrol.saplamadurum = true;
                Debug.Log("Saplama Durumu: " + EtkinlikKontrol.saplamadurum);
            }
        }
        else if (yanlisSürüklendi)
        {
            // image.color = new Color32(255, 0, 0, 255);
            Debug.Log("Yanlýþ sürüklendi." + " " + "Nesne: " + Nesne_Ýsmi);
            // this.enabled = false;
        }
        else if (yanlisSürüklendi2)
        {
            // image.color = new Color32(255, 0, 0, 255);
            Debug.Log("Yanlýþ sürüklendi." + " " + "Nesne: " + Nesne_Ýsmi);
            // this.enabled = false;
        }
        else if (yanlisSürüklendi3)
        {
            // image.color = new Color32(255, 0, 0, 255);
            Debug.Log("Yanlýþ sürüklendi." + " " + "Nesne: " + Nesne_Ýsmi);
            // this.enabled = false;
        }
        sürüklemeTamamlandý = true;
    }
    public void KontrolEt()
    {
        if (EtkinlikKontrol.saplamadurum && EtkinlikKontrol.pimdurum && EtkinlikKontrol.vidadurum && EtkinlikKontrol.civatadurum == true)
        {
            EtkinlikKontrol.ButonuAc(true);
            Debug.Log("Butonu Ac True Gönderildi.");
        }
        else
        {
            Debug.Log("Henüz bütün nesneler düzgün yerleþtirilmemiþ.");
            StartCoroutine(YanlisYazi());
        }
    }
    private bool IsPointerOverCollider(PointerEventData eventData, GameObject colliderObject)
    {
        if (colliderObject == null)
        {
            return false;
        }

        RectTransform colliderTransform = colliderObject.GetComponent<RectTransform>();
        if (colliderTransform == null)
        {
            return false;
        }

        Vector3[] corners = new Vector3[4];
        colliderTransform.GetWorldCorners(corners);

        Vector2 pointerPosition = eventData.position;

        return RectTransformUtility.RectangleContainsScreenPoint(colliderTransform, pointerPosition);
    }
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();
    }

    IEnumerator YanlisYazi()
    {
        Yanlýþ_Yazýsý.gameObject.SetActive(true);
        yield return new WaitForSeconds(Yanlýþ_Gözükme_Süresi);
        Yanlýþ_Yazýsý.gameObject.SetActive(false);
    }
}