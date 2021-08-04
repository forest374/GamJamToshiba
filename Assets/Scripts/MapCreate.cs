using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreate : MonoBehaviour
{
    [SerializeField] List<GameObject> maps;

    [System.NonSerialized] public List<GameObject> mapsObj = new List<GameObject>();

    int count = 2;
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
    }

    /// <summary>
    /// 足場を生成する
    /// </summary>
    public void CreateScaffold(int level)
    {
        count++;
        int createLevel = count * 16;
        Vector2 mapsHeight = new Vector2(createLevel, 0);

        //int num = LevelRandom(level);
        int num = Random.Range(0, mapsObj.Count);
        mapsObj.Add(Instantiate(maps[num], mapsHeight, Quaternion.identity)) ;

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
