using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;

public class Health : MonoBehaviourPunCallbacks, IPunObservable
{
    public int health = 100;
   public int HitPoints = 5;
    [SerializeField] private Image HealthBarImage;
    int numOfhealth;
    [SerializeField]
    Text win_Loose;
   
 
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
    private void Update()
    {
        numOfhealth = FindObjectsOfType<Health>().Length;

        if (numOfhealth == 1 && gameObject.GetComponent<Health>() != null)
        {
            win_Loose.text = "Win";
        }

    }

    public void takeDamage(int Damage)
    {
        if (health <= 0)
        {
            win_Loose.text = "Loose";
            gameObject.GetComponent<FirstPersonController>().enabled = false;
            gameObject.GetComponent<Gun>().enabled = false;
            gameObject.GetComponent<Health>().enabled = false;
        }
        else
        {
            health -= Damage;
            HealthBarImage.fillAmount = HealthBarImage.fillAmount - .24f;
        }
    }

}
