using UnityEngine;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// 网路管理
/// </summary>
public class NetManager : MonoBehaviour {
    //单例
    private static NetManager mInstance;

    public static NetManager Instance
    {
        get
        {
            return mInstance;
        }
    }

    //本地玩家
    private Communication com;

    private int reConnectTime;
    public void ReConnect()
    {
        if (!com.ReConnect())
        {
            reConnectTime++;
            Debug.Log("reConnectTime:" + reConnectTime);
            Invoke("ReConnect", 1f);
        }
    }


    #region U3D 

    void Awake() {
        mInstance = this;
    }

    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(this.gameObject);
        NetManager.Instance.InitNet();
    }

    public bool InitNet() {
        com = new Communication();
        if (com.Init())
        {
            return true;
        }
        return false;
    }

	// Update is called once per frame
	void Update () {

    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(10,20,100,30),"Login")) {
            Communication.SendMessage("LOGIN", "User is Pig");
        }
        if (GUI.Button(new Rect(10, 60, 100, 30), "Echo"))
        {
            Communication.SendMessage("ECHO", "ECHO is Send");
        }
    }

    void OnDestroy() {     
        mInstance = null;
    }

    //程序退出，关闭网络
    void OnApplicationQuit()
    {
        if (com != null)
        {
            if (Communication.IsConnect)
            {
                com.Close();
            } 
        }
        Application.Quit();
    }

    #endregion
}
