using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class menu : MonoBehaviour
{
   public GameObject pause_panel;
   public AudioMixer audiom;
   
   public void PlayGame()
   {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
   }

   public void QuitGame()
   {
       Application.Quit();
   }

   public void ReturnMenu()
   {
       SceneManager.LoadScene(0);
       Time.timeScale=1f;
   }

   public void UIEnable()
   {
       GameObject.Find("Canvas/Panel/UI").SetActive(true);
   }




   public void PauseGame()
   {
       pause_panel.SetActive(true);
       //游戏运算时间变成零，相当于停止
       Time.timeScale=0f;
   }
   public void ResumeGame()
   {
       pause_panel.SetActive(false);
       Time.timeScale=1f;
   }

   public void SetVolume(float value)
   {
       audiom.SetFloat("MainVolume",value);
   }
}
