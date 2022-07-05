using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{

    
    GameObject player;

    private void Start()
    {
        player = GameObject.Find("PlayerDummy");
    }
    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.transform.position, this.transform.position) < 6)
        {
            this.transform.GetChild(0).gameObject.SetActive(true);


        }
        else
        {
            this.transform.GetChild(0).gameObject.SetActive(false);
        }
        
    }
}
