using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : PickUp
{
    private int point = 5;

    public override void Picked()
    {
        GameManager.Instance.AddPoints(point);
        base.Picked();
    }
}
