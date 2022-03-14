using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;
using System.Collections;

public class showin : MonoBehaviourPunCallbacks,IOnEventCallback
{

    [SerializeField] GameObject winPannel; 

   
    // Update is called once per frame
   
    private void OnEnable()
    {
        PhotonNetwork.AddCallbackTarget(this);
    }

    private void OnDisable()
    {
        PhotonNetwork.RemoveCallbackTarget(this);
    }

    IEnumerator leveroom()
    {
        // suspend execution for 5 seconds
        yield return new WaitForSeconds(2);
        PhotonNetwork.LeaveRoom();
    }

    public void OnEvent(EventData photonEvent)
    {
        if (photonEvent.Code == 1 && photonView.IsMine)
        {
            Instantiate(winPannel, transform.position, Quaternion.identity);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            StartCoroutine(leveroom());
        }
    }
}
