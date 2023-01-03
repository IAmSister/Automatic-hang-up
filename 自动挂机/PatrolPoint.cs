
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GCGame.Table;
using Games.GlobeDefine;

    public class PatrolPoint
    {
        //寻路基本信息
        public PatrolPoint()
        {
            ResetPatrolPoint();
        }

        //根据表格ID获取巡逻信息
        public bool InitPatrolPoint(int nTableID)
        {
            ResetPatrolPoint();
        //根据传过来id 读出巡逻点
        //目前暂时用数字表示上限 8
        //缓存所有巡逻点
    
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

        private int m_nSceneResID;                      //路点所在场景资源ID
        public int SceneResID
        {
            get { return m_nSceneResID; }
            set { m_nSceneResID = value; }
        }

        private List<Vector2> m_listPatrolPoint;        //路点序列
        public List<Vector2> ListPatrolPoint
        {
            get { return m_listPatrolPoint; }
            set { m_listPatrolPoint = value; }
        }
    

}
