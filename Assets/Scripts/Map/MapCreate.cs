using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreate : MonoBehaviour
{
    [SerializeField] List<GameObject> maps;
    public List<GameObject> Maps { set { maps = value; } get { return maps; } }
    [SerializeField] GameObject goalMap;
    [SerializeField] float moveSpeed = 0.1f;
    [SerializeField] int goalPoint = 10;
    [SerializeField] GameObject backGround;
    [SerializeField] Goal goal;

    List<GameObject> mapsObj = new List<GameObject>();
    Map map;
    int count;
    private void Start()
    {
        StartCreate();
        Instantiate(backGround, new Vector3(80, -35, 50), Quaternion.identity);
    }


    // 最初のマップを生成する
    public void StartCreate()
    {
        mapsObj.Add(Instantiate(maps[3], new Vector2(-15, 0), Quaternion.identity));
        mapsObj.Add(Instantiate(maps[0], new Vector2(1, 0), Quaternion.identity));
        mapsObj.Add(Instantiate(maps[1], new Vector2(17, 0), Quaternion.identity));
        mapsObj.Add(Instantiate(maps[2], new Vector2(33, 0), Quaternion.identity));

        foreach (var item in mapsObj)
        {
            item.AddComponent<Map>();
            map = item.GetComponent<Map>();
            map.MapCreate = this;
            map.MoveSpeed = moveSpeed;
        }
    }

    /// <summary>
    /// mapを生成する
    /// </summary>
    public void CreateScaffold()
    {
        int createLevel = 48;
        Vector2 mapsHeight = new Vector2(createLevel, 0);

        if (count < goalPoint)
        {
            int num = Random.Range(0, maps.Count);
            mapsObj.Add(Instantiate(maps[num], mapsHeight, Quaternion.identity));
            mapsObj[mapsObj.Count - 1].AddComponent<Map>();
            map = mapsObj[mapsObj.Count - 1].GetComponent<Map>();
            map.MapCreate = this;
            map.MoveSpeed = moveSpeed;
            count++;
            DestroyScaffold();
        }
        else if (count == goalPoint)
        {
            mapsObj.Add(Instantiate(goalMap, mapsHeight, Quaternion.identity));
            mapsObj[mapsObj.Count - 1].AddComponent<Map>();
            map = mapsObj[mapsObj.Count - 1].GetComponent<Map>();
            map.MapCreate = this;
            map.MoveSpeed = moveSpeed;
            count++;
        }
        else
        {
            if (count == goalPoint + 3)
            {
                goal.GoalPoint();
            }
            else
            {
                count++;
            }
        }

    }


    /// <summary>
    /// 古いマップを破壊する
    /// </summary>
    public void DestroyScaffold()
    {
        Destroy(mapsObj[0]);
        mapsObj.RemoveAt(0);
    }

    public void GameStopCall()
    {
        foreach (var item in mapsObj)
        {
            map = item.GetComponent<Map>();
            map.MapStopCall();
        }
    }
    public void GameStartCall()
    {
        foreach (var item in mapsObj)
        {
            map = item.GetComponent<Map>();
            map.MapStartCall();
        }
    }
}
