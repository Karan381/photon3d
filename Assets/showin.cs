using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class showin : MonoBehaviour
{
    temp tempObj;
    [SerializeField] Text textF; 

   
    // Update is called once per frame
    void Update()
    {
        
       tempObj = FindObjectOfType<temp>();
        if (tempObj != null)
        {
            textF.text = "You Win";
        }
    }
}
