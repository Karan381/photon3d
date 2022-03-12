using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using CodeMonkey.Utils;

public class Player : MonoBehaviourPunCallbacks
{

    [SerializeField]float horizontalSpeed = 1f;
    [SerializeField]float verticalSpeed = 1f;
    PhotonView view;
    
    

    private void Awake()
    {
      
    }

    // Start is called before the first frame update
    void Start()
    {
        if (!photonView.IsMine)
        {
           
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            ProcessMovement();
        }
    }

    private void ProcessMovement()
    {
      
        if(Input.GetKey(KeyCode.D))
        {
            transform.position = transform.position + new Vector3(horizontalSpeed, 0,0) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = transform.position + new Vector3(-horizontalSpeed, 0, 0) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position = transform.position + new Vector3(0, -verticalSpeed, 0) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position = transform.position + new Vector3(0, verticalSpeed , 0) * Time.deltaTime;
        }

    }

    


}
