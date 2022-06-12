using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : Act
{

   


    override public void PlayAct()
    {
        //������ ��ġ�� nav���󰡰� ����
        M_transform.position = P_transform.position;

        //�÷��̾�� ���� ��
        if (collisionP == true)
        {   //���߱�
            Nav.waitTime = true;
            //�����ؼ� ���� ���
            Nav.collisionP = Nav.MonsterState.Attack;
            //�ʱ�ȭ
            collisionP = false;
        
        }

        //�÷��̾� Ž��
        Collider[] playerPosC = Physics.OverlapSphere(M_transform.position, 5f, playerlm);

        if (playerPosC.Length > 0)
        { 
            Nav.detectPlayer = true;

        }
        else
        {

            Nav.detectPlayer = false;
        }

    }

    

}
