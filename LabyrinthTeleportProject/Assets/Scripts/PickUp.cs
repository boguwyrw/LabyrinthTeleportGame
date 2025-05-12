using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private float rotationSpeed = 120f;

    public virtual void Picked()
    {
        Debug.Log("Pick up item");
        Destroy(gameObject);
    }

    private void Update()
    {
        RotationItem();
    }

    private void RotationItem()
    {
        transform.Rotate(new Vector3(0f, rotationSpeed * Time.deltaTime, 0f));
    }
}
