using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump2D : Act
{
    override public void PlayAct()
    {


        //�÷��̾� space �� Ŭ�� �� ���� 1ȸ
        if (Input.GetKeyDown(KeyCode.Space) && Player2D.planeState == true)
        {
            P_rigidbody.AddForce(Vector3.up* 250);

            audioSource.clip = jumpAudio;
            PlaySound();
            Player2D.planeState = false;

        }





    }
}
