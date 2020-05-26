namespace Client2
{
    partial class Login
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.yourName = new System.Windows.Forms.TextBox();
            this.enterName = new System.Windows.Forms.TextBox();
            this.signIn = new System.Windows.Forms.Button();
            this.chatIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.chatIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // yourName
            // 
            this.yourName.Location = new System.Drawing.Point(38, 225);
            this.yourName.Name = "yourName";
            this.yourName.Size = new System.Drawing.Size(73, 22);
            this.yourName.TabIndex = 1;
            this.yourName.Text = "Your name";
            this.yourName.TextChanged += new System.EventHandler(this.yourName_TextChanged);
            // 
            // enterName
            // 
            this.enterName.Location = new System.Drawing.Point(38, 253);
            this.enterName.Name = "enterName";
            this.enterName.Size = new System.Drawing.Size(222, 22);
            this.enterName.TabIndex = 2;
            this.enterName.TextChanged += new System.EventHandler(this.enterName_TextChanged);
            // 
            // signIn
            // 
            this.signIn.ForeColor = System.Drawing.SystemColors.Highlight;
            this.signIn.Location = new System.Drawing.Point(79, 303);
            this.signIn.Name = "signIn";
            this.signIn.Size = new System.Drawing.Size(124, 47);
            this.signIn.TabIndex = 3;
            this.signIn.Text = "Sign In";
            this.signIn.UseVisualStyleBackColor = true;
            this.signIn.Click += new System.EventHandler(this.signIn_Click);
            // 
            // chatIcon
            // 
            this.chatIcon.Image = global::Client2.Properties.Resources.ChatIcon1;
            this.chatIcon.Location = new System.Drawing.Point(67, 45);
            this.chatIcon.Name = "chatIcon";
            this.chatIcon.Size = new System.Drawing.Size(155, 134);
            this.chatIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.chatIcon.TabIndex = 0;
            this.chatIcon.TabStop = false;
            this.chatIcon.Click += new System.EventHandler(this.chatIcon_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.signIn);
            this.Controls.Add(this.enterName);
            this.Controls.Add(this.yourName);
            this.Controls.Add(this.chatIcon);
            this.Name = "Login";
            this.Size = new System.Drawing.Size(290, 500);
            ((System.ComponentModel.ISupportInitialize)(this.chatIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox chatIcon;
        private System.Windows.Forms.TextBox yourName;
        private System.Windows.Forms.TextBox enterName;
        private System.Windows.Forms.Button signIn;
    }
}
