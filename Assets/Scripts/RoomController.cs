using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class RoomController : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    [SerializeField]
    int multiplayerSceneIndex;
    [SerializeField]
    public InputField IF;
    public override void OnEnable()
    {
        PhotonNetwork.AddCallbackTarget(this);
    }
    public override void OnDisable ()
    {
        PhotonNetwork.RemoveCallbackTarget(this);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined Room");
        StartGame();
    }

    void StartGame()
    {
        if(PhotonNetwork.IsMasterClient)
        {
            Debug.Log("StartinGame");
            PhotonNetwork.LoadLevel(multiplayerSceneIndex);       
        }
    }

    private void Start()
    {  
        IF.text = PlayerPrefs.GetString("NickName");
        IF.onEndEdit.AddListener(SetName);
    }

    void SetName(string s)
    {
        PhotonNetwork.NickName = s;
        PlayerPrefs.SetString("NickName", s); 
    }
}
