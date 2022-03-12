using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;

public class Health : MonoBehaviourPunCallbacks, IPunObservable
{
    public int health = 100;
    [SerializeField] private Image HealthBarImage;
    [SerializeField] GameObject tempObject;
    [SerializeField] GameObject gameoverscreen;
    


   
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
                Instantiate(gameoverscreen, transform.position, Quaternion.identity);
            }
            Instantiate(tempObject, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }
        else
        {
            health -= Damage;
            HealthBarImage.fillAmount = HealthBarImage.fillAmount - .24f;
        }
    }

}
