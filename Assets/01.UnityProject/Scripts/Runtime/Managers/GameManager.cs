using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = default;

    private const string UI_OBJS = "UiObjs";
    private const string SCORE_TEXT_OBJ = "ScoreText";
    private const string GAME_OVER_UI_OBJ = "GameoverUi";

    public bool isGameOver = false;
    private GameObject scoreTxObj = default;
    private GameObject gameOverUi = default;

    private int score = default;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            // Init
            isGameOver = false;
            GameObject uiobjs_ =  GFunc.GetRootObj(UI_OBJS);
            scoreTxObj = uiobjs_.FindChildObj(SCORE_TEXT_OBJ);
            gameOverUi = uiobjs_.FindChildObj(GAME_OVER_UI_OBJ);

            score = 0;

        } // if: 게임 메니저가 존재하지 않는 경우 변수에 할당 및 초기화
        else
        {
            GFunc.LogWarning("[system] GameManger : Duplicated object warning");
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver == true && Input.GetMouseButton(0))
        {
            GFunc.LoadScene(GFunc.GetActiveScene().name);
        }
    }

    // 점수를 증가시키는 메서드
    public void AddScore(int newScore)
    {
        if (isGameOver == true)
        {
            return;
        }
        // 게임이 진행중인 경우
            score += newScore;
            scoreTxObj.SetTmpText($"Score : {score}");
    } // AddScore()

    // 플레이어 사망시 게임오버를 출력하는 메서드
    public void OnPlayerDead()
    {
        isGameOver = true;
        gameOverUi.SetActive(true);
    } // OnPlayerDead()
}
