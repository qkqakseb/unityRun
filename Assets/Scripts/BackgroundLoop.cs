using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� ������ �̵��� ����� ������ ������ ���ġ�ϴ� ��ũ��Ʈ
public class BackgroundLoop : MonoBehaviour
{
    // ��� ���� ����
    private float width;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // ���� ���̸� �����ϴ� ó��
    private void Awake()
    {
        //base.Awake();
        //width = gameObject.GetRectSizeDelta().x;

        // BoxCollider2D ������Ʈ�� Size �ʵ��� x ���� ���� ���̷� ���
        BoxCollider2D backgroundCollider = GetComponent<BoxCollider2D>();   
        width = backgroundCollider.size.x;
    }


    // Update is called once per frame
    // ���� ��ġ�� �������� �������� width�̻� �̵����� �� ��ġ�� ���ġ
    void Update()
    {
        // ���� ��ġ�� �������� ��������  width �̻� �̵����� �� ��ġ�� ���ġ
        if(transform.position.x <= -width)
        {
            Reposition();
        }
    }

    // ��ġ�� ���ġ�ϴ� �޼���
    private void Reposition()
    {
        // ���� ��ġ���� ���������� ���� ���� * 2 ��ŭ �̵�
        Vector3 offset = new Vector3(width * 2, 0f, 0f);
        transform.position = transform.position + offset; 
    }
}
