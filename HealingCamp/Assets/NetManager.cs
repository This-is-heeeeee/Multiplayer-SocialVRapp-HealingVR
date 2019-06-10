using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class NetManager : MonoBehaviour
{
    public GameObject avatarPrefab;
    //public Vector3 pos;
    SpawnSpot[] spawnSpots;

    public const string VERSION = "1.0";

    // Start is called before the first frame update
    void Start()
    {
        spawnSpots = FindObjectsOfType<SpawnSpot>();
        PhotonNetwork.ConnectUsingSettings(VERSION);
        var temp = PhotonVoiceNetwork.Client;
    }

    public virtual void OnConnectedToMaster()
    {
        Debug.Log("OnConnectedToMaster() was called by PUN. Now this client is connected and could join a room. Calling: PhotonNetwork.JoinRandomRoom();");
        PhotonNetwork.JoinRandomRoom();
    }

    public virtual void OnJoinedLobby()
    {
        Debug.Log("OnJoinedLobby(). This client is connected and does get a room-list, which gets stored as PhotonNetwork.GetRoomList(). This script now calls: PhotonNetwork.JoinRandomRoom();");
        PhotonNetwork.JoinRandomRoom();
    }

    public virtual void OnPhotonRandomJoinFailed()
    {
        Debug.Log("OnPhotonRandomJoinFailed() was called by PUN. No random room available, so we create one. Calling: PhotonNetwork.CreateRoom(null, new RoomOptions() {maxPlayers = 4}, null);");
        PhotonNetwork.CreateRoom(null, new RoomOptions() { MaxPlayers = 4 }, null);
    }

    // the following methods are implemented to give you some context. re-implement them as needed.

    public virtual void OnFailedToConnectToPhoton(DisconnectCause cause)
    {
        Debug.LogError("Cause: " + cause);
    }

    public void OnJoinedRoom()
    {
        //pos.x = (float)-1.77;
        //pos.y = (float)-4.75;
        //pos.z = (float)-10.31;
        /*pos.x = (float)27.19;
        pos.y = (float)4.6;
        pos.z = (float)-33.07; */
        SpawnSpot mySpawnSpot = spawnSpots[Random.Range(0, spawnSpots.Length)];
        Debug.Log("OnJoinedRoom() called by PUN. Now this client is in a room. From here on, your game would be running. For reference, all callbacks are listed in enum: PhotonNetworkingMessage");
        GameObject go = PhotonNetwork.Instantiate(avatarPrefab.name, mySpawnSpot.transform.position ,
             mySpawnSpot.transform.rotation, 0);
    }
}



