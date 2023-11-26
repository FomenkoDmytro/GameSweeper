using Microsoft.VisualBasic;
using System.Diagnostics.Eventing.Reader;
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
        public int ResetIndicator;
        public Form1()
        {

            InitializeComponent();
            PlayGround.ColumnHeadersVisible = false;
            PlayGround.RowHeadersVisible = false;
            Difficulty.SelectedIndex = 0;

        }
        public void FieldMouseLeftClick(int x, int y)
        {

            if (PlayGround[y, x].Value == "F")
            {
                return;
            }

            else if (PlayGround[y, x].Value == null)
            {
                StepCounter--;
                PlayGround[y, x].Style.BackColor = Color.Gray;
                PlayGround[y, x].Style.ForeColor = Color.White;
                PlayGround[y, x].Style.SelectionBackColor = Color.Gray;
                PlayGround[y, x].Style.SelectionForeColor = Color.White;
                PlayGround[y, x].Value = Field[x, y];
                if (Field[x, y] < 0)
                {
                    PlayGround[y, x].Value = "Mine";
                    MessageBox.Show("You lost", "Lost", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetIndicator = 1;
                    return;
                }
                if (StepCounter == 0)
                {
                    MessageBox.Show("You won", "won", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetIndicator = 1;
                    return;
                }


                if (Field[x, y] == 0)
                {
                    if (IsCellExist(x - 1, y))
                    {
                        if (PlayGround[y, x - 1].Value == null)
                        {
                            FieldMouseLeftClick(x - 1, y);
                        }
                    }

                    if (IsCellExist(x - 1, y + 1))
                    {
                        if (PlayGround[y + 1, x - 1].Value == null)
                        {
                            FieldMouseLeftClick(x + 1, y + 1);
                        }
                    }

                    if (IsCellExist(x, y + 1))
                    {
                        if (PlayGround[y + 1, x].Value == null)
                        {
                            FieldMouseLeftClick(x, y + 1);
                        }
                    }

                    if (IsCellExist(x + 1, y + 1))
                    {
                        if (PlayGround[y + 1, x + 1].Value == null)
                        {
                            FieldMouseLeftClick(x + 1, y + 1);
                        }
                    }

                    if (IsCellExist(x + 1, y))
                    {
                        if (PlayGround[y, x + 1].Value == null)
                        {
                            FieldMouseLeftClick(x + 1, y);
                        }
                    }

                    if (IsCellExist(x + 1, y - 1))
                    {
                        if (PlayGround[y - 1, x + 1].Value == null)
                        {
                            FieldMouseLeftClick(x + 1, y - 1);
                        }
                    }

                    if (IsCellExist(x, y - 1))
                    {
                        if (PlayGround[y - 1, x].Value == null)
                        {
                            FieldMouseLeftClick(x, y - 1);
                        }
                    }

                    if (IsCellExist(x - 1, y - 1))
                    {
                        if (PlayGround[y - 1, x - 1].Value == null)
                        {
                            FieldMouseLeftClick(x - 1, y - 1);
                        }
                    }
                }
            }


        }

        public void FieldMouseRightClick(int x, int y)
        {
            if (PlayGround[y, x].Value == "F")
            {
                PlayGround[y, x].Value = null;
                FlagCounter++;
                FlagCounter_TextBox.Text = FlagCounter.ToString();
            }
            else if (PlayGround[y, x].Value == null && FlagCounter > 0)
            {
                PlayGround[y, x].Value = "F";
                FlagCounter--;
                FlagCounter_TextBox.Text = FlagCounter.ToString();
            }
        }

        private void DataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                FieldMouseLeftClick(e.RowIndex, e.ColumnIndex);
                if (ResetIndicator == 1)
                {
                    ResetGame_Click(sender, e);
                }
                return;
            }


            else if (e.Button == MouseButtons.Right)
            {
                FieldMouseRightClick(e.RowIndex, e.ColumnIndex);
                return;
            }
        }


        private void ResetGame_Click(object sender, EventArgs e)
        {
            ResetIndicator = 0;
            Difficulty_SelectedIndexChanged(sender, e);
        }

        public void Difficulty_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (Difficulty.SelectedIndex)
            {
                case 0:
                    FieldRows = 9;
                    FieldCols = 9;
                    FieldMines = 10;
                    break;
                case 1:
                    FieldRows = 16;
                    FieldCols = 16;
                    FieldMines = 40;
                    break;
                case 2:
                    FieldRows = 30;
                    FieldCols = 16;
                    FieldMines = 99;
                    break;
                case 3:
                    int UserFieldRows;
                    int UserFieldColumns;
                    int UserFieldMiness;

                    string CustomRows;
                    string CustomCols;
                    string CustomMines;

                    do
                    {
                        CustomRows = Interaction.InputBox("Write number of rows", "number of rows", "");
                    } while (!int.TryParse(CustomRows, out UserFieldRows));

                    do
                    {
                        CustomCols = Interaction.InputBox("Write number of columns", "number of columns", "");
                    } while (!int.TryParse(CustomCols, out UserFieldColumns));

                    do
                    {
                        CustomMines = Interaction.InputBox("Write number of mines", "number of mines", "");
                        int.TryParse(CustomMines, out UserFieldMiness);
                    } while (!int.TryParse(CustomMines, out UserFieldMiness) | (UserFieldMiness > UserFieldRows * UserFieldColumns));
                    FieldRows = UserFieldRows;
                    FieldCols = UserFieldColumns;
                    FieldMines = UserFieldMiness;
                    break;
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
            DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
            dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle.BackColor = Color.White;
            dataGridViewCellStyle.ForeColor = Color.Black;
            dataGridViewCellStyle.SelectionBackColor = Color.White;
            dataGridViewCellStyle.SelectionForeColor = Color.Black;

            for (int i = PlayGround.ColumnCount; i < FieldCols; i++)
            {
                DataGridViewButtonColumn ColumnAdd = new DataGridViewButtonColumn();
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
            Field = new int[FieldRows, FieldCols];
            int RandMinesCount = 0;
            int minex;
            int miney;

            while (RandMinesCount < FieldMines)
            {

                minex = rand.Next(0, FieldRows);
                miney = rand.Next(0, FieldCols);

                if (Field[minex, miney] >= 0)
                {
                    AddMine(minex, miney);
                    RandMinesCount++;
                }
            };
        }

        public void AddMine(int x, int y)
        {

            Field[x, y] = -50; //Number for mine

            //Доавление счетчика кол-ва мин во все ячейки вокруг мины по часовой стрелке
            if (IsCellExist(x - 1, y))
            {
                Field[x - 1, y]++;
            }

            if (IsCellExist(x - 1, y + 1))
            {
                Field[x - 1, y + 1]++;
            }

            if (IsCellExist(x, y + 1))
            {
                Field[x, y + 1]++;
            }

            if (IsCellExist(x + 1, y + 1))
            {
                Field[x + 1, y + 1]++;
            }

            if (IsCellExist(x + 1, y))
            {
                Field[x + 1, y]++;
            }

            if (IsCellExist(x + 1, y - 1))
            {
                Field[x + 1, y - 1]++;
            }

            if (IsCellExist(x, y - 1))
            {
                Field[x, y - 1]++;
            }

            if (IsCellExist(x - 1, y - 1))
            {
                Field[x - 1, y - 1]++;
            }
        }

        private void ExitButtom_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        public bool IsCellExist(int x, int y)
        {
            if (x >= 0 && x < FieldRows &&
                y >= 0 && y < FieldCols)
            {
                return true;
            }
            return false;
        }
    }
}