using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class surukle_birak_sistemi : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler // S�r�kleme eklentileri, UnityEngine.EventSystem'den �ekiyor.
{
    private RectTransform rectTransform; // kordinat
    private Image image; // resim
    public GameObject Yanl��_Yaz�s�;
    public string Nesne_�smi;
    public GameObject dogruCollider;
    public GameObject yanlisCollider;
    public GameObject yanlisCollider2;
    public GameObject yanlisCollider3;
    public int Yanl��_G�z�kme_S�resi;
    private bool s�r�klemeTamamland� = false;

    public void OnBeginDrag(PointerEventData eventData)
    {
        s�r�klemeTamamland� = false; 
        image.color = new Color32(255, 255, 255, 170);
    }

    public void OnDrag(PointerEventData eventData) 
    {
        if (s�r�klemeTamamland� == false)
        {
            rectTransform.anchoredPosition += eventData.delta; // kordinat�n�n g�ncellenmesi
        }
        else
        {
            Debug.Log("�u anda s�r�klenemez.");
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (s�r�klemeTamamland�)
        {
            return;
        }
        image.color = new Color32(255, 255, 255, 255);
        bool dogruS�r�klendi = IsPointerOverCollider(eventData, dogruCollider);
        bool yanlisS�r�klendi = IsPointerOverCollider(eventData, yanlisCollider);
        bool yanlisS�r�klendi2 = IsPointerOverCollider(eventData, yanlisCollider2);
        bool yanlisS�r�klendi3 = IsPointerOverCollider(eventData, yanlisCollider3);
        if (dogruS�r�klendi)
        {
            // image.color = new Color32(0, 255, 0, 255);
            Debug.Log("Do�ru s�r�klendi." + " " + "Nesne: " + Nesne_�smi);
            if(Nesne_�smi == "C�vata")
            {
                EtkinlikKontrol.civatadurum = true;
                Debug.Log("Civata Durumu: " + EtkinlikKontrol.civatadurum);
            }
            else if(Nesne_�smi == "Vida")
            {
                EtkinlikKontrol.vidadurum = true;
                Debug.Log("Vida Durumu: " + EtkinlikKontrol.vidadurum);
            }
            else if(Nesne_�smi == "Pim")
            {
                EtkinlikKontrol.pimdurum = true;
                Debug.Log("Pim Durumu: " + EtkinlikKontrol.pimdurum);
            }
            else if(Nesne_�smi == "Saplama")
            {
                EtkinlikKontrol.saplamadurum = true;
                Debug.Log("Saplama Durumu: " + EtkinlikKontrol.saplamadurum);
            }
        }
        else if (yanlisS�r�klendi)
        {
            // image.color = new Color32(255, 0, 0, 255);
            Debug.Log("Yanl�� s�r�klendi." + " " + "Nesne: " + Nesne_�smi);
            // this.enabled = false;
        }
        else if (yanlisS�r�klendi2)
        {
            // image.color = new Color32(255, 0, 0, 255);
            Debug.Log("Yanl�� s�r�klendi." + " " + "Nesne: " + Nesne_�smi);
            // this.enabled = false;
        }
        else if (yanlisS�r�klendi3)
        {
            // image.color = new Color32(255, 0, 0, 255);
            Debug.Log("Yanl�� s�r�klendi." + " " + "Nesne: " + Nesne_�smi);
            // this.enabled = false;
        }
        s�r�klemeTamamland� = true;
    }
    public void KontrolEt()
    {
        if (EtkinlikKontrol.saplamadurum && EtkinlikKontrol.pimdurum && EtkinlikKontrol.vidadurum && EtkinlikKontrol.civatadurum == true)
        {
            EtkinlikKontrol.ButonuAc(true);
            Debug.Log("Butonu Ac True G�nderildi.");
        }
        else
        {
            Debug.Log("Hen�z b�t�n nesneler d�zg�n yerle�tirilmemi�.");
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
        Yanl��_Yaz�s�.gameObject.SetActive(true);
        yield return new WaitForSeconds(Yanl��_G�z�kme_S�resi);
        Yanl��_Yaz�s�.gameObject.SetActive(false);
    }
}