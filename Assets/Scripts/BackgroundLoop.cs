using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 왼쪽 끝으로 이동한 배경을 오른쪽 끝으로 재배치하는 스크립트
public class BackgroundLoop : MonoBehaviour
{
    // 배경 가로 길이
    private float width;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // 가로 길이를 측정하는 처리
    private void Awake()
    {
        //base.Awake();
        //width = gameObject.GetRectSizeDelta().x;

        // BoxCollider2D 컴포넌트의 Size 필드의 x 값을 가로 길이로 사용
        BoxCollider2D backgroundCollider = GetComponent<BoxCollider2D>();   
        width = backgroundCollider.size.x;
    }


    // Update is called once per frame
    // 현재 위치가 원점에서 왼쪽으로 width이상 이동했을 때 위치를 재배치
    void Update()
    {
        // 현재 위치가 원점에서 왼쪽으로  width 이상 이동했을 때 위치를 재배치
        if(transform.position.x <= -width)
        {
            Reposition();
        }
    }

    // 위치를 재배치하는 메서드
    private void Reposition()
    {
        // 현재 위치에서 오른쪽으로 가로 길이 * 2 만큼 이동
        Vector3 offset = new Vector3(width * 2, 0f, 0f);
        transform.position = transform.position + offset; 
    }
}
