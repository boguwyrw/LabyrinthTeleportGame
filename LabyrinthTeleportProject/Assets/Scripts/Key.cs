using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : PickUp
{
    [SerializeField] private KeyColor keyColor;

    public override void Picked()
    {
        GameManager.Instance.AddKey(keyColor);
        base.Picked();
    }
}
