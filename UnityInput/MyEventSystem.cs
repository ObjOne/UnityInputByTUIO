using UnityEngine;
using UnityEngine.EventSystems;


[RequireComponent(typeof(UnityInput))]
[RequireComponent(typeof(WM_Input))]
[RequireComponent(typeof(MouseInput))]
[RequireComponent(typeof(TuioInput))]
[RequireComponent(typeof(StandaloneInputModule))]
public class MyEventSystem : EventSystem
{
    /// <summary>
    /// 是否在编辑器模式下设置为程序失去焦点也可以调用UGUI事件
    /// </summary>
    public bool UsingEventSystemOnNoFocus = true;
    protected override void OnApplicationFocus(bool hasFocus)
    {
#if UNITY_EDITOR
        if(UsingEventSystemOnNoFocus)
            hasFocus = true;
#endif
        base.OnApplicationFocus(hasFocus);
    }
}
