using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectFlag
{
    MonsterBomb,
    MonsterBombEffect,
    PlayerMissile,
    PlayerMissileEffect,


}
public class ObjectPool : MonoBehaviour
{

    //�̱���
    public static ObjectPool Instance;
    //������Ʈ ����
    public int[] initCount;

    // ������Ʈ ������
    [SerializeField]
    GameObject[] cpyObject;

    //������Ʈ ����Ʈ
    public List<Queue<GameObject>> queList = new List<Queue<GameObject>>();




    private void init(int count, GameObject gb, int flag)
    {

        for (int i = 0; i < count; i++)
        {

            GameObject tempGB = GameObject.Instantiate(gb, this.transform);
            tempGB.gameObject.SetActive(false);
            queList[flag].Enqueue(tempGB);
        }

    }

    public GameObject get(ObjectFlag flag, Vector3 pos)
    {
        GameObject tempGB;
        int index = (int)flag;


        if (queList[index].Count > 0)
        {

            tempGB = queList[index].Dequeue();

            tempGB.transform.SetParent(null);
            tempGB.SetActive(true);

        }
        else
        {
            tempGB = GameObject.Instantiate(cpyObject[index], this.transform);
            tempGB.transform.SetParent(null);

        }
        tempGB.transform.position = pos;

      
        return tempGB;

    }


    public void Set(GameObject gb, ObjectFlag flag)
    {
        int index = (int)flag;
        gb.gameObject.SetActive(false);
        gb.transform.SetParent(this.transform);
        queList[index].Enqueue(gb);

    }

    void Awake()
    {
        Instance = this;

        for (int i = 0; i < cpyObject.Length; i++)
        {
            queList.Add(new Queue<GameObject>());

            init(initCount[i], cpyObject[i], i);
        }

    }

}
