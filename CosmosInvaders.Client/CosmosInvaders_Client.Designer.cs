using System.Threading;
using System.Threading.Tasks;

namespace CosmosInvaders.Client
{
    partial class CosmosInvaders_Client
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.positionSaves = new System.Windows.Forms.RichTextBox();
            this.sendMessage = new System.Windows.Forms.Button();
            this.message = new System.Windows.Forms.TextBox();
            this.messageBox = new System.Windows.Forms.RichTextBox();
            this.logBox = new System.Windows.Forms.RichTextBox();
            this.DirectionValue = new System.Windows.Forms.Label();
            this.SpeedValue = new System.Windows.Forms.Label();
            this.DirectionName = new System.Windows.Forms.Label();
            this.SpeedName = new System.Windows.Forms.Label();
            this.OutputLog = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.StatusDescriptionLabel = new System.Windows.Forms.Label();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.ShipLabel = new System.Windows.Forms.Label();
            this.ShipsDropDown = new System.Windows.Forms.ComboBox();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.UsernameTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.positionSaves);
            this.splitContainer1.Panel2.Controls.Add(this.sendMessage);
            this.splitContainer1.Panel2.Controls.Add(this.message);
            this.splitContainer1.Panel2.Controls.Add(this.messageBox);
            this.splitContainer1.Panel2.Controls.Add(this.logBox);
            this.splitContainer1.Panel2.Controls.Add(this.DirectionValue);
            this.splitContainer1.Panel2.Controls.Add(this.SpeedValue);
            this.splitContainer1.Panel2.Controls.Add(this.DirectionName);
            this.splitContainer1.Panel2.Controls.Add(this.SpeedName);
            this.splitContainer1.Panel2.Controls.Add(this.OutputLog);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2.Controls.Add(this.ConnectButton);
            this.splitContainer1.Panel2.Controls.Add(this.ShipLabel);
            this.splitContainer1.Panel2.Controls.Add(this.ShipsDropDown);
            this.splitContainer1.Panel2.Controls.Add(this.UsernameLabel);
            this.splitContainer1.Panel2.Controls.Add(this.UsernameTextBox);
            this.splitContainer1.Size = new System.Drawing.Size(1221, 768);
            this.splitContainer1.SplitterDistance = 794;
            this.splitContainer1.TabIndex = 0;
            // 
            // positionSaves
            // 
            this.positionSaves.Location = new System.Drawing.Point(251, 12);
            this.positionSaves.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.positionSaves.Name = "positionSaves";
            this.positionSaves.ReadOnly = true;
            this.positionSaves.Size = new System.Drawing.Size(156, 110);
            this.positionSaves.TabIndex = 20;
            this.positionSaves.Text = "";
            this.positionSaves.TextChanged += new System.EventHandler(this.positionSaves_TextChanged);
            // 
            // sendMessage
            // 
            this.sendMessage.Location = new System.Drawing.Point(349, 485);
            this.sendMessage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sendMessage.Name = "sendMessage";
            this.sendMessage.Size = new System.Drawing.Size(71, 28);
            this.sendMessage.TabIndex = 18;
            this.sendMessage.Text = "Send";
            this.sendMessage.UseVisualStyleBackColor = true;
            this.sendMessage.Click += new System.EventHandler(this.sendMessage_Click);
            // 
            // message
            // 
            this.message.Location = new System.Drawing.Point(12, 485);
            this.message.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.message.Name = "message";
            this.message.ReadOnly = true;
            this.message.Size = new System.Drawing.Size(328, 22);
            this.message.TabIndex = 17;
            // 
            // messageBox
            // 
            this.messageBox.Location = new System.Drawing.Point(12, 517);
            this.messageBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.messageBox.Name = "messageBox";
            this.messageBox.ReadOnly = true;
            this.messageBox.Size = new System.Drawing.Size(407, 194);
            this.messageBox.TabIndex = 16;
            this.messageBox.Text = "";
            // 
            // logBox
            // 
            this.logBox.Location = new System.Drawing.Point(12, 289);
            this.logBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.logBox.Name = "logBox";
            this.logBox.ReadOnly = true;
            this.logBox.Size = new System.Drawing.Size(407, 187);
            this.logBox.TabIndex = 15;
            this.logBox.Text = "";
            this.logBox.TextChanged += new System.EventHandler(this.logBox_TextChanged);
            // 
            // DirectionValue
            // 
            this.DirectionValue.AutoSize = true;
            this.DirectionValue.Location = new System.Drawing.Point(153, 191);
            this.DirectionValue.Name = "DirectionValue";
            this.DirectionValue.Size = new System.Drawing.Size(13, 17);
            this.DirectionValue.TabIndex = 14;
            this.DirectionValue.Text = "-";
            // 
            // SpeedValue
            // 
            this.SpeedValue.AutoSize = true;
            this.SpeedValue.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SpeedValue.Location = new System.Drawing.Point(37, 186);
            this.SpeedValue.Name = "SpeedValue";
            this.SpeedValue.Size = new System.Drawing.Size(27, 25);
            this.SpeedValue.TabIndex = 13;
            this.SpeedValue.Text = "0";
            // 
            // DirectionName
            // 
            this.DirectionName.AutoSize = true;
            this.DirectionName.Location = new System.Drawing.Point(131, 156);
            this.DirectionName.Name = "DirectionName";
            this.DirectionName.Size = new System.Drawing.Size(64, 17);
            this.DirectionName.TabIndex = 12;
            this.DirectionName.Text = "Direction";
            // 
            // SpeedName
            // 
            this.SpeedName.AutoSize = true;
            this.SpeedName.Location = new System.Drawing.Point(29, 156);
            this.SpeedName.Name = "SpeedName";
            this.SpeedName.Size = new System.Drawing.Size(49, 17);
            this.SpeedName.TabIndex = 11;
            this.SpeedName.Text = "Speed";
            // 
            // OutputLog
            // 
            this.OutputLog.Location = new System.Drawing.Point(11, 225);
            this.OutputLog.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OutputLog.Name = "OutputLog";
            this.OutputLog.ReadOnly = true;
            this.OutputLog.Size = new System.Drawing.Size(409, 57);
            this.OutputLog.TabIndex = 9;
            this.OutputLog.Text = "";
            this.OutputLog.TextChanged += new System.EventHandler(this.OutputLog_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.StatusLabel);
            this.panel1.Controls.Add(this.StatusDescriptionLabel);
            this.panel1.Location = new System.Drawing.Point(3, 740);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(236, 25);
            this.panel1.TabIndex = 8;
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Location = new System.Drawing.Point(3, 2);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(56, 17);
            this.StatusLabel.TabIndex = 6;
            this.StatusLabel.Text = "Status: ";
            // 
            // StatusDescriptionLabel
            // 
            this.StatusDescriptionLabel.AutoSize = true;
            this.StatusDescriptionLabel.Location = new System.Drawing.Point(60, 2);
            this.StatusDescriptionLabel.Name = "StatusDescriptionLabel";
            this.StatusDescriptionLabel.Size = new System.Drawing.Size(102, 17);
            this.StatusDescriptionLabel.TabIndex = 7;
            this.StatusDescriptionLabel.Text = "Not Connected";
            this.StatusDescriptionLabel.Click += new System.EventHandler(this.StatusDescriptionLabel_Click);
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(11, 98);
            this.ConnectButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(216, 32);
            this.ConnectButton.TabIndex = 10;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // ShipLabel
            // 
            this.ShipLabel.AutoSize = true;
            this.ShipLabel.Location = new System.Drawing.Point(8, 59);
            this.ShipLabel.Name = "ShipLabel";
            this.ShipLabel.Size = new System.Drawing.Size(36, 17);
            this.ShipLabel.TabIndex = 4;
            this.ShipLabel.Text = "Ship";
            // 
            // ShipsDropDown
            // 
            this.ShipsDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ShipsDropDown.FormattingEnabled = true;
            this.ShipsDropDown.Location = new System.Drawing.Point(87, 57);
            this.ShipsDropDown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ShipsDropDown.Name = "ShipsDropDown";
            this.ShipsDropDown.Size = new System.Drawing.Size(140, 24);
            this.ShipsDropDown.TabIndex = 2;
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Location = new System.Drawing.Point(8, 16);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(73, 17);
            this.UsernameLabel.TabIndex = 1;
            this.UsernameLabel.Text = "Username";
            // 
            // UsernameTextBox
            // 
            this.UsernameTextBox.Location = new System.Drawing.Point(87, 14);
            this.UsernameTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.UsernameTextBox.Name = "UsernameTextBox";
            this.UsernameTextBox.Size = new System.Drawing.Size(140, 22);
            this.UsernameTextBox.TabIndex = 0;
            // 
            // CosmosInvaders_Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1221, 768);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "CosmosInvaders_Client";
            this.Text = "CosmosInvaders Client";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CosmosInvaders_Client_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CosmosInvaders_Client_KeyDown);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.TextBox UsernameTextBox;
        private System.Windows.Forms.Label ShipLabel;
        private System.Windows.Forms.ComboBox ShipsDropDown;
        private System.Windows.Forms.Label StatusDescriptionLabel;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox OutputLog;
        private System.Windows.Forms.Label DirectionValue;
        private System.Windows.Forms.Label SpeedValue;
        private System.Windows.Forms.Label DirectionName;
        private System.Windows.Forms.Label SpeedName;
        private System.Windows.Forms.RichTextBox logBox;
        private System.Windows.Forms.RichTextBox messageBox;
        private System.Windows.Forms.Button sendMessage;
        private System.Windows.Forms.TextBox message;
        private System.Windows.Forms.RichTextBox positionSaves;
    }
}

