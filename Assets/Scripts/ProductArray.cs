using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ProductArray : MonoBehaviour
{
    public static ProductArray Instance { get; private set; }
    public GameObject Burger;
    public GameObject HotDog;
    public GameObject Cola;

    List<IProduct> m_Burgers = new List<IProduct>();
    List<IProduct> m_HotDogs = new List<IProduct>();
    List<IProduct> m_Cola = new List<IProduct>();


    private void Awake()
    {
        Instance = this;
    }

    public IProduct GetProduct<T>(Transform parent) where T : IProduct
    {
        IProduct product;
        if (typeof(T) == typeof(Burger))
        {
            product = Get<Burger>(m_Burgers, Burger);

        }
        else if (typeof(T) == typeof(Cola))
        {
            product = Get<Cola>(m_Cola, Cola);

        }
        else if (typeof(T) == typeof(HotDog))
        {
            
            product = Get<HotDog>(m_HotDogs, HotDog);

        }
        else
        {
            Debug.LogError("incorrect type");
            product = Get<HotDog>(m_HotDogs, HotDog);
        }

        product.Transform.SetParent(parent, false);
        product.Transform.localPosition = Vector3.zero;

        return product;
    }

    IProduct Get<T>(List<IProduct> products, GameObject prefab) where T : IProduct
    {
        var product = products.FirstOrDefault(x => !x.GameObject.activeSelf);
        if (product == null)
        {
            product = GameObject.Instantiate(prefab).GetComponent<T>();
            products.Add(product);
        }

        return product;
    }
}
