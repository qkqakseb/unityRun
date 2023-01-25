using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public static partial class Func
{
   // 게임을 종료하는 함수
   public static void  QuitThisGame()
   {
    #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
    #else
                Application.Quit();
    #endif
   }

   // public static void Nanju12Func(this GameObject obj_)
   // {
   //    Debug.Log("이것은 내가 만든 함수가 분명하다");
   // }

   // 다른 씬을 로드하는 경우
   public static void LoadScene(string sceneName_)
   {
      SceneManager.LoadScene(sceneName_);
   }  // LoadScene
}
