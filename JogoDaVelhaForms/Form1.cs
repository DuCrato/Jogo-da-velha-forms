using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JogoDaVelhaForms
{
    public partial class Form1 : Form
    {
        private int xScore = 0,
            oScore = 0,
            tie    = 0,
            round  = 0;

        private bool shift = true,
            winGame = false;

        private string[] listGame = new string[9];

        public Form1()
        {
            InitializeComponent();
        }

        private void ClearBtn()
        {
            btn_0.Text = "";
            btn_1.Text = "";
            btn_2.Text = "";
            btn_3.Text = "";
            btn_4.Text = "";
            btn_5.Text = "";
            btn_6.Text = "";
            btn_7.Text = "";
            btn_8.Text = "";
        }

        private void ClearColorBtn()
        {
            btn_0.BackColor = Color.White;
            btn_1.BackColor = Color.White;
            btn_2.BackColor = Color.White;
            btn_3.BackColor = Color.White;
            btn_4.BackColor = Color.White;
            btn_5.BackColor = Color.White;
            btn_6.BackColor = Color.White;
            btn_7.BackColor = Color.White;
            btn_8.BackColor = Color.White;
        }

        private void btn_resete_Click(object sender, EventArgs e)
        {
            ClearBtn();
            ClearColorBtn();

            round = 0;
            winGame = false;
           
            for (int i = 0; i < 9; i++)
            {
                listGame[i] = " ";
            }
        }

        private void btn_0_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            int buttonIndex = btn.TabIndex;

            if (btn.Text == "" && winGame == false)
            {
                if (shift)
                {
                    btn.Text = "X";
                    btn.BackColor = Color.Green;
                    listGame[buttonIndex] = btn.Text;
                    round++;
                    shift = !shift;
                    CheckPlayer(1);
                }
                else
                {
                    btn.Text = "O";
                    btn.BackColor = Color.Orange;
                    listGame[buttonIndex] = btn.Text;
                    round++;
                    shift = !shift;
                    CheckPlayer(2);
                }
            }
        }

        void CheckPlayer(int player)
        {
            string aux;

            if (player == 1)
            {
                aux = "X";
            }
            else
            {
                aux = "O";
            }

            for (int horizontal = 0; horizontal < 8; horizontal += 3)
            {
                if (aux == listGame[horizontal])
                {
                    if (listGame[horizontal] == listGame[horizontal + 1] && listGame[horizontal] == listGame[horizontal + 2])
                    {
                        WinPlayer(player);
                        return;
                    }
                }
            }

            for (int vertical = 0; vertical < 3; vertical++)
            {
                if (aux == listGame[vertical])
                {
                    if (listGame[vertical] == listGame[vertical + 3] && listGame[vertical] == listGame[vertical + 6])
                    {
                        WinPlayer(player);
                        return;
                    }
                }
            }

            if (listGame[0] == aux)
            {
                if (listGame[0] == listGame[4] && listGame[0] == listGame[8])
                {
                    WinPlayer(player);
                    return;
                }
            }

            if (listGame[2] == aux)
            {
                if (listGame[2] == listGame[4] && listGame[2] == listGame[6])
                {
                    WinPlayer(player);
                    return;
                }
            }

            if (round == 9 && winGame == false)
            {
                tie++;
                lbl_tie.Text = Convert.ToString(tie);
                MessageBox.Show("Empate!!!");
                winGame = true;
                return;
            }
        }

        void WinPlayer(int player)
        {
            winGame = true;

            if (player == 1)
            {
                xScore++;
                lbl_x_score.Text = Convert.ToString(xScore);
                MessageBox.Show("Jogador X ganhou!!!");
                shift = true;
            }
            else
            {
                oScore++;
                lbl_o_score.Text = Convert.ToString(oScore);
                MessageBox.Show("Jogador O ganhou!!!");
                shift = true;
            }
        }
    }
}
