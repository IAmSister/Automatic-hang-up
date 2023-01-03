
using UnityEngine;
using System.Collections;
using Games.GlobeDefine;
using Games.LogicObj;

namespace Games.AI_Logic
{
    public class AI_Patrol : BaseAI
    {
        public AI_Patrol()
        {
            m_AIType = CharacterDefine.AI_TYPE.AI_TYPE_PATROL;
            AIStateType = CharacterDefine.AI_STATE_TYPE.AI_STATE_NORMAL;

            m_patrolPoint = new PatrolPoint();
        }

        private int m_nCurrentPatrolIdx;
        public int CurrentPatrolIdx
        {
            get { return m_nCurrentPatrolIdx; }
            set { m_nCurrentPatrolIdx = value; }
        }

        //检测是否到达路点的距离
        public float m_fStopDistance = 1.0f;
        //到达路点后的停顿间隔
        public float m_fReachedStopTimeInterval = 2.0f;
        //上次停顿时间，心跳中检测
        private float m_fLastReachedStopTime = 0.0f;
        //是否处于停留状态
        private bool m_bIsReachedStop = false;

        //路点表格索引
        public int PatrolTableID = GlobeVar.INVALID_ID;

        //路点数据
        private PatrolPoint m_patrolPoint;
        public PatrolPoint patrolPoint
        {
            get { return m_patrolPoint; }
        }

        //走向某一个路点
        private int GotoPatrolPoint(int nPatrolIdx)
        {
            //越界判断
            if (nPatrolIdx < 0 || m_patrolPoint.ListPatrolPoint.Count <= nPatrolIdx)
            {
                return GlobeVar.INVALID_ID;
            }

            //检测是否是Obj类型
            Obj_Character obj = this.gameObject.GetComponent<Obj_Character>();
            if (obj)
            {
                m_nCurrentPatrolIdx = nPatrolIdx;
                Vector2 point2D = m_patrolPoint.ListPatrolPoint[nPatrolIdx];
                Vector3 dest = new Vector3(point2D.x, 0, point2D.y);
                obj.MoveTo(dest, null, m_fStopDistance);
                return nPatrolIdx;
            }

            return GlobeVar.INVALID_ID;
        }

        private int GotoNextPatrolPoint()
        {
            m_nCurrentPatrolIdx++;
            //到达上限，则回归第一个路点
            if (m_patrolPoint.ListPatrolPoint.Count == m_nCurrentPatrolIdx)
            {
                m_nCurrentPatrolIdx = 0;
            }

            //判断是否越界
            if (m_nCurrentPatrolIdx < 0 || m_patrolPoint.ListPatrolPoint.Count <= m_nCurrentPatrolIdx)
            {
                return GlobeVar.INVALID_ID;
            }

            return GotoPatrolPoint(m_nCurrentPatrolIdx);
        }

        private bool IsReached()
        {
            if (m_nCurrentPatrolIdx < 0 || m_patrolPoint.ListPatrolPoint.Count <= m_nCurrentPatrolIdx)
            {
                return false;
            }

            Vector2 point2D = m_patrolPoint.ListPatrolPoint[m_nCurrentPatrolIdx];
            Vector3 dest = new Vector3(point2D.x, 0, point2D.y);
            Vector3 currentPos = this.gameObject.transform.position;
            if (Vector3.Distance(dest, currentPos) <= m_fStopDistance)
            {
                return true;
            }

            return false;
        }

        void Awake()
        {
            m_nCurrentPatrolIdx = 0;
            m_bIsReachedStop = false;
        }

        void Start()
        {
            //装载AI到AIController，进行统一管理
            LoadAI();
            //先暂时在这里初始化
            m_patrolPoint.InitPatrolPoint(PatrolTableID);

            //走向第一个点
            if (GlobeVar.INVALID_ID == GotoPatrolPoint(m_nCurrentPatrolIdx))
            {
                return;
            }
        }

        public override void UpdateAI()
        {
            //首先更新到达一个路点后的停留时间
            if (m_bIsReachedStop)
            {
                if (Time.time - m_fLastReachedStopTime < m_fReachedStopTimeInterval)
                {
                    //未到时间，则停留等待
                    return;
                }
                else
                {
                    //到达时间，向下一个点移动
                    m_bIsReachedStop = false;
                    GotoNextPatrolPoint();
                }
            }

            if (true == IsReached())
            {
                m_bIsReachedStop = true;
                m_fLastReachedStopTime = Time.time;
            }
        }
    }
}
