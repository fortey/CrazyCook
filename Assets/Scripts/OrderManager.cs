using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    public int OrderCount = 15;
    public int CountForWin;
    public int Score = 0;
    public float VisitorDelay = 3f;

    public event System.Action OnStart;
    public event System.Action OnReady;
    public event System.Action OnEnd;

    public Order[] VisitorOrders = new Order[4];

    public Queue<List<TypeOfProduct>> Orders { get; set; } = new Queue<List<TypeOfProduct>>();

    void Start()
    {
        CountForWin = 0;
        var types = new TypeOfProduct[] { TypeOfProduct.Cola, TypeOfProduct.Burger, TypeOfProduct.HotDog };
        
        for(var i = 0; i < OrderCount; i++)
        {
            var products = new List<TypeOfProduct>();
            Orders.Enqueue(products);
            var productsCount = UnityEngine.Random.Range(1, 4);
            for(var j =0; j<productsCount; j++)
            {
                products.Add(types[UnityEngine.Random.Range(0, types.Length)]);
                CountForWin += 1;
            }
        }

        CountForWin -= 2;
        OnReady?.Invoke();
    }

    public void Begin()
    {
        OnStart?.Invoke();

        for (var i = 0; i < VisitorOrders.Length; i++)
        {
            var order = VisitorOrders[i];
            StartCoroutine(AddVisitor(order, (i + 1) * VisitorDelay));

            void OnEnd()
            {
                if(Orders.Count == 0)
                    EndGame();
                else
                    StartCoroutine(AddVisitor(order, VisitorDelay));
            }
            order.OnEnd += OnEnd;
        }
    }

    public IEnumerator AddVisitor(Order order, float delay)
    {
        yield return new WaitForSeconds(delay);
        if (Orders.Count > 0)
        {
            order.Initiate(Orders.Dequeue());
        }
    }

    public bool CompleteProduct(TypeOfProduct typeOfProduct)
    {
        var orders = VisitorOrders.OrderBy(x => x.RestOfTime);
        foreach(var order in orders)
        {
            if (order.CompleteProduct(typeOfProduct))
            {
                Score++;
                return true;
            }
        }
        return false;
    }

    void EndGame()
    {
        if (VisitorOrders.Count(x => x.isActiveAndEnabled) == 0)
            OnEnd?.Invoke();
    }
}
