using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gobang
{
    /// <summary>
    /// 每个点的权重
    /// </summary>
    public class ChessWeight
    {
        /// <summary>
        /// 棋手默认为电脑
        /// </summary>
        private GobangPlayer ValuePlayer = GobangPlayer.Player1;
        /// <summary>
        /// 对手的最大权重
        /// </summary>
        private int ValueOpponent = 0;
        /// <summary>
        /// 对手的最大权重
        /// </summary>
        public int WeightOppinent
        {
            get => ValueOpponent;
            set
            {
                if (ValuePlayer == GobangPlayer.Player1)//如果对手的棋手甲，那么他最大权重就是值
                {
                    ValueOpponent = value;
                }
                else
                {
                    ValueOpponent = value;//如果对手是电脑，那么他最大权重需要再加上5
                    if (value == 12 || value == 13)
                    {
                        WeightMax += 5;
                    }
                }
            }
        }
        public int WeightMax { set; get; } = 0;
        public int WeightLarge { set; get; } = 0;
        public int WeightSmall { set; get; } = 0;
        public int WeightMin { set; get; } = 0;
        /// <summary>
        /// 四个方向上的总权重
        /// </summary>
        public int TotalWeight
        {
            get
            {
                int total = 0;
                if (WeightMax > 4) total += WeightMax;
                if (WeightLarge > 4) total += WeightLarge;
                if (WeightSmall > 4) total += WeightSmall;
                if (WeightMin > 4) total += WeightMin;
                if (total < 7)
                    total = WeightMax + WeightLarge + WeightSmall + WeightMin;
                return total;
            }
        }
        public ChessWeight()
        { }
        public ChessWeight(int[] singlesweight, GobangPlayer player)
        {
            ValuePlayer = player;
            Array.Sort(singlesweight);
            Array.Reverse(singlesweight);
            WeightMax = singlesweight[0];
            WeightLarge = singlesweight[1];
            WeightSmall = singlesweight[2];
            WeightMin = singlesweight[3];
            if ((WeightMax == 11 || WeightMax == 12) &&
                (WeightLarge == 11 || WeightLarge == 12))
            {
                WeightMax = 40;
            }
            if ((WeightMax == 11 || WeightMax == 12) &&
                (WeightLarge == 9 || WeightLarge == 10))
            {
                WeightMax = 30;
            }
            if (ValuePlayer == GobangPlayer.Player2)
            {
                if ((WeightMax == 11 || WeightMax == 12) && WeightLarge < 7)
                {
                    WeightMax = 7;
                }
            }
        }
        public static bool operator >(ChessWeight cw1, ChessWeight cw2)
        {
            if (cw1.WeightMax > cw2.WeightMax) return true;
            if (cw1.WeightMax < cw2.WeightMax) return false;
            if (cw1.WeightLarge > cw2.WeightLarge) return true;
            if (cw1.WeightLarge < cw2.WeightLarge) return false;
            if (cw1.WeightSmall > cw2.WeightSmall) return true;
            if (cw1.WeightSmall < cw2.WeightSmall) return false;
            if (cw1.WeightMin > cw2.WeightMin) return true;
            if (cw1.WeightMin < cw2.WeightMin) return false;
            return false;
        }
        public static bool operator <(ChessWeight cw1, ChessWeight cw2)
        {
            if (cw1.WeightMax < cw2.WeightMax) return true;
            if (cw1.WeightMax > cw2.WeightMax) return false;
            if (cw1.WeightLarge < cw2.WeightLarge) return true;
            if (cw1.WeightLarge > cw2.WeightLarge) return false;
            if (cw1.WeightSmall < cw2.WeightSmall) return true;
            if (cw1.WeightSmall > cw2.WeightSmall) return false;
            if (cw1.WeightMin < cw2.WeightMin) return true;
            if (cw1.WeightMin > cw2.WeightMin) return false;
            return false;
        }
        public static bool operator >=(ChessWeight cw1, ChessWeight cw2)
        {
            if (cw1.WeightMax > cw2.WeightMax) return true;
            if (cw1.WeightMax < cw2.WeightMax) return false;
            if (cw1.WeightLarge > cw2.WeightLarge) return true;
            if (cw1.WeightLarge < cw2.WeightLarge) return false;
            if (cw1.WeightSmall > cw2.WeightSmall) return true;
            if (cw1.WeightSmall < cw2.WeightSmall) return false;
            if (cw1.WeightMin > cw2.WeightMin) return true;
            if (cw1.WeightMin < cw2.WeightMin) return false;
            return true;
        }
        public static bool operator <=(ChessWeight cw1, ChessWeight cw2)
        {
            if (cw1.WeightMax < cw2.WeightMax) return true;
            if (cw1.WeightMax > cw2.WeightMax) return false;
            if (cw1.WeightLarge < cw2.WeightLarge) return true;
            if (cw1.WeightLarge > cw2.WeightLarge) return false;
            if (cw1.WeightSmall < cw2.WeightSmall) return true;
            if (cw1.WeightSmall > cw2.WeightSmall) return false;
            if (cw1.WeightMin < cw2.WeightMin) return true;
            if (cw1.WeightMin > cw2.WeightMin) return false;
            return true;
        }
        public static bool operator ==(ChessWeight cw1, ChessWeight cw2)
        {
            if (cw1.WeightMax == cw2.WeightMax &&
                cw1.WeightLarge == cw2.WeightLarge &&
                cw1.WeightSmall == cw2.WeightSmall &&
                cw1.WeightMin == cw2.WeightMin)
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(ChessWeight cw1, ChessWeight cw2)
        {
            if (cw1.WeightMax == cw2.WeightMax &&
                cw1.WeightLarge == cw2.WeightLarge &&
                cw1.WeightSmall == cw2.WeightSmall &&
                cw1.WeightMin == cw2.WeightMin)
            {
                return false;
            }
            return true;
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }


    }
}
