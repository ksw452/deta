using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : Act
{

    // 상하좌우 움직임 
    override public void PlayAct()
    {

        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            P_transform.Translate(Vector3.right * Time.deltaTime);

            if (flips)
            {
                P_transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = false;
                flips = false;
            }

        }
        else if (Input.GetAxisRaw("Horizontal") == 1)
        {
           P_transform.Translate(Vector3.left * Time.deltaTime);

            if (!flips)
            {
               P_transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = true;
                flips = true;
            }

        }


        if (Input.GetAxisRaw("Vertical") == -1)
        {
            P_transform.Translate(Vector3.forward * Time.deltaTime);


        }
        else if (Input.GetAxisRaw("Vertical") == 1)
        {
            P_transform.Translate(Vector3.back * Time.deltaTime);
        }


    }

}
