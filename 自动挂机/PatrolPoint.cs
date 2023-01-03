
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GCGame.Table;
using Games.GlobeDefine;

    public class PatrolPoint
    {
        //Ѱ·������Ϣ
        public PatrolPoint()
        {
            ResetPatrolPoint();
        }

        //���ݱ��ID��ȡѲ����Ϣ
        public bool InitPatrolPoint(int nTableID)
        {
            ResetPatrolPoint();
        //���ݴ�����id ����Ѳ�ߵ�
        //Ŀǰ��ʱ�����ֱ�ʾ���� 8
        //��������Ѳ�ߵ�
    
            return true;
        }

        public void AddPatrolPoint(int nX, int nY)
        {
            AddPatrolPoint(new Vector2(nX, nY));
        }

        public void AddPatrolPoint(Vector2 point)
        {
            if (null != m_listPatrolPoint)
            {
                m_listPatrolPoint.Add(point);
            }
        }

        public void ResetPatrolPoint()
        {
            m_nSceneResID = GlobeVar.INVALID_ID;
            m_listPatrolPoint = new List<Vector2>();
        }

        private int m_nSceneResID;                      //·�����ڳ�����ԴID
        public int SceneResID
        {
            get { return m_nSceneResID; }
            set { m_nSceneResID = value; }
        }

        private List<Vector2> m_listPatrolPoint;        //·������
        public List<Vector2> ListPatrolPoint
        {
            get { return m_listPatrolPoint; }
            set { m_listPatrolPoint = value; }
        }
    

}
