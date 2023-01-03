
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
			//装载AI到AIController，进行统一管理
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
			//玩家ai控制器不为空 玩家不死亡
			//轻功状态下 不挂机
			if (m_player.QingGongState)
			{
				return;
			}
			if (m_player.AcceleratedMotion != null && m_player.AcceleratedMotion.Going == true)
			{
				return;
			}
			//剧情播放中不挂机
			if (m_player.IsInModelStory)
			{
				return;
			}
			if (m_target != null)
				m_player.MoveTo(m_target.transform.position, m_target.gameObject, 2.0f);
		}
	
}

