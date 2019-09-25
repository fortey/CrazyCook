using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotDog : MonoBehaviour, IProduct
{
    public TypeOfProduct TypeOfProduct { get; set; }
    public GameObject GameObject => gameObject;
    public Transform Transform => transform;
    public GameObject BreadBottom;
    public GameObject Sosige;
    public GameObject BreadTop;

    public void ChangeType(TypeOfProduct type)
    {
        switch (type)
        {
            case TypeOfProduct.Bread:
                BreadBottom.SetActive(true);
                Sosige.SetActive(false);
                BreadTop.SetActive(true);
                break;
            case TypeOfProduct.HotDog:
                BreadBottom.SetActive(true);
                Sosige.SetActive(true);
                BreadTop.SetActive(true);
                break;
        }
        TypeOfProduct = type;
        gameObject.SetActive(true);
    }
}
