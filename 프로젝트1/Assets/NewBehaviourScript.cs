using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : Photon.MonoBehaviour
{
    public Transform targetRotate;
    void Update()
    {
        if (photonView.isMine)
            transform.rotation = targetRotate.rotation;
    }
}
