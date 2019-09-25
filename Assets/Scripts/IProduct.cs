using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public enum TypeOfProduct { Empty, Cola, Bread, Burger, HotDog}

public interface IProduct
{
    TypeOfProduct TypeOfProduct { get; set; }
    GameObject GameObject { get; }
    Transform Transform { get; }

    void ChangeType(TypeOfProduct type);
}

