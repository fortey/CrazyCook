using System.Collections;
using System.Collections.Generic;

public class PlateBurger : Plate
{
    public override void PutBread()
    {
        Product = ProductArray.Instance.GetProduct<Burger>(transform);
        Product.ChangeType(TypeOfProduct.Bread);
    }

    public override void PutFilling()
    {
        Product.ChangeType(TypeOfProduct.Burger);
    }
}
