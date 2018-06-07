using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Specks
{
    public partial class Form5 : Form
    {
        Form form;
        Button[,] buttons;
        Random rnd = new Random();
        List<int> numbers;

        public Form5()
        {
            InitializeComponent();
            button16.Text = "";
        }

        public Form5(Form form1)
        {
            InitializeComponent();
            button16.Text = "";
            form = form1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Fill_Array();
            numbers = new List<int>();
            for (int i = 0; i < 15; i++)
            {
                numbers.Add(i + 1);
            }

            SetUpGame();
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button.Text != "")
            {
                for (int x = 0; x < 4; x++)
                {
                    for (int y = 0; y < 4; y++)
                    {
                        if (buttons[x, y].Text == button.Text)
                        {
                            CheckNeighbours(x, y);
                        }
                    }
                }
            }
            Win();
        }
    

        public void Fill_Array()
        {
            buttons = new Button[4, 4];
            buttons[0, 0] = button1;
            buttons[0, 1] = button2;
            buttons[0, 2] = button3;
            buttons[0, 3] = button4;
            buttons[1, 0] = button5;
            buttons[1, 1] = button6;
            buttons[1, 2] = button7;
            buttons[1, 3] = button8;
            buttons[2, 0] = button9;
            buttons[2, 1] = button10;
            buttons[2, 2] = button11;
            buttons[2, 3] = button12;
            buttons[3, 0] = button13;
            buttons[3, 1] = button14;
            buttons[3, 2] = button15;
            buttons[3, 3] = button16;
        }

        public void SetUpGame()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++) 
                {
                    if (i == 3 && j == 3)
                    {
                        buttons[i, j].Text = "";
                        break;
                    }

                    int index = rnd.Next(0, numbers.Count );
                    buttons[i, j].Text = numbers[index].ToString();
                    numbers.RemoveAt(index);
                }
            }
        }

        public void CheckNeighbours(int x, int y)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                  
                    {
                        if ((i == x - 1 || i == x || i == x + 1) && (j == y - 1 || j == y || j == y + 1) && (i == x || j == y))
                        {
                            if (buttons[i, j].Text == "")
                            {
                                buttons[i, j].Text = buttons[x, y].Text;
                                buttons[x, y].Text = "";
                                buttons[i, j].Visible = true;
                                buttons[x, y].Visible = false;
                            }
                        }
                    }
                }
            }
        }

        public void Win()
        {
            int num = 1;
            int kolvo = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (i == 3 && j == 3)
                    {
                        break;
                    }
                    if (buttons[i, j].Text == num.ToString())
                    {
                        kolvo++;
                        num++;
                    }
                }
            }

            if (kolvo == 15)
            {
                MessageBox.Show("You won!");
            }
        }

        private void btnmenu_Click(object sender, EventArgs e)
        {
            Hide();
            form.ShowDialog();
            Close();
        }
    }
}
