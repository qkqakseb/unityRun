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

        // ������ ������Ʈ�� ��ġ�� �����Ѵ�.
        Vector2 posOffset = Vector2.zero;

        float xPos = objPrefabSize.x * (scrollingObjCount - 1) * (-1) * 0.5f;
        float yPos = prefabYPos;

        for (int i = 0; i < scrollingObjCount; i++)
        {   
            scrollingPool[i].SetLocalPos(xPos, yPos, 0f);

            // ������ �������� �޾ƿͼ� x, y �����ǿ� ���ϴ� ����
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
        }       // loop: ������ ������Ʈ�� ���η� ���ʺ��� ���ʴ�� �����ϴ� ����
    }

    protected override void RepositionFirstobj()
    {
        base.RepositionFirstobj();

        // ��ũ�Ѹ� Ǯ�� ù��° ������Ʈ�� ���������� �������Ŵ� �ϴ� ����
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
        } // if : ��ũ�Ѹ� ������Ʈ�� ������ ������Ʈ�� ȭ�� â�� �������� Draw �Ǵ� ��
    }

    // ������ ������ �������� �����ϴ� �Լ�
    private Vector2 GetRandomPosOffset()
    {
        Vector2 offset = Vector2.zero;
        offset.x = Random.Range(50f, 300f);
        offset.y = Random.Range(10f, 50f);

        return offset;
    }//  GetRandomPosOffset()
}
