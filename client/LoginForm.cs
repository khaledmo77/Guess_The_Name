using System.Diagnostics;

namespace ClientSideImp
{
    public partial class LoginForm : Form
    {
        private client? ClientInstance;
        public LoginForm()
        {
            InitializeComponent();
         

        }

        private void OnResponse(string s)
        {

        }
        private void PlayerConnecttoServer_Click(object sender, EventArgs e)
        {
        }

        private void SuccessConnection(string msg)
        {
        }

        private void Rooms_Click(object sender, EventArgs e)
        {
        
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void signInBtnCyber_Click(object sender, EventArgs e)
        {
            ClientInstance = new client();
            ClientInstance.OnClientConnected += SuccessConnection;
            ClientInstance.OnMessageReceive += OnResponse;
            ClientInstance.StartServer();

            ClientInstance.ClientName = LoginTextBox.TextButton;

          
        }

        private void PlayBtnCyber_Click(object sender, EventArgs e)
        {
            ClientInstance = new client();
            ClientInstance.OnClientConnected += SuccessConnection;
            ClientInstance.OnMessageReceive += OnResponse;
            ClientInstance.StartServer();

            ClientInstance.ClientName = LoginTextBox.TextButton;



          

            LobbyForm clientForm = new LobbyForm(ClientInstance);
            ClientInstance.form = clientForm;
            clientForm.Show();
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }
    }
}
