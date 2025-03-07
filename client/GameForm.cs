using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Formats.Asn1.AsnWriter;

namespace ClientSideImp
{
    public partial class GameForm : Form
    {
        private Label dynamicLabel = new Label();
        int score = 0;
        private string pressed_key = "";
        private readonly List<Label> dynamicLabels = new();
        private readonly client clientInstance;
        private string Random_Word = "";
        public GameForm(client clientinst)
        {
            InitializeComponent();
            clientInstance = clientinst ?? throw new ArgumentNullException(nameof(clientinst));
            Random_Word = clientinst.RandomWord ?? "";
            Player1.Text = clientinst.ClientState == "Host"
       ? clientinst.ClientName
       : clientinst.Player1 ?? "";
            Player2.Text = clientinst.Player2 ?? "";
            Player1Score.Text = clientinst.Player1Score ?? "0";
            Player2Score.Text = clientinst.Player2Score ?? "0";
            if (clientinst.ClientState == "Watcher")
            {
                // Disable input and show existing state
                Keyboard.Enabled = false;

                // Initialize scores if available
                if (clientinst.Player1Score != null && clientinst.Player2Score != null)
                {
                    Player1Score.Text = clientinst.Player1Score;
                    Player2Score.Text = clientinst.Player2Score;
                }

                // Draw existing guessed letters
                if (!string.IsNullOrEmpty(clientinst.GuessedLetters))
                {
                    foreach (char c in clientinst.GuessedLetters)
                    {
                        DrawCharTheAnotherPlayerPressed(c.ToString());
                    }
                }
            }
            InitializeGameComponents();
        }

        private void InitializeGameComponents()
        {
            if (string.IsNullOrWhiteSpace(Random_Word))
            {
                MessageBox.Show("Error: No word received from server");
                Close();
                return;
            }

            Word_dashed();
            Player1.Text = clientInstance.Player1 ?? "";
            Player2.Text = clientInstance.Player2 ?? "";
            Player1Score.Text = "0";
            Player2Score.Text = "0";
            Player_turn.Text = "Your Turn";
            WatchersNum.Text = "0";
            Keyboard.Enabled = false;
        }

        public void Word_dashed()
        {
            int x_size = 50;

            for (int i = 0; i < Random_Word.Length; i++)
            {

                dynamicLabel = new Label();

                dynamicLabel.Text = "___";
                dynamicLabel.Location = new Point(100 + x_size, 150);
                dynamicLabel.Size = new Size(30, 50);
                dynamicLabel.Font = new Font("Arial", 20);
                Controls.Add(dynamicLabel);


                dynamicLabels.Add(dynamicLabel);
                x_size += 50;


                if (Random_Word.ToUpper()[i].ToString() == " ")
                {
                    dynamicLabels[i].Text = "";
                }

            }
        }
        public void DrawCharTheAnotherPlayerPressed(string charPressed)
        {
            string pressed_key = charPressed;


            if (Random_Word.ToUpper().Contains(pressed_key))
            {


                for (int i = 0; i < Random_Word.Length; i++)
                {
                    if (Random_Word.ToUpper()[i].ToString() == pressed_key)
                    {
                        dynamicLabels[i].Text = pressed_key;
                    }
                    foreach (Control cntrl in Keyboard.Controls)
                    {
                        if ( cntrl.Text == pressed_key)
                        {
                            cntrl.Enabled = false;
                        }
                    }

                }
            }
        }




        public void Word_index(string charPressed)
        {
            string pressed_key = charPressed;
            score += 1;

            if (Random_Word.ToUpper().Contains(pressed_key))
            {
                for (int i = 0; i < Random_Word.Length; i++)
                {
                    if (Random_Word.ToUpper()[i].ToString() == pressed_key)
                    {
                        dynamicLabels[i].Text = pressed_key;
                    }
                    foreach (Control cntrl in Keyboard.Controls)
                    {
                        if (cntrl.Text == pressed_key) // Remove Focus check
                        {
                            cntrl.Enabled = false;
                        }
                    }
                }
                clientInstance.SendMessageToServer($"10,{clientInstance.ClientId},{clientInstance.RoomId},{clientInstance.ClientState},{pressed_key}");

                // Keep turn if correct guess
                clientInstance.FlagToYourTurnOrNot = true;
                ChangeThePlayerTurn("Your Turn", "");  // Update through method
            }
            else
            {
                clientInstance.SendMessageToServer($"11,{clientInstance.ClientId},{clientInstance.RoomId},{clientInstance.ClientState}");

                // Pass turn to other player
                clientInstance.FlagToYourTurnOrNot = false;
                ChangeThePlayerTurn("Another Player Turn", "");  // Update through method
            }
        }
        public void StartPlay()
        {

            Player2.Text = clientInstance.Player2;
            clientInstance.FlagToStartPlay = true;
            clientInstance.FlagToYourTurnOrNot = true;
            Keyboard.Enabled = true;
        }
        public void ChangeThePlayerTurn(string PlayerTurnName, string c)
        {
            Player_turn.Text = PlayerTurnName;
            Keyboard.Enabled = (PlayerTurnName == "Your Turn"); // Add this line
        }
        public void ChangeTheWatchersNum(string c)
        {
            WatchersNum.Text = c;

        }
        public void ChangeTheScores(string Score1 ,string Score2)
        {
            Player1Score.Text = Score1.ToString();
            Player2Score.Text = Score2.ToString();

        }
        public void closeTheGameRoom()
        {
            this.Hide();
            LobbyForm form = new LobbyForm(clientInstance);
            form.Show();
        }
        #region buttons
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void e_Click_1(object sender, EventArgs e)
        {
            if(clientInstance.FlagToYourTurnOrNot==false)
            { 
                MessageBox.Show("it is the another player Turn");
            }
            else
            {
                Word_index("E");

            }
        }
      
        private void t_Click_1(object sender, EventArgs e)
        {
            if (clientInstance.FlagToYourTurnOrNot == false)
            {
                MessageBox.Show("it is the another player Turn");
            }
            else
            {
                Word_index("T");

            }
        }

        private void q_Click(object sender, EventArgs e)
        {
            if (clientInstance.FlagToYourTurnOrNot == false)
            {
                MessageBox.Show("it is the another player Turn");
            }
            else
            {
                Word_index("Q");

            }
        }

        private void w_Click(object sender, EventArgs e)
        {
            if (clientInstance.FlagToYourTurnOrNot == false)
            {
                MessageBox.Show("it is the another player Turn");
            }
            else
            {
                Word_index("W");

            }
        }

        private void r_Click(object sender, EventArgs e)
        {
            if (clientInstance.FlagToYourTurnOrNot == false)
            {
                MessageBox.Show("it is the another player Turn");
            }
            else
            {
                Word_index("R");

            }
        }

        private void y_Click(object sender, EventArgs e)
        {
            if (clientInstance.FlagToYourTurnOrNot == false)
            {
                MessageBox.Show("it is the another player Turn");
            }
            else
            {
                Word_index("Y");

            }
        }

        private void u_Click(object sender, EventArgs e)
        {
            if (clientInstance.FlagToYourTurnOrNot == false)
            {
                MessageBox.Show("it is the another player Turn");
            }
            else
            {
                Word_index("U");

            }
        }

        private void i_Click(object sender, EventArgs e)
        {
            if (clientInstance.FlagToYourTurnOrNot == false)
            {
                MessageBox.Show("it is the another player Turn");
            }
            else
            {
                Word_index("I");

            }
        }

        private void o_Click(object sender, EventArgs e)
        {
            if (clientInstance.FlagToYourTurnOrNot == false)
            {
                MessageBox.Show("it is the another player Turn");
            }
            else
            {
                Word_index("O");

            }
        }

        private void p_Click(object sender, EventArgs e)
        {
            if (clientInstance.FlagToYourTurnOrNot == false)
            {
                MessageBox.Show("it is the another player Turn");
            }
            else
            {
                Word_index("P");

            }
        }

        private void a_Click(object sender, EventArgs e)
        {
            if (clientInstance.FlagToYourTurnOrNot == false)
            {
                MessageBox.Show("it is the another player Turn");
            }
            else
            {
                Word_index("A");

            }
        }

        private void s_Click(object sender, EventArgs e)
        {
            if (clientInstance.FlagToYourTurnOrNot == false)
            {
                MessageBox.Show("it is the another player Turn");
            }
            else
            {
                Word_index("S");

            }
        }

        private void d_Click(object sender, EventArgs e)
        {
            if (clientInstance.FlagToYourTurnOrNot == false)
            {
                MessageBox.Show("it is the another player Turn");
            }
            else
            {
                Word_index("D");

            }
        }

        private void f_Click(object sender, EventArgs e)
        {
            if (clientInstance.FlagToYourTurnOrNot == false)
            {
                MessageBox.Show("it is the another player Turn");
            }
            else
            {
                Word_index("F");

            }
        }

        private void g_Click(object sender, EventArgs e)
        {
            if (clientInstance.FlagToYourTurnOrNot == false)
            {
                MessageBox.Show("it is the another player Turn");
            }
            else
            {
                Word_index("G");

            }
        }

        private void h_Click(object sender, EventArgs e)
        {
            if (clientInstance.FlagToYourTurnOrNot == false)
            {
                MessageBox.Show("it is the another player Turn");
            }
            else
            {
                Word_index("H");

            }
        }

        private void j_Click(object sender, EventArgs e)
        {
            if (clientInstance.FlagToYourTurnOrNot == false)
            {
                MessageBox.Show("it is the another player Turn");
            }
            else
            {
                Word_index("J");

            }
        }

        private void k_Click(object sender, EventArgs e)
        {
            if (clientInstance.FlagToYourTurnOrNot == false)
            {
                MessageBox.Show("it is the another player Turn");
            }
            else
            {
                Word_index("K");

            }
        }

        private void l_Click(object sender, EventArgs e)
        {
            if (clientInstance.FlagToYourTurnOrNot == false)
            {
                MessageBox.Show("it is the another player Turn");
            }
            else
            {
                Word_index("L");

            }
        }

        private void z_Click(object sender, EventArgs e)
        {
            if (clientInstance.FlagToYourTurnOrNot == false)
            {
                MessageBox.Show("it is the another player Turn");
            }
            else
            {
                Word_index("Z");

            }
        }

        private void x_Click(object sender, EventArgs e)
        {
            if (clientInstance.FlagToYourTurnOrNot == false)
            {
                MessageBox.Show("it is the another player Turn");
            }
            else
            {
                Word_index("X");

            }
        }

        private void c_Click(object sender, EventArgs e)
        {
            if (clientInstance.FlagToYourTurnOrNot == false)
            {
                MessageBox.Show("it is the another player Turn");
            }
            else
            {
                Word_index("C");

            }
        }

        private void v_Click(object sender, EventArgs e)
        {
            if (clientInstance.FlagToYourTurnOrNot == false)
            {
                MessageBox.Show("it is the another player Turn");
            }
            else
            {
                Word_index("V");

            }
        }

        private void b_Click(object sender, EventArgs e)
        {
            if (clientInstance.FlagToYourTurnOrNot == false)
            {
                MessageBox.Show("it is the another player Turn");
            }
            else
            {
                Word_index("B");

            }
        }

        private void n_Click(object sender, EventArgs e)
        {
            if (clientInstance.FlagToYourTurnOrNot == false)
            {
                MessageBox.Show("it is the another player Turn");
            }
            else
            {
                Word_index("N");

            }

        }

        private void m_Click(object sender, EventArgs e)
        {
            if (clientInstance.FlagToYourTurnOrNot == false)
            {
                MessageBox.Show("it is the another player Turn");
            }
            else
            {
                Word_index("M");

            }
        }
        #endregion
    }
}
