using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : PickUp
{
    [SerializeField] private bool addTime; // true - dodawaæ czas, false - odejmowaæ czas
    [SerializeField] private uint time = 5;

    public override void Picked()
    {
        if (addTime) // addTime == true
        {
            GameManager.Instance.AddRemoveTime((int)time);
        }
        else
        {
            GameManager.Instance.AddRemoveTime(-(int)time);
        }
        base.Picked();
    }
}
