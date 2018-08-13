using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gobang
{
    public class ComputerAI_Du
    {
        private Chessman[,] main_chess = null;
        public ComputerAI_Du(Chessman[,] chess)
        {
            main_chess = chess;
        }
        public Task<Point> CalculateComputerAI(GobangPlayer player)
        {
            return Task.Run<Point>(() =>
            {
                Task.Delay(100);
                GobangPlayer enemy = GobangPlayer.Player1;
                if (player == enemy)
                {
                    enemy = GobangPlayer.Player2;
                }
                ChessWeight[,] m_Weights_opinion = new ChessWeight[21, 21];
                ChessWeight[,] m_Weights_enemy = new ChessWeight[21, 21];
                for (int i = 0; i < 21; i++)
                {
                    for (int j = 0; j < 21; j++)
                    {
                        if (main_chess[i, j].GoBangPlayer != GobangPlayer.NoPlayer)
                        {
                            m_Weights_opinion[i, j] = new ChessWeight(new int[] { -1, -1, -1, -1 }, player);
                            m_Weights_enemy[i, j] = new ChessWeight(new int[] { -1, -1, -1, -1 }, enemy);
                            continue;
                        }
                        m_Weights_opinion[i, j] = GetWeight(i, j, player);
                        m_Weights_enemy[i, j] = GetWeight(i, j, enemy);
                        m_Weights_opinion[i, j].WeightOppinent = m_Weights_enemy[i, j].WeightMax;
                        m_Weights_enemy[i, j].WeightOppinent = m_Weights_opinion[i, j].WeightMax;
                    }
                }
                List<Point> MaxPointComputer = new List<Point>();
                int MaxPlayer1 = 0;
                int MaxPlayer2 = 0;
                List<Point> MaxPointPlayer1 = new List<Point>();
                for (int i = 0; i < 21; i++)
                {
                    for (int j = 0; j < 21; j++)
                    {
                        if (m_Weights_opinion[i, j].TotalWeight > MaxPlayer1)
                        {
                            MaxPlayer1 = m_Weights_opinion[i, j].TotalWeight;
                            MaxPointComputer.Clear();
                            MaxPointComputer.Add(new Point(i, j));
                        }
                        else if (m_Weights_opinion[i, j].TotalWeight == MaxPlayer1)
                        {
                            MaxPointComputer.Add(new Point(i, j));
                        }

                        if (m_Weights_enemy[i, j].TotalWeight > MaxPlayer2)
                        {
                            MaxPlayer2 = m_Weights_enemy[i, j].TotalWeight;
                            MaxPointPlayer1.Clear();
                            MaxPointPlayer1.Add(new Point(i, j));
                        }
                        else if (m_Weights_enemy[i, j].TotalWeight == MaxPlayer2)
                        {
                            MaxPointPlayer1.Add(new Point(i, j));
                        }
                    }
                }
                if ((MaxPlayer1 > 49 && MaxPlayer2 < 200) || (MaxPlayer1 >= 200) && MaxPlayer2 >= 200)
                {
                    int MaxTemp = 0;
                    Point MaxPoint = new Point();
                    for (int i = 0; i < MaxPointComputer.Count; i++)
                    {
                        if (MaxTemp < m_Weights_opinion[MaxPointComputer[i].X, MaxPointComputer[i].Y].WeightOppinent)
                        {
                            MaxTemp = m_Weights_opinion[MaxPointComputer[i].X, MaxPointComputer[i].Y].WeightOppinent;
                            MaxPoint = MaxPointComputer[i];
                        }
                    }
                    return MaxPoint;
                }
                if (MaxPlayer1 >= MaxPlayer2)
                {
                    int MaxTemp = 0;
                    Point MaxPoint = new Point();
                    for (int i = 0; i < MaxPointComputer.Count; i++)
                    {
                        if (MaxTemp < m_Weights_opinion[MaxPointComputer[i].X, MaxPointComputer[i].Y].WeightOppinent)
                        {
                            MaxTemp = m_Weights_opinion[MaxPointComputer[i].X, MaxPointComputer[i].Y].WeightOppinent;
                            MaxPoint = MaxPointComputer[i];
                        }
                    }
                    return MaxPoint;
                }
                else
                {
                    int MaxTemp = 0;
                    Point MaxPoint = new Point();
                    for (int i = 0; i < MaxPointPlayer1.Count; i++)
                    {
                        if (m_Weights_enemy[MaxPointPlayer1[i].X,
                            MaxPointPlayer1[i].Y].WeightOppinent > MaxTemp)
                        {
                            MaxTemp = m_Weights_enemy[MaxPointPlayer1[i].X,
                            MaxPointPlayer1[i].Y].WeightOppinent;
                            MaxPoint = MaxPointPlayer1[i];
                        }
                    }
                    return MaxPoint;
                }
            });
        }
        public Task<Point> CalculateComputerAI()
        {
            return Task.Run<Point>(() =>
            {
                Task.Delay(100);
                ChessWeight[,] m_Weights_Computer = new ChessWeight[21, 21];
                ChessWeight[,] m_Weights_Player1 = new ChessWeight[21, 21];
                for (int i = 0; i < 21; i++)
                {
                    for (int j = 0; j < 21; j++)
                    {
                        if (main_chess[i, j].GoBangPlayer != GobangPlayer.NoPlayer)
                        {
                            m_Weights_Computer[i, j] = new ChessWeight(new int[] { -1, -1, -1, -1 }, GobangPlayer.Player1);
                            m_Weights_Player1[i, j] = new ChessWeight(new int[] { -1, -1, -1, -1 }, GobangPlayer.Player2);
                            continue;
                        }
                        m_Weights_Computer[i, j] = GetWeight(i, j, GobangPlayer.Player1);
                        m_Weights_Player1[i, j] = GetWeight(i, j, GobangPlayer.Player2);
                        m_Weights_Computer[i, j].WeightOppinent = m_Weights_Player1[i, j].WeightMax;
                        m_Weights_Player1[i, j].WeightOppinent = m_Weights_Computer[i, j].WeightMax;
                    }
                }
                List<Point> MaxPointComputer = new List<Point>();
                int MaxPlayer1 = 0;
                int MaxPlayer2 = 0;
                List<Point> MaxPointPlayer1 = new List<Point>();
                for (int i = 0; i < 21; i++)
                {
                    for (int j = 0; j < 21; j++)
                    {
                        if (m_Weights_Computer[i, j].TotalWeight > MaxPlayer1)
                        {
                            MaxPlayer1 = m_Weights_Computer[i, j].TotalWeight;
                            MaxPointComputer.Clear();
                            MaxPointComputer.Add(new Point(i, j));
                        }
                        else if (m_Weights_Computer[i, j].TotalWeight == MaxPlayer1)
                        {
                            MaxPointComputer.Add(new Point(i, j));
                        }

                        if (m_Weights_Player1[i, j].TotalWeight > MaxPlayer2)
                        {
                            MaxPlayer2 = m_Weights_Player1[i, j].TotalWeight;
                            MaxPointPlayer1.Clear();
                            MaxPointPlayer1.Add(new Point(i, j));
                        }
                        else if (m_Weights_Player1[i, j].TotalWeight == MaxPlayer2)
                        {
                            MaxPointPlayer1.Add(new Point(i, j));
                        }
                    }
                }
                if ((MaxPlayer1 > 49 && MaxPlayer2 < 200) || (MaxPlayer1 >= 200) && MaxPlayer2 >= 200)
                {
                    int MaxTemp = 0;
                    Point MaxPoint = new Point();
                    for (int i = 0; i < MaxPointComputer.Count; i++)
                    {
                        if (MaxTemp < m_Weights_Computer[MaxPointComputer[i].X, MaxPointComputer[i].Y].WeightOppinent)
                        {
                            MaxTemp = m_Weights_Computer[MaxPointComputer[i].X, MaxPointComputer[i].Y].WeightOppinent;
                            MaxPoint = MaxPointComputer[i];
                        }
                    }
                    return MaxPoint;
                }
                if (MaxPlayer1 >= MaxPlayer2)
                {
                    int MaxTemp = 0;
                    Point MaxPoint = new Point();
                    for (int i = 0; i < MaxPointComputer.Count; i++)
                    {
                        if (MaxTemp < m_Weights_Computer[MaxPointComputer[i].X, MaxPointComputer[i].Y].WeightOppinent)
                        {
                            MaxTemp = m_Weights_Computer[MaxPointComputer[i].X, MaxPointComputer[i].Y].WeightOppinent;
                            MaxPoint = MaxPointComputer[i];
                        }
                    }
                    return MaxPoint;
                }
                else
                {
                    int MaxTemp = 0;
                    Point MaxPoint = new Point();
                    for (int i = 0; i < MaxPointPlayer1.Count; i++)
                    {
                        if (m_Weights_Player1[MaxPointPlayer1[i].X,
                            MaxPointPlayer1[i].Y].WeightOppinent > MaxTemp)
                        {
                            MaxTemp = m_Weights_Player1[MaxPointPlayer1[i].X,
                            MaxPointPlayer1[i].Y].WeightOppinent;
                            MaxPoint = MaxPointPlayer1[i];
                        }
                    }
                    return MaxPoint;
                }
            }
            );
        }

        private ChessWeight GetWeight(int m_x, int m_y, GobangPlayer m_player)
        {
            int[] m_Weight = new int[4];
            for (int i = 0; i < 4; i++)
            {
                m_Weight[i] = GetWeightSingle(i, m_x, m_y, m_player);
            }
            ChessWeight cw = new ChessWeight(m_Weight, m_player);
            return cw;
        }

        private int GetWeightSingle(int Direction, int m_x, int m_y, GobangPlayer m_player)
        {
            Chessman[] LEFT_TO_RIGHT = new Chessman[9];
            if (Direction == 0)
            {
                for (int i = 0; i < 9; i++)
                {
                    LEFT_TO_RIGHT[i] = GetClassChessMan(m_x + i - 4, m_y, m_player);
                }
            }
            else if (Direction == 1)
            {
                for (int i = 0; i < 9; i++)
                {
                    LEFT_TO_RIGHT[i] = GetClassChessMan(m_x, m_y + i - 4, m_player);
                }
            }
            else if (Direction == 2)
            {
                for (int i = 0; i < 9; i++)
                {
                    LEFT_TO_RIGHT[i] = GetClassChessMan(m_x + i - 4, m_y + i - 4, m_player);
                }
            }
            else
            {
                for (int i = 0; i < 9; i++)
                {
                    LEFT_TO_RIGHT[i] = GetClassChessMan(m_x - (i - 4), m_y + i - 4, m_player);
                }
            }
            GobangPlayer player_enemy = GobangPlayer.Player1;
            if (m_player == GobangPlayer.Player1)   player_enemy = GobangPlayer.Player2;
            Chessman OwnPawn = new Chessman() { GoBangPlayer = m_player };
            Chessman OtherPawn = new Chessman() { GoBangPlayer = player_enemy };

            if (LEFT_TO_RIGHT[1].IsEmpty &&
                LEFT_TO_RIGHT[2].IsEmpty &&
                LEFT_TO_RIGHT[3].IsEmpty &&

                LEFT_TO_RIGHT[5].IsEmpty &&
                LEFT_TO_RIGHT[6].IsEmpty &&
                LEFT_TO_RIGHT[7].IsEmpty)
            {
                return 1;//四周都没有棋子为1
            }
            //0000#
            if (LEFT_TO_RIGHT[0] == OwnPawn &&
                LEFT_TO_RIGHT[1] == OwnPawn &&
                LEFT_TO_RIGHT[2] == OwnPawn &&
                LEFT_TO_RIGHT[3] == OwnPawn)
            {
                return 200;
            }
            if (LEFT_TO_RIGHT[1] == OwnPawn &&
                LEFT_TO_RIGHT[2] == OwnPawn &&
                LEFT_TO_RIGHT[3] == OwnPawn &&

                LEFT_TO_RIGHT[5] == OwnPawn)
            {
                return 200;
            }
            if (LEFT_TO_RIGHT[2] == OwnPawn &&
                LEFT_TO_RIGHT[3] == OwnPawn &&

                LEFT_TO_RIGHT[5] == OwnPawn &&
                LEFT_TO_RIGHT[6] == OwnPawn)
            {
                return 200;
            }
            if (LEFT_TO_RIGHT[3] == OwnPawn &&

                LEFT_TO_RIGHT[5] == OwnPawn &&
                LEFT_TO_RIGHT[6] == OwnPawn &&
                LEFT_TO_RIGHT[7] == OwnPawn)
            {
                return 200;
            }
            if (LEFT_TO_RIGHT[5] == OwnPawn &&
                LEFT_TO_RIGHT[6] == OwnPawn &&
                LEFT_TO_RIGHT[7] == OwnPawn &&
                LEFT_TO_RIGHT[8] == OwnPawn)
            {
                return 200;
            }

            //四子两头空
            //*000#*

            if (LEFT_TO_RIGHT[0].IsEmpty &&
                LEFT_TO_RIGHT[1] == OwnPawn &&
                LEFT_TO_RIGHT[2] == OwnPawn &&
                LEFT_TO_RIGHT[3] == OwnPawn &&

                LEFT_TO_RIGHT[5].IsEmpty)
            {
                return 50;
            }
            if (LEFT_TO_RIGHT[1].IsEmpty &&
                LEFT_TO_RIGHT[2] == OwnPawn &&
                LEFT_TO_RIGHT[3] == OwnPawn &&

                LEFT_TO_RIGHT[5] == OwnPawn &&
                LEFT_TO_RIGHT[6].IsEmpty)
            {
                return 50;
            }
            if (LEFT_TO_RIGHT[2].IsEmpty &&
                LEFT_TO_RIGHT[3] == OwnPawn &&

                LEFT_TO_RIGHT[5] == OwnPawn &&
                LEFT_TO_RIGHT[6] == OwnPawn &&
                LEFT_TO_RIGHT[7].IsEmpty)
            {
                return 50;
            }
            if (LEFT_TO_RIGHT[3].IsEmpty &&

                LEFT_TO_RIGHT[5] == OwnPawn &&
                LEFT_TO_RIGHT[6] == OwnPawn &&
                LEFT_TO_RIGHT[7] == OwnPawn &&
                LEFT_TO_RIGHT[8].IsEmpty)
            {
                return 50;
            }
            //0*0#0*0
            if (LEFT_TO_RIGHT[1] == OwnPawn &&
                    LEFT_TO_RIGHT[2].IsEmpty &&
                    LEFT_TO_RIGHT[3] == OwnPawn &&

                    LEFT_TO_RIGHT[5] == OwnPawn &&
                    LEFT_TO_RIGHT[6].IsEmpty &&
                    LEFT_TO_RIGHT[7] == OwnPawn)
            {
                return 50;
            }
            //四子一头空 1000#*
            if (LEFT_TO_RIGHT[0] == OtherPawn &&
                LEFT_TO_RIGHT[1] == OwnPawn &&
                LEFT_TO_RIGHT[2] == OwnPawn &&
                LEFT_TO_RIGHT[3] == OwnPawn &&

                LEFT_TO_RIGHT[5].IsEmpty)
            {
                return 12;
            }
            if (LEFT_TO_RIGHT[1] == OtherPawn &&
                LEFT_TO_RIGHT[2] == OwnPawn &&
                LEFT_TO_RIGHT[3] == OwnPawn &&

                LEFT_TO_RIGHT[5] == OwnPawn &&
                LEFT_TO_RIGHT[6].IsEmpty)
            {
                return 12;
            }
            if (LEFT_TO_RIGHT[2] == OtherPawn &&
                LEFT_TO_RIGHT[3] == OwnPawn &&

                LEFT_TO_RIGHT[5] == OwnPawn &&
                LEFT_TO_RIGHT[6] == OwnPawn &&
                LEFT_TO_RIGHT[7].IsEmpty)
            {
                return 12;
            }
            if (LEFT_TO_RIGHT[3] == OtherPawn &&

                LEFT_TO_RIGHT[5] == OwnPawn &&
                LEFT_TO_RIGHT[6] == OwnPawn &&
                LEFT_TO_RIGHT[7] == OwnPawn &&
                LEFT_TO_RIGHT[8].IsEmpty)
            {
                return 12;
            }

            if (LEFT_TO_RIGHT[0].IsEmpty &&
                LEFT_TO_RIGHT[1] == OwnPawn &&
                LEFT_TO_RIGHT[2] == OwnPawn &&
                LEFT_TO_RIGHT[3] == OwnPawn &&

                LEFT_TO_RIGHT[5] == OtherPawn)
            {
                return 12;
            }
            if (LEFT_TO_RIGHT[1].IsEmpty &&
                LEFT_TO_RIGHT[2] == OwnPawn &&
                LEFT_TO_RIGHT[3] == OwnPawn &&

                LEFT_TO_RIGHT[5] == OwnPawn &&
                LEFT_TO_RIGHT[6] == OtherPawn)
            {
                return 12;
            }
            if (LEFT_TO_RIGHT[2].IsEmpty &&
                LEFT_TO_RIGHT[3] == OwnPawn &&

                LEFT_TO_RIGHT[5] == OwnPawn &&
                LEFT_TO_RIGHT[6] == OwnPawn &&
                LEFT_TO_RIGHT[7] == OtherPawn)
            {
                return 12;
            }
            if (LEFT_TO_RIGHT[3].IsEmpty &&

                LEFT_TO_RIGHT[5] == OwnPawn &&
                LEFT_TO_RIGHT[6] == OwnPawn &&
                LEFT_TO_RIGHT[7] == OwnPawn &&
                LEFT_TO_RIGHT[8] == OtherPawn)
            {
                return 12;
            }


            //0*00 
            if (LEFT_TO_RIGHT[0] == OwnPawn &&
                    LEFT_TO_RIGHT[1].IsEmpty &&
                    LEFT_TO_RIGHT[2] == OwnPawn &&
                    LEFT_TO_RIGHT[3] == OwnPawn)
            {
                return 11;
            }
            if (LEFT_TO_RIGHT[0] == OwnPawn &&
                    LEFT_TO_RIGHT[1] == OwnPawn &&
                    LEFT_TO_RIGHT[2].IsEmpty &&
                    LEFT_TO_RIGHT[3] == OwnPawn)
            {
                return 11;
            }
            if (LEFT_TO_RIGHT[1] == OwnPawn &&
                    LEFT_TO_RIGHT[2].IsEmpty &&
                    LEFT_TO_RIGHT[3] == OwnPawn &&

                    LEFT_TO_RIGHT[5] == OwnPawn)
            {
                return 11;
            }
            if (LEFT_TO_RIGHT[0] == OwnPawn &&
                    LEFT_TO_RIGHT[1] == OwnPawn &&
                    LEFT_TO_RIGHT[2] == OwnPawn &&
                    LEFT_TO_RIGHT[3].IsEmpty)
            {
                return 11;
            }
            if (LEFT_TO_RIGHT[1] == OwnPawn &&
                    LEFT_TO_RIGHT[2] == OwnPawn &&
                    LEFT_TO_RIGHT[3].IsEmpty &&

                    LEFT_TO_RIGHT[5] == OwnPawn)
            {
                return 11;
            }
            if (LEFT_TO_RIGHT[2] == OwnPawn &&
                    LEFT_TO_RIGHT[3].IsEmpty &&

                    LEFT_TO_RIGHT[5] == OwnPawn &&
                    LEFT_TO_RIGHT[6] == OwnPawn)
            {
                return 11;
            }
            if (LEFT_TO_RIGHT[5].IsEmpty &&
                    LEFT_TO_RIGHT[6] == OwnPawn &&
                    LEFT_TO_RIGHT[7] == OwnPawn &&
                    LEFT_TO_RIGHT[8] == OwnPawn)
            {
                return 11;
            }
            if (LEFT_TO_RIGHT[3] == OwnPawn &&

                    LEFT_TO_RIGHT[5].IsEmpty &&
                    LEFT_TO_RIGHT[6] == OwnPawn &&
                    LEFT_TO_RIGHT[7] == OwnPawn)
            {
                return 11;
            }
            if (LEFT_TO_RIGHT[2] == OwnPawn &&
                    LEFT_TO_RIGHT[3] == OwnPawn &&

                    LEFT_TO_RIGHT[5].IsEmpty &&
                    LEFT_TO_RIGHT[6] == OwnPawn)
            {
                return 11;
            }
            if (LEFT_TO_RIGHT[5] == OwnPawn &&
                    LEFT_TO_RIGHT[6].IsEmpty &&
                    LEFT_TO_RIGHT[7] == OwnPawn &&
                    LEFT_TO_RIGHT[8] == OwnPawn)
            {
                return 11;
            }
            if (LEFT_TO_RIGHT[3] == OwnPawn &&

                    LEFT_TO_RIGHT[5] == OwnPawn &&
                    LEFT_TO_RIGHT[6].IsEmpty &&
                    LEFT_TO_RIGHT[7] == OwnPawn)
            {
                return 11;
            }
            if (LEFT_TO_RIGHT[5] == OwnPawn &&
                    LEFT_TO_RIGHT[6] == OwnPawn &&
                    LEFT_TO_RIGHT[7].IsEmpty &&
                    LEFT_TO_RIGHT[8] == OwnPawn)
            {
                return 11;
            }
            //四子两头堵1000#1
            if (LEFT_TO_RIGHT[0] == OtherPawn &&
                LEFT_TO_RIGHT[1] == OwnPawn &&
                LEFT_TO_RIGHT[2] == OwnPawn &&
                LEFT_TO_RIGHT[3] == OwnPawn &&

                LEFT_TO_RIGHT[5] == OtherPawn)
            {
                return 0;
            }
            if (LEFT_TO_RIGHT[1] == OtherPawn &&
                LEFT_TO_RIGHT[2] == OwnPawn &&
                LEFT_TO_RIGHT[3] == OwnPawn &&

                LEFT_TO_RIGHT[5] == OwnPawn &&
                LEFT_TO_RIGHT[6] == OtherPawn)
            {
                return 0;
            }
            if (LEFT_TO_RIGHT[2] == OtherPawn &&
                LEFT_TO_RIGHT[3] == OwnPawn &&

                LEFT_TO_RIGHT[5] == OwnPawn &&
                LEFT_TO_RIGHT[6] == OwnPawn &&
                LEFT_TO_RIGHT[7] == OtherPawn)
            {
                return 0;
            }
            if (LEFT_TO_RIGHT[3] == OtherPawn &&

                LEFT_TO_RIGHT[5] == OwnPawn &&
                LEFT_TO_RIGHT[6] == OwnPawn &&
                LEFT_TO_RIGHT[7] == OwnPawn &&
                LEFT_TO_RIGHT[8] == OtherPawn)
            {
                return 0;
            }

            //三子两头空=============================================
            //以下三种情况削减得分1*00#**1
            if (LEFT_TO_RIGHT[0] == OtherPawn &&
                LEFT_TO_RIGHT[1].IsEmpty &&
                LEFT_TO_RIGHT[2] == OwnPawn &&
                LEFT_TO_RIGHT[3] == OwnPawn &&

                LEFT_TO_RIGHT[5].IsEmpty &&
                LEFT_TO_RIGHT[6] == OtherPawn)
            {
                return 7;
            }
            if (
                LEFT_TO_RIGHT[1] == OtherPawn &&
                LEFT_TO_RIGHT[2].IsEmpty &&
                LEFT_TO_RIGHT[3] == OwnPawn &&

                LEFT_TO_RIGHT[5] == OwnPawn &&
                LEFT_TO_RIGHT[6].IsEmpty &&
                LEFT_TO_RIGHT[7] == OtherPawn)
            {
                return 7;
            }
            if (LEFT_TO_RIGHT[2] == OtherPawn &&
                LEFT_TO_RIGHT[3].IsEmpty &&

                LEFT_TO_RIGHT[5] == OwnPawn &&
                LEFT_TO_RIGHT[6] == OwnPawn &&
                LEFT_TO_RIGHT[7].IsEmpty &&
                LEFT_TO_RIGHT[8] == OtherPawn)
            {
                return 7;
            }
            //*00#*  
            if (LEFT_TO_RIGHT[1].IsEmpty &&
                LEFT_TO_RIGHT[2] == OwnPawn &&
                LEFT_TO_RIGHT[3] == OwnPawn &&

                LEFT_TO_RIGHT[5].IsEmpty)
            {
                return 10;
            }
            if (LEFT_TO_RIGHT[2].IsEmpty &&
                LEFT_TO_RIGHT[3] == OwnPawn &&

                LEFT_TO_RIGHT[5] == OwnPawn &&
                LEFT_TO_RIGHT[6].IsEmpty)
            {
                return 10;
            }
            if (LEFT_TO_RIGHT[3].IsEmpty &&

                LEFT_TO_RIGHT[5] == OwnPawn &&
                LEFT_TO_RIGHT[6] == OwnPawn &&
                LEFT_TO_RIGHT[7].IsEmpty)
            {
                return 10;
            }

            //特殊处理
            //*00#**   
            if (LEFT_TO_RIGHT[0].IsEmpty &&
                    LEFT_TO_RIGHT[1] == OwnPawn &&
                    LEFT_TO_RIGHT[2] == OwnPawn &&
                    LEFT_TO_RIGHT[3].IsEmpty &&
                    LEFT_TO_RIGHT[5].IsEmpty)
            {
                return 9;
            }
            if (LEFT_TO_RIGHT[0].IsEmpty &&
                    LEFT_TO_RIGHT[1] == OwnPawn &&
                    LEFT_TO_RIGHT[2].IsEmpty &&
                    LEFT_TO_RIGHT[3] == OwnPawn &&

                    LEFT_TO_RIGHT[5].IsEmpty)
            {
                return 9;
            }
            if (LEFT_TO_RIGHT[1].IsEmpty &&
                    LEFT_TO_RIGHT[2] == OwnPawn &&
                    LEFT_TO_RIGHT[3].IsEmpty &&

                    LEFT_TO_RIGHT[5] == OwnPawn &&
                    LEFT_TO_RIGHT[6].IsEmpty)
            {
                return 9;
            }
            if (LEFT_TO_RIGHT[2].IsEmpty &&
                  LEFT_TO_RIGHT[3] == OwnPawn &&

                  LEFT_TO_RIGHT[5].IsEmpty &&
                  LEFT_TO_RIGHT[6] == OwnPawn &&
                  LEFT_TO_RIGHT[7].IsEmpty)
            {
                return 9;
            }
            if (LEFT_TO_RIGHT[3].IsEmpty &&
                  LEFT_TO_RIGHT[5].IsEmpty &&
                  LEFT_TO_RIGHT[6] == OwnPawn &&
                  LEFT_TO_RIGHT[7] == OwnPawn &&
                  LEFT_TO_RIGHT[8].IsEmpty)
            {
                return 9;
            }
            if (LEFT_TO_RIGHT[3].IsEmpty &&
                  LEFT_TO_RIGHT[5] == OwnPawn &&
                  LEFT_TO_RIGHT[6].IsEmpty &&
                  LEFT_TO_RIGHT[7] == OwnPawn &&
                  LEFT_TO_RIGHT[8].IsEmpty)
            {
                return 9;
            }
            //三子一头空==================================================
            //100#** 
            if (LEFT_TO_RIGHT[1] == OtherPawn &&
              LEFT_TO_RIGHT[2] == OwnPawn &&
              LEFT_TO_RIGHT[3] == OwnPawn &&

              LEFT_TO_RIGHT[5].IsEmpty &&
              LEFT_TO_RIGHT[6].IsEmpty)
            {
                return 8;
            }
            if (LEFT_TO_RIGHT[2] == OtherPawn &&
              LEFT_TO_RIGHT[3] == OwnPawn &&

              LEFT_TO_RIGHT[5] == OwnPawn &&
              LEFT_TO_RIGHT[6].IsEmpty &&
              LEFT_TO_RIGHT[7].IsEmpty)
            {
                return 8;
            }
            if (LEFT_TO_RIGHT[3] == OtherPawn &&

              LEFT_TO_RIGHT[5] == OwnPawn &&
              LEFT_TO_RIGHT[6] == OwnPawn &&
              LEFT_TO_RIGHT[7].IsEmpty &&
              LEFT_TO_RIGHT[8].IsEmpty)
            {
                return 8;
            }
            if (LEFT_TO_RIGHT[0].IsEmpty &&
              LEFT_TO_RIGHT[1].IsEmpty &&
              LEFT_TO_RIGHT[2] == OwnPawn &&
              LEFT_TO_RIGHT[3] == OwnPawn &&

              LEFT_TO_RIGHT[5] == OtherPawn)
            {
                return 8;
            }
            if (LEFT_TO_RIGHT[1].IsEmpty &&
              LEFT_TO_RIGHT[2].IsEmpty &&
              LEFT_TO_RIGHT[3] == OwnPawn &&

              LEFT_TO_RIGHT[5] == OwnPawn &&
              LEFT_TO_RIGHT[6] == OtherPawn)
            {
                return 8;
            }
            if (LEFT_TO_RIGHT[2].IsEmpty &&
              LEFT_TO_RIGHT[3].IsEmpty &&

              LEFT_TO_RIGHT[5] == OwnPawn &&
              LEFT_TO_RIGHT[6] == OwnPawn &&
              LEFT_TO_RIGHT[7] == OtherPawn)
            {
                return 8;
            }
            //100*#* 
            if (LEFT_TO_RIGHT[0] == OtherPawn &&
                  LEFT_TO_RIGHT[1] == OwnPawn &&
                  LEFT_TO_RIGHT[2] == OwnPawn &&
                  LEFT_TO_RIGHT[3].IsEmpty &&

                  LEFT_TO_RIGHT[5].IsEmpty)
            {
                return 7;
            }
            if (LEFT_TO_RIGHT[0] == OtherPawn &&
                 LEFT_TO_RIGHT[1] == OwnPawn &&
                 LEFT_TO_RIGHT[2].IsEmpty &&
                 LEFT_TO_RIGHT[3] == OwnPawn &&

                 LEFT_TO_RIGHT[5].IsEmpty)
            {
                return 7;
            }
            if (LEFT_TO_RIGHT[1] == OtherPawn &&
                 LEFT_TO_RIGHT[2] == OwnPawn &&
                 LEFT_TO_RIGHT[3].IsEmpty &&

                 LEFT_TO_RIGHT[5] == OwnPawn &&
                 LEFT_TO_RIGHT[6].IsEmpty)
            {
                return 7;
            }
            if (LEFT_TO_RIGHT[2] == OtherPawn &&
                  LEFT_TO_RIGHT[3] == OwnPawn &&

                  LEFT_TO_RIGHT[5].IsEmpty &&
                  LEFT_TO_RIGHT[6] == OwnPawn &&
                  LEFT_TO_RIGHT[7].IsEmpty)
            {
                return 7;
            }
            if (LEFT_TO_RIGHT[3] == OtherPawn &&
                  LEFT_TO_RIGHT[5].IsEmpty &&

                  LEFT_TO_RIGHT[6] == OwnPawn &&
                  LEFT_TO_RIGHT[7] == OwnPawn &&
                  LEFT_TO_RIGHT[8].IsEmpty)
            {
                return 7;
            }
            if (LEFT_TO_RIGHT[3] == OtherPawn &&

                  LEFT_TO_RIGHT[5] == OwnPawn &&
                  LEFT_TO_RIGHT[6].IsEmpty &&
                  LEFT_TO_RIGHT[7] == OwnPawn &&
                  LEFT_TO_RIGHT[8].IsEmpty)
            {
                return 7;
            }


            if (LEFT_TO_RIGHT[0].IsEmpty &&
                  LEFT_TO_RIGHT[1] == OwnPawn &&
                  LEFT_TO_RIGHT[2] == OwnPawn &&
                  LEFT_TO_RIGHT[3].IsEmpty &&
                  LEFT_TO_RIGHT[5] == OtherPawn)
            {
                return 7;
            }
            if (LEFT_TO_RIGHT[0].IsEmpty &&
                  LEFT_TO_RIGHT[1] == OwnPawn &&
                  LEFT_TO_RIGHT[3] == OwnPawn &&
                  LEFT_TO_RIGHT[2].IsEmpty &&
                  LEFT_TO_RIGHT[5] == OtherPawn)
            {
                return 7;
            }
            if (LEFT_TO_RIGHT[1].IsEmpty &&
                  LEFT_TO_RIGHT[2] == OwnPawn &&
                  LEFT_TO_RIGHT[5] == OwnPawn &&
                  LEFT_TO_RIGHT[3].IsEmpty &&
                  LEFT_TO_RIGHT[6] == OtherPawn)
            {
                return 7;
            }
            if (LEFT_TO_RIGHT[2].IsEmpty &&
                  LEFT_TO_RIGHT[3] == OwnPawn &&
                  LEFT_TO_RIGHT[6] == OwnPawn &&
                  LEFT_TO_RIGHT[5].IsEmpty &&
                  LEFT_TO_RIGHT[7] == OtherPawn)
            {
                return 7;
            }
            if (LEFT_TO_RIGHT[3].IsEmpty &&
                  LEFT_TO_RIGHT[6] == OwnPawn &&
                  LEFT_TO_RIGHT[7] == OwnPawn &&
                  LEFT_TO_RIGHT[5].IsEmpty &&
                  LEFT_TO_RIGHT[8] == OtherPawn)
            {
                return 7;
            }
            if (LEFT_TO_RIGHT[3].IsEmpty &&
                  LEFT_TO_RIGHT[5] == OwnPawn &&
                  LEFT_TO_RIGHT[7] == OwnPawn &&
                  LEFT_TO_RIGHT[6].IsEmpty &&
                  LEFT_TO_RIGHT[8] == OtherPawn)
            {
                return 7;
            }
            //特殊状态的冲三
            //#**00
            if (LEFT_TO_RIGHT[7] == OwnPawn &&
                  LEFT_TO_RIGHT[8] == OwnPawn &&
                  LEFT_TO_RIGHT[5].IsEmpty &&
                  LEFT_TO_RIGHT[6].IsEmpty)
            {
                return 7;
            }
            if (LEFT_TO_RIGHT[0] == OwnPawn &&
                  LEFT_TO_RIGHT[1] == OwnPawn &&
                  LEFT_TO_RIGHT[2].IsEmpty &&
                  LEFT_TO_RIGHT[3].IsEmpty)
            {
                return 7;
            }
            //三子两头堵====================================
            //100#1
            if (LEFT_TO_RIGHT[1] == OtherPawn &&
                LEFT_TO_RIGHT[2] == OwnPawn &&
                LEFT_TO_RIGHT[3] == OwnPawn &&

                LEFT_TO_RIGHT[5] == OtherPawn)
            {
                return 0;
            }
            if (LEFT_TO_RIGHT[2] == OtherPawn &&
                LEFT_TO_RIGHT[3] == OwnPawn &&

                LEFT_TO_RIGHT[5] == OwnPawn &&
                LEFT_TO_RIGHT[6] == OtherPawn)
            {
                return 0;
            }
            if (LEFT_TO_RIGHT[3] == OtherPawn &&

                LEFT_TO_RIGHT[5] == OwnPawn &&
                LEFT_TO_RIGHT[6] == OwnPawn &&
                LEFT_TO_RIGHT[7] == OtherPawn)
            {
                return 0;
            }

            //两子两头空==========================================
            //0*0*#*
            if (LEFT_TO_RIGHT[0] == OwnPawn &&
                 LEFT_TO_RIGHT[1].IsEmpty &&
                  LEFT_TO_RIGHT[2] == OwnPawn &&
                  LEFT_TO_RIGHT[3].IsEmpty &&
                  LEFT_TO_RIGHT[5].IsEmpty)
            {
                return 6;
            }
            if (LEFT_TO_RIGHT[3].IsEmpty &&
                  LEFT_TO_RIGHT[6] == OwnPawn &&
                  LEFT_TO_RIGHT[5].IsEmpty &&
                  LEFT_TO_RIGHT[7].IsEmpty &&
                  LEFT_TO_RIGHT[8] == OwnPawn)
            {
                return 6;
            }
            //*1#*
            if (LEFT_TO_RIGHT[2].IsEmpty &&
                  LEFT_TO_RIGHT[3] == OwnPawn &&
                  LEFT_TO_RIGHT[5].IsEmpty)
            {
                return 5;
            }
            if (LEFT_TO_RIGHT[3].IsEmpty &&
                  LEFT_TO_RIGHT[5] == OwnPawn &&
                  LEFT_TO_RIGHT[6].IsEmpty)
            {
                return 5;
            }
            if (LEFT_TO_RIGHT[1].IsEmpty &&
                  LEFT_TO_RIGHT[2] == OwnPawn &&
                  LEFT_TO_RIGHT[3].IsEmpty &&
                  LEFT_TO_RIGHT[5].IsEmpty)
            {
                return 5;
            }
            if (LEFT_TO_RIGHT[3].IsEmpty &&
                  LEFT_TO_RIGHT[6] == OwnPawn &&
                  LEFT_TO_RIGHT[5].IsEmpty &&
                  LEFT_TO_RIGHT[7].IsEmpty)
            {
                return 5;
            }
            if (LEFT_TO_RIGHT[0].IsEmpty &&
                LEFT_TO_RIGHT[1] == OwnPawn &&
                  LEFT_TO_RIGHT[2].IsEmpty &&
                  LEFT_TO_RIGHT[3].IsEmpty &&
                  LEFT_TO_RIGHT[5].IsEmpty)
            {
                return 5;
            }
            if (LEFT_TO_RIGHT[3].IsEmpty &&
                LEFT_TO_RIGHT[7] == OwnPawn &&
                  LEFT_TO_RIGHT[6].IsEmpty &&
                  LEFT_TO_RIGHT[5].IsEmpty &&
                  LEFT_TO_RIGHT[8].IsEmpty)
            {
                return 5;
            }
            //两子一头空==============================================
            //10#*
            if (LEFT_TO_RIGHT[2] == OtherPawn &&
                  LEFT_TO_RIGHT[3] == OwnPawn &&
                  LEFT_TO_RIGHT[5].IsEmpty)
            {
                return 4;
            }
            if (LEFT_TO_RIGHT[3] == OtherPawn &&
                  LEFT_TO_RIGHT[5] == OwnPawn &&
                  LEFT_TO_RIGHT[6].IsEmpty)
            {
                return 4;
            }
            if (LEFT_TO_RIGHT[2].IsEmpty &&
                  LEFT_TO_RIGHT[3] == OwnPawn &&
                  LEFT_TO_RIGHT[5] == OtherPawn)
            {
                return 4;
            }
            if (LEFT_TO_RIGHT[3].IsEmpty &&
                  LEFT_TO_RIGHT[5] == OwnPawn &&
                  LEFT_TO_RIGHT[6] == OtherPawn)
            {
                return 4;
            }
            //1#*0*
            if (LEFT_TO_RIGHT[3] == OtherPawn &&
                  LEFT_TO_RIGHT[6] == OwnPawn &&
                  LEFT_TO_RIGHT[5].IsEmpty &&
                  LEFT_TO_RIGHT[7].IsEmpty)
            {
                return 3;
            }
            if (LEFT_TO_RIGHT[1] == OtherPawn &&
                  LEFT_TO_RIGHT[2] == OwnPawn &&
                  LEFT_TO_RIGHT[3].IsEmpty &&
                  LEFT_TO_RIGHT[5].IsEmpty)
            {
                return 3;
            }
            if (LEFT_TO_RIGHT[5] == OtherPawn &&
                  LEFT_TO_RIGHT[2] == OwnPawn &&
                  LEFT_TO_RIGHT[3].IsEmpty &&
                  LEFT_TO_RIGHT[1].IsEmpty)
            {
                return 3;
            }
            if (LEFT_TO_RIGHT[7] == OtherPawn &&
                  LEFT_TO_RIGHT[6] == OwnPawn &&
                  LEFT_TO_RIGHT[5].IsEmpty &&
                  LEFT_TO_RIGHT[3].IsEmpty)
            {
                return 3;
            }
            //两子两头堵10#1
            if (LEFT_TO_RIGHT[2] == OtherPawn &&
                  LEFT_TO_RIGHT[3] == OwnPawn &&
                  LEFT_TO_RIGHT[5] == OtherPawn)
            {
                return 0;
            }
            if (LEFT_TO_RIGHT[3] == OtherPawn &&
                  LEFT_TO_RIGHT[5] == OwnPawn &&
                  LEFT_TO_RIGHT[6] == OtherPawn)
            {
                return 0;
            }
            //一子两头空*#*
            if (LEFT_TO_RIGHT[3].IsEmpty &&
                  LEFT_TO_RIGHT[5].IsEmpty)
            {
                return 1;
            }
            //一子一头空1#*
            if (LEFT_TO_RIGHT[3] == OtherPawn &&
                  LEFT_TO_RIGHT[5].IsEmpty)
            {
                return 2;
            }
            if (LEFT_TO_RIGHT[3].IsEmpty &&
                  LEFT_TO_RIGHT[5] == OtherPawn)
            {
                return 2;
            }
            //一子两头堵1#1
            if (LEFT_TO_RIGHT[3] == OtherPawn &&
                  LEFT_TO_RIGHT[5] == OtherPawn)
            {
                return 0;
            }
            return 1;

        }

        

        private Chessman GetClassChessMan(int m_x, int m_y, GobangPlayer m_player)
        {
            if (m_x >= 0 && m_x < 21 && m_y >= 0 && m_y < 21)
            {
                return main_chess[m_x, m_y];
            }
            else
            {
                if (m_player == GobangPlayer.Player1)
                {
                    return new Chessman()
                    {
                        GoBangPlayer = GobangPlayer.Player2
                    };
                }
                else
                {
                    return new Chessman()
                    {
                        GoBangPlayer = GobangPlayer.Player1
                    };
                }
           
            }

        }


        ///====================================================================================//
        /// <summary>
        /// 对于棋手来说每个点的得分
        /// </summary>
        public void CalculateAllPoints()
        {
            for (int i = 0; i < 21; i++)
            {
                for (int j = 0; j < 21; j++)
                {
                    main_chess[i, j].WeightScore = GetWeight(i, j, GobangPlayer.Player2).TotalWeight;
                }
            }
        }
    }
}
