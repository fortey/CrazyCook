using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Order: MonoBehaviour
{
    public Image Progress;
    public float RestOfTime;
    public float TimeLimit = 18f;
    public float AdditionalTime = 6f;
    public List<IProduct> Products { get; set; } = new List<IProduct>();
    public Action OnEnd;

    float m_StartTime;
    public void Initiate(List<TypeOfProduct> types)
    {
        m_StartTime = Time.unscaledTime;
        foreach(var type in types)
        {
            IProduct product;
            switch (type)
            {
                case TypeOfProduct.Burger:
                    product = ProductArray.Instance.GetProduct<Burger>(transform);
                    break;
                case TypeOfProduct.HotDog:
                    product = ProductArray.Instance.GetProduct<HotDog>(transform);
                    break;
                case TypeOfProduct.Cola:
                    product = ProductArray.Instance.GetProduct<Cola>(transform);
                    break;
                default:
                    product = ProductArray.Instance.GetProduct<Burger>(transform);
                    break;
            }
            product.ChangeType(type);
            Products.Add(product);
        }
        transform.parent.gameObject.SetActive(true);
    }

    void Update()
    {
        RestOfTime = TimeLimit - (Time.unscaledTime - m_StartTime);
        Progress.fillAmount = RestOfTime / TimeLimit;
        if (RestOfTime <= 0) EndOrder();
    }

    public bool CompleteProduct(TypeOfProduct typeOfProduct)
    {
        var product = Products.FirstOrDefault(x => x.TypeOfProduct == typeOfProduct);
        if (product != null)
        {
            product.GameObject.SetActive(false);
            Products.Remove(product);
            if (Products.Count == 0)
            {
                EndOrder();
            }
            else
            {
                m_StartTime += Math.Min(AdditionalTime, Time.unscaledTime - m_StartTime);
            }
        }
        return product != null;
    }

    void EndOrder()
    {
        foreach(var product in Products)
        {
            product.GameObject.SetActive(false);
        }
        Products.Clear();
        transform.parent.gameObject.SetActive(false);
        OnEnd?.Invoke();
    }
}

