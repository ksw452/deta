using System.Collections;
using System.Collections.Generic;
using UnityEngine;





//ĳ������ ���� Ȱ�� Ŭ����
public class Act 
{

    public LayerMask playerlm;
    public AudioSource audioSource;
    public AudioClip jumpAudio;
    // Start is called before the first frame update
    public bool collisionP = false;
    public bool flips = false;
    public Transform P_transform;
    public Transform M_transform;
    public Rigidbody P_rigidbody;




    virtual public void PlaySound()
    {
        // ĳ���� ����� ����
        audioSource.Play();

    }

    virtual public void PlayAct()
    {


    }
}
