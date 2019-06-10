using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : Photon.PunBehaviour
{
    Camera playerCam;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        playerCam = GetComponentInChildren<Camera>();

        if (!photonView.isMine)
        {
            playerCam.gameObject.SetActive(false);
        }
        if (photonView.isMine)
        {
            GetComponent<PhotonVoiceRecorder>().enabled = true;
        }
    }

}
