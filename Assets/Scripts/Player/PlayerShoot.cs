using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    //���� ��ġ
    [SerializeField]
    Transform m_transform;
    //�Ѿ� ��� Ÿ�̹�
    bool shootBool= true;


    IEnumerator Shoot()
    {
        Vector3 tempPos = this.transform.position;
        tempPos.y = this.transform.position.y ;
        GameObject missile = ObjectPool.Instance.get(ObjectFlag.PlayerMissile, tempPos);
        Vector3 mTempPos = m_transform.position;
 
        mTempPos.y = 0.8f;
        mTempPos.x += 0.3f;
        missile.transform.LookAt(mTempPos);
        yield return new WaitForSeconds(1f);
        shootBool = true;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)&&shootBool)
        {
            shootBool = false;
            StartCoroutine(Shoot());
        }


    }
}
