using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;

public class GameController : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    public GameObject playerPrefab;
    [SerializeField]
 
    

    void Start()
    {
        CreatePlayer();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;  
    }

    public void Quit()
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        PhotonNetwork.LoadLevel(0);
    }

    // Update is called once per frame
    void CreatePlayer()
    {
        Debug.Log("Creating Player");  
        PhotonNetwork.Instantiate(playerPrefab.name,new Vector3 (0,5,0), Quaternion.identity); 
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Quit();
        }
    }

  
}
