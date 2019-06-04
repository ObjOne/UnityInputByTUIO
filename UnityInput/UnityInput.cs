using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Touch = UnityEngine.Touch;
using System;
using System.Net;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

/// <summary>
/// Unity输入模块，整合了鼠标，TUIO，windows原生触摸，适用于windows平台
/// Unity Input类为UnityEngine核心类库,如须使用Input相关API且运行平台使用TUIO,触摸相关API请使用UnityInput.Input来获取
/// </summary>
[RequireComponent(typeof(MyEventSystem))]
[RequireComponent(typeof(WM_Input))]
[RequireComponent(typeof(MouseInput))]
[RequireComponent(typeof(TuioInput))]
[RequireComponent(typeof(StandaloneInputModule))]
public class UnityInput : BaseInput
{
    public static UnityInput Input { get; private set; }
    public MouseInput mMouseInput { get; private set; }
    public WM_Input mWMInput { get; private set; }
    public TuioInput mTuioInput { get; private set; }

    public List<Touch> touches = new List<Touch>();

    [Header("使用Tuio")]
    public bool IsUseTUIO = true;
    [Header("使用Windows原生触控")]
    public bool IsUseWM = true;
    [Header("使用鼠标")]
    public bool IsUseMouse = false;

    public bool IsShowLogOnGetTouchByIndex = true;
    private BaseInputModule mBaseInputModule;
    protected override void Start()
    {
        base.Start();
        Input = this;
        mBaseInputModule = GetComponent<BaseInputModule>();
        mBaseInputModule.inputOverride = this;
        mTuioInput = GetComponent<TuioInput>();
        mMouseInput = GetComponent<MouseInput>();
        mWMInput = GetComponent<WM_Input>();
    }


    /// <summary>
    /// Call in PreUpdate
    /// </summary>
    public void Update()
    {
        try
        {
            touches = new List<Touch>();
            if (IsUseTUIO)
            {
                touches.AddRange(TuioInput.touches);
            }
            if (IsUseWM)
                touches.AddRange(WM_Input.touches);
            if (IsUseMouse)
                touches.AddRange(MouseInput.touches);
        }
        catch (Exception ex)
        {
            Debug.LogWarning(ex.Message);
        }
    }

    public override Touch GetTouch(int index)
    {
        if (!IsShowLogOnGetTouchByIndex)
            Debug.Log("UnityInput Pointer Position:" + MiniJSON.Json.Serialize(touches[index].position));
        return touches[index];
    }

    public override int touchCount
    {
        get
        {
            return touches.Count;
        }
    }

    public override bool touchSupported
    {
        get
        {
            return true;
        }
    }

}
