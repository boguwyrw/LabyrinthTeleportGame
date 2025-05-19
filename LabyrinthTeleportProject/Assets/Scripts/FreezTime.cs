using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezTime : PickUp
{
    [SerializeField] private int freezTime = 10;

    public override void Picked()
    {
        GameManager.Instance.FreezTime(freezTime);
        base.Picked();
    }
}
