
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

    public class ThreatInfo
    {
        public ThreatInfo()
        {
            m_threatObj = null;
            m_nThreatValue = 0;
        }

        public ThreatInfo(GameObject obj, int nValue)
        {
            m_threatObj = obj;
            m_nThreatValue = nValue;
        }

        private GameObject m_threatObj;     //ÍþÐ²ÖµµÄOBJ
        public GameObject ThreatObj
        {
            get { return m_threatObj; }
            set { m_threatObj = value; }
        }

        private int m_nThreatValue;         //ÍþÐ²Öµ
        public int ThreatValue
        {
            get { return m_nThreatValue; }
            set { m_nThreatValue = value; }
        }
    }

    public class Threat
    {
        public Threat()
        {
            if (null == m_ThreatList)
            {
                m_ThreatList = new List<ThreatInfo>();
            }
        }
        private List<ThreatInfo> m_ThreatList;

        public ThreatInfo FindThreadInfo(GameObject obj)
        {
            if (null == obj)
            {
                return null;
            }

            for (int i = 0; i < m_ThreatList.Count; ++i)
            {
                if (m_ThreatList[i].ThreatObj == obj)
                {
                    return m_ThreatList[i];
                }
            }

            return null;
        }

        public GameObject FindMaxThreatObj()
        {
            ThreatInfo maxThreat = null;

            for (int i = 0; i < m_ThreatList.Count; ++i)
            {
                if (null == maxThreat)
                {
                    maxThreat = m_ThreatList[i];
                }
                else if (maxThreat.ThreatValue < m_ThreatList[i].ThreatValue)
                {
                    maxThreat = m_ThreatList[i];
                }
            }
            if (maxThreat == null)
            {
                return null;
            }
            return maxThreat.ThreatObj;
        }

        public void AddThreat(GameObject obj, int value)
        {
            if (null == obj)
            {
                return;
            }

            ThreatInfo info = FindThreadInfo(obj);
            if (null == info)
            {
                info = new ThreatInfo(obj, value);
                info.ThreatValue = Math.Max(0, info.ThreatValue);
                m_ThreatList.Add(info);
            }
            else
            {
                info.ThreatValue += value;
                info.ThreatValue = Math.Max(0, info.ThreatValue);
            }
        }

        public void ResetAllThreat()
        {
            m_ThreatList.Clear();
        }

        public void ResetThreat(GameObject obj)
        {
            ThreatInfo info = FindThreadInfo(obj);
            if (null != info)
            {
                m_ThreatList.Remove(info);
            }
        }
    
}
