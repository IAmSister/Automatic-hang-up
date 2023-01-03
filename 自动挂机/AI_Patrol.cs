
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

        //����Ƿ񵽴�·��ľ���
        public float m_fStopDistance = 1.0f;
        //����·����ͣ�ټ��
        public float m_fReachedStopTimeInterval = 2.0f;
        //�ϴ�ͣ��ʱ�䣬�����м��
        private float m_fLastReachedStopTime = 0.0f;
        //�Ƿ���ͣ��״̬
        private bool m_bIsReachedStop = false;

        //·��������
        public int PatrolTableID = GlobeVar.INVALID_ID;

        //·������
        private PatrolPoint m_patrolPoint;
        public PatrolPoint patrolPoint
        {
            get { return m_patrolPoint; }
        }

        //����ĳһ��·��
        private int GotoPatrolPoint(int nPatrolIdx)
        {
            //Խ���ж�
            if (nPatrolIdx < 0 || m_patrolPoint.ListPatrolPoint.Count <= nPatrolIdx)
            {
                return GlobeVar.INVALID_ID;
            }

            //����Ƿ���Obj����
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
            //�������ޣ���ع��һ��·��
            if (m_patrolPoint.ListPatrolPoint.Count == m_nCurrentPatrolIdx)
            {
                m_nCurrentPatrolIdx = 0;
            }

            //�ж��Ƿ�Խ��
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
            //װ��AI��AIController������ͳһ����
            LoadAI();
            //����ʱ�������ʼ��
            m_patrolPoint.InitPatrolPoint(PatrolTableID);

            //�����һ����
            if (GlobeVar.INVALID_ID == GotoPatrolPoint(m_nCurrentPatrolIdx))
            {
                return;
            }
        }

        public override void UpdateAI()
        {
            //���ȸ��µ���һ��·����ͣ��ʱ��
            if (m_bIsReachedStop)
            {
                if (Time.time - m_fLastReachedStopTime < m_fReachedStopTimeInterval)
                {
                    //δ��ʱ�䣬��ͣ���ȴ�
                    return;
                }
                else
                {
                    //����ʱ�䣬����һ�����ƶ�
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
