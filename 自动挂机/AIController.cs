using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    //NPC非战斗AI
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
    //剧情AI
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
    //NPC战斗AI
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

    //NPC死亡AI
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

    //当前NPC状态
    private BaseAI m_CurrentAIState = null;
    public BaseAI CurrentAIState
    {
        get { return m_CurrentAIState; }
        set { m_CurrentAIState = value; }
    }

    //标记位
    //private bool m_bAliveFlag = true;       //是否死亡标记位
    private bool m_bCombatFlag = false;     //是否战斗标记位
    public bool CombatFlag
    {
        get { return m_bCombatFlag; }
        set { m_bCombatFlag = value; }
    }
    //private bool m_bRestFlag = false;       //是否正在进行复位操作

    //更新间隔
    private float m_fLastUpdateTime = 0.0f;
    public static float m_fUpdateInterval = 0.5f;   //每次AI的更新间隔（秒）
    private Threat m_ThreadInfo;
    public Threat ThreadInfo
    {
        get { return m_ThreadInfo; }
        set { m_ThreadInfo = value; }
    }

    //初始化AI Controller操作
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
        //是否达到更新间隔
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
      //自动寻路true
      //切换AI状态
        SwitchCurrentAI();
    }
    //切换AI
    public void SwitchCurrentAI()
    {
        //当前状态不为空 执行上个Ai释放方法
        //当前AI 为传进来ai
        //不空   //重置Threat
        //执行初始方法  怎么走看OnActive 方法 激活Ai


    }
    public void AddAIByStateType(BaseAI ai)
    {

    }

}
