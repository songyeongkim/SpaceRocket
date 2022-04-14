using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject star;
    public GameObject enemy;
    public GameObject player;
    public GameObject starGroup;
    public GameObject enemyGroup;
    public Transform goalPos;
    public float posXRange;
    public float posYRange;
    public float posZDistance;
    List<float> objPosData;
    public int objDensity;
    int objNum;
    float starTime;

    private void Start()
    {
        objPosData = new List<float>();
        SetObjectsPos();
        objNum = 0;
        starTime = 2f;
    }

    void FixedUpdate()
    {
        if(starTime > Time.time)
        {
            CreateStars();
            starTime = Time.time + 2f; //Invoke 대신 실행
        }

        if(player.transform.position.z > objPosData[objNum] && objPosData.Count-1 > objNum)
        {
            objNum++;
            CreateObjects(objNum + 2);
        }
    }


    void CreateStars()
    {
        GameObject Ranobj = StarPool.GetGameObject();
        Ranobj.transform.parent = starGroup.transform;
        SetRanPos(Ranobj,20);
    }

    void CreateObjects(int maxNum)
    {
        int objRanNum = Random.Range(4, maxNum);

        for(int i=0;i<objRanNum;i++)
        {
            GameObject Ranobj = ObjectPool.GetGameObject();
            Ranobj.transform.parent = enemyGroup.transform;
            SetRanPos(Ranobj,posZDistance);
        }
    }

    void SetRanPos(GameObject obj, float zDistance)
    {
        Vector3 playerPos = player.transform.position;

        float posX = Random.Range(player.transform.position.x - posXRange, player.transform.position.x + posXRange);
        float posY = Random.Range(player.transform.position.y - posXRange, player.transform.position.y + posXRange);
        zDistance = zDistance + Random.Range(0,100);
        float posZ = player.transform.position.z + zDistance;

        obj.transform.position = new Vector3(posX, posY, posZ);
    }

    //일정 간격의 거리를 만들고 플레이어가 그 거리에 도달 시 오브젝트 생성
    void SetObjectsPos()
    {
        float objDistance = goalPos.position.z/objDensity;
        for(int i = 0; i < objDensity; i++)
        {
            objPosData.Add(objDistance * i);
        }
    }

}
