using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
namespace GameSwiper
{


    public partial class Form1 : Form
    {
        public const int FieldCellWidth = 30;
        public const int FieldCellHeight = 25;
        public Random rand = new Random();
        public int[,] Field;
        public int FlagCounter;
        public int StepCounter;
        public Form1()
        {

            InitializeComponent();
            PlayGround.ColumnHeadersVisible = false;
            PlayGround.RowHeadersVisible = false;
            Difficulty.SelectedIndex = 0;

        }

        private void DataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (PlayGround[e.ColumnIndex, e.RowIndex].Value == "F")
                {
                    return;
                }

                else if (PlayGround[e.ColumnIndex, e.RowIndex].Value == null)
                {
                    StepCounter--;
                    PlayGround[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.Gray;
                    PlayGround[e.ColumnIndex, e.RowIndex].Style.ForeColor = Color.White;
                    PlayGround[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Gray;
                    PlayGround[e.ColumnIndex, e.RowIndex].Style.SelectionForeColor = Color.White;
                    PlayGround[e.ColumnIndex, e.RowIndex].Value = Field[e.ColumnIndex, e.RowIndex];
                    if (Field[e.ColumnIndex, e.RowIndex] < 0)
                    {
                        PlayGround[e.ColumnIndex, e.RowIndex].Value = "Mine";
                        MessageBox.Show("You lost", "Lost", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ResetGame_Click(sender, e);
                    }
                    else if (StepCounter == 0)
                    {
                        MessageBox.Show("You win", "win", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ResetGame_Click(sender, e);
                    }
                    else if (Field[e.ColumnIndex, e.RowIndex] == 0)
                    {
                        if (ExistCellTop(e.RowIndex, e.ColumnIndex))
                        {
                            if (PlayGround[e.ColumnIndex, e.RowIndex - 1].Value == null)
                            {
                                DataGridViewCellMouseEventArgs e1 = new DataGridViewCellMouseEventArgs(e.ColumnIndex, e.RowIndex - 1, (e.X - FieldCellWidth), e.Y, e);
                                DataGridView1_CellMouseClick(sender, e1);
                            }
                        }

                        if (ExistCellTopRight(e.RowIndex, e.ColumnIndex))
                        {
                            if (PlayGround[e.ColumnIndex + 1, e.RowIndex - 1].Value == null)
                            {
                                DataGridViewCellMouseEventArgs e1 = new DataGridViewCellMouseEventArgs(e.ColumnIndex + 1, e.RowIndex - 1, (e.X - FieldCellWidth), e.Y + FieldCellHeight, e);
                                DataGridView1_CellMouseClick(sender, e1);
                            }
                        }

                        if (ExistCellRight(e.RowIndex, e.ColumnIndex))
                        {
                            if (PlayGround[e.ColumnIndex + 1, e.RowIndex].Value == null)
                            {
                                DataGridViewCellMouseEventArgs e1 = new DataGridViewCellMouseEventArgs(e.ColumnIndex + 1, e.RowIndex, (e.X + FieldCellWidth), e.Y, e);
                                DataGridView1_CellMouseClick(sender, e1);
                            }
                        }

                        if (ExistCellBottomRight(e.RowIndex, e.ColumnIndex))
                        {
                            if (PlayGround[e.ColumnIndex + 1, e.RowIndex + 1].Value == null)
                            {
                                DataGridViewCellMouseEventArgs e1 = new DataGridViewCellMouseEventArgs(e.ColumnIndex + 1, e.RowIndex + 1, (e.X + FieldCellWidth), e.Y + FieldCellHeight, e);
                                DataGridView1_CellMouseClick(sender, e1);
                            }
                        }

                        if (ExistCellBottom(e.RowIndex, e.ColumnIndex))
                        {
                            if (PlayGround[e.ColumnIndex, e.RowIndex + 1].Value == null)
                            {
                                DataGridViewCellMouseEventArgs e1 = new DataGridViewCellMouseEventArgs(e.ColumnIndex, e.RowIndex + 1, (e.X), e.Y + FieldCellHeight, e);
                                DataGridView1_CellMouseClick(sender, e1);
                            }
                        }

                        if (ExistCellBottomLeft(e.RowIndex, e.ColumnIndex))
                        {
                            if (PlayGround[e.ColumnIndex - 1, e.RowIndex + 1].Value == null)
                            {
                                DataGridViewCellMouseEventArgs e1 = new DataGridViewCellMouseEventArgs(e.ColumnIndex - 1, e.RowIndex + 1, (e.X - FieldCellWidth), e.Y + FieldCellHeight, e);
                                DataGridView1_CellMouseClick(sender, e1);
                            }
                        }

                        if (ExistCellLeft(e.RowIndex, e.ColumnIndex))
                        {
                            if (PlayGround[e.ColumnIndex - 1, e.RowIndex].Value == null)
                            {
                                DataGridViewCellMouseEventArgs e1 = new DataGridViewCellMouseEventArgs(e.ColumnIndex - 1, e.RowIndex, (e.X), e.Y - FieldCellHeight, e);
                                DataGridView1_CellMouseClick(sender, e1);
                            }
                        }

                        if (ExistCellTopLeft(e.RowIndex, e.ColumnIndex))
                        {
                            if (PlayGround[e.ColumnIndex - 1, e.RowIndex - 1].Value == null)
                            {
                                DataGridViewCellMouseEventArgs e1 = new DataGridViewCellMouseEventArgs(e.ColumnIndex - 1, e.RowIndex - 1, (e.X - FieldCellWidth), e.Y - FieldCellHeight, e);
                                DataGridView1_CellMouseClick(sender, e1);
                            }
                        }
                    }
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (PlayGround[e.ColumnIndex, e.RowIndex].Value == "F")
                {
                    PlayGround[e.ColumnIndex, e.RowIndex].Value = null;
                    FlagCounter++;
                    FlagCounter_TextBox.Text = FlagCounter.ToString();
                }
                else if (PlayGround[e.ColumnIndex, e.RowIndex].Value == null && FlagCounter > 0)
                {
                    PlayGround[e.ColumnIndex, e.RowIndex].Value = "F";
                    FlagCounter--;
                    FlagCounter_TextBox.Text = FlagCounter.ToString();
                }
            }
        }


        private void ResetGame_Click(object sender, EventArgs e)
        {
            Difficulty_SelectedIndexChanged(sender, e);
        }

        public void Difficulty_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Difficulty.SelectedIndex == 0) //Easy level
            {
                FieldRows = 9;
                FieldCols = 9;
                FieldMines = 10;
            }
            else if (Difficulty.SelectedIndex == 1) //Normal level
            {
                FieldRows = 16;
                FieldCols = 16;
                FieldMines = 40;
            }
            else if (Difficulty.SelectedIndex == 2) // Hard level
            {
                FieldRows = 30;
                FieldCols = 16;
                FieldMines = 99;
            }
            StepCounter = FieldRows * FieldCols - FieldMines;
            FlagCounter = FieldMines;
            FlagCounter_TextBox.Text = FieldMines.ToString();
            SetFieldMines();
            PlayGround.Rows.Clear();
            PlayGround.Columns.Clear();
            SetFieldSize();

        }
        public void SetFieldSize()
        {
            for (int i = PlayGround.ColumnCount; i < FieldCols; i++)
            {
                DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
                dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridViewCellStyle.BackColor = Color.White;
                dataGridViewCellStyle.ForeColor = Color.Black;
                dataGridViewCellStyle.SelectionBackColor = Color.White;
                dataGridViewCellStyle.SelectionForeColor = Color.Black;

                DataGridViewButtonColumn ColumnAdd = new DataGridViewButtonColumn();
                ColumnAdd.Name = "Column" + (i + 1);
                ColumnAdd.HeaderText = "Column" + (i + 1);
                ColumnAdd.DefaultCellStyle = dataGridViewCellStyle;
                ColumnAdd.Width = FieldCellWidth;
                ColumnAdd.FlatStyle = FlatStyle.Popup;
                PlayGround.Columns.Add(ColumnAdd);
            }
            PlayGround.Width = (PlayGround.ColumnCount + 1) * FieldCellWidth;

            for (int i = PlayGround.RowCount; i < FieldRows; i++)
            {
                PlayGround.Rows.Add();
                PlayGround.Rows[i].Height = FieldCellHeight;
            }
            PlayGround.Height = (PlayGround.RowCount + 1) * FieldCellHeight;
        }

        //Generate Mines and Field
        public void SetFieldMines()
        {
            Field = new int[FieldCols, FieldRows];
            List<int[,]> Mines = new List<int[,]>(FieldMines);
            int RandMinesCount = 0;

            do
            {
                int[,] mine = new int[1, 2]; //почему я не могу это объявление вынести за пределы do, чтобы не забивать память??? Если за пределами do - считает что один и тот же массив

                mine[0, 0] = rand.Next(0, FieldRows);
                mine[0, 1] = rand.Next(0, FieldCols);
                //mine[0, 0] = 4;
                //mine[0, 1] = 8;


                if (MinesDublicateCheck(Mines, mine))
                {
                    Mines.Add(mine);
                    RandMinesCount++;
                }
            } while (RandMinesCount < FieldMines);

            //Mines.Sort();
            foreach (var m in Mines)
            {
                Field[m[0, 0], m[0, 1]] = -50; //Number for mine

                //Доавление счетчика кол-ва мин во все ячейки вокруг мины по часовой стрелке
                if (ExistCellTop(m[0, 0], m[0, 1]))
                {
                    Field[m[0, 0] - 1, m[0, 1]]++;
                }

                if (ExistCellTopRight(m[0, 0], m[0, 1]))
                {
                    Field[m[0, 0] - 1, m[0, 1] + 1]++;
                }

                if (ExistCellRight(m[0, 0], m[0, 1]))
                {
                    Field[m[0, 0], m[0, 1] + 1]++;
                }

                if (ExistCellBottomRight(m[0, 0], m[0, 1]))
                {
                    Field[m[0, 0] + 1, m[0, 1] + 1]++;
                }

                if (ExistCellBottom(m[0, 0], m[0, 1]))
                {
                    Field[m[0, 0] + 1, m[0, 1]]++;
                }

                if (ExistCellBottomLeft(m[0, 0], m[0, 1]))
                {
                    Field[m[0, 0] + 1, m[0, 1] - 1]++;
                }

                if (ExistCellLeft(m[0, 0], m[0, 1]))
                {
                    Field[m[0, 0], m[0, 1] - 1]++;
                }

                if (ExistCellTopLeft(m[0, 0], m[0, 1]))
                {
                    Field[m[0, 0] - 1, m[0, 1] - 1]++;
                }
            }

        }

        public bool MinesDublicateCheck(List<int[,]> MinesStack, int[,] mine)
        {
            foreach (var m in MinesStack)
            {
                //if (m.Equals(mine)) поч????
                if (m[0, 0] == mine[0, 0] && m[0, 1] == mine[0, 1])
                {
                    return false;
                }
            }
            return true;
        }


        private void ExitButtom_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //public partial class Form1 : Form
        //{

        int x;
        int y;
        public bool ExistCellTop(int x, int y)
        {
            if ((x - 1) >= 0)
            {
                return true;
            }
            return false;
        }

        public bool ExistCellTopRight(int x, int y)
        {
            if ((x - 1) >= 0 && (y + 1) < FieldCols)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ExistCellRight(int x, int y)
        {
            if ((y + 1) < FieldCols)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ExistCellBottomRight(int x, int y)
        {
            if ((x + 1) < FieldRows && (y + 1) < FieldCols)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ExistCellBottom(int x, int y)
        {
            if ((x + 1) < FieldRows)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ExistCellBottomLeft(int x, int y)
        {
            if ((x + 1) < FieldRows && (y - 1) >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ExistCellLeft(int x, int y)
        {
            if ((y - 1) >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ExistCellTopLeft(int x, int y)
        {
            if ((x - 1) >= 0 && (y - 1) >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //}
    }
}