using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public static partial class Func
{
    // 특정 오브젝트이 자식 오브젝트를 서치해서 찾아주는 함수
    public static GameObject FindChildObj(this GameObject targetObj_, string objName_)
    {
        GameObject searchResult = default;
        GameObject searchTarget = default;
        for(int i = 0; i < targetObj_.transform.childCount; i++)
        {
            searchTarget = targetObj_.transform.GetChild(i).gameObject;
            if(searchTarget.name.Equals(objName_))
            {
                searchResult = searchTarget;
                return searchResult;
            }
            else
            {
                searchResult = FindChildObj(searchTarget, objName_);
            }
        } // loop
        
        return searchResult;
    }  // FindChildObj()

    // { LEGACY
    // // 특정 오브젝트의 하위에서 자식 오브젝트를 서치해서 찾아주는 함수
    // private static GameObject GetChildObj(this GameObject targetObj_, string objName_)
    // {
    //     GameObject searchResult = default;
    //     for(int i = 0; i < targetObj_.transform.childCount; i++)
    //     {
    //         if(targetObj_.transform.GetChild(i).gameObject.name.Equals(objName_))
    //         {
    //             searchResult = targetObj_.transform.GetChild(i).gameObject;
    //             return searchResult;
    //         }  // if: 타겟 오브젝트에서 이름이 같은 오브젝트를 찾아서 리턴
    //         else { continue;}
    //     }
    //     // 이름이 같은 오브젝트를 찾지 못한 경우 default 값을 리턴한다.
    //      return searchResult;
    // } // GetChildObj()
    // } LEGACY

    // 씬의 루트 오브젝트를 서치해서 찾아주는 함수
    public static GameObject GetRootObj(string objName_)
    {
         Scene activeScene_ = GetActiveScene();
         GameObject[] rootObjs_ = activeScene_.GetRootGameObjects();

         GameObject targetObj_ = default;
         foreach(GameObject rootObj in rootObjs_)
         {
            if(rootObj.name.Equals(objName_))
            {
                targetObj_ = rootObj;
                return targetObj_;
            }
            else { continue;}        
         }  // loop

         return targetObj_;
    } // GetRootObj()

    // RectTransform 에서 sizeDelta를 찾아서 리턴하는 함수
    public static Vector2 GetRectSizeDelta(this GameObject obj_)
    {
        return obj_.GetComponentMust<RectTransform>().sizeDelta;
    }

    // 현재 활성화 되어 있는 씬을 찾아주는 함수
    public static Scene GetActiveScene()
    {
        Scene activeScene_ = SceneManager.GetActiveScene();
        return activeScene_;
    } 
    
    // 오브젝트의 로컬 포지션을 변경하는 함수
    public static void SetLocalPos(this GameObject obj_, float x, float y, float z)
    {
        obj_.transform.localPosition = new Vector3(x, y, z);
    }

    // 트렌스폼을 사용해서 오브젝트를 움직이는 함수
    public static void Translate(this Transform transform_, Vector2 moveVector)
    {
        transform_.Translate(moveVector.x, moveVector.y, 0f);
    }

    // 컴포넌트 가져오는 함수
    public static T GetComponentMust<T>(this GameObject obj)
    {
        T component_ = obj.GetComponent<T>();
        bool isComponentValid = !component_.Equals(null);
            //((Component)(component_ as Component)).IsValid();

        Func.Assert(component_.IsValid<T>() != false, string.Format("{0}에서 {1}을(를) 찾을 수 없습니다.",
                    obj.name, component_.GetType().Name));

        return component_;
    }
}
