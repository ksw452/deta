using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : Act
{

   


    override public void PlayAct()
    {
        //몬스터의 위치를 nav따라가게 만듦
        M_transform.position = P_transform.position;

        //플레이어와 접촉 시
        if (collisionP == true)
        {   //멈추기
            Nav.waitTime = true;
            //접촉해서 멈춘 경우
            Nav.collisionP = Nav.MonsterState.Attack;
            //초기화
            collisionP = false;
        
        }

        //플레이어 탐지
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
