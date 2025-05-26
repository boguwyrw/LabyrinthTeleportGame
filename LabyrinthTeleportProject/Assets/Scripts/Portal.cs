using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] Portal otherPortal;
    [SerializeField] Material material;

    [SerializeField] private GameObject player;
    [SerializeField] private PortalTeleport portalTeleport;

    [SerializeField] private PortalCamera portalCamera;

    public Camera myCamera;

    public Transform renderSurface;
    public Transform portalCollider;

    private void Awake()
    {
        portalTeleport.player = player.transform;
        portalTeleport.receiver = otherPortal.portalCollider;

        renderSurface.GetComponent<Renderer>().material = Instantiate(material);
        if (myCamera.targetTexture != null)
        {
            myCamera.targetTexture.Release();
        }

        myCamera.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
    }

    private void Start()
    {
        renderSurface.GetComponent<Renderer>().material.mainTexture =
            otherPortal.GetComponent<Portal>().myCamera.targetTexture;
    }
}
