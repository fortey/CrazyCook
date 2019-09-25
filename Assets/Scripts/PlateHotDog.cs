using System.Collections;
using System.Collections.Generic;

public class PlateHotDog : Plate
{
    public override void PutBread()
    {
        Product = ProductArray.Instance.GetProduct<HotDog>(transform);
        Product.ChangeType(TypeOfProduct.Bread);
    }

    public override void PutFilling()
    {
        Product.ChangeType(TypeOfProduct.HotDog);
    }
}
