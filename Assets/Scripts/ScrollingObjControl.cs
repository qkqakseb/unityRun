using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObjControl : MonoBehaviour
{
    public string prefabName = default;
    public int scrollingObjCount = default;

    private GameObject objPrefab = default;
    private List<GameObject> scrollingPool = default;
    private Vector3 objPrefabsSize;

    // Start is called before the first frame update
    void Start()
    {
        objPrefab = gameObject.FindChildObj(prefabName);

        scrollingPool= new List<GameObject>();
        GameObject tempObj = default;
        objPrefabsSize = objPrefab.GetRectSizeDelta();
        
        if (scrollingPool.Count <= 0)
        {
            for (int i =0; i < scrollingObjCount; i++)
            {
                tempObj = Instantiate(objPrefab, objPrefab.transform.position,
                        objPrefab.transform.rotation, transform);

                scrollingPool.Add(tempObj);
                tempObj = default;
            }  // loop : ��ũũ�Ѹ� ������Ʈ�� �־��� ����ũŭ �ʱ�ȭ �ϴ� ����
        }// if: scrolling pool �� �ʱ�ȭ �Ѵ�.

        objPrefab.SetActive(false);

        // ������ ������Ʈ�� ��ġ�� �����Ѵ�.
        float horizonPos = objPrefabsSize.x * scrollingObjCount * (-1) * 0.5f; 
        for (int i= 0; i < scrollingObjCount; i++)
        {
            scrollingPool[i].SetLocalPos(horizonPos, 0f, 0f);
            Func.Log($"Horizon position : {horizonPos}");
            horizonPos = horizonPos + objPrefabsSize.x;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
