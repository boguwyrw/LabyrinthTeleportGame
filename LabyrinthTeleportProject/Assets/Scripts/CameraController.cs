using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float mouseSensivity = 100f;

    private Transform playerBody;
    private float xRotation = 0f;
    
    void Start()
    {
        playerBody = transform.parent;
    }

    void Update()
    {
        
    }
}
