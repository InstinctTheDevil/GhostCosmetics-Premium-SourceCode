using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Fiddler;
using GhostAuth;
using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Suite;

using PremiumCache;
using Siticone.UI.WinForms;

namespace Premium;

public class BetaInit : Form
{
	private IContainer components;

	private SiticoneGradientPanel panelTemp;

	private Label label1;

	private Label tempLabel;

	private Guna2GradientTileButton startUnlinker;

	private Guna2GradientTileButton spoofBloodweb;

	private SiticoneLabel betaUser;

	private SiticoneLabel siticoneLabel1;

	private SiticoneControlBox minimizeForm;

	private SiticoneControlBox closeForm;

	private SiticoneDragControl dragForm;

	[DllImport("Gdi32.dll")]
	private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

	public void Alert(string msg, Form_Alert.enmType type)
	{
		new Form_Alert().showAlert(msg, type);
	}

	public BetaInit()
	{
		InitializeComponent();
		string text = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
		char[] array = new char[8];
		Random random = new Random();
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = text[random.Next(text.Length)];
		}
		string text3 = (Text = new string(array));
		((Control)(object)betaUser).Text = "Beta User: " + User.Username;
		base.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, base.Width, base.Height, 15, 15));
	}

	private void startUnlinker_Click(object sender, EventArgs e)
	{
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected O, but got Unknown
		if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\Configs\\b1.txt"))
		{
			File.Create(AppDomain.CurrentDomain.BaseDirectory + "\\Configs\\b1.txt");
			File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "\\Configs\\b1.txt", "1");
		}
		MessageBox.Show("You're about to participate in the Beta program for the Sets Unlinker Feature. This feature works for STEAM (BYPASS NEEDED), MS, EGS. This is not guaranteed to work. Leave your feedback at Infinity Discord.", "Attention!");
		FiddlerApplication.BeforeResponse += (new SessionStateHandler(FiddlerApplication_BeforeForSkins));
		Alert("Unlinker Beta Initialized", Form_Alert.enmType.Info);
		API.Log(User.Username, "Unlinker Beta");
	}

	public static void FiddlerApplication_BeforeForSkins(Session oSession)
	{
		if (oSession.uriContains("/catalog.json"))
		{
			oSession.utilCreateResponseAndBypassServer();
			oSession.utilSetResponseBody(Cache.unbinderData);
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		this.components = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(BetaInit));
		this.panelTemp = new SiticoneGradientPanel();
		this.tempLabel = new Label();
		this.startUnlinker = new Guna2GradientTileButton();
		this.spoofBloodweb = new Guna2GradientTileButton();
		this.betaUser = new SiticoneLabel();
		this.label1 = new Label();
		this.siticoneLabel1 = new SiticoneLabel();
		this.closeForm = new SiticoneControlBox();
		this.minimizeForm = new SiticoneControlBox();
		this.dragForm = new SiticoneDragControl(this.components);
		this.panelTemp.SuspendLayout();
		base.SuspendLayout();
		this.panelTemp.BackColor = Color.Transparent;
		this.panelTemp.BorderRadius = 10;
		this.panelTemp.Controls.Add(this.minimizeForm);
		this.panelTemp.Controls.Add(this.closeForm);
		this.panelTemp.Controls.Add(this.siticoneLabel1);
		this.panelTemp.Controls.Add(this.label1);
		this.panelTemp.Controls.Add(this.tempLabel);
		this.panelTemp.Controls.Add(this.startUnlinker);
		this.panelTemp.Controls.Add(this.spoofBloodweb);
		this.panelTemp.Controls.Add(this.betaUser);
		this.panelTemp.Cursor = Cursors.Cross;
		this.panelTemp.FillColor = Color.FromArgb(64, 64, 64);
		this.panelTemp.FillColor2 = Color.DarkGray;
		this.panelTemp.Location = new Point(-1, -5);
		this.panelTemp.Name = "panelTemp";
		this.panelTemp.ShadowDecoration.Parent = this.panelTemp;
		this.panelTemp.Size = new Size(510, 229);
		this.panelTemp.TabIndex = 37;
		this.tempLabel.AutoSize = true;
		this.tempLabel.Font = new Font("Segoe UI", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		this.tempLabel.ForeColor = Color.White;
		this.tempLabel.Location = new Point(217, 9);
		this.tempLabel.Name = "tempLabel";
		this.tempLabel.Size = new Size(81, 17);
		this.tempLabel.TabIndex = 34;
		this.tempLabel.Text = "G C  B E T A";
		this.startUnlinker.Animated = true;
		this.startUnlinker.AutoRoundedCorners = true;
		this.startUnlinker.BorderRadius = 22;
		this.startUnlinker.CheckedState.Parent = this.startUnlinker;
		this.startUnlinker.Cursor = Cursors.Cross;
		this.startUnlinker.CustomImages.Parent = this.startUnlinker;
		this.startUnlinker.FillColor = Color.FromArgb(64, 0, 64);
		this.startUnlinker.FillColor2 = Color.DarkBlue;
		this.startUnlinker.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		this.startUnlinker.ForeColor = Color.White;
		this.startUnlinker.HoverState.Parent = this.startUnlinker;
		this.startUnlinker.Location = new Point(14, 35);
		this.startUnlinker.Name = "startUnlinker";
		this.startUnlinker.ShadowDecoration.Parent = this.startUnlinker;
		this.startUnlinker.Size = new Size(103, 47);
		this.startUnlinker.TabIndex = 21;
		this.startUnlinker.Text = "Unlink Sets";
		this.startUnlinker.Click += this.startUnlinker_Click;
		this.spoofBloodweb.Animated = true;
		this.spoofBloodweb.AutoRoundedCorners = true;
		this.spoofBloodweb.BorderRadius = 22;
		this.spoofBloodweb.CheckedState.Parent = this.spoofBloodweb;
		this.spoofBloodweb.CustomImages.Parent = this.spoofBloodweb;
		this.spoofBloodweb.Enabled = false;
		this.spoofBloodweb.FillColor = Color.Navy;
		this.spoofBloodweb.FillColor2 = Color.FromArgb(192, 0, 192);
		this.spoofBloodweb.Font = new Font("Microsoft Sans Serif", 10.75f, FontStyle.Bold);
		this.spoofBloodweb.ForeColor = Color.White;
		this.spoofBloodweb.HoverState.Parent = this.spoofBloodweb;
		this.spoofBloodweb.Location = new Point(123, 35);
		this.spoofBloodweb.Name = "spoofBloodweb";
		this.spoofBloodweb.ShadowDecoration.Parent = this.spoofBloodweb;
		this.spoofBloodweb.Size = new Size(92, 47);
		this.spoofBloodweb.TabIndex = 33;
		this.spoofBloodweb.Text = "CloudID Friends";
		this.betaUser.BackColor = Color.Transparent;
		this.betaUser.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
		this.betaUser.ForeColor = Color.White;
		this.betaUser.IsSelectionEnabled = false;
		this.betaUser.Location = new Point(14, 172);
		this.betaUser.Name = "betaUser";
		this.betaUser.Size = new Size(60, 15);
		this.betaUser.TabIndex = 20;
		this.betaUser.Text = "Loading...";
		this.label1.AutoSize = true;
		this.label1.Font = new Font("Segoe UI", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		this.label1.ForeColor = Color.White;
		this.label1.Location = new Point(11, 190);
		this.label1.Name = "label1";
		this.label1.Size = new Size(37, 17);
		this.label1.TabIndex = 35;
		this.label1.Text = "0.5.0";
		this.siticoneLabel1.BackColor = Color.Transparent;
		this.siticoneLabel1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
		this.siticoneLabel1.ForeColor = Color.White;
		this.siticoneLabel1.IsSelectionEnabled = false;
		this.siticoneLabel1.Location = new Point(14, 151);
		this.siticoneLabel1.Name = "siticoneLabel1";
		this.siticoneLabel1.Size = new Size(380, 15);
		this.siticoneLabel1.TabIndex = 36;
		this.siticoneLabel1.Text = "Note: CloudID Friends is not ready yet. Beta will be released soon.";
		this.closeForm.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
		this.closeForm.FillColor = Color.Transparent;
		this.closeForm.HoveredState.Parent = this.closeForm;
		this.closeForm.IconColor = Color.FromArgb(64, 0, 64);
		this.closeForm.Location = new Point(474, 9);
		this.closeForm.Name = "closeForm";
		this.closeForm.ShadowDecoration.Parent = this.closeForm;
		this.closeForm.Size = new Size(19, 17);
		this.closeForm.TabIndex = 37;
		this.minimizeForm.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
		this.minimizeForm.ControlBoxType = 0;
		this.minimizeForm.FillColor = Color.Transparent;
		this.minimizeForm.HoveredState.Parent = this.minimizeForm;
		this.minimizeForm.IconColor = Color.FromArgb(64, 0, 64);
		this.minimizeForm.Location = new Point(445, 9);
		this.minimizeForm.Name = "minimizeForm";
		this.minimizeForm.ShadowDecoration.Parent = this.minimizeForm;
		this.minimizeForm.Size = new Size(23, 17);
		this.minimizeForm.TabIndex = 38;
		this.dragForm.TargetControl = this.panelTemp;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		this.BackColor = Color.Black;
		base.ClientSize = new Size(500, 216);
		base.Controls.Add(this.panelTemp);
		base.FormBorderStyle = FormBorderStyle.None;
		base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		base.Name = "BetaInit";
		base.StartPosition = FormStartPosition.CenterScreen;
		this.Text = "BetaInit";
		this.panelTemp.ResumeLayout(false);
		this.panelTemp.PerformLayout();
		base.ResumeLayout(false);
	}
}
