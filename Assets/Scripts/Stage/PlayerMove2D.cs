using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove2D : Act
{
    
    // ÁÂ¿ì ¿òÁ÷ÀÓ 
    override public void PlayAct()
    {

        if (StartStage.playerMoveB)
        {

            if (Input.GetAxisRaw("Horizontal") == -1)
            {

                P_transform.Translate(Vector3.right * 2 * Time.deltaTime);

                if (flips)
                {
                    P_transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = false;
                    flips = false;
                }

            }
            else if (Input.GetAxisRaw("Horizontal") == 1)
            {
                P_transform.Translate(Vector3.left * 2 * Time.deltaTime);

                if (!flips)
                {
                    P_transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = true;
                    flips = true;
                }

            }

            if (Input.GetAxisRaw("Vertical") == -1)
            {
                P_transform.Translate(Vector3.forward * 2 * Time.deltaTime);


            }
            else if (Input.GetAxisRaw("Vertical") == 1)
            {
                P_transform.Translate(Vector3.back * 2 * Time.deltaTime);
            }
        }
    }
}
