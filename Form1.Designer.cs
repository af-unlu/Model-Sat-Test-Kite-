
namespace ModelSat_Test_Kite
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
            this.components = new System.ComponentModel.Container();
            this.richTextBox_console = new System.Windows.Forms.RichTextBox();
            this.button_pid_send = new System.Windows.Forms.Button();
            this.textBox_KD = new System.Windows.Forms.TextBox();
            this.textBox_KI = new System.Windows.Forms.TextBox();
            this.textBox_KP = new System.Windows.Forms.TextBox();
            this.button_Ayril = new System.Windows.Forms.Button();
            this.button_clean = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button_TeamNumberSend = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBox_console
            // 
            this.richTextBox_console.BackColor = System.Drawing.SystemColors.MenuText;
            this.richTextBox_console.ForeColor = System.Drawing.SystemColors.Info;
            this.richTextBox_console.Location = new System.Drawing.Point(506, 12);
            this.richTextBox_console.Name = "richTextBox_console";
            this.richTextBox_console.Size = new System.Drawing.Size(344, 446);
            this.richTextBox_console.TabIndex = 0;
            this.richTextBox_console.Text = "";
            // 
            // button_pid_send
            // 
            this.button_pid_send.Location = new System.Drawing.Point(12, 12);
            this.button_pid_send.Name = "button_pid_send";
            this.button_pid_send.Size = new System.Drawing.Size(110, 42);
            this.button_pid_send.TabIndex = 1;
            this.button_pid_send.Text = "PID Send";
            this.button_pid_send.UseVisualStyleBackColor = true;
            this.button_pid_send.Click += new System.EventHandler(this.button_pid_send_Click);
            // 
            // textBox_KD
            // 
            this.textBox_KD.Location = new System.Drawing.Point(12, 128);
            this.textBox_KD.Name = "textBox_KD";
            this.textBox_KD.Size = new System.Drawing.Size(110, 23);
            this.textBox_KD.TabIndex = 2;
            // 
            // textBox_KI
            // 
            this.textBox_KI.Location = new System.Drawing.Point(12, 99);
            this.textBox_KI.Name = "textBox_KI";
            this.textBox_KI.Size = new System.Drawing.Size(110, 23);
            this.textBox_KI.TabIndex = 3;
            // 
            // textBox_KP
            // 
            this.textBox_KP.Location = new System.Drawing.Point(12, 70);
            this.textBox_KP.Name = "textBox_KP";
            this.textBox_KP.Size = new System.Drawing.Size(110, 23);
            this.textBox_KP.TabIndex = 4;
            // 
            // button_Ayril
            // 
            this.button_Ayril.Location = new System.Drawing.Point(319, 12);
            this.button_Ayril.Name = "button_Ayril";
            this.button_Ayril.Size = new System.Drawing.Size(100, 42);
            this.button_Ayril.TabIndex = 5;
            this.button_Ayril.Text = "Ayrıl";
            this.button_Ayril.UseVisualStyleBackColor = true;
            this.button_Ayril.Click += new System.EventHandler(this.button_Ayril_Click);
            // 
            // button_clean
            // 
            this.button_clean.Location = new System.Drawing.Point(319, 82);
            this.button_clean.Name = "button_clean";
            this.button_clean.Size = new System.Drawing.Size(90, 40);
            this.button_clean.TabIndex = 6;
            this.button_clean.Text = "Clean";
            this.button_clean.UseVisualStyleBackColor = true;
            this.button_clean.Click += new System.EventHandler(this.button_clean_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button_TeamNumberSend
            // 
            this.button_TeamNumberSend.Location = new System.Drawing.Point(319, 148);
            this.button_TeamNumberSend.Name = "button_TeamNumberSend";
            this.button_TeamNumberSend.Size = new System.Drawing.Size(150, 57);
            this.button_TeamNumberSend.TabIndex = 7;
            this.button_TeamNumberSend.Text = "Team Number Send";
            this.button_TeamNumberSend.UseVisualStyleBackColor = true;
            this.button_TeamNumberSend.Click += new System.EventHandler(this.button_TeamNumberSend_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(319, 231);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 48);
            this.button1.TabIndex = 8;
            this.button1.Text = "VStream is ON";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 492);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button_TeamNumberSend);
            this.Controls.Add(this.button_clean);
            this.Controls.Add(this.button_Ayril);
            this.Controls.Add(this.textBox_KP);
            this.Controls.Add(this.textBox_KI);
            this.Controls.Add(this.textBox_KD);
            this.Controls.Add(this.button_pid_send);
            this.Controls.Add(this.richTextBox_console);
            this.Name = "Form1";
            this.Text = "Test Kit";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox_console;
        private System.Windows.Forms.Button button_pid_send;
        private System.Windows.Forms.TextBox textBox_KD;
        private System.Windows.Forms.TextBox textBox_KI;
        private System.Windows.Forms.TextBox textBox_KP;
        private System.Windows.Forms.Button button_Ayril;
        private System.Windows.Forms.Button button_clean;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button_TeamNumberSend;
        private System.Windows.Forms.Button button1;
    }
}

