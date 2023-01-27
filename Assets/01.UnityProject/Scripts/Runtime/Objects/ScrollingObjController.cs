using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObjController : MonoBehaviour
{
    public string prefabName = default;
    public int scrollingObjCount = default;

    public float scrollingSpeed = default;

    private GameObject objPrefab = default;
    protected Vector2 objPrefabSize = default;
    protected List<GameObject> scrollingPool = default;

    private float lastScrObjInitXPos = default;

    // Start is called before the first frame update
    public virtual void Start()
    {
        objPrefab = gameObject.FindChildObj(prefabName);
        scrollingPool = new List<GameObject>();
        GFunc.Assert(objPrefab != null || objPrefab != default);

        objPrefabSize = objPrefab.GetRectSizeDelta();

        // { ��ũ�Ѹ� Ǯ�� �����ؼ� �־��� ����ŭ �ʱ�ȭ
        GameObject tempObj = default;
        if(scrollingPool.Count <= 0)
        {
            for (int i = 0; i < scrollingObjCount; i++)
            {
                tempObj = Instantiate(objPrefab,
                    objPrefab.transform.position,
                    objPrefab.transform.rotation, transform);

                scrollingPool.Add(tempObj);
                tempObj = default;
            }       // loop: ��ũ�Ѹ� ������Ʈ�� �־��� ����ŭ �ʱ�ȭ �ϴ� ����
        }       // if: scrolling pool�� �ʱ�ȭ �Ѵ�.

        objPrefab.SetActive(false);
        // } ��ũ�Ѹ� Ǯ�� �����ؼ� �־��� ����ŭ �ʱ�ȭ

        // { ������ ������Ʈ�� ��ġ�� �����Ѵ�.
        InitObjsPosition();

        // } ������ ������Ʈ�� ��ġ�� �����Ѵ�.
    }       // Start()

    // Update is called once per frame
    public virtual void Update()
    {
        if (scrollingPool == default || scrollingPool.Count <= 0)
        {
            return;
        } // if : ��ũ�Ѹ� �� ������Ʈ�� �������� �ʴ� ���

        if (GameManager.instance.isGameOver == false)
        {


            // { ��濡 �������� �ִ� ����
            // ��ũ�Ѹ� �� ������Ʈ�� �����ϴ� ���
            for (int i = 0; i < scrollingObjCount; i++)
            {
                scrollingPool[i].AddLoclPos(scrollingSpeed * Time.deltaTime * (-1), 0f, 0f);
            } // loop: ����� �������� �����̰� �ϴ� ����

            // ��ũ�Ѹ� ���� ù��° ������Ʈ�� ���������� �������Ŵ� �ϴ� ���� 
            RepositionFirstobj();
            // { ��濡 �������� �ִ� ����
        } // if: ������ �������� ���

    } // Update()


    // ������ ������Ʈ�� ��ġ�� �����ϴ� �Լ�
    protected virtual void InitObjsPosition()
    {
        /*Do Someting*/
    }

    // ��ũ�Ѹ� ���� ù��° ������Ʈ�� ���������� �������Ŵ� �ϴ� �Լ�
    protected virtual void RepositionFirstobj()
    {
        /*Do Someting*/
    }
}
