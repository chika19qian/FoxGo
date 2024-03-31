using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level_select : MonoBehaviour
{
    /*public Button[] levelButtons;


    // Start is called before the first frame update
    void Start()
    {
        //设定一个玩家参数，将int储存到这
        int level_reached=PlayerPrefs.GetInt("level_reached",1);
        for (int i = 0; i<levelButtons.Length; i++)
        {
            if(i>=level_reached)
            {
                levelButtons[i].interactable=false;
            }
        }
    }*/

    public void Select(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex+1);
    }

    
}
