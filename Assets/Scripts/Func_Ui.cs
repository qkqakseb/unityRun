using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public static partial class Func // Func 이라는 파일을 나누는 것이다.(partial)
{
    // 텍스트메쉬프로 형태의 컴포넌트의 텍스트를 설정하는 함수
   public static void SetTmpText(GameObject obj_, string text_)
   {
        TMP_Text tmpTxt = obj_.GetComponent<TMP_Text>();
        if(tmpTxt == null || tmpTxt == default(TMP_Text))
        {
            return;
        }  // if: 가져올 텍스트메쉬 컴포넌트가 없는 경우

        // 가져올 텍스트매쉬 컴포넌트가 존재하는 경우
        tmpTxt.text = text_;
   }  //SetTmpText()
}
