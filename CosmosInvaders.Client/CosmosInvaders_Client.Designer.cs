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
            this.DirectionValue = new System.Windows.Forms.Label();
            this.SpeedValue = new System.Windows.Forms.Label();
            this.DirectionName = new System.Windows.Forms.Label();
            this.SpeedName = new System.Windows.Forms.Label();
            this.OutputLog = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.StatusDescriptionLabel = new System.Windows.Forms.Label();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.VehicleLabel = new System.Windows.Forms.Label();
            this.VehiclesDropDown = new System.Windows.Forms.ComboBox();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.UsernameTextBox = new System.Windows.Forms.TextBox();
            this.logBox = new System.Windows.Forms.RichTextBox();
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
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
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
            this.splitContainer1.Panel2.Controls.Add(this.VehicleLabel);
            this.splitContainer1.Panel2.Controls.Add(this.VehiclesDropDown);
            this.splitContainer1.Panel2.Controls.Add(this.UsernameLabel);
            this.splitContainer1.Panel2.Controls.Add(this.UsernameTextBox);
            this.splitContainer1.Size = new System.Drawing.Size(916, 624);
            this.splitContainer1.SplitterDistance = 596;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 0;
            // 
            // positionSaves
            // 
            this.positionSaves.Location = new System.Drawing.Point(188, 10);
            this.positionSaves.Margin = new System.Windows.Forms.Padding(2);
            this.positionSaves.Name = "positionSaves";
            this.positionSaves.ReadOnly = true;
            this.positionSaves.Size = new System.Drawing.Size(118, 90);
            this.positionSaves.TabIndex = 20;
            this.positionSaves.Text = "";
            this.positionSaves.TextChanged += new System.EventHandler(this.positionSaves_TextChanged);
            // 
            // sendMessage
            // 
            this.sendMessage.Location = new System.Drawing.Point(262, 394);
            this.sendMessage.Name = "sendMessage";
            this.sendMessage.Size = new System.Drawing.Size(53, 23);
            this.sendMessage.TabIndex = 18;
            this.sendMessage.Text = "Send";
            this.sendMessage.UseVisualStyleBackColor = true;
            this.sendMessage.Click += new System.EventHandler(this.sendMessage_Click);
            // 
            // message
            // 
            this.message.Location = new System.Drawing.Point(9, 394);
            this.message.Name = "message";
            this.message.ReadOnly = true;
            this.message.Size = new System.Drawing.Size(247, 20);
            this.message.TabIndex = 17;
            // 
            // messageBox
            // 
            this.messageBox.Location = new System.Drawing.Point(9, 420);
            this.messageBox.Name = "messageBox";
            this.messageBox.ReadOnly = true;
            this.messageBox.Size = new System.Drawing.Size(306, 158);
            this.messageBox.TabIndex = 16;
            this.messageBox.Text = "";
            // 
            // DirectionValue
            // 
            this.DirectionValue.AutoSize = true;
            this.DirectionValue.Location = new System.Drawing.Point(115, 155);
            this.DirectionValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.DirectionValue.Name = "DirectionValue";
            this.DirectionValue.Size = new System.Drawing.Size(10, 13);
            this.DirectionValue.TabIndex = 14;
            this.DirectionValue.Text = "-";
            // 
            // SpeedValue
            // 
            this.SpeedValue.AutoSize = true;
            this.SpeedValue.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SpeedValue.Location = new System.Drawing.Point(28, 151);
            this.SpeedValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SpeedValue.Name = "SpeedValue";
            this.SpeedValue.Size = new System.Drawing.Size(21, 20);
            this.SpeedValue.TabIndex = 13;
            this.SpeedValue.Text = "0";
            // 
            // DirectionName
            // 
            this.DirectionName.AutoSize = true;
            this.DirectionName.Location = new System.Drawing.Point(98, 127);
            this.DirectionName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.DirectionName.Name = "DirectionName";
            this.DirectionName.Size = new System.Drawing.Size(49, 13);
            this.DirectionName.TabIndex = 12;
            this.DirectionName.Text = "Direction";
            // 
            // SpeedName
            // 
            this.SpeedName.AutoSize = true;
            this.SpeedName.Location = new System.Drawing.Point(22, 127);
            this.SpeedName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SpeedName.Name = "SpeedName";
            this.SpeedName.Size = new System.Drawing.Size(38, 13);
            this.SpeedName.TabIndex = 11;
            this.SpeedName.Text = "Speed";
            // 
            // OutputLog
            // 
            this.OutputLog.Location = new System.Drawing.Point(8, 183);
            this.OutputLog.Margin = new System.Windows.Forms.Padding(2);
            this.OutputLog.Name = "OutputLog";
            this.OutputLog.ReadOnly = true;
            this.OutputLog.Size = new System.Drawing.Size(308, 47);
            this.OutputLog.TabIndex = 9;
            this.OutputLog.Text = "";
            this.OutputLog.TextChanged += new System.EventHandler(this.OutputLog_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.StatusLabel);
            this.panel1.Controls.Add(this.StatusDescriptionLabel);
            this.panel1.Location = new System.Drawing.Point(2, 601);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(177, 20);
            this.panel1.TabIndex = 8;
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Location = new System.Drawing.Point(2, 2);
            this.StatusLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(43, 13);
            this.StatusLabel.TabIndex = 6;
            this.StatusLabel.Text = "Status: ";
            // 
            // StatusDescriptionLabel
            // 
            this.StatusDescriptionLabel.AutoSize = true;
            this.StatusDescriptionLabel.Location = new System.Drawing.Point(45, 2);
            this.StatusDescriptionLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.StatusDescriptionLabel.Name = "StatusDescriptionLabel";
            this.StatusDescriptionLabel.Size = new System.Drawing.Size(79, 13);
            this.StatusDescriptionLabel.TabIndex = 7;
            this.StatusDescriptionLabel.Text = "Not Connected";
            this.StatusDescriptionLabel.Click += new System.EventHandler(this.StatusDescriptionLabel_Click);
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(8, 80);
            this.ConnectButton.Margin = new System.Windows.Forms.Padding(2);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(162, 26);
            this.ConnectButton.TabIndex = 10;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // VehicleLabel
            // 
            this.VehicleLabel.AutoSize = true;
            this.VehicleLabel.Location = new System.Drawing.Point(6, 48);
            this.VehicleLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.VehicleLabel.Name = "VehicleLabel";
            this.VehicleLabel.Size = new System.Drawing.Size(42, 13);
            this.VehicleLabel.TabIndex = 4;
            this.VehicleLabel.Text = "Vehicle";
            // 
            // VehiclesDropDown
            // 
            this.VehiclesDropDown.FormattingEnabled = true;
            this.VehiclesDropDown.Location = new System.Drawing.Point(65, 46);
            this.VehiclesDropDown.Margin = new System.Windows.Forms.Padding(2);
            this.VehiclesDropDown.Name = "VehiclesDropDown";
            this.VehiclesDropDown.Size = new System.Drawing.Size(106, 21);
            this.VehiclesDropDown.TabIndex = 2;
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Location = new System.Drawing.Point(6, 13);
            this.UsernameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(55, 13);
            this.UsernameLabel.TabIndex = 1;
            this.UsernameLabel.Text = "Username";
            // 
            // UsernameTextBox
            // 
            this.UsernameTextBox.Location = new System.Drawing.Point(65, 11);
            this.UsernameTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.UsernameTextBox.Name = "UsernameTextBox";
            this.UsernameTextBox.Size = new System.Drawing.Size(106, 20);
            this.UsernameTextBox.TabIndex = 0;
            // 
            // logBox
            // 
            this.logBox.Location = new System.Drawing.Point(9, 235);
            this.logBox.Name = "logBox";
            this.logBox.ReadOnly = true;
            this.logBox.Size = new System.Drawing.Size(306, 153);
            this.logBox.TabIndex = 15;
            this.logBox.Text = "";
            this.logBox.TextChanged += new System.EventHandler(this.logBox_TextChanged);
            // 
            // CosmosInvaders_Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 624);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(2);
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
        private System.Windows.Forms.Label VehicleLabel;
        private System.Windows.Forms.ComboBox VehiclesDropDown;
        private System.Windows.Forms.Label StatusDescriptionLabel;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox OutputLog;
        private System.Windows.Forms.Label DirectionValue;
        private System.Windows.Forms.Label SpeedValue;
        private System.Windows.Forms.Label DirectionName;
        private System.Windows.Forms.Label SpeedName;
        private System.Windows.Forms.RichTextBox messageBox;
        private System.Windows.Forms.Button sendMessage;
        private System.Windows.Forms.TextBox message;
        private System.Windows.Forms.RichTextBox positionSaves;
        private System.Windows.Forms.RichTextBox logBox;
    }
}

