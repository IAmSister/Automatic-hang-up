using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    //NPC��ս��AI
    private BaseAI m_NormalAI = null;
    public BaseAI NormalAI
    {
        get { return m_NormalAI; }
        set
        {
            if (null != m_NormalAI)
            {
                m_NormalAI.Destroy();
            }

            m_NormalAI = value;
        }
    }
    //����AI
    private BaseAI m_JuQingAI = null;
    public BaseAI JuQingAI
    {
        get { return m_JuQingAI; }
        set
        {
            if (null != m_JuQingAI)
            {
                m_JuQingAI.Destroy();
            }

            m_JuQingAI = value;
        }
    }
    //NPCս��AI
    private BaseAI m_CombatAI = null;
    public BaseAI CombatAI
    {
        get { return m_CombatAI; }
        set
        {
            if (null != m_CombatAI)
            {
                m_CombatAI.Destroy();
            }

            m_CombatAI = value;
        }
    }

    //NPC����AI
    private BaseAI m_DeadAI = null;
    public BaseAI DeadAI
    {
        get { return m_DeadAI; }
        set
        {
            if (null != m_DeadAI)
            {
                m_DeadAI.Destroy();
            }

            m_DeadAI = value;
        }
    }

    //��ǰNPC״̬
    private BaseAI m_CurrentAIState = null;
    public BaseAI CurrentAIState
    {
        get { return m_CurrentAIState; }
        set { m_CurrentAIState = value; }
    }

    //���λ
    //private bool m_bAliveFlag = true;       //�Ƿ��������λ
    private bool m_bCombatFlag = false;     //�Ƿ�ս�����λ
    public bool CombatFlag
    {
        get { return m_bCombatFlag; }
        set { m_bCombatFlag = value; }
    }
    //private bool m_bRestFlag = false;       //�Ƿ����ڽ��и�λ����

    //���¼��
    private float m_fLastUpdateTime = 0.0f;
    public static float m_fUpdateInterval = 0.5f;   //ÿ��AI�ĸ��¼�����룩
    private Threat m_ThreadInfo;
    public Threat ThreadInfo
    {
        get { return m_ThreadInfo; }
        set { m_ThreadInfo = value; }
    }

    //��ʼ��AI Controller����
    void Awake()
    {
        //m_bAliveFlag = true;
        m_bCombatFlag = false;
        //m_bRestFlag = false;
        if (null == ThreadInfo)
        {
            ThreadInfo = new Threat();
        }
    }

    void FixedUpdate()
    {
        //�Ƿ�ﵽ���¼��
        if (Time.time - m_fLastUpdateTime >= m_fUpdateInterval)
        {
            m_fLastUpdateTime = Time.time;
        }
        else
        {
            return;
        }

        if (null == m_CurrentAIState)
        {
            m_CurrentAIState = m_NormalAI;
        }

        if (null != m_CurrentAIState)
        {
            m_CurrentAIState.UpdateAI();
        }
    }

    public void EnterCombat()
    {
      //�Զ�Ѱ·true
      //�л�AI״̬
        SwitchCurrentAI();
    }
    //�л�AI
    public void SwitchCurrentAI()
    {
        //��ǰ״̬��Ϊ�� ִ���ϸ�Ai�ͷŷ���
        //��ǰAI Ϊ������ai
        //����   //����Threat
        //ִ�г�ʼ����  ��ô�߿�OnActive ���� ����Ai


    }
    public void AddAIByStateType(BaseAI ai)
    {

    }

}
