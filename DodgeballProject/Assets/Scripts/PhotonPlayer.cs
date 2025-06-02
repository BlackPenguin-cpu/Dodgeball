using System;
using System.Security.Cryptography;
using UnityEngine;
using Photon.Pun;
using UnityEditor.Rendering;

public class PhotonPlayer : MonoBehaviourPun
{
    private PhotonView PV;

    private void Start()
    {
        PV = photonView;

        if (PV.IsMine) PV.RPC("Test", RpcTarget.All, "A");
    }

    [PunRPC]
    private void Test(string str1)
    {
        Debug.Log(str1);
    }

    private void FixedUpdate()
    {
        var hor = Input.GetAxisRaw("Horizontal");
        var ver = Input.GetAxisRaw("Vertical");
        
        transform.Translate(hor / 10, ver / 10, 0f);
    }
    
    
}