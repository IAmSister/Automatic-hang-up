
using UnityEngine;
using System.Collections;
using Games.GlobeDefine;
using Games.LogicObj;

    public class BaseAI : MonoBehaviour
    {
        //AI�ľ�������
        protected CharacterDefine.AI_TYPE m_AIType;
        public CharacterDefine.AI_TYPE AIType
        {
            get { return m_AIType; }
            set { m_AIType = value; }
        }
        public Obj m_target = null;
        public CharacterDefine.AI_STATE_TYPE AIStateType;

        public BaseAI()
        {
            m_AIType = CharacterDefine.AI_TYPE.AI_TYPE_INVALID;
        }

        //��ʼ��AI
        void Awake()
        {

        }

        //��AIװ�ص�OBJ��AIController��
        public void LoadAI()
        {
            AIController aiController = this.gameObject.GetComponent<AIController>();
            if (aiController)
            {
                aiController.AddAIByStateType(this);
            }
        }
        public void SetTarget(Obj obj)
        {
            m_target = obj;
        }
        //����AI
        public virtual void Destroy()
        {
        }

        //����AI
        public virtual void OnActive()
        {
        }

        //�ر�AI
        public virtual void OnDeactive()
        {
        }

        //����AI
        public virtual void UpdateAI()
        {
        }
    }

