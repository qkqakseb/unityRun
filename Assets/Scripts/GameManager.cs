using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    private GameObject gameOverTxtObj = default;
    private GameObject timeTxtObj = default;  // 생존 시간을 표시할 텍스트
    private GameObject bestRecordTxtObj = default;  // 최고 기록을 표시할 텍스트

    private const string SCENE_NAME = "SampleScene";
    private const string BEST_TIME_RECORD = "BestTime";
    private float surviveTime = default;
    private bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        // 출력할 텍스트 오브젝트를 찾아온다
        GameObject uiObj_ = Func.GetRootObj("UiObjs");
        // if(uiObj_ == null || uiObj_ == default)
        // {
        //     Debug.Log("uiObj_  못찾았다.");
        // }
        // else
        // {
        //     Debug.Log("uiObj_  찾았다.");
        // }

        timeTxtObj = uiObj_.FindChildObj("TimeText");
        gameOverTxtObj = uiObj_.FindChildObj("GameOverText");
        bestRecordTxtObj = uiObj_.FindChildObj("BestTimeTxt");

        surviveTime = 0f;
        isGameOver = false;
        gameOverTxtObj.transform.localScale = new Vector3(0.001f, 0.001f, 0.001f);

        
        // if(uiObj_ == null || uiObj_ == default)
        // {
        //     Debug.Log("uiObj_  못찾았다.");
        // }
        // else
        // {
        //     Debug.Log("uiObj_  찾았다.");
        // }
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameOver == true)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                Func.LoadScene(SCENE_NAME);
            } // if : R 키 누른 경우 리스타트
            if(Input.GetKeyDown(KeyCode.Q))
            {
                Func.QuitThisGame();
            }
        }  // if : 게임 오버인 경우

        // 게임 오버가 아닌 경우

        // 생존시간을 갱신한다.
            surviveTime = surviveTime + Time.deltaTime;
            Func.SetTmpText(timeTxtObj, $"Time : {Mathf.FloorToInt(surviveTime)}");
          
            // timeTxt.gameObject
    }

    // 현재 게임을 게임오버 상태로 변경하는 메서드
    public void EndGame() 
    {
        isGameOver = true;
        // gameOverTxtObj.SetActive(true);
        gameOverTxtObj.transform.localScale = Vector3.one;

        // BestTime 키로 저장된 이전까지의 최고 기록 가져오기
        float bestTime = PlayerPrefs.GetFloat(BEST_TIME_RECORD);

        // 이전까지의 최고 기록보다 현재 생존 시간이 더 긴 경우
        if(bestTime < surviveTime)
        {
            //  플레이어 프리팹스에 베스트 타임을 갱신해서 저장한다.
            bestTime = surviveTime;
            PlayerPrefs.SetFloat(BEST_TIME_RECORD, bestTime);
        } // if : 현재 surviveTime이 bestTime 보다 큰 경우

        // 최고 기록을 텍스트에 갱신한다.
        Func.SetTmpText(bestRecordTxtObj, $"Best Time : {Mathf.FloorToInt(bestTime)}");
    }   // EndGame()
}
