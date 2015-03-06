using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GladiatusBot.Models {
    public class PlayerOverview {
        /// <summary>
        /// Gold amount
        /// </summary>
        public int Gold { get; set; }
        /// <summary>
        /// Ruby amount
        /// </summary>
        public int Rubies { get; set; }
        /// <summary>
        /// Current position on server
        /// </summary>
        public int Ranking { get; set; }
        /// <summary>
        /// Total honour popublic ints
        /// </summary>
        public int Honour { get; set; }
        /// <summary>
        /// Total fame popublic ints
        /// </summary>
        public int Fame { get; set; }
        /// <summary>
        /// Current level
        /// </summary>
        public int Level { get; set; }
        /// <summary>
        /// Current hitpopublic ints
        /// </summary>
        public int CurrentHP { get; set; }
        /// <summary>
        /// Max hitpopublic ints
        /// </summary>
        public int MaxHP { get; set; }
        /// <summary>
        /// Current experience popublic ints
        /// </summary>
        public int CurrentXP { get; set; }
        /// <summary>
        /// Required experience for next level
        /// </summary>
        public int RequiredXP { get; set; }
        /// <summary>
        /// Current expedition popublic ints
        /// </summary>
        public int ExpeditionPoints { get; set; }
        /// <summary>
        /// Max expedition popublic ints
        /// </summary>
        public int MaxExpeditionPoints { get; set; }
        /// <summary>
        /// Current dungeon popublic ints
        /// </summary>
        public int DungeonPoints { get; set; }
        /// <summary>
        /// Max dungeon popublic ints
        /// </summary>
        public int MaxDungeonPoints { get; set; }
        /// <summary>
        /// Current position on the arena
        /// </summary>
        public int ArenaPosition { get; set; }
        /// <summary>
        /// Current position on the circus turma
        /// </summary>
        public int CircusTurmaPosition { get; set; }

        /// <summary>
        /// Strength popublic ints
        /// </summary>
        public int Strength { get; set; }
        /// <summary>
        /// Dexterity popublic ints
        /// </summary>
        public int Dexterity { get; set; }
        /// <summary>
        /// Agility popublic ints
        /// </summary>
        public int Agility { get; set; }
        /// <summary>
        /// Constitution popublic ints
        /// </summary>
        public int Constitution { get; set; }
        /// <summary>
        /// Charism popublic ints
        /// </summary>
        public int Charism { get; set; }
        /// <summary>
        /// public intelligence popublic ints
        /// </summary>
        public int intelligence { get; set; }
        /// <summary>
        /// Total armour
        /// </summary>
        public int Armour { get; set; }
        /// <summary>
        /// Minimum damage
        /// </summary>
        public int MinDamage { get; set; }
        /// <summary>
        /// Max damage
        /// </summary>
        public int MaxDamage { get; set; }

        /// <summary>
        /// Current unread news
        /// </summary>
        public int UnreadNews { get; set; }
        /// <summary>
        /// Current unread battle reports
        /// </summary>
        public int UnreadBattleReports { get; set; }
        /// <summary>
        /// Current unread messages
        /// </summary>
        public int UnreadMessages { get; set; }
        /// <summary>
        /// Current new packages
        /// </summary>
        public int NewPackages { get; set; }
    }
}
