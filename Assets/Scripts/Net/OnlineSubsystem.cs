using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

/// <summary>
/// 此类定义客户端需要实现的方法（虚）
/// </summary>
public class OnlineSubsystem
{
    //登录
    public static void SCLogin(string info) {
        Debug.Log("OnlineSubsystem SCLogin:"+ info);
    }

}

