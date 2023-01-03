using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SGAutoFightBtn : MonoBehaviour
{
    public GameObject m_BtnAutoBegin;
    public GameObject m_BtnAutoStop;

    public static SGAutoFightBtn Instance;

    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        //时间绑定
        //ObjManager.Instance.MainPlayerOnLoad += UpdateAutoFightBtnState;
    }

    public void OnDestroy()
    {
        //ObjManager.Instance.MainPlayerOnLoad -= UpdateAutoFightBtnState;
    }
    // 直接调用自动战斗
    void OnDoAutoFightClick()
    {
        //找玩家
      
        //玩家进入战斗
       // mainPalyer.EnterAutoCombat();
        UpdateAutoFightBtnState();
    }
    public void UpdateAutoFightBtnState()
    {
        //自动寻路面板打开 
        //不显示自动寻路面板关闭
    
    }

    void OnDoAutoStopFightClick()
    {
        //判断玩家为不为空
        //玩家自动战斗
        //mainPalyer.LeveAutoCombat();
        UpdateAutoFightBtnState();
    }
}
