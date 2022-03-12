
using UnityEngine;
using Photon.Pun;


public class Gun : MonoBehaviourPunCallbacks
{
    public Transform gunTransform;
    public ParticleSystem bullet;
 
    void Update()
    {   
        if (photonView.IsMine)
        {
            if (Input.GetMouseButtonDown(0))
            {
                photonView.RPC("RPC_shoot", RpcTarget.All); 
            }
        }
    }

    [PunRPC]
    void RPC_shoot()
    {
        bullet.Play();
        Ray ray = new Ray(gunTransform.position, gunTransform.forward);
        if(Physics.Raycast(ray,out RaycastHit hit,100f))
        {
            var enemyHealth = hit.collider.GetComponent<Health>();
            if(enemyHealth)
            {
                enemyHealth.takeDamage(25);
            }
        }      
    }
}
