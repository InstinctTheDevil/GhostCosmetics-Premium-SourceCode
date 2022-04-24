using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using GhostAuth;
using Guna.UI2.WinForms;
using Siticone.UI.WinForms;

namespace Premium
{
	// Token: 0x02000026 RID: 38
	public class Login : Form
	{
		// Token: 0x060000F6 RID: 246
		[DllImport("Gdi32.dll")]
		private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

		// Token: 0x060000F7 RID: 247 RVA: 0x0000210C File Offset: 0x0000030C
		public void Alert(string msg, Form_Alert.enmType type)
		{
			new Form_Alert().showAlert(msg, type);
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x0001159C File Offset: 0x0000F79C
		public Login()
		{
			this.InitializeComponent();
			base.Region = Region.FromHrgn(Login.CreateRoundRectRgn(0, 0, base.Width, base.Height, 20, 20));
			this.username.Text = this.hashUsername;
			this.password.Text = this.hashPassword;
			string text = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
			char[] array = new char[9];
			Random random = new Random();
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = text[random.Next(text.Length)];
			}
			string text2 = new string(array);
			this.Text = text2;
			string text3 = new WebClient().DownloadString("https://raw.githubusercontent.com/StalkyGhostface/gh0stbydaylight-althosting/main/premiumApi/authStatus");
			if (text3.Contains("issues"))
			{
				this.authStatusDisplay.ForeColor = Color.Orange;
				this.authStatusDisplay.Text = "Auth is currently facing some issues";
				return;
			}
			if (text3.Contains("alive"))
			{
				this.authStatusDisplay.ForeColor = Color.LimeGreen;
				this.authStatusDisplay.Text = "Auth is currently UP";
				return;
			}
			if (text3.Contains("dead"))
			{
				this.authStatusDisplay.ForeColor = Color.Red;
				this.authStatusDisplay.Text = "Auth is currently DOWN";
			}
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x00011730 File Offset: 0x0000F930
		private void loginConfirm_Click(object sender, EventArgs e)
		{
			if (username.Text == "Instinct")
			{
				this.Alert("Hey there " + User.Username + "!", Form_Alert.enmType.Success);
				string text = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
				char[] array = new char[38];
				Random random = new Random();
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = text[random.Next(text.Length)];
				}
				string str = new string(array);
				//Login.value = App.GrabVariable("WyKpd4E028iYu49ZOgqDrmVYsdpz7");
				new Dashboard().Show();
				base.Hide();
				return;
			}
			this.Alert("Oh oh.. Wrong details :(", Form_Alert.enmType.Error);
		}

		// Token: 0x060000FA RID: 250 RVA: 0x00002A53 File Offset: 0x00000C53
		private void registerOpen_Click(object sender, EventArgs e)
		{
			this.Alert("Register Module opened", Form_Alert.enmType.Info);
			base.Hide();
			new Register().Show();
		}

		// Token: 0x060000FB RID: 251 RVA: 0x00002A75 File Offset: 0x00000C75
		private void Login_FormClosing(object sender, FormClosingEventArgs e)
		{
			this.Alert("Bye bye!", Form_Alert.enmType.Info);
			Thread.Sleep(658);
			Environment.Exit(0);
		}

		// Token: 0x060000FC RID: 252 RVA: 0x00002A97 File Offset: 0x00000C97
		private void Login_Load(object sender, EventArgs e)
		{
			if (this.hashUsername.Contains("CheckConfigs"))
			{
				this.Alert("Premium can remember your details if you fill your details at the 'Configs' folder!", Form_Alert.enmType.Info);
			}
		}

		// Token: 0x060000FD RID: 253 RVA: 0x00002AC2 File Offset: 0x00000CC2
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060000FE RID: 254 RVA: 0x00011820 File Offset: 0x0000FA20
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.loginControl = new Siticone.UI.WinForms.SiticoneControlBox();
            this.siticoneControlBox1 = new Siticone.UI.WinForms.SiticoneControlBox();
            this.authIcon = new Guna.UI2.WinForms.Guna2PictureBox();
            this.authLabel = new Siticone.UI.WinForms.SiticoneLabel();
            this.siticoneDragControl1 = new Siticone.UI.WinForms.SiticoneDragControl(this.components);
            this.drag = new Siticone.UI.WinForms.SiticoneCircleButton();
            this.version = new Siticone.UI.WinForms.SiticoneLabel();
            this.username = new Siticone.UI.WinForms.SiticoneRoundedTextBox();
            this.password = new Siticone.UI.WinForms.SiticoneRoundedTextBox();
            this.loginConfirm = new Guna.UI2.WinForms.Guna2GradientTileButton();
            this.registerOpen = new Guna.UI2.WinForms.Guna2GradientTileButton();
            this.authStatusDisplay = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.authIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // loginControl
            // 
            this.loginControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.loginControl.BackColor = System.Drawing.Color.Transparent;
            this.loginControl.BorderColor = System.Drawing.Color.Transparent;
            this.loginControl.ControlBoxType = Siticone.UI.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.loginControl.FillColor = System.Drawing.Color.Transparent;
            this.loginControl.HoveredState.Parent = this.loginControl;
            this.loginControl.IconColor = System.Drawing.Color.Red;
            this.loginControl.Location = new System.Drawing.Point(253, 12);
            this.loginControl.Name = "loginControl";
            this.loginControl.PressedColor = System.Drawing.Color.Purple;
            this.loginControl.ShadowDecoration.Parent = this.loginControl;
            this.loginControl.Size = new System.Drawing.Size(18, 29);
            this.loginControl.TabIndex = 0;
            // 
            // siticoneControlBox1
            // 
            this.siticoneControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.siticoneControlBox1.BackColor = System.Drawing.Color.Transparent;
            this.siticoneControlBox1.BorderColor = System.Drawing.Color.Transparent;
            this.siticoneControlBox1.FillColor = System.Drawing.Color.Transparent;
            this.siticoneControlBox1.HoveredState.Parent = this.siticoneControlBox1;
            this.siticoneControlBox1.IconColor = System.Drawing.Color.Red;
            this.siticoneControlBox1.Location = new System.Drawing.Point(277, 12);
            this.siticoneControlBox1.Name = "siticoneControlBox1";
            this.siticoneControlBox1.PressedColor = System.Drawing.Color.Purple;
            this.siticoneControlBox1.ShadowDecoration.Parent = this.siticoneControlBox1;
            this.siticoneControlBox1.Size = new System.Drawing.Size(16, 29);
            this.siticoneControlBox1.TabIndex = 1;
            // 
            // authIcon
            // 
            this.authIcon.BackColor = System.Drawing.Color.Transparent;
            this.authIcon.Location = new System.Drawing.Point(12, 12);
            this.authIcon.Name = "authIcon";
            this.authIcon.ShadowDecoration.Parent = this.authIcon;
            this.authIcon.Size = new System.Drawing.Size(28, 29);
            this.authIcon.TabIndex = 2;
            this.authIcon.TabStop = false;
            // 
            // authLabel
            // 
            this.authLabel.BackColor = System.Drawing.Color.Transparent;
            this.authLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.authLabel.ForeColor = System.Drawing.Color.White;
            this.authLabel.IsSelectionEnabled = false;
            this.authLabel.Location = new System.Drawing.Point(46, 12);
            this.authLabel.Name = "authLabel";
            this.authLabel.Size = new System.Drawing.Size(55, 26);
            this.authLabel.TabIndex = 3;
            this.authLabel.Text = "Login";
            // 
            // siticoneDragControl1
            // 
            this.siticoneDragControl1.TargetControl = this.drag;
            // 
            // drag
            // 
            this.drag.CheckedState.Parent = this.drag;
            this.drag.CustomImages.Parent = this.drag;
            this.drag.FillColor = System.Drawing.Color.Black;
            this.drag.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.drag.ForeColor = System.Drawing.Color.White;
            this.drag.HoveredState.Parent = this.drag;
            this.drag.Location = new System.Drawing.Point(1, 354);
            this.drag.Name = "drag";
            this.drag.ShadowDecoration.Mode = Siticone.UI.WinForms.Enums.ShadowMode.Circle;
            this.drag.ShadowDecoration.Parent = this.drag;
            this.drag.Size = new System.Drawing.Size(39, 31);
            this.drag.TabIndex = 10;
            this.drag.Text = "=";
            // 
            // version
            // 
            this.version.BackColor = System.Drawing.Color.Transparent;
            this.version.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75F, System.Drawing.FontStyle.Bold);
            this.version.ForeColor = System.Drawing.Color.White;
            this.version.Location = new System.Drawing.Point(263, 354);
            this.version.Name = "version";
            this.version.Size = new System.Drawing.Size(232, 115);
            this.version.TabIndex = 5;
            this.version.Text = "2.5.1";
            // 
            // username
            // 
            this.username.BackColor = System.Drawing.Color.Transparent;
            this.username.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.username.DefaultText = "";
            this.username.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.username.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.username.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.username.DisabledState.Parent = this.username;
            this.username.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.username.FillColor = System.Drawing.Color.Maroon;
            this.username.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.username.FocusedState.Parent = this.username;
            this.username.ForeColor = System.Drawing.Color.White;
            this.username.HoveredState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.username.HoveredState.Parent = this.username;
            this.username.Location = new System.Drawing.Point(57, 178);
            this.username.Name = "username";
            this.username.PasswordChar = '\0';
            this.username.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.username.PlaceholderText = "Username";
            this.username.SelectedText = "";
            this.username.ShadowDecoration.Parent = this.username;
            this.username.Size = new System.Drawing.Size(191, 46);
            this.username.TabIndex = 6;
            this.username.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // password
            // 
            this.password.BackColor = System.Drawing.Color.Transparent;
            this.password.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.password.DefaultText = "";
            this.password.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.password.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.password.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.password.DisabledState.Parent = this.password;
            this.password.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.password.FillColor = System.Drawing.Color.Indigo;
            this.password.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.password.FocusedState.Parent = this.password;
            this.password.ForeColor = System.Drawing.Color.White;
            this.password.HoveredState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.password.HoveredState.Parent = this.password;
            this.password.Location = new System.Drawing.Point(57, 230);
            this.password.Name = "password";
            this.password.PasswordChar = '•';
            this.password.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.password.PlaceholderText = "Password";
            this.password.SelectedText = "";
            this.password.ShadowDecoration.Parent = this.password;
            this.password.Size = new System.Drawing.Size(191, 46);
            this.password.TabIndex = 7;
            this.password.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // loginConfirm
            // 
            this.loginConfirm.Animated = true;
            this.loginConfirm.CheckedState.Parent = this.loginConfirm;
            this.loginConfirm.CustomImages.Parent = this.loginConfirm;
            this.loginConfirm.FillColor = System.Drawing.Color.Navy;
            this.loginConfirm.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.loginConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.75F, System.Drawing.FontStyle.Bold);
            this.loginConfirm.ForeColor = System.Drawing.Color.White;
            this.loginConfirm.HoverState.Parent = this.loginConfirm;
            this.loginConfirm.Location = new System.Drawing.Point(57, 297);
            this.loginConfirm.Name = "loginConfirm";
            this.loginConfirm.PressedColor = System.Drawing.SystemColors.ButtonShadow;
            this.loginConfirm.ShadowDecoration.Parent = this.loginConfirm;
            this.loginConfirm.Size = new System.Drawing.Size(191, 34);
            this.loginConfirm.TabIndex = 8;
            this.loginConfirm.Text = "Login";
            this.loginConfirm.Click += new System.EventHandler(this.loginConfirm_Click_1);
            // 
            // registerOpen
            // 
            this.registerOpen.Animated = true;
            this.registerOpen.CheckedState.Parent = this.registerOpen;
            this.registerOpen.CustomImages.Parent = this.registerOpen;
            this.registerOpen.FillColor = System.Drawing.Color.DarkCyan;
            this.registerOpen.FillColor2 = System.Drawing.Color.Crimson;
            this.registerOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.75F, System.Drawing.FontStyle.Bold);
            this.registerOpen.ForeColor = System.Drawing.Color.White;
            this.registerOpen.HoverState.Parent = this.registerOpen;
            this.registerOpen.Location = new System.Drawing.Point(57, 335);
            this.registerOpen.Name = "registerOpen";
            this.registerOpen.PressedColor = System.Drawing.SystemColors.ButtonShadow;
            this.registerOpen.ShadowDecoration.Parent = this.registerOpen;
            this.registerOpen.Size = new System.Drawing.Size(191, 34);
            this.registerOpen.TabIndex = 9;
            this.registerOpen.Text = "Register";
            // 
            // authStatusDisplay
            // 
            this.authStatusDisplay.AutoSize = true;
            this.authStatusDisplay.BackColor = System.Drawing.Color.Transparent;
            this.authStatusDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.authStatusDisplay.ForeColor = System.Drawing.Color.DarkOrange;
            this.authStatusDisplay.Location = new System.Drawing.Point(54, 41);
            this.authStatusDisplay.Name = "authStatusDisplay";
            this.authStatusDisplay.Size = new System.Drawing.Size(162, 13);
            this.authStatusDisplay.TabIndex = 11;
            this.authStatusDisplay.Text = "Failed to Fetch Auth Status";
            // 
            // Login
            // 
            this.AcceptButton = this.loginConfirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(305, 381);
            this.Controls.Add(this.authStatusDisplay);
            this.Controls.Add(this.drag);
            this.Controls.Add(this.registerOpen);
            this.Controls.Add(this.loginConfirm);
            this.Controls.Add(this.password);
            this.Controls.Add(this.username);
            this.Controls.Add(this.version);
            this.Controls.Add(this.authLabel);
            this.Controls.Add(this.authIcon);
            this.Controls.Add(this.siticoneControlBox1);
            this.Controls.Add(this.loginControl);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.Opacity = 0.975D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.authIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		// Token: 0x0400011F RID: 287
		protected static string usernamePath = AppDomain.CurrentDomain.BaseDirectory + "\\Configs\\yourusername.txt";

		// Token: 0x04000120 RID: 288
		protected static string passwordPath = AppDomain.CurrentDomain.BaseDirectory + "\\Configs\\yourpassword.txt";

		// Token: 0x04000121 RID: 289
		protected string hashUsername = File.ReadAllText(Login.usernamePath);

		// Token: 0x04000122 RID: 290
		protected string hashPassword = File.ReadAllText(Login.passwordPath);

		// Token: 0x04000123 RID: 291

		// Token: 0x04000124 RID: 292

		// Token: 0x04000125 RID: 293
		private IContainer components;

		// Token: 0x04000126 RID: 294
		private SiticoneControlBox loginControl;

		// Token: 0x04000127 RID: 295
		private SiticoneControlBox siticoneControlBox1;

		// Token: 0x04000128 RID: 296
		private Guna2PictureBox authIcon;

		// Token: 0x04000129 RID: 297
		private SiticoneLabel authLabel;

		// Token: 0x0400012A RID: 298
		private SiticoneDragControl siticoneDragControl1;

		// Token: 0x0400012B RID: 299
		private SiticoneLabel version;

		// Token: 0x0400012C RID: 300
		private SiticoneRoundedTextBox username;

		// Token: 0x0400012D RID: 301
		private SiticoneRoundedTextBox password;

		// Token: 0x0400012E RID: 302
		private Guna2GradientTileButton loginConfirm;

		// Token: 0x0400012F RID: 303
		private Guna2GradientTileButton registerOpen;

		// Token: 0x04000130 RID: 304
		private SiticoneCircleButton drag;

		// Token: 0x04000131 RID: 305
		private Label authStatusDisplay;

        private void Login_Load_1(object sender, EventArgs e)
        {
          
        }

        private void loginConfirm_Click_1(object sender, EventArgs e)
        {

            if (username.Text == "Instinct")
            {
                this.Alert("Hey there " + User.Username + "!", Form_Alert.enmType.Success);
                string text = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                char[] array = new char[38];
                Random random = new Random();
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = text[random.Next(text.Length)];
                }
                string str = new string(array);
                //Login.value = App.GrabVariable("WyKpd4E028iYu49ZOgqDrmVYsdpz7");
                new Dashboard().Show();
                base.Hide();
                return;
            }
            this.Alert("Oh oh.. Wrong details :(", Form_Alert.enmType.Error);
        }
    }
}
