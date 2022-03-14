using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;
using System.Collections.Generic;
using System.Collections;

public class Health : MonoBehaviourPunCallbacks, IPunObservable
{
    public int health = 100;
    [SerializeField] private Image HealthBarImage;
    public static byte eventcode = 1;
    [SerializeField] GameObject loosePannel;

  

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(health);
        }
        if(stream.IsReading)
        {
            health = (int)stream.ReceiveNext();
        }

    }
 
    public void takeDamage(int Damage)
    {
        if (health <= 0)
        {
            if (photonView.IsMine)
            {
                ExitGames.Client.Photon.SendOptions sendOptions = new ExitGames.Client.Photon.SendOptions { Reliability = true };
                RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.All };
                PhotonNetwork.RaiseEvent(eventcode, null, raiseEventOptions, sendOptions);
                Instantiate(loosePannel, transform.position, Quaternion.identity);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }      
                gameObject.SetActive(false);
        }
        else
        {
            health -= Damage;
            HealthBarImage.fillAmount = HealthBarImage.fillAmount - .24f;
        }
    }

   

}
