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
        //ʱ���
        //ObjManager.Instance.MainPlayerOnLoad += UpdateAutoFightBtnState;
    }

    public void OnDestroy()
    {
        //ObjManager.Instance.MainPlayerOnLoad -= UpdateAutoFightBtnState;
    }
    // ֱ�ӵ����Զ�ս��
    void OnDoAutoFightClick()
    {
        //�����
      
        //��ҽ���ս��
       // mainPalyer.EnterAutoCombat();
        UpdateAutoFightBtnState();
    }
    public void UpdateAutoFightBtnState()
    {
        //�Զ�Ѱ·���� 
        //����ʾ�Զ�Ѱ·���ر�
    
    }

    void OnDoAutoStopFightClick()
    {
        //�ж����Ϊ��Ϊ��
        //����Զ�ս��
        //mainPalyer.LeveAutoCombat();
        UpdateAutoFightBtnState();
    }
}
