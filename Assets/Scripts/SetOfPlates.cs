using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SetOfPlates : MonoBehaviour
{
    Plate[] m_Plates;

    private void Start()
    {
        m_Plates = GetComponentsInChildren<Plate>();
    }
    public void PutBread()
    {
        var plate = m_Plates.FirstOrDefault(x => x.Product == null);
        if (plate)
        {
            plate.PutBread();
        }
    }

    public bool PutFilling()
    {
        var plate = m_Plates.FirstOrDefault(x => x.Product != null && x.Product.TypeOfProduct == TypeOfProduct.Bread);
        if (plate)
        {
            plate.PutFilling();
        }
        return plate;
    }
}
