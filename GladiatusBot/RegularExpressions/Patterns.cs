using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GladiatusBot.RegularExpressions {
    public class Patterns {
        public const string HONOUR_PATTERN = "Honour:</td><[^>]*>(?<Honour>[^<]*)";
        public const string HITPOINTS_PATTERN = "Life points:</td><[^>]*>[^<]*?(?<CurrentHP>[0-9]*) / (?<MaxHP>[0-9]*)";
        public const string EXPERIENCE_PATTERN = "Experience:</td><[^>]*>[^<]*?(?<CurrentExp>[0-9]*) / (?<MaxExp>[0-9]*)";
        public const string GUILD_INDEX_PATTERN = "index\\.php\\?mod=guild&i=(?<index>[0-9]*)&sh=";
    }
}
