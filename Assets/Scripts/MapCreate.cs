using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreate : MonoBehaviour
{
    [SerializeField] List<GameObject> maps;
    [SerializeField] float moveSpeed = 0.1f;

    List<GameObject> mapsObj = new List<GameObject>();
    Map map;

    private void Start()
    {
        StartCreate();
    }


    // 最初のマップを生成する
    public void StartCreate()
    {
        mapsObj.Add(Instantiate(maps[0]));
        mapsObj.Add(Instantiate(maps[1], new Vector2(16, 0), Quaternion.identity));
        mapsObj.Add(Instantiate(maps[2], new Vector2(32, 0), Quaternion.identity));

        foreach (var item in mapsObj)
        {
            item.AddComponent<Map>();
            map = item.GetComponent<Map>();
            map.MapCreate = this;
            map.MoveSpeed = moveSpeed;
        }
    }

    /// <summary>
    /// 足場を生成する
    /// </summary>
    public void CreateScaffold()
    {
        int createLevel = 32;
        Vector2 mapsHeight = new Vector2(createLevel, 0);

        int num = Random.Range(0, mapsObj.Count);
        mapsObj.Add(Instantiate(maps[num], mapsHeight, Quaternion.identity)) ;
        mapsObj[mapsObj.Count - 1].AddComponent<Map>();
        map = mapsObj[mapsObj.Count - 1].GetComponent<Map>();
        map.MapCreate = this;
        map.MoveSpeed = moveSpeed;

        DestroyScaffold();
    }

    /// <summary>
    /// レベルに応じて難易度を変える
    /// </summary>
    /// <param name="level">レベル</param>
    /// <returns></returns>
    int LevelRandom(int level)
    {
        int num = 0;
        switch (level)
        {
            case 0:
                num = Random.Range(0, 8);
                break;
            case 1:
                num = Random.Range(3, 12);
                break;
            case 2:
                num = Random.Range(10, 15);
                break;
            case 3:
                num = Random.Range(8, 15);
                break;
            case 4:
                num = Random.Range(15, 20);
                break;
            default:
                break;
        }
        return num;
    }

    /// <summary>
    /// 古いマップを破壊する
    /// </summary>
    public void DestroyScaffold()
    {
        Destroy(mapsObj[0]);
        mapsObj.RemoveAt(0);
    }
}
