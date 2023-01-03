
using UnityEngine;
using System.Collections;
using Games.GlobeDefine;
using Games.LogicObj;


	public class AI_JuQing : BaseAI
	{
		Obj_MainPlayer m_player = null;

		public AI_JuQing()
		{
			m_AIType = CharacterDefine.AI_TYPE.AI_TYPE_JUQING;
			AIStateType = CharacterDefine.AI_STATE_TYPE.AI_STATE_JUQING;
		}
		void Start()
		{
			//װ��AI��AIController������ͳһ����
			LoadAI();
			m_player = gameObject.GetComponent<Obj_MainPlayer>();

		}

		public override void OnActive()
		{
			base.OnActive();
			UpdateAI();
		}
		public override void UpdateAI()
		{
			base.UpdateAI();
			//���ai��������Ϊ�� ��Ҳ�����
			//�Ṧ״̬�� ���һ�
			if (m_player.QingGongState)
			{
				return;
			}
			if (m_player.AcceleratedMotion != null && m_player.AcceleratedMotion.Going == true)
			{
				return;
			}
			//���鲥���в��һ�
			if (m_player.IsInModelStory)
			{
				return;
			}
			if (m_target != null)
				m_player.MoveTo(m_target.transform.position, m_target.gameObject, 2.0f);
		}
	
}

