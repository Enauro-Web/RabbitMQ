namespace MQTTApp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtMessage = new System.Windows.Forms.RichTextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.cbExchangeType = new System.Windows.Forms.ComboBox();
            this.lbChatCanvas = new System.Windows.Forms.ListBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbContacts = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtServerName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(12, 483);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(301, 59);
            this.txtMessage.TabIndex = 0;
            this.txtMessage.Text = "";
            this.txtMessage.Visible = false;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(238, 548);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 43);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "SEND";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Visible = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // cbExchangeType
            // 
            this.cbExchangeType.FormattingEnabled = true;
            this.cbExchangeType.Items.AddRange(new object[] {
            "Topic",
            "Fanout"});
            this.cbExchangeType.Location = new System.Drawing.Point(261, 16);
            this.cbExchangeType.Name = "cbExchangeType";
            this.cbExchangeType.Size = new System.Drawing.Size(52, 21);
            this.cbExchangeType.TabIndex = 2;
            this.cbExchangeType.Visible = false;
            // 
            // lbChatCanvas
            // 
            this.lbChatCanvas.FormattingEnabled = true;
            this.lbChatCanvas.Location = new System.Drawing.Point(12, 122);
            this.lbChatCanvas.Name = "lbChatCanvas";
            this.lbChatCanvas.Size = new System.Drawing.Size(301, 355);
            this.lbChatCanvas.TabIndex = 4;
            this.lbChatCanvas.Visible = false;
            // 
            // txtUser
            // 
            this.txtUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUser.Location = new System.Drawing.Point(100, 40);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(213, 23);
            this.txtUser.TabIndex = 5;
            this.txtUser.TextChanged += new System.EventHandler(this.txtUser_TextChanged);
            this.txtUser.Validated += new System.EventHandler(this.txtUser_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Contact";
            // 
            // cbContacts
            // 
            this.cbContacts.FormattingEnabled = true;
            this.cbContacts.Items.AddRange(new object[] {
            "John",
            "Bob",
            "Alice",
            "Rafa",
            "All"});
            this.cbContacts.Location = new System.Drawing.Point(100, 69);
            this.cbContacts.Name = "cbContacts";
            this.cbContacts.Size = new System.Drawing.Size(213, 21);
            this.cbContacts.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Your Name";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(238, 96);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 9;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtServerName
            // 
            this.txtServerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtServerName.Location = new System.Drawing.Point(100, 14);
            this.txtServerName.Name = "txtServerName";
            this.txtServerName.Size = new System.Drawing.Size(213, 23);
            this.txtServerName.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Server Name";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 599);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtServerName);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbContacts);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.lbChatCanvas);
            this.Controls.Add(this.cbExchangeType);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtMessage);
            this.Name = "Form1";
            this.Text = "MQTT Chat";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtMessage;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.ComboBox cbExchangeType;
        private System.Windows.Forms.ListBox lbChatCanvas;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbContacts;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtServerName;
        private System.Windows.Forms.Label label1;
    }
}

