using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoSizeBoxCollider2D : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector2 objsize_ = default;
        BoxCollider2D boxCollider_ = gameObject.GetComponent<BoxCollider2D>();
        Image image_ = gameObject.GetComponent<Image>();
        RectTransform parentRectTransform_ = transform.parent.GetComponent<RectTransform>();    
        RectTransform rectTransform_ = gameObject.GetComponent<RectTransform>();

        objsize_.x = rectTransform_.sizeDelta.x;
        objsize_.y = rectTransform_.sizeDelta.x;

        boxCollider_.size = objsize_;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
 