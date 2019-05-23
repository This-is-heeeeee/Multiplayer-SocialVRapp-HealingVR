using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyScript : Photon.MonoBehaviour
{
    
    Vector3 realPosition;
    Quaternion realRotation;
    
    void Start(){
        if(photonView.isMine)
            GetComponent<PhotonVoiceRecorder>().enabled = true;
    }
    // Update is called once per frame
    void Update()
    {
        if(photonView.isMine){
            //transform.rotation = GvrViewer.Instance.HeadPose.Orientation;

        }
        else{
            transform.position= Vector3.Lerp(transform.position,realPosition, .1f);
            transform.rotation= Quaternion.Lerp(transform.rotation, realRotation, .1f);
        }
    }
    /*
    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
        if (stream.isWriting) {
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
        }
        else {
                realPosition = (Vector3)stream.ReceiveNext(); 
                realRotation = (Quaternion)stream.ReceiveNext(); 
        }
    }*/
}
