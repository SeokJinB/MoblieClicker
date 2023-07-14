using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
#if UNITY_ANDROID
    void Update()
    {
        if(Input.touchCount>0)
        {
            Touch touch = Input.touches[0];
            TouchObjects(touch);
        }
    }

    private void TouchObjects(Touch touch)
    {
        Ray touchRay = Camera.main.ScreenPointToRay(touch.position);

        RaycastHit hit;
        int layerMask = ~0;

        if(Physics.Raycast(touchRay,out hit, Mathf.Infinity, layerMask, QueryTriggerInteraction.Ignore))
        {
            hit.transform.SendMessage("PlayerTouch", SendMessageOptions.DontRequireReceiver);
        }
    }
#endif
}
