using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

abstract public class Plate : MonoBehaviour, IPointerClickHandler
{
    public IProduct Product;
    public OrderManager OrderManager;

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        if (Product != null && OrderManager.CompleteProduct(Product.TypeOfProduct))
        {
            Product.GameObject.SetActive(false);
            Product = null;
        }
    }

    abstract public void PutBread();

    abstract public void PutFilling();
}
