using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : Act
{
  

    // Start is called before the first frame update
    override public void PlayAct()
    {


        //�÷��̾� space �� Ŭ�� �� ���� 1ȸ
        if (Input.GetKeyDown(KeyCode.Space) && Player.planeState ==true)
        {
            P_rigidbody.AddForce(Vector3.up*200);

            audioSource.clip = jumpAudio;
            PlaySound();
            Player.planeState = false;

        }
        




    }

}
