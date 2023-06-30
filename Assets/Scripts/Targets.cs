using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class Targets : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler,IDragHandler,IPointerMoveHandler
{
  
    Image img;
    public GameObject InfoPanel;
    public CardsInfo Info;
    public TMP_Text NameText;
    public TMP_Text FactText;
    // Start is called before the first frame update
    void Start()
    {
      
        img = (Image)GetComponent("Image");
       // Info = (CardsInfo)GetComponent("CardInfo");
    }

    // Update is called once per frame
    void Update()
    {
        OnHover();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        img.color = Color.red;
       
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        img.color = Color.white;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void DeactivateInfoPanel()
    {
        InfoPanel.SetActive(false);
    }

    public void OnPointerMove(PointerEventData eventData)
    {
        if (Input.GetMouseButtonDown(1))
        {
            InfoPanel.SetActive(true);
        }
    }
    public void OnHover()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            if (Input.GetMouseButtonDown(1))
            {
                InfoPanel.SetActive(true);

                NameText.text = Info.Name;
                FactText.text = Info.Facts;

            }
            Debug.Log("Its over UI elements");
        }
       
    }
}
