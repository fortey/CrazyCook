using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burger : MonoBehaviour, IProduct
{
    public TypeOfProduct TypeOfProduct { get; set; }
    public GameObject GameObject => gameObject;
    public Transform Transform => transform;
    public GameObject BreadBottom;
    public GameObject Meat;
    public GameObject BreadTop;

    public void ChangeType(TypeOfProduct type)
    {
        switch (type)
        {
            case TypeOfProduct.Bread:
                BreadBottom.SetActive(true);
                Meat.SetActive(false);
                BreadTop.SetActive(true);
                break;
            case TypeOfProduct.Burger:
                BreadBottom.SetActive(true);
                Meat.SetActive(true);
                BreadTop.SetActive(true);
                break;
        }
        TypeOfProduct = type;
        gameObject.SetActive(true);
    }

}
