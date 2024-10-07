using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;



namespace ChatServer
{
    public partial class Form1 : Form
    {
        //bool ontheusersBox = false;
        bool isConnected = false;
        public Form1()
        {
            InitializeComponent();
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
            chatBox.AppendText("Welcome to the chat, you can select a user from the menu on the right to send a private message" +
                "\n-------------------------------------------------------");
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            dateBox.Text = DateTime.Now.ToString("HH:mm:ss");
            RefreshChat();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dateBox.Text = DateTime.Now.ToString("HH:mm:ss");
            dateBox.ReadOnly = true;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            client.message = privateBox.Text + ": " + textBox1.Text;
        }

        private void dateBox_TextChanged(object sender, EventArgs e)
        {

        }



        private System.Windows.Forms.Timer timer;

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!isConnected)
                {
                    client = new TCPClientLibrary.TCPClient();
                    _ = Task.Run(() => client.SendAsync());
                    client.message = nameBox.Text;
                    connectButton.Text = "Disconnect";
                    isConnected = true;
                }
                else
                {
                    chatBox.Text = "";
                    usersBox.Text = "";
                    connectButton.Text = "Connect";
                    client.Disconnect();
                    isConnected = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("unable to connect tcp client" + ex.Message);
            }
        }

        TCPClientLibrary.TCPClient client = null;

        private void chatBox_TextChanged(object sender, EventArgs e)
        {

        }
        private void RefreshChat()
        {
            if (client != null && client.received != null)
            {
                if (client.received.StartsWith("USERLIST"))
                {
                    usersBox.Items.Clear();
                    string names = client.received.Substring(9);
                    string[] namesArray = names.Split(',');
                    foreach (string name in namesArray)
                    {
                        usersBox.Items.Add(name);
                        usersBox.Items.Add("\n");
                    }

                    client.received = null;
                }
                else
                {
                    chatBox.AppendText(client.received);
                    chatBox.AppendText("\n");
                    client.received = null;
                    // chatBox.AppendText("czesc");
                }

            }
        }

        private void usersBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedUser = usersBox.SelectedItem.ToString();
            privateBox.Text = selectedUser;
            //System.Windows.Forms.ListBox+SelectedObjectCollection
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
