using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class leveroom : MonoBehaviourPunCallbacks
{
    private void Start()
    {
        StartCoroutine(leveroom_());
    }
    IEnumerator leveroom_()
    {
        // suspend execution for 5 seconds
        yield return new WaitForSeconds(2);
        PhotonNetwork.LeaveRoom();
    }
}
