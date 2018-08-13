using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gobang
{
    public partial class Gobang : Form
    {

        /// <summary>
        /// 鼠标是否在棋子上
        /// 在焦点（-10，10）
        /// </summary>
        private bool IsMouseHoverOnChess { get; set; } = true;

        /// <summary>
        /// 棋盘位置，从0开始笛卡尔第一象限
        /// </summary>
        private Point MouseActivePosition { get; set; } = new Point(-1, -1);
        /// <summary>
        /// 上一次棋子的位置
        /// </summary>
        private Point LastPressPosition { get; set; } = new Point(-1, -1);
        private bool IsGamePlaying { get; set; } = false;
        private int PawnIndex { set; get; } = 0;
        private StringFormat StringFormatCenter { get; set; } = new StringFormat()
        {
            Alignment=StringAlignment.Center,
            LineAlignment=StringAlignment.Center,
        };

        private GobangPlayer CurrentPlayer { set; get; } = GobangPlayer.Player1;
        private Point LastPointOfPlayerUser { set; get; } = new Point(-1, -1);

        private Chessman[,] main_chess = new Chessman[21, 21];

        private ComputerAI_Du computerAI_Du = null;
        public Gobang()
        {
            InitializeComponent();
        }
        private void Gobang_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 21; i++)
            {
                for (int j = 0; j < 21; j++)
                {
                    main_chess[i, j] = new Chessman();
                }
            }
            computerAI_Du = new ComputerAI_Du(main_chess);
        }
        private void Gobang_Shown(object sender, EventArgs e)
        {
            backgroundpicture.Image = GetBackgroundBitmap();
        }
        /// <summary>
        /// 获取背景图片
        /// </summary>
        /// <returns>图片</returns>
        private Bitmap GetBackgroundBitmap()
        {
            Bitmap bt = new Bitmap(524, 524);
            Graphics e = Graphics.FromImage(bt);
            e.Clear(Color.White);
            Pen pen = Pens.LightGray;
            for (int i = 0; i < 21; i++)
            {
                e.DrawLine(pen, new Point(12, 12 + i * 25), new Point(512, 12 + i * 25));
                e.DrawLine(pen, new Point(12 + i * 25, 12), new Point(12 + i * 25, 512));
            }
            e.Dispose();
            return bt;
        }

        private void backgroundpicture_MouseMove(object sender, MouseEventArgs e)
        {

            if ((e.X - 12) % 25 > 10 && (e.X - 12) % 25 < 15 ||
                (e.Y - 12) % 25 > 10 && (e.Y - 12) % 25 < 15 ||
                e.X > 522 ||
                e.Y > 522)
            {
                IsMouseHoverOnChess = false;
                backgroundpicture.Refresh();
                return;
            }
            MouseActivePosition = MouseMovePoint(e.X, e.Y);
            IsMouseHoverOnChess = !IsPositionHasPawn(MouseActivePosition);
            backgroundpicture.Refresh();
        }




        private bool IsPositionHasPawn(Point point)
        {
            return IsPositionHasPawn(point.X, point.Y);
        }

        private bool IsPositionHasPawn(int x, int y)
        {

            if (x >= 0 && x < 21 && y >= 0 && y < 21)
            {
                return main_chess[x,y].GoBangPlayer != GobangPlayer.NoPlayer;//判断是否在棋子上
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 转换成棋盘位置
        /// </summary>
        /// <param name="picture_x">e.x</param>
        /// <param name="picture_y">e.y</param>
        /// <returns>棋盘位置</returns>
        private Point MouseMovePoint(int picture_x, int picture_y)
        {
            int m_x = (picture_x-2) / 25;//棋盘位置，每个棋相当于占用（-10，15）
            int m_y = (picture_y-2) / 25;
            m_y = 20 - m_y;
            return new Point(m_x, m_y);
        }

        private void backgroundpicture_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            for (int i = 0; i < 21; i++)
            {
                for (int j = 0; j < 21; j++)
                {
                    int m_x = i * 25 + 12;
                    int m_y = (20 - j) * 25 + 12;
                    if (main_chess[i, j].GoBangPlayer == GobangPlayer.NoPlayer)
                    {
                        if (showScore.Checked)
                        {
                            Rectangle m_rect = new Rectangle(m_x - 20, m_y - 10, 40, 20);
                            using (Font fontSmall = new Font("Microsoft YaHei UI", 8))
                            {
                                g.DrawString(main_chess[i, j].WeightScore.ToString(), fontSmall, Brushes.Gray, m_rect, StringFormatCenter);
                            }
                        }
                    }
                    else
                    {
                        Rectangle m_rect = new Rectangle(m_x - 10, m_y - 10, 20, 20);
                        g.FillEllipse(main_chess[i, j].GetPawnBrush, m_rect);
                        g.DrawEllipse(Pens.DimGray, m_rect);
                        m_rect.Offset(-10, 0);
                        m_rect.Width += 20;
                        if (showStep.Checked)
                        {
                            using (Font fontSmall = new Font("Microsoft YaHei UI", 8))
                            {
                                g.DrawString(main_chess[i, j].StepNumber.ToString(), fontSmall, Brushes.White, m_rect, StringFormatCenter);
                            }
                        }
                    }
                }
            }
            if (IsMouseHoverOnChess)
            {
                PaintMarkPoint(g, MouseActivePosition);
            }
            if (!showStep.Checked)
            {

            }
        }
        
        /// <summary>
        /// 绘制标识
        /// </summary>
        /// <param name="g">画布</param>
        /// <param name="point">棋盘点位</param>
        private void PaintMarkPoint(Graphics g, Point point)
        {
            if (point.X < 0 || point.Y < 0)
            {
                return;
            }
            int temx = point.X * 25 + 12;
            int temy = 12 + (20 - point.Y) * 25;
            Pen pen = Pens.LightGray;

            if (point.X > 0 && point.Y > 0 && point.X < 20 && point.Y < 20)
            {
                g.DrawLines(pen, new Point[]
                    {
                        new Point(temx-9,temy+3),
                        new Point(temx-3,temy+3),
                        new Point(temx-3,temy+9)
                    });//第三象限
                g.DrawLines(pen, new Point[]
                    {
                        new Point(temx+3,temy+9),
                        new Point(temx+3,temy+3),
                        new Point(temx+9,temy+3)
                    });//第四象限
                g.DrawLines(pen, new Point[]
                    {
                        new Point(temx+3,temy-9),
                        new Point(temx+3,temy-3),
                        new Point(temx+9,temy-3)
                    });//第一象限
                g.DrawLines(pen, new Point[]
                    {
                        new Point(temx-9,temy-3),
                        new Point(temx-3,temy-3),
                        new Point(temx-3,temy-9)
                    });//第二象限
            }
            else if (point.X == 0 && point.Y == 0)
            {
                g.DrawLines(pen, new Point[]
                    {
                        new Point(temx+3,temy-9),
                        new Point(temx+3,temy-3),
                        new Point(temx+9,temy-3)
                    });//第一象限
            }
            else if (point.X == 20 && point.Y == 0)
            {
                g.DrawLines(pen, new Point[]
                    {
                        new Point(temx-9,temy-3),
                        new Point(temx-3,temy-3),
                        new Point(temx-3,temy-9)
                    });//第二象限
            }
            else if (point.X == 20 && point.Y == 20)
            {
                g.DrawLines(pen, new Point[]
                     {
                        new Point(temx-9,temy+3),
                        new Point(temx-3,temy+3),
                        new Point(temx-3,temy+9)
                     });//第三象限
            }
            else if (point.X == 0 && point.Y == 20)
            {
                g.DrawLines(pen, new Point[]
                   {
                        new Point(temx+3,temy+9),
                        new Point(temx+3,temy+3),
                        new Point(temx+9,temy+3)
                   });//第四象限
            }
            else if (point.X == 0 && point.Y != 20 && point.Y!=0)
            {
                g.DrawLines(pen, new Point[]
                   {
                        new Point(temx+3,temy+9),
                        new Point(temx+3,temy+3),
                        new Point(temx+9,temy+3)
                   });//第四象限
                g.DrawLines(pen, new Point[]
                    {
                        new Point(temx+3,temy-9),
                        new Point(temx+3,temy-3),
                        new Point(temx+9,temy-3)
                    });//第一象限
            }
            else if (point.X == 20 && point.Y != 20 && point.Y != 0)
            {
                g.DrawLines(pen, new Point[]
                    {
                        new Point(temx-9,temy-3),
                        new Point(temx-3,temy-3),
                        new Point(temx-3,temy-9)
                    });//第二象限
                g.DrawLines(pen, new Point[]
                    {
                        new Point(temx-9,temy+3),
                        new Point(temx-3,temy+3),
                        new Point(temx-3,temy+9)
                    });//第三象限
            }
            else if (point.Y == 0 && point.X != 20 && point.X != 0)
            {
                g.DrawLines(pen, new Point[]
                    {
                        new Point(temx+3,temy-9),
                        new Point(temx+3,temy-3),
                        new Point(temx+9,temy-3)
                    });//第一象限
                g.DrawLines(pen, new Point[]
                    {
                        new Point(temx-9,temy-3),
                        new Point(temx-3,temy-3),
                        new Point(temx-3,temy-9)
                    });//第二象限
            }
            else if (point.Y == 20 && point.X != 20 && point.X != 0)
            {
                g.DrawLines(pen, new Point[]
                    {
                        new Point(temx-9,temy+3),
                        new Point(temx-3,temy+3),
                        new Point(temx-3,temy+9)
                    });//第三象限
                g.DrawLines(pen, new Point[]
                    {
                        new Point(temx+3,temy+9),
                        new Point(temx+3,temy+3),
                        new Point(temx+9,temy+3)
                    });//第四象限
            }
        }

        private void startGame_Click(object sender, EventArgs e)
        {
            StartGame();
        }

        private void StartGame()
        {
            for (int i = 0; i < 21; i++)
            {
                for (int j = 0; j < 21; j++)
                {
                    main_chess[i, j].GoBangPlayer = GobangPlayer.NoPlayer;
                    main_chess[i, j].StepNumber = 0;
                    main_chess[i, j].WeightScore = 0;
                }
            }
            HistoryData.Items.Clear();
            IsGamePlaying = true;
            CurrentPlayer = GobangPlayer.NoPlayer;
            PawnIndex = 1;
            if (ComputerFirst.Checked)
            {
                
                SetPointPawn(new Point(10, 10), GobangPlayer.Player1);
                AddHistoryData(new Point(10, 10));
            }
            toolStripStatusLabel1.Text = "Waiting";
            backgroundpicture.Refresh();
        }

        private void SetPointPawn(Point point, GobangPlayer player1)
        {
            main_chess[point.X, point.Y].GoBangPlayer = player1;
            main_chess[point.X, point.Y].StepNumber = PawnIndex++;
            LastPressPosition = point;
            CurrentPlayer = player1;
            if (player1 == GobangPlayer.Player1)
            {
                computerAI_Du.CalculateAllPoints();
            }
        }

        private void backgroundpicture_MouseClick(object sender, MouseEventArgs e)
        {
            if (!IsGamePlaying) return;
            Point point_origin = backgroundpicture.PointToClient(Cursor.Position);
            if ((point_origin.X - 12) % 25 > 10 && (point_origin.X - 12) % 25 < 15 ||
                (point_origin.Y - 12) % 25 > 10 && (point_origin.Y - 12) % 25 < 15 ||
                point_origin.X > 522 ||
                point_origin.Y > 522)
                return;
            Point point = MouseMovePoint(point_origin.X, point_origin.Y);
            if (IsPositionHasPawn(point)) return;
            if (CurrentPlayer != GobangPlayer.Player2)
            {
                SetPointPawn(point, GobangPlayer.Player2);
                AddHistoryData(point);
                LastPointOfPlayerUser = point;
                if (IsGameOver(point.X, point.Y, GobangPlayer.Player2))
                {
                    IsGamePlaying = false;
                    toolStripStatusLabel1.Text = "You Win";
                    PlayerWin.Text = (Convert.ToInt32(PlayerWin.Text) + 1).ToString();
                }
                else
                {
                    ComputerPlayerRunning();
                }
            }
        }
        private async void  ComputerPlayerRunning()
        {
            toolStripStatusLabel1.Text = "Thinking";
            Point computer = await computerAI_Du.CalculateComputerAI();
            SetPointPawn(computer, GobangPlayer.Player1);
            AddHistoryData(computer);
            if (IsGameOver(computer.X, computer.Y, GobangPlayer.Player1))
            {
                toolStripStatusLabel1.Text = "You Lose";
                IsGamePlaying = false;
                ComputerWin.Text = (Convert.ToInt32(ComputerWin.Text) + 1).ToString();
            }
            else
            {
                toolStripStatusLabel1.Text = "You Please";
            }
            backgroundpicture.Refresh();
        }

        private bool IsGameOver(int x, int y, GobangPlayer player)
        {
            int m_lenght = 1;
            int m_x = x;
            int m_y = y;
            GobangPlayer m_play = player;
            for (int j = 0; j < 4; j++)
            {
                m_lenght = 1;
                Point m_Point_1;
                for (int i = 1; i < 5; i++)
                {
                    if (j == 0) m_Point_1 = new Point(m_x - i, m_y);
                    else if (j == 1) m_Point_1 = new Point(m_x, m_y - i);
                    else if (j == 2) m_Point_1 = new Point(m_x - i, m_y + i);
                    else m_Point_1 = new Point(m_x - i, m_y - i);
                    if (IsPositionHasPawn(m_Point_1, player))
                    {
                        m_lenght++;
                    }
                    else
                    {
                        break;
                    }
                }
                for (int i = 1; i < 5; i++)//计算四个棋子
                {
                    if (j == 0) m_Point_1 = new Point(m_x + i, m_y);
                    else if (j == 1) m_Point_1 = new Point(m_x, m_y + i);
                    else if (j == 2) m_Point_1 = new Point(m_x + i, m_y - i);
                    else m_Point_1 = new Point(m_x + i, m_y + i);
                    if (IsPositionHasPawn(m_Point_1, player))
                    {
                        m_lenght++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (m_lenght >= 5) return true;
                m_lenght = 1;
            }
            return false;
        }

        private bool IsPositionHasPawn(Point point, GobangPlayer player)
        {
            return IsPositionHasPawn(point.X, point.Y, player);
        }

        private bool IsPositionHasPawn(int x, int y, GobangPlayer player)
        {
            if (x >= 0 && x < 21 && y >= 0 && y < 21)
            {
                return main_chess[x, y].GoBangPlayer == player;
            }
            else
            {
                return false;
            }
        }

        private async void helpAI_Click(object sender, EventArgs e)
        {
            if (!IsGamePlaying) return;
            toolStripStatusLabel1.Text = "Thinking";
            Point computer = await computerAI_Du.CalculateComputerAI(GobangPlayer.Player2);
            SetPointPawn(computer, GobangPlayer.Player2);
            AddHistoryData(computer);
            if (IsGameOver(computer.X, computer.Y, GobangPlayer.Player2))
            {
                toolStripStatusLabel1.Text = "You Win";
                IsGamePlaying = false;
                PlayerWin.Text = (Convert.ToInt32(PlayerWin.Text) + 1).ToString();
                backgroundpicture.Refresh();
                return;
            }
            else
            {
                ComputerPlayerRunning();
            }

            
        }
        private void AddHistoryData(Point point)
        {
            HistoryData.BeginUpdate();
            HistoryData.Items.Add(point);
            HistoryData.EndUpdate();
                
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!IsGamePlaying) return;
            if (HistoryData.Items.Count > 1)
            {
                Point po1=(Point)HistoryData.Items[HistoryData.Items.Count - 1];
                Point po2 = (Point)HistoryData.Items[HistoryData.Items.Count - 2];
                main_chess[po1.X, po1.Y].GoBangPlayer = GobangPlayer.NoPlayer;
                main_chess[po2.X, po2.Y].GoBangPlayer = GobangPlayer.NoPlayer;
                PawnIndex--;
                PawnIndex--;
                HistoryData.Items.Remove(po1);
                HistoryData.Items.Remove(po2);
                backgroundpicture.Refresh();
            }
        }
    }
}
