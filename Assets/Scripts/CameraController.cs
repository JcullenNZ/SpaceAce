using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    
    void Start()
    {
              
        transform.position = new Vector3(player.transform.position.x,player.transform.position.y,-30);       
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -30);

        
    }

}
