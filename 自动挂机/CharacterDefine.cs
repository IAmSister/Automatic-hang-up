using UnityEngine;
using System.Collections;
using System.Collections.Generic;


    public class CharacterDefine
    {
        public const int offset = 1;
        public enum CharacterAnimId
        {
            Stand = 1001,
            ActStand = 1002,
            Walk = 1003,
            Attack = 9 + offset,
            Hit = 2,
            Knockback_01 = 6005,
            Knockback_02 = 6006,
            Die = 1005,
            PlayerHit = 6004,
            RIDE_STAND = 1007,
            RIDE_RUN = 1008,
            Dead = 1005,
            Jump01 = 60 + offset,
            Jump01_Loop = 61 + offset,
            Jump02 = 62 + offset,
            Jump02_Loop = 63 + offset,
            Jump03 = 64 + offset,
            Jump03_Loop = 65 + offset,
            JumpEnd_Run = 66 + offset,
            JumpEnd_Stand = 67 + offset,
            Fastrun_Left = 68 + offset,
            Fastrun_Right = 69 + offset,
            AttackStand = 102 + offset,      //战斗型的NPC专属站立动作
        }

        //角色之间的关系
        public enum REPUTATION_TYPE
        {
            REPUTATION_INVALID = -1,
            REPUTATION_FRIEND,
            REPUTATION_NEUTRAL,
            REPUTATION_HOSTILE,
        }

        //角色AI状态类型
        public enum AI_STATE_TYPE
        {
            AI_STATE_NORMAL,            //非战斗型AI
            AI_STATE_COMBAT,            //战斗型AI
            AI_STATE_WALK,            //战斗型AI
            AI_STATE_DEAD,              //死亡型AI
            AI_STATE_JUQING,          //剧情AI
        }

        //角色具体AI类型
        public enum AI_TYPE
        {
            AI_TYPE_INVALID = -1,      //非法类型
            AI_TYPE_PATROL,             //普通巡逻AI
            AI_TYPE_COMBAT,             //普通战斗AI
            AI_TYPE_JUQING,            //剧情AI
        }

        //主角点选目标状态
        public enum SELECT_TARGET_TYPE
        {
            SELECT_TARGET_NONE,         //未选中
            SELECT_TARGET_CHAT,         //选中可对话目标
            SELECT_TARGET_ATK,          //选中可攻击状态
        }

        //玩家职业列表
        public enum PROFESSION
        {
            SHAOLIN,
            TIANSHAN,
            DALI,
            XIAOYAO,
            MAX,
        }

        public static int[] PROFESSION_DICNUM =
        {
            1178, // (SHAOLIN)
            1180, // (TIANSHAN)
            1179, // (DALI)
            1181, // (XIAOYAO)
        };
        public static int[] COPYSCENE_DIFFICULTY =
        {
            1311, // (简单)
            1312, // (困难)
            1313, // (挑战)
        };
        //PK模式
        public enum PKMODLE
        {
            NORMAL = 0,
            KILL,
            MAX,
        }

        //选择目标的类型
        public enum TARGETTYPE
        {
            TYPE_INVAILD = 0,
            SELF = 1, //自身
            TEAMEM = 2,//队员
            ENEMY = 4,//敌人
            FRIEND = 8,//友方
        }

        //关系人状态
        public enum RELATION_TYPE
        {
            OFFLINE,        //离线
            ONLINE,         //在线
        }

        public enum Attr
        {
            MAXHP,
            MAXMP,
            MAXXP,
            PYSATTACK,
            MAGATTACK,
            PYSDEF,
            MAGDEF,
            HIT,
            DODGE,
            CRITICAL,
            DECRITICAL,
            STRIKE,
            DUCTICAL,
            CRITIADD,
            CRITIMIS,
            MOVESPEED,
            ATTACKSPEED,
            COMBATATTR_MAXNUM,
        }

        public enum MixAttr
        {
            MIXTYPE_BEGIN = 999,
            MIXTYPE_ALLATTACK = 1000,
            MIXTYPE_ALLDEF = 1001,
        }

        public static Dictionary<int, int> AttrTable = new Dictionary<int, int>()
        {
            { (int)Attr.MAXHP, 1573 },
            { (int)Attr.MAXMP, 1574 },
            { (int)Attr.MAXXP, 1575 },
            { (int)Attr.PYSATTACK, 1576 },
            { (int)Attr.MAGATTACK, 1577 },
            { (int)Attr.PYSDEF, 1578 },
            { (int)Attr.MAGDEF, 1579 },
            { (int)Attr.HIT, 1580 },
            { (int)Attr.DODGE, 1581 },
            { (int)Attr.CRITICAL, 1582 },
            { (int)Attr.DECRITICAL, 1583 },
            { (int)Attr.STRIKE, 1584 },
            { (int)Attr.DUCTICAL, 1585 },
            { (int)Attr.CRITIADD, 1586 },
            { (int)Attr.CRITIMIS, 1587 },
            { (int)Attr.MOVESPEED, 1588 },
            { (int)Attr.ATTACKSPEED, 1589 },
            { (int)MixAttr.MIXTYPE_ALLATTACK, 1590 },
            { (int)MixAttr.MIXTYPE_ALLDEF, 1591 },
        };

        //public static Color NPC_COLOR_DIE = GCGame.Utils.GetColorByString("868686");
        //public static Color NPC_COLOR_FRIEND = GCGame.Utils.GetColorByString("70E718");
        //public static Color NPC_COLOR_NEUTRAL = GCGame.Utils.GetColorByString("E7D718");
        //public static Color NPC_COLOR_ENEMY = GCGame.Utils.GetColorByString("E71818");
    
}
