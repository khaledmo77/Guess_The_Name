using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace ClientSideImp
{
    public partial class LobbyForm : Form
    {
        private client ClientInstance = null!;
        private string randomWord = "";
        Random rand = new Random();
        private  int intRoomNumber;
        Rooms rm = new Rooms();
        string[] parts;
        public static int Count=0;
        public LobbyForm(client clientInstance)
        {
            InitializeComponent();
            ClientInstance = clientInstance ?? throw new ArgumentNullException(nameof(clientInstance));
            ClientInstance.OnMessageReceive += OnResponseForm2;
            Options.Visible = false;
            intRoomNumber = clientInstance.RoomNumber;
            DrawRooms();
        }

        private void OnResponseForm2(string message)
        {
            this.Invoke((MethodInvoker)delegate
            {
                if (message.StartsWith("ROOM_UPDATE:"))
                {
                    // Handle room list updates
                    intRoomNumber = int.Parse(message.Split(':')[1]);
                    DrawRooms();
                }
                else if (message.StartsWith("2,")) // Player join response
                {
                    string[] parts = message.Split(',');
                    if (parts[1] == "Accepted")
                    {
                        // Close existing game form if any
                        if (ClientInstance.gameRoomInClientThread != null &&
                            !ClientInstance.gameRoomInClientThread.IsDisposed)
                        {
                            ClientInstance.gameRoomInClientThread.Close();
                        }

                        var gm = new GameForm(ClientInstance);
                        ClientInstance.gameRoomInClientThread = gm;
                        gm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Join request denied by host");
                        this.Show(); // Re-show lobby if denied
                    }
                }
                else if (message.StartsWith("3,")) // Watcher join response
                {
                    string[] parts = message.Split(',');
                    if (parts.Length > 7)
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            ClientInstance.RoomId = int.Parse(parts[1]);
                            ClientInstance.RandomWord = parts[2];
                            ClientInstance.Player1 = parts[3];
                            ClientInstance.Player2 = parts[4];
                            ClientInstance.Player1Score = parts[5];
                            ClientInstance.Player2Score = parts[6];
                            ClientInstance.GuessedLetters = parts[7];

                            var gm = new GameForm(ClientInstance)
                            {
                                Text = $"Spectating - {ClientInstance.Player1} vs {ClientInstance.Player2}"
                            };

                            // Force UI update
                            gm.Player1.Text = ClientInstance.Player1;
                            gm.Player2.Text = ClientInstance.Player2;
                            gm.Player1Score.Text = ClientInstance.Player1Score;
                            gm.Player2Score.Text = ClientInstance.Player2Score;

                            // Draw guessed letters
                            foreach (char c in ClientInstance.GuessedLetters)
                            {
                                gm.DrawCharTheAnotherPlayerPressed(c.ToString());
                            }

                            ClientInstance.gameRoomInClientThread = gm;
                            gm.Show();
                            this.Hide();
                        });
                    }
                }
                else if (message.StartsWith("ROOM_STATUS:"))
                {
                    var parts = message.Split(new[] { ':' }, 2);
                    var roomData = parts[1].Split(',');

                    if (roomData.Length >= 4)
                    {
                        int roomId = int.Parse(roomData[0]);
                        int playerCount = int.Parse(roomData[1]);
                        string player1 = roomData[2];
                        string player2 = roomData[3];

                        UpdateRoomButton(roomId, playerCount, player1, player2);
                    }
                }
            });
        }
        private void UpdateRoomButton(int roomId, int playerCount, string player1, string player2)
        {
            this.Invoke((MethodInvoker)delegate
            {
                foreach (Control panel in groupBox1.Controls)
                {
                    if (panel is Panel roomPanel && roomPanel.Name == $"roomPanel{roomId - 1}")
                    {
                        var btnJoin = roomPanel.Controls[$"joinButton{roomId - 1}"] as Button;
                        var lblPlayers = roomPanel.Controls.OfType<Label>()
                            .FirstOrDefault(l => l.Name == $"lblPlayers{roomId - 1}");

                        if (btnJoin != null)
                        {
                            btnJoin.Enabled = playerCount < 2;
                            btnJoin.BackColor = playerCount >= 2 ? Color.Gray : SystemColors.Control;
                        }

                        if (lblPlayers != null)
                        {
                            lblPlayers.Text = $"Players: {player1}{(playerCount > 1 ? $", {player2}" : "")}";
                        }
                        break;
                    }
                }
            });
        }


        public void DrawRooms()
        {
            const int PANEL_WIDTH = 300;
            const int PANEL_HEIGHT = 80;
            const int RIGHT_MARGIN = 20;
      

            groupBox1.Controls.Clear();
            Label header = new()
            {
                Text = "Available Rooms",
                Font = new Font(Font, FontStyle.Bold),
                Location = new Point(20, 20),
                AutoSize = true
            };
            groupBox1.Controls.Add(header);

            for (int i = 0; i < intRoomNumber; i++)
            {
                Panel roomPanel = CreateRoomPanel(i, PANEL_WIDTH, PANEL_HEIGHT, RIGHT_MARGIN);
                groupBox1.Controls.Add(roomPanel);
            }
        }

        private Panel CreateRoomPanel(int index, int width, int height, int margin)
        {
            var panel = new Panel
            {
                Name = "roomPanel" + index,
                Location = new Point(20, 50 + (height + 15) * index),
                Size = new Size(width, height),
                BorderStyle = BorderStyle.FixedSingle
            };

            var lblRoomId = new Label
            {
                Text = $"Room ID: {index + 1}",
                ForeColor = Color.RoyalBlue,
                Location = new Point(15, 15),
                AutoSize = true
            };

            var btnJoin = new Button
            {
                Text = "Join",
                Size = new Size(80, 30),
                Location = new Point(width - 80 - margin, 15),
                Name = "joinButton" + index,
                
                
            };

            var btnWatch = new Button
            {
                Text = "Watch",
                Size = new Size(80, 30),
                Location = new Point(width - 80 - margin, 50),
                Name = "watchButton" + index
            };

            btnJoin.Click += JoinButtonClick;
            btnWatch.Click += WatchButtonClick;

            panel.Controls.Add(lblRoomId);
            panel.Controls.Add(btnJoin);
            panel.Controls.Add(btnWatch);

            return panel;
        }

        private void JoinButtonClick(object? sender, EventArgs e)
        {
            var joinButton = (Button)sender!;
            int roomIndex = int.Parse(joinButton.Name.Replace("joinButton", ""));
            int roomId = roomIndex + 1;

            // Immediately disable button
            joinButton.Enabled = false;
            joinButton.BackColor = Color.Gray;

            ClientInstance.RoomId = roomId;
            ClientInstance.ClientState = "Player";
            ClientInstance.SendMessageToServer($"2,{ClientInstance.ClientId},{roomId},{ClientInstance.ClientName}");
            MessageBox.Show("Request sent. Waiting for host approval...");
        }

        private void WatchButtonClick(object sender, EventArgs e)
        {
            Button watchButton = (Button)sender;
            int roomId = int.Parse(watchButton.Name.Replace("watchButton", ""));
            ClientInstance.RoomId = roomId;
            ClientInstance.ClientState = "Watcher";
            ClientInstance.SendMessageToServer($"3,{ClientInstance.ClientId},{roomId}");
            MessageBox.Show("Please Wait a minute");
            GameForm gm = new GameForm(ClientInstance);
            ClientInstance.gameRoomInClientThread = gm;
            gm.Show();
            this.Hide();

        }


        private void CreateRoomHandler(Action<string> categoryHandler)
        {
            Options.Visible = false;
            categoryHandler?.Invoke("");
        }

        private void Animals_CheckedChanged(object sender, EventArgs e)
        {
            CreateRoomHandler(_ =>
            {
                randomWord = GetRandomWord(@"D:\C# mosh\Project C#\Resources\Categories\Animals.txt");
                CreateGameRoom("Animals");
            });
        }

        private void Food_CheckedChanged(object sender, EventArgs e)
        {
            CreateRoomHandler(_ =>
            {
                randomWord = GetRandomWord(@"D:\C# mosh\Project C#\Resources\Categories\Food.txt");
                CreateGameRoom("Food");
            });
        }

        private void Vehicle_CheckedChanged(object sender, EventArgs e)
        {
            CreateRoomHandler(_ =>
            {
                randomWord = GetRandomWord(@"D:\C# mosh\Project C#\Resources\Categories\Vehicles.txt");
                CreateGameRoom("Vehicle");
            });
        }

        private string GetRandomWord(string filePath)
        {
            return File.ReadAllLines(filePath)[rand.Next(File.ReadAllLines(filePath).Length)];
        }

        private void CreateGameRoom(string category)
        {
            // 1. Set all client properties FIRST
            ClientInstance.Player1 = ClientInstance.ClientName; // Set host as Player1
            ClientInstance.Player2 = "";
            ClientInstance.ClientState = "Host";
            ClientInstance.RandomWord = randomWord;
            ClientInstance.RoomId = intRoomNumber + 1;

            // 2. Create game form AFTER setting properties
            var gameForm = new GameForm(ClientInstance);

            // 3. Maintain reference in client before server communication
            ClientInstance.gameRoomInClientThread = gameForm;

            // 4. Send server message AFTER form is initialized
            ClientInstance.SendMessageToServer(
                $"1,{ClientInstance.ClientId},{ClientInstance.RoomId},{category},{randomWord},{ClientInstance.ClientName}");

            // 5. Show/Hide forms LAST
            gameForm.Show();
            this.Hide();
        }

        private void CreateRoomBtn_Click(object sender, EventArgs e)
        {
            Options.Visible = true;
        }
        private void Options_Enter(object sender, EventArgs e)
        {

        }
    }
}

