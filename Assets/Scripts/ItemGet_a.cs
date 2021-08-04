using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGet_a : MonoBehaviour
{
    // Start is called before the first frame update
    public bool a = true;
    private string playerTag = "Player";

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == playerTag)
        {
            a = true;
            Debug.Log("アイテムを取得した！");
            
        }
    }
}
