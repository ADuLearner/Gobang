using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gobang
{
    public enum GobangPlayer
    {
        /// <summary>
        /// 没有棋子
        /// </summary>
        NoPlayer=1,
        /// <summary>
        /// 电脑
        /// </summary>
        Player1,
        /// <summary>
        /// 棋手甲
        /// </summary>
        Player2
    }

    /// <summary>
    /// 棋子类
    /// </summary>
    public class Chessman
    {
        /// <summary>
        /// 标识这个棋子的棋手
        /// </summary>
        public GobangPlayer GoBangPlayer { set; get; } = GobangPlayer.NoPlayer;
        /// <summary>
        /// 棋子是第几步
        /// </summary>
        public int StepNumber { set; get; } = 0;
        /// <summary>
        /// 棋子的得分
        /// </summary>
        public int WeightScore { set; get; } = 0;
        /// <summary>
        /// 是否为空
        /// </summary>
        public bool IsEmpty
        {
            get { return GoBangPlayer == GobangPlayer.NoPlayer; }
        }
        /// <summary>
        /// 两个棋子是否是同一棋手
        /// </summary>
        /// <param name="cm1"></param>
        /// <param name="cm2"></param>
        /// <returns></returns>
        public static bool operator ==(Chessman cm1, Chessman cm2)
        {
            return cm1.GoBangPlayer == cm2.GoBangPlayer;
        }
        /// <summary>
        /// 两个棋子是否是不同棋手
        /// </summary>
        /// <param name="cm1"></param>
        /// <param name="cm2"></param>
        /// <returns></returns>
        public static bool operator !=(Chessman cm1, Chessman cm2)
        {
            return cm1.GoBangPlayer != cm2.GoBangPlayer;
        }
        /// <summary>
        /// 获得对应棋手的颜色
        /// </summary>
        public System.Drawing.Brush GetPawnBrush
        {
            get
            {
                switch (GoBangPlayer)
                {
                    case GobangPlayer.Player1:return System.Drawing.Brushes.Orange;
                    case GobangPlayer.Player2:return System.Drawing.Brushes.Blue;
                    default: return System.Drawing.Brushes.Transparent;
                }
            }
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
    }
}
