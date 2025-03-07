using System;
using System.Net.Sockets;
using System.Net;
using System.ComponentModel;
using System.Windows.Forms;

namespace ClientSideImp
{
    public class client
    {
        public delegate void MessageReceiveEventHandler(string message);

        TcpClient Client = new TcpClient();
        byte[] bt = new byte[] { 127, 0, 0, 1 };
        IPAddress serverIPadress = IPAddress.Parse("127.0.0.1");
        NetworkStream? nstream;
        BinaryReader? br;
        BinaryWriter? bw;

        BackgroundWorker worker = new BackgroundWorker();
        DialogResult joinResult;
        public LobbyForm form { get; set; } = null!;
        public event MessageReceiveEventHandler OnClientConnected = delegate { };
        public event MessageReceiveEventHandler OnMessageReceive = delegate { };

        public int ClientId { get; set; }
        public string ClientName { get; set; } = "";
        public string ClientState { get; set; } = "";
        public string RandomWord { get; set; } = "";
        public int RoomId { get; set; }

        public int RoomNumber { get; set; }
        public bool Flag { get; set; }
        public string Player1 { get; set; } = "";
        public string Player2 { get; set; } = "";
            public string Player1Score { get; set; } = "0";
    public string Player2Score { get; set; } = "0";
    public string GuessedLetters { get; set; } = "";
        public bool Flag2 { get; set; }
        public bool FlagToStartPlay { get; set; }
        public GameForm gameRoomInClientThread { get; set; } = null!;
        public GameForm gameRoomInClientThread2 { get; set; } = null!;
        public string MessageFromserver { get; set; } = "";
        public bool FlagToYourTurnOrNot { get; set; }
        public string PlayerTurn { get; set; } = "";

        public client()
        {
            worker.DoWork += DoBackgroundWork;
        }

        public void StartServer() => worker.RunWorkerAsync();

        private void DoBackgroundWork(object? sender, DoWorkEventArgs e) => ConnectToServer();

        public void ConnectToServer()
        {
            try
            {
                Client.Connect(new IPEndPoint(serverIPadress, 2000));
                if (Client.Connected)
                {
                    nstream = Client.GetStream();
                    bw = new BinaryWriter(nstream);
                    br = new BinaryReader(nstream);
                    OnClientConnected("Success");
                    ReceiveMessages();
                }
            }
            catch (Exception ex)
            {
                SafeMessage($"Error: {ex.Message}");
            }
        }

        public void ReceiveMessages()
        {
            try
            {
                while (Client.Connected)
                {
                    var msg = br?.ReadString() ?? "";
                    OnMessageReceive(msg);
                    ProcessMessage(msg);
                }
            }
            catch (Exception ex)
            {
                SafeMessage($"Receive error: {ex.Message}");
            }
        }

        private void ProcessMessage(string msg)
        {
            var clientMsg = msg.Split(',');

            try
            {
                switch (clientMsg[0])
                {
                    case "0" when clientMsg.Length > 2:
                        RoomNumber = int.Parse(clientMsg[1]);
                        ClientId = int.Parse(clientMsg[2]);
                        break;

                    case "1" when clientMsg.Length > 1:
                        Player2 = clientMsg[1];
                        joinResult = MessageBox.Show($"{Player2} wants to join. Accept?", "Join Request", MessageBoxButtons.OKCancel);

                        if (bw != null)
                        {
                            bw.Write(joinResult == DialogResult.OK ? "4,Accept" : "4,Reject");
                            if (joinResult == DialogResult.OK)
                            {
                                FlagToStartPlay = true;
                                gameRoomInClientThread?.Invoke(() => gameRoomInClientThread.StartPlay());
                            }
                        }
                        break;

                    case "2" when clientMsg.Length > 1:
                        Flag2 = clientMsg[1] == "Accepted";
                        MessageFromserver = clientMsg[1];
                        if (clientMsg[1] == "notAccepted")
                            SafeMessage("Host denied your request to join");
                        break;

                    case "3" when clientMsg.Length > 2:
                        RandomWord = clientMsg[1];
                        Player1 = clientMsg[2];
                        Player2 = ClientName;
                        // Notify UI to create game form
                        OnMessageReceive?.Invoke("WATCHER_JOINED");
                        break;

                    case "4" when clientMsg.Length > 3:
                        RandomWord = clientMsg[1];
                        Player1 = clientMsg[2];
                        Player2 = clientMsg[3];
                        break;

                    case "10" when clientMsg.Length > 2:
                        gameRoomInClientThread?.Invoke(() => {
                            gameRoomInClientThread.DrawCharTheAnotherPlayerPressed(clientMsg[1]);
                            gameRoomInClientThread.ChangeThePlayerTurn("Another Player Turn", clientMsg[2]);
                        });
                        FlagToYourTurnOrNot = false;
                        break;

                    case "11" when clientMsg.Length > 2:
                        gameRoomInClientThread?.Invoke(() =>
                            gameRoomInClientThread.ChangeThePlayerTurn("Your Turn", clientMsg[2]));
                        FlagToYourTurnOrNot = true;
                        break;

                    case "12" when clientMsg.Length > 3:
                        PlayerTurn = clientMsg[3];
                        gameRoomInClientThread?.Invoke(() => {
                            gameRoomInClientThread.Word_index(clientMsg[1]);
                            gameRoomInClientThread.ChangeThePlayerTurn(PlayerTurn, "");
                        });
                        FlagToYourTurnOrNot = false;
                        break;

                    case "13" when clientMsg.Length > 1:
                        PlayerTurn = clientMsg[1];
                        gameRoomInClientThread?.Invoke(() =>
                            gameRoomInClientThread.ChangeThePlayerTurn(PlayerTurn, ""));
                        FlagToYourTurnOrNot = false;
                        break;

                    case "14" when clientMsg.Length > 2:
                        ShowGameResult(clientMsg[1], clientMsg[2]);
                        gameRoomInClientThread?.Invoke(() => gameRoomInClientThread.closeTheGameRoom());
                        break;

                    case "15" when clientMsg.Length > 2:
                        gameRoomInClientThread?.Invoke(() =>
                            gameRoomInClientThread.ChangeTheScores(clientMsg[1], clientMsg[2]));
                        break;

                    case "16" when clientMsg.Length > 1:
                        gameRoomInClientThread?.Invoke(() =>
                            gameRoomInClientThread.ChangeTheWatchersNum(clientMsg[1]));
                        break;
                }
            }
            catch (Exception ex)
            {
                SafeMessage($"Error processing message: {ex.Message}");
            }
        }

        private void ShowGameResult(string result, string player)
        {
            if (result == "1" && player == ClientName)
                SafeMessage("You Won!", "Congratulations");
            else if (result == "1")
                SafeMessage("Better luck next time", "Loser");
            else
                SafeMessage("It's a Tie", "Draw");
        }

        public bool SendMessageToServer(string message)
        {
            try
            {
                bw?.Write(message);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void DisconnectFromServer()
        {
            try
            {
                nstream?.Close();
                Client?.Close();
            }
            catch { }
        }

        private void SafeMessage(string text, string caption = "Error")
        {
            if (!Client.Connected) return;
            try
            {
                MessageBox.Show(text, caption);
            }
            catch { }
        }

        public string ReceiveRandomWordFromServer()
        {
            try
            {
                var msg = br?.ReadString() ?? "";
                return msg.Split(',')[0] == "3" ? msg.Split(',')[1] : "not found";
            }
            catch
            {
                return "not found";
            }
        }
    }
}