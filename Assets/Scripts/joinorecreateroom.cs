using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class joinorecreateroom : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update

    [SerializeField] GameObject Findagain;
    [SerializeField] int RoomSize = 2;
    private void Start()
    {
        if (!PhotonNetwork.IsConnected)
        {
            PhotonNetwork.ConnectUsingSettings();
        }
    }
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        Debug.Log("we are connected to " + PhotonNetwork.CloudRegion + " server!");
        Findagain.SetActive(true);
    }
    public void QuickMatch()
    {
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.JoinRandomOrCreateRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Failed To Join Room");
        CreateRoom();
    }
    void CreateRoom()
    {
        Debug.Log("Creating Room Now");
        int randomRoomNumber = Random.Range(0, 1000);
        RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = (byte)RoomSize };
        PhotonNetwork.CreateRoom("Room" + randomRoomNumber, roomOps);
        Debug.Log(randomRoomNumber);
    }
    public override void OnJoinedRoom()
    {
        Debug.Log("Joined Room");
        StartGame();
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Failed To Create Room");
        CreateRoom();
    }

    void StartGame()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            Debug.Log("StartinGame");
            PhotonNetwork.LoadLevel(1);
        }
    }

    void SetName()
    {
        PhotonNetwork.NickName = PlayerPrefs.GetString("NickName"); 
    }
    // Update is called once per frame
   
}
