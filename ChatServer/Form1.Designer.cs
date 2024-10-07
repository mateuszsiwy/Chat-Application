namespace ChatServer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            panel1 = new Panel();
            usersBox = new ListBox();
            privateBox = new TextBox();
            chatBox = new RichTextBox();
            sendButton = new Button();
            textBox1 = new TextBox();
            panel2 = new Panel();
            pictureBox1 = new PictureBox();
            usernameLabel = new Label();
            nameBox = new TextBox();
            connectButton = new Button();
            label1 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            dateBox = new TextBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(64, 64, 64);
            panel1.Controls.Add(usersBox);
            panel1.Controls.Add(privateBox);
            panel1.Controls.Add(chatBox);
            panel1.Controls.Add(sendButton);
            panel1.Controls.Add(textBox1);
            panel1.Location = new Point(344, 75);
            panel1.Name = "panel1";
            panel1.Size = new Size(726, 446);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // usersBox
            // 
            usersBox.BackColor = Color.Azure;
            usersBox.BorderStyle = BorderStyle.FixedSingle;
            usersBox.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 238);
            usersBox.FormattingEnabled = true;
            usersBox.ItemHeight = 25;
            usersBox.Location = new Point(534, 33);
            usersBox.Name = "usersBox";
            usersBox.Size = new Size(147, 327);
            usersBox.TabIndex = 6;
            usersBox.SelectedIndexChanged += usersBox_SelectedIndexChanged;
            // 
            // privateBox
            // 
            privateBox.BackColor = Color.Azure;
            privateBox.BorderStyle = BorderStyle.FixedSingle;
            privateBox.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            privateBox.Location = new Point(49, 377);
            privateBox.Name = "privateBox";
            privateBox.Size = new Size(69, 35);
            privateBox.TabIndex = 5;
            // 
            // chatBox
            // 
            chatBox.BackColor = Color.Azure;
            chatBox.BorderStyle = BorderStyle.FixedSingle;
            chatBox.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            chatBox.Location = new Point(49, 33);
            chatBox.Name = "chatBox";
            chatBox.Size = new Size(452, 335);
            chatBox.TabIndex = 3;
            chatBox.Text = "";
            chatBox.TextChanged += chatBox_TextChanged;
            // 
            // sendButton
            // 
            sendButton.BackColor = Color.White;
            sendButton.Location = new Point(534, 376);
            sendButton.Name = "sendButton";
            sendButton.Size = new Size(127, 39);
            sendButton.TabIndex = 1;
            sendButton.Text = "Send\r\n";
            sendButton.UseVisualStyleBackColor = false;
            sendButton.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.Azure;
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            textBox1.Location = new Point(135, 377);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(366, 35);
            textBox1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(64, 64, 64);
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(usernameLabel);
            panel2.Controls.Add(nameBox);
            panel2.Controls.Add(connectButton);
            panel2.Location = new Point(12, 75);
            panel2.Name = "panel2";
            panel2.Size = new Size(305, 446);
            panel2.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.image_removebg_preview__4_;
            pictureBox1.Location = new Point(3, 89);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(299, 154);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click_1;
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.BackColor = Color.White;
            usernameLabel.Font = new Font("Tahoma", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            usernameLabel.Location = new Point(95, 296);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(113, 25);
            usernameLabel.TabIndex = 2;
            usernameLabel.Text = "Username:";
            // 
            // nameBox
            // 
            nameBox.Location = new Point(55, 324);
            nameBox.Name = "nameBox";
            nameBox.Size = new Size(189, 23);
            nameBox.TabIndex = 1;
            // 
            // connectButton
            // 
            connectButton.Font = new Font("Tahoma", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            connectButton.Location = new Point(55, 372);
            connectButton.Name = "connectButton";
            connectButton.Size = new Size(189, 47);
            connectButton.TabIndex = 0;
            connectButton.Text = "Connect";
            connectButton.UseVisualStyleBackColor = true;
            connectButton.Click += connectButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Rubik", 27.7499962F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(393, 16);
            label1.Name = "label1";
            label1.Size = new Size(242, 44);
            label1.TabIndex = 2;
            label1.Text = "Chat Server\r\n";
            label1.Click += label1_Click;
            // 
            // dateBox
            // 
            dateBox.BackColor = SystemColors.InactiveCaptionText;
            dateBox.Font = new Font("Rubik", 27.7499962F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateBox.ForeColor = SystemColors.InactiveBorder;
            dateBox.Location = new Point(869, 14);
            dateBox.Name = "dateBox";
            dateBox.Size = new Size(156, 51);
            dateBox.TabIndex = 3;
            dateBox.TextChanged += dateBox_TextChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(1099, 544);
            Controls.Add(dateBox);
            Controls.Add(label1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button sendButton;
        private TextBox textBox1;
        private Panel panel2;
        private Label label1;
        private System.Windows.Forms.Timer timer1;
        private TextBox dateBox;
        private Label usernameLabel;
        private TextBox nameBox;
        private Button connectButton;
        private RichTextBox chatBox;
        private TextBox privateBox;
        private ListBox usersBox;
        private PictureBox pictureBox1;
    }
}
