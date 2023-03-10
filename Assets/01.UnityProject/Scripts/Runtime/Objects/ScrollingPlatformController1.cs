using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingPlatformController1 : ScrollingObjController
{
    private bool isStart = false;
   

    public override void Start()
    {
        base.Start();

        isStart = true;
        //prefabYPos = objPrefab.transform.localPosition.y;
    }

    public override void Update()
    {
        base.Update();
    }

    protected override void InitObjsPosition()
    {
        base.InitObjsPosition();

        // 생성한 오브젝트의 위치를 설정한다.
        Vector2 posOffset = Vector2.zero;

        float xPos = objPrefabSize.x * (scrollingObjCount - 1) * (-1) * 0.5f;
        float yPos = prefabYPos;

        for (int i = 0; i < scrollingObjCount; i++)
        {   
            scrollingPool[i].SetLocalPos(xPos, yPos, 0f);

            // 랜덤한 오프셋을 받아와서 x, y 포지션에 더하는 로직
            posOffset = GetRandomPosOffset();
            if (isStart == true)
            {
                xPos = xPos + objPrefabSize.x;
                isStart = false;
            }
            else
            {
                xPos = xPos + objPrefabSize.x + posOffset.x;
            }
            yPos = prefabYPos + posOffset.y;
        }       // loop: 생성한 오브젝트를 가로로 왼쪽부터 차례대로 정렬하는 루프
    }

    protected override void RepositionFirstobj()
    {
        base.RepositionFirstobj();

        // 스크롤링 풀의 첫번째 오브젝트를 마지막으로 리포지셔닝 하는 로직
        float lastScrObjCurrentXPos = scrollingPool[scrollingObjCount - 1].transform.localPosition.x;
        if (lastScrObjCurrentXPos <= objPrefabSize.x * 0.5f)
        {
            Vector2 posOffset = Vector2.zero;
            posOffset = GetRandomPosOffset();

            float lastScrObjInitXPos = Mathf.Floor(scrollingObjCount * 0.5f) * objPrefabSize.x + (objPrefabSize.x * 0.48f);

            scrollingPool[0].SetLocalPos(lastScrObjInitXPos + posOffset.x, prefabYPos + posOffset.y, 0f);
            scrollingPool.Add(scrollingPool[0]);
            scrollingPool.RemoveAt(0);

            // GFunc.Log($"List Pos : {scrollingPool[0].transform.localPosition}" + $"{scrollingPool[2].transform.localPosition}");
        } // if : 스크롤링 오브젝트의 마지막 오브젝트가 화면 창의 절반정도 Draw 되는 떄
    }

    // 랜덤한 포지션 오프셋을 리턴하는 함수
    private Vector2 GetRandomPosOffset()
    {
        Vector2 offset = Vector2.zero;
        offset.x = Random.Range(50f, 300f);
        offset.y = Random.Range(10f, 50f);

        return offset;
    }//  GetRandomPosOffset()
}
