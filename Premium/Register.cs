using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using GhostAuth;
using Guna.UI2.WinForms;
using Siticone.UI.WinForms;

namespace Premium
{
	// Token: 0x0200002A RID: 42
	public class Register : Form
	{
		// Token: 0x06000110 RID: 272 RVA: 0x00002B6A File Offset: 0x00000D6A
		public Register()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000111 RID: 273 RVA: 0x00014144 File Offset: 0x00012344
		private void registerConfirm_Click(object sender, EventArgs e)
		{
			if (API.Register(this.username.Text, this.password.Text, this.email.Text, this.license.Text))
			{
				MessageBox.Show("Enjoy Premium :)", "GhostAccount Created!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		// Token: 0x06000112 RID: 274 RVA: 0x00002B78 File Offset: 0x00000D78
		private void guna2GradientTileButton1_Click(object sender, EventArgs e)
		{
			base.Hide();
			new Login().Show();
		}

		// Token: 0x06000113 RID: 275 RVA: 0x00002B8A File Offset: 0x00000D8A
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000114 RID: 276 RVA: 0x000141A4 File Offset: 0x000123A4
		private void InitializeComponent()
		{
			this.components = new Container();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Register));
			this.guna2PictureBox1 = new Guna2PictureBox();
			this.siticoneLabel1 = new SiticoneLabel();
			this.closeButton = new SiticoneControlBox();
			this.minimizeButton = new SiticoneControlBox();
			this.username = new SiticoneRoundedTextBox();
			this.email = new SiticoneRoundedTextBox();
			this.password = new SiticoneRoundedTextBox();
			this.license = new SiticoneRoundedTextBox();
			this.version = new SiticoneLabel();
			this.registerConfirm = new Guna2GradientTileButton();
			this.guna2GradientTileButton1 = new Guna2GradientTileButton();
			this.drag = new SiticoneCircleButton();
			this.siticoneDragControl1 = new SiticoneDragControl(this.components);
			this.label1 = new Label();
			base.SuspendLayout();
			this.guna2PictureBox1.Image = (Image)componentResourceManager.GetObject("guna2PictureBox1.Image");
			this.guna2PictureBox1.Location = new Point(12, 12);
			this.guna2PictureBox1.Margin = new Padding(2, 3, 2, 3);
			this.guna2PictureBox1.Name = "guna2PictureBox1";
			this.guna2PictureBox1.ShadowDecoration.Parent = this.guna2PictureBox1;
			this.guna2PictureBox1.Size = new Size(32, 30);
			this.guna2PictureBox1.TabIndex = 0;
			this.guna2PictureBox1.TabStop = false;
			this.siticoneLabel1.BackColor = Color.Transparent;
			this.siticoneLabel1.Font = new Font("Microsoft Sans Serif", 16.25f, FontStyle.Bold);
			this.siticoneLabel1.ForeColor = Color.White;
			this.siticoneLabel1.Location = new Point(50, 12);
			this.siticoneLabel1.Margin = new Padding(2, 3, 2, 3);
			this.siticoneLabel1.Name = "siticoneLabel1";
			this.siticoneLabel1.Size = new Size(92, 28);
			this.siticoneLabel1.TabIndex = 1;
			this.siticoneLabel1.Text = "Register";
			this.closeButton.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.closeButton.ControlBoxStyle =  Siticone.UI.WinForms.Enums.ControlBoxStyle.Windows10;
			this.closeButton.FillColor = Color.Transparent;
			this.closeButton.HoveredState.Parent = this.closeButton;
			this.closeButton.IconColor = Color.Red;
			this.closeButton.Location = new Point(242, 13);
			this.closeButton.Margin = new Padding(2, 3, 2, 3);
			this.closeButton.Name = "closeButton";
			this.closeButton.PressedColor = Color.Purple;
			this.closeButton.ShadowDecoration.Parent = this.closeButton;
			this.closeButton.Size = new Size(20, 30);
			this.closeButton.TabIndex = 2;
			this.minimizeButton.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.minimizeButton.ControlBoxStyle =  Siticone.UI.WinForms.Enums.ControlBoxStyle.Windows10;
			this.minimizeButton.ControlBoxType = 0;
			this.minimizeButton.FillColor = Color.Transparent;
			this.minimizeButton.HoveredState.Parent = this.minimizeButton;
			this.minimizeButton.IconColor = Color.Red;
			this.minimizeButton.Location = new Point(210, 13);
			this.minimizeButton.Margin = new Padding(2, 3, 2, 3);
			this.minimizeButton.Name = "minimizeButton";
			this.minimizeButton.PressedColor = Color.Purple;
			this.minimizeButton.ShadowDecoration.Parent = this.minimizeButton;
			this.minimizeButton.Size = new Size(26, 30);
			this.minimizeButton.TabIndex = 3;
			this.username.BackColor = Color.Transparent;
			this.username.Cursor = Cursors.IBeam;
			this.username.DefaultText = "";
			this.username.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
			this.username.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
			this.username.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
			this.username.DisabledState.Parent = this.username;
			this.username.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
			this.username.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
			this.username.FocusedState.Parent = this.username;
			this.username.ForeColor = Color.Black;
			this.username.HoveredState.BorderColor = Color.FromArgb(94, 148, 255);
			this.username.HoveredState.Parent = this.username;
			this.username.Location = new Point(36, 74);
			this.username.Margin = new Padding(2, 1, 2, 1);
			this.username.MaxLength = 33;
			this.username.Name = "username";
			this.username.PasswordChar = '\0';
			this.username.PlaceholderForeColor = Color.DimGray;
			this.username.PlaceholderText = "Username";
			this.username.SelectedText = "";
			this.username.ShadowDecoration.Parent = this.username;
			this.username.Size = new Size(200, 36);
			this.username.TabIndex = 4;
			this.username.TextAlign = HorizontalAlignment.Center;
			this.email.BackColor = Color.Transparent;
			this.email.Cursor = Cursors.IBeam;
			this.email.DefaultText = "";
			this.email.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
			this.email.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
			this.email.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
			this.email.DisabledState.Parent = this.email;
			this.email.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
			this.email.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
			this.email.FocusedState.Parent = this.email;
			this.email.ForeColor = Color.Black;
			this.email.HoveredState.BorderColor = Color.FromArgb(94, 148, 255);
			this.email.HoveredState.Parent = this.email;
			this.email.Location = new Point(36, 112);
			this.email.Margin = new Padding(2, 1, 2, 1);
			this.email.MaxLength = 164;
			this.email.Name = "email";
			this.email.PasswordChar = '\0';
			this.email.PlaceholderForeColor = Color.DimGray;
			this.email.PlaceholderText = "Email";
			this.email.SelectedText = "";
			this.email.ShadowDecoration.Parent = this.email;
			this.email.Size = new Size(200, 36);
			this.email.TabIndex = 5;
			this.email.TextAlign = HorizontalAlignment.Center;
			this.password.BackColor = Color.Transparent;
			this.password.Cursor = Cursors.IBeam;
			this.password.DefaultText = "";
			this.password.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
			this.password.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
			this.password.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
			this.password.DisabledState.Parent = this.password;
			this.password.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
			this.password.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
			this.password.FocusedState.Parent = this.password;
			this.password.ForeColor = Color.Black;
			this.password.HoveredState.BorderColor = Color.FromArgb(94, 148, 255);
			this.password.HoveredState.Parent = this.password;
			this.password.Location = new Point(36, 150);
			this.password.Margin = new Padding(2, 1, 2, 1);
			this.password.MaxLength = 128;
			this.password.Name = "password";
			this.password.PasswordChar = '\0';
			this.password.PlaceholderForeColor = Color.DimGray;
			this.password.PlaceholderText = "Password";
			this.password.SelectedText = "";
			this.password.ShadowDecoration.Parent = this.password;
			this.password.Size = new Size(200, 36);
			this.password.TabIndex = 6;
			this.password.TextAlign = HorizontalAlignment.Center;
			this.license.BackColor = Color.Transparent;
			this.license.Cursor = Cursors.IBeam;
			this.license.DefaultText = "";
			this.license.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
			this.license.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
			this.license.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
			this.license.DisabledState.Parent = this.license;
			this.license.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
			this.license.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
			this.license.FocusedState.Parent = this.license;
			this.license.ForeColor = Color.Black;
			this.license.HoveredState.BorderColor = Color.FromArgb(94, 148, 255);
			this.license.HoveredState.Parent = this.license;
			this.license.Location = new Point(36, 188);
			this.license.Margin = new Padding(2, 1, 2, 1);
			this.license.MaxLength = 256;
			this.license.Name = "license";
			this.license.PasswordChar = '\0';
			this.license.PlaceholderForeColor = Color.DimGray;
			this.license.PlaceholderText = "License";
			this.license.SelectedText = "";
			this.license.ShadowDecoration.Parent = this.license;
			this.license.Size = new Size(200, 36);
			this.license.TabIndex = 7;
			this.license.TextAlign = HorizontalAlignment.Center;
			this.version.BackColor = Color.Transparent;
			this.version.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.version.ForeColor = Color.White;
			this.version.Location = new Point(228, 331);
			this.version.Margin = new Padding(2, 3, 2, 3);
			this.version.Name = "version";
			this.version.Size = new Size(35, 17);
			this.version.TabIndex = 8;
			this.version.Text = "2.5.1";
			this.registerConfirm.Animated = true;
			this.registerConfirm.CheckedState.Parent = this.registerConfirm;
			this.registerConfirm.CustomImages.Parent = this.registerConfirm;
			this.registerConfirm.FillColor2 = Color.FromArgb(64, 0, 64);
			this.registerConfirm.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.registerConfirm.ForeColor = Color.White;
			this.registerConfirm.HoverState.Parent = this.registerConfirm;
			this.registerConfirm.Location = new Point(43, 244);
			this.registerConfirm.Margin = new Padding(2, 3, 2, 3);
			this.registerConfirm.Name = "registerConfirm";
			this.registerConfirm.ShadowDecoration.Parent = this.registerConfirm;
			this.registerConfirm.Size = new Size(193, 38);
			this.registerConfirm.TabIndex = 9;
			this.registerConfirm.Text = "Register";
			this.registerConfirm.Click += this.registerConfirm_Click;
			this.guna2GradientTileButton1.Animated = true;
			this.guna2GradientTileButton1.CheckedState.Parent = this.guna2GradientTileButton1;
			this.guna2GradientTileButton1.CustomImages.Parent = this.guna2GradientTileButton1;
			this.guna2GradientTileButton1.FillColor = Color.DarkCyan;
			this.guna2GradientTileButton1.FillColor2 = Color.DeepPink;
			this.guna2GradientTileButton1.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.guna2GradientTileButton1.ForeColor = Color.White;
			this.guna2GradientTileButton1.HoverState.Parent = this.guna2GradientTileButton1;
			this.guna2GradientTileButton1.Location = new Point(43, 288);
			this.guna2GradientTileButton1.Margin = new Padding(2, 3, 2, 3);
			this.guna2GradientTileButton1.Name = "guna2GradientTileButton1";
			this.guna2GradientTileButton1.ShadowDecoration.Parent = this.guna2GradientTileButton1;
			this.guna2GradientTileButton1.Size = new Size(193, 37);
			this.guna2GradientTileButton1.TabIndex = 10;
			this.guna2GradientTileButton1.Text = "Return to Login";
			this.guna2GradientTileButton1.Click += this.guna2GradientTileButton1_Click;
			this.drag.CheckedState.Parent = this.drag;
			this.drag.CustomImages.Parent = this.drag;
			this.drag.FillColor = Color.Black;
			this.drag.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
			this.drag.ForeColor = Color.White;
			this.drag.HoveredState.Parent = this.drag;
			this.drag.Location = new Point(5, 318);
			this.drag.Name = "drag";
			this.drag.ShadowDecoration.Parent = this.drag;
			this.drag.Size = new Size(33, 30);
			this.drag.TabIndex = 11;
			this.drag.Text = "=";
			this.siticoneDragControl1.TargetControl = this.drag;
			this.label1.AutoSize = true;
			this.label1.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label1.ForeColor = Color.White;
			this.label1.Location = new Point(9, 46);
			this.label1.Name = "label1";
			this.label1.Size = new Size(246, 15);
			this.label1.TabIndex = 12;
			this.label1.Text = "Pro Tip: Type something and delete it";
			base.AcceptButton = this.registerConfirm;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = Color.Black;
			base.ClientSize = new Size(275, 351);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.drag);
			base.Controls.Add(this.guna2GradientTileButton1);
			base.Controls.Add(this.registerConfirm);
			base.Controls.Add(this.version);
			base.Controls.Add(this.license);
			base.Controls.Add(this.password);
			base.Controls.Add(this.email);
			base.Controls.Add(this.username);
			base.Controls.Add(this.minimizeButton);
			base.Controls.Add(this.closeButton);
			base.Controls.Add(this.siticoneLabel1);
			base.Controls.Add(this.guna2PictureBox1);
			base.FormBorderStyle = FormBorderStyle.None;
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.Margin = new Padding(2, 3, 2, 3);
			base.Name = "Register";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Register";
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000146 RID: 326
		private IContainer components;

		// Token: 0x04000147 RID: 327
		private Guna2PictureBox guna2PictureBox1;

		// Token: 0x04000148 RID: 328
		private SiticoneLabel siticoneLabel1;

		// Token: 0x04000149 RID: 329
		private SiticoneControlBox closeButton;

		// Token: 0x0400014A RID: 330
		private SiticoneControlBox minimizeButton;

		// Token: 0x0400014B RID: 331
		private SiticoneRoundedTextBox username;

		// Token: 0x0400014C RID: 332
		private SiticoneRoundedTextBox email;

		// Token: 0x0400014D RID: 333
		private SiticoneRoundedTextBox password;

		// Token: 0x0400014E RID: 334
		private SiticoneRoundedTextBox license;

		// Token: 0x0400014F RID: 335
		private SiticoneLabel version;

		// Token: 0x04000150 RID: 336
		private Guna2GradientTileButton registerConfirm;

		// Token: 0x04000151 RID: 337
		private Guna2GradientTileButton guna2GradientTileButton1;

		// Token: 0x04000152 RID: 338
		private SiticoneCircleButton drag;

		// Token: 0x04000153 RID: 339
		private SiticoneDragControl siticoneDragControl1;

		// Token: 0x04000154 RID: 340
		private Label label1;
	}
}
