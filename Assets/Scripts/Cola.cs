using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cola : MonoBehaviour, IProduct, IPointerClickHandler
{
    public ProgressBar GreenProgress;
    public GameObject Empty;
    public GameObject Full;
    public OrderManager OrderManager;
    public float CookingTime = 5f;

    public TypeOfProduct TypeOfProduct { get; set; }
    public GameObject GameObject => gameObject;
    public Transform Transform => transform;

    void Start()
    {
        if (OrderManager)
            OrderManager.OnStart += OnStart;
    }
    public void StartCooking()
    {
        TypeOfProduct = TypeOfProduct.Empty;
        Empty.SetActive(true);
        Full.SetActive(false);
        GreenProgress.StartTimer(CookingTime, CompleteCooking);
    }

    void CompleteCooking()
    {
        TypeOfProduct = TypeOfProduct.Cola;
        Empty.SetActive(false);
        Full.SetActive(true);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (TypeOfProduct == TypeOfProduct.Cola)
        {
            if (OrderManager.CompleteProduct(TypeOfProduct))
            {
                StartCooking();
            }
        }
    }

    void OnStart()
    {
        StartCooking();
    }

    public void ChangeType(TypeOfProduct type)
    {
        switch (type)
        {
            case TypeOfProduct.Empty:
                Empty.SetActive(true);
                Full.SetActive(false);
                break;
            case TypeOfProduct.Cola:
                Empty.SetActive(false);
                Full.SetActive(true);
                break;
        }
        TypeOfProduct = type;
        gameObject.SetActive(true);
    }
}
