using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : Act
{
  

    // Start is called before the first frame update
    override public void PlayAct()
    {


        //플레이어 space 바 클릭 시 점프 1회
        if (Input.GetKeyDown(KeyCode.Space) && Player.planeState ==true)
        {
            P_rigidbody.AddForce(Vector3.up*200);

            audioSource.clip = jumpAudio;
            PlaySound();
            Player.planeState = false;

        }
        




    }

}
