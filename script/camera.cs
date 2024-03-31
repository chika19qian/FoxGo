using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    //获取角色transform变量
    public Transform player;


    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3 (player.position.x,0,-10);
    }
}
