using Siticone.UI.WinForms;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Premium;

public class Form_Alert : Form
{
	// Token: 0x060000BF RID: 191
	[DllImport("Gdi32.dll")]
	private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

	// Token: 0x060000C0 RID: 192 RVA: 0x00002773 File Offset: 0x00000973
	public Form_Alert()
	{
		this.InitializeComponent();
		base.Region = Region.FromHrgn(Form_Alert.CreateRoundRectRgn(0, 0, base.Width, base.Height, 20, 20));
	}

	// Token: 0x060000C1 RID: 193 RVA: 0x000027A3 File Offset: 0x000009A3
	private void closeNoti_Click(object sender, EventArgs e)
	{
		base.Close();
	}

	// Token: 0x060000C2 RID: 194 RVA: 0x0000D524 File Offset: 0x0000B724
	private void timer1_Tick(object sender, EventArgs e)
	{
		switch (this.action)
		{
			case Form_Alert.enmAction.wait:
				this.timer1.Interval = 5000;
				this.action = Form_Alert.enmAction.close;
				return;
			case Form_Alert.enmAction.start:
				this.timer1.Interval = 1;
				base.Opacity += 0.1;
				if (this.x < base.Location.X)
				{
					int left = base.Left;
					base.Left = left - 1;
					return;
				}
				if (base.Opacity == 1.0)
				{
					this.action = Form_Alert.enmAction.wait;
					return;
				}
				break;
			case Form_Alert.enmAction.close:
				this.timer1.Interval = 1;
				base.Opacity -= 0.1;
				base.Left -= 3;
				if (base.Opacity == 0.0)
				{
					base.Close();
				}
				break;
			default:
				return;
		}
	}

	// Token: 0x060000C3 RID: 195 RVA: 0x0000D618 File Offset: 0x0000B818
	public void showAlert(string msg, Form_Alert.enmType type)
	{
		base.Opacity = 0.0;
		base.StartPosition = FormStartPosition.Manual;
		for (int i = 1; i < 10; i++)
		{
			string name = "alert" + i.ToString();
			if ((Form_Alert)Application.OpenForms[name] == null)
			{
				base.Name = name;
				this.x = Screen.PrimaryScreen.WorkingArea.Width - base.Width + 15;
				this.y = Screen.PrimaryScreen.WorkingArea.Height - base.Height * i - 5 * i;
				base.Location = new Point(this.x, this.y);
				break;
			}
		}
		this.x = Screen.PrimaryScreen.WorkingArea.Width - base.Width - 5;
		switch (type)
		{
			case Form_Alert.enmType.Success:
				this.msgType.Text = "Success";
				break;
			case Form_Alert.enmType.Warning:
				this.msgType.Text = "Attention!";
				break;
			case Form_Alert.enmType.Error:
				this.msgType.Text = "Error!";
				break;
			case Form_Alert.enmType.Info:
				this.msgType.Text = "Information";
				break;
		}
		this.lblMsg.Text = msg;
		base.Show();
		this.action = Form_Alert.enmAction.start;
		this.timer1.Interval = 1;
		this.timer1.Start();
	}

	// Token: 0x060000C4 RID: 196 RVA: 0x000027AB File Offset: 0x000009AB
	protected override void Dispose(bool disposing)
	{
		if (disposing && this.components != null)
		{
			this.components.Dispose();
		}
		base.Dispose(disposing);
	}

	// Token: 0x060000C5 RID: 197 RVA: 0x0000D7B0 File Offset: 0x0000B9B0
	private void InitializeComponent()
	{
		this.components = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Form_Alert));
		this.premiumNoti = new PictureBox();
		this.msgType = new Label();
		this.lblMsg = new Label();
		this.closeNoti = new SiticoneCircleButton();
		this.timer1 = new Timer(this.components);
		((ISupportInitialize)this.premiumNoti).BeginInit();
		base.SuspendLayout();
		this.premiumNoti.Image = (Image)componentResourceManager.GetObject("premiumNoti.Image");
		this.premiumNoti.Location = new Point(12, 12);
		this.premiumNoti.Name = "premiumNoti";
		this.premiumNoti.Size = new Size(78, 79);
		this.premiumNoti.SizeMode = PictureBoxSizeMode.StretchImage;
		this.premiumNoti.TabIndex = 0;
		this.premiumNoti.TabStop = false;
		this.msgType.AutoSize = true;
		this.msgType.BackColor = Color.Transparent;
		this.msgType.Font = new Font("Segoe UI Black", 10f, FontStyle.Bold);
		this.msgType.ForeColor = Color.White;
		this.msgType.Location = new Point(108, 9);
		this.msgType.Name = "msgType";
		this.msgType.Size = new Size(130, 19);
		this.msgType.TabIndex = 16;
		this.msgType.Text = "Notification Type";
		this.lblMsg.AutoSize = true;
		this.lblMsg.BackColor = Color.Transparent;
		this.lblMsg.Font = new Font("Segoe UI Semibold", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		this.lblMsg.ForeColor = Color.White;
		this.lblMsg.Location = new Point(109, 44);
		this.lblMsg.Name = "lblMsg";
		this.lblMsg.Size = new Size(86, 17);
		this.lblMsg.TabIndex = 17;
		this.lblMsg.Text = "Stalky = God";
		this.closeNoti.CheckedState.Parent = this.closeNoti;
		this.closeNoti.CustomImages.Parent = this.closeNoti;
		this.closeNoti.FillColor = Color.Purple;
		this.closeNoti.Font = new Font("Segoe UI", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
		this.closeNoti.ForeColor = Color.White;
		this.closeNoti.HoveredState.Parent = this.closeNoti;
		this.closeNoti.Location = new Point(340, 9);
		this.closeNoti.Name = "closeNoti";
		this.closeNoti.ShadowDecoration.Mode =  Siticone.UI.WinForms.Enums.ShadowMode.Custom;
		this.closeNoti.ShadowDecoration.Parent = this.closeNoti;
		this.closeNoti.Size = new Size(30, 31);
		this.closeNoti.TabIndex = 18;
		this.closeNoti.Text = "X";
		this.closeNoti.Click += this.closeNoti_Click;
		this.timer1.Tick += this.timer1_Tick;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		this.BackColor = Color.FromArgb(64, 0, 64);
		base.ClientSize = new Size(382, 101);
		base.Controls.Add(this.closeNoti);
		base.Controls.Add(this.lblMsg);
		base.Controls.Add(this.msgType);
		base.Controls.Add(this.premiumNoti);
		base.FormBorderStyle = FormBorderStyle.None;
		base.Name = "Form_Alert";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		this.Text = "Form_Alert";
		((ISupportInitialize)this.premiumNoti).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	// Token: 0x040000BC RID: 188
	private Form_Alert.enmAction action;

	// Token: 0x040000BD RID: 189
	private int x;

	// Token: 0x040000BE RID: 190
	private int y;

	// Token: 0x040000BF RID: 191
	private IContainer components;

	// Token: 0x040000C0 RID: 192
	private PictureBox premiumNoti;

	// Token: 0x040000C1 RID: 193
	private Label msgType;

	// Token: 0x040000C2 RID: 194
	private Label lblMsg;

	// Token: 0x040000C3 RID: 195
	private SiticoneCircleButton closeNoti;

	// Token: 0x040000C4 RID: 196
	private Timer timer1;

	// Token: 0x0200001A RID: 26
	public enum enmAction
	{
		// Token: 0x040000C6 RID: 198
		wait,
		// Token: 0x040000C7 RID: 199
		start,
		// Token: 0x040000C8 RID: 200
		close
	}

	// Token: 0x0200001B RID: 27
	public enum enmType
	{
		// Token: 0x040000CA RID: 202
		Success,
		// Token: 0x040000CB RID: 203
		Warning,
		// Token: 0x040000CC RID: 204
		Error,
		// Token: 0x040000CD RID: 205
		Info
	}
}