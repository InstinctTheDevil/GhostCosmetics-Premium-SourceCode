using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Fiddler;
using GhostAuth;
using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Suite;
using Siticone.UI.WinForms;

namespace Premium;

public class LocalMarket : Form
{
	public static string marketPath = Dashboard.appPath + "\\Configs\\Market.json";

	public static string market = File.ReadAllText(marketPath);

	private IContainer components;

	private Label label1;

	private SiticoneControlBox closeLocal;

	private SiticoneControlBox minimizeLocal;

	private System.Windows.Forms.TextBox localMarketBox;

	private SiticoneLabel thisData;

	private Guna2PictureBox localMarketIcon;

	private Guna2GradientTileButton startLocal;

	private Label localStatus;

	private Guna2GradientTileButton hideButton;

	private NotifyIcon trayLocal;

	private SiticoneCircleButton drag;

	private SiticoneDragControl siticoneDragControl1;

	public LocalMarket()
	{
		InitializeComponent();
		localMarketBox.Text = market;
	}

	public static void FiddlerApplication_BeforeRequest(Session oSession)
	{
		oSession.bBufferResponse = true;
	}

	public static void FiddlerApplication_BeforeResponseLocal(Session oSession)
	{
		if (oSession.fullUrl.Contains("/api/v1/inventories"))
		{
			oSession.utilDecodeResponse();
			oSession.utilSetResponseBody(market);
		}
	}

	private void startLocal_Click(object sender, EventArgs e)
	{
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Expected O, but got Unknown
		localStatus.Text = "Info: Unlocker Ignited";
		API.Log(User.Username, "Local Market ignited");
		((Control)(object)startLocal).Enabled = false;
		FiddlerApplication.BeforeRequest +=(new SessionStateHandler(FiddlerApplication_BeforeRequest));
		FiddlerApplication.BeforeResponse += (new SessionStateHandler(FiddlerApplication_BeforeResponseLocal));
	}

	private void hideButton_Click(object sender, EventArgs e)
	{
		Hide();
		trayLocal.Visible = true;
		MessageBox.Show("Now Hidden at Tray", "Click Local Market Icon at tray to open again!");
		API.Log(User.Username, "Incognito Mode Triggered at Local Market");
	}

	private void trayLocal_MouseClick(object sender, MouseEventArgs e)
	{
		Show();
		trayLocal.Visible = false;
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(LocalMarket));
		this.label1 = new Label();
		this.closeLocal = new SiticoneControlBox();
		this.minimizeLocal = new SiticoneControlBox();
		this.localMarketBox = new System.Windows.Forms.TextBox();
		this.thisData = new SiticoneLabel();
		this.localMarketIcon = new Guna2PictureBox();
		this.startLocal = new Guna2GradientTileButton();
		this.localStatus = new Label();
		this.hideButton = new Guna2GradientTileButton();
		this.trayLocal = new NotifyIcon(this.components);
		this.drag = new SiticoneCircleButton();
		this.siticoneDragControl1 = new SiticoneDragControl(this.components);
		base.SuspendLayout();
		this.label1.AutoSize = true;
		this.label1.Font = new Font("Meiryo UI", 13.75f, FontStyle.Bold);
		this.label1.ForeColor = Color.White;
		this.label1.Location = new Point(58, 18);
		this.label1.Name = "label1";
		this.label1.Size = new Size(137, 24);
		this.label1.TabIndex = 0;
		this.label1.Text = "Local Market";
		this.closeLocal.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
		this.closeLocal.BackColor = Color.Transparent;
		this.closeLocal.BorderColor = Color.Transparent;
		this.closeLocal.ControlBoxStyle =  Siticone.UI.WinForms.Enums.ControlBoxStyle.Windows10;
		this.closeLocal.FillColor = Color.Transparent;
		this.closeLocal.HoveredState.Parent = this.closeLocal;
		this.closeLocal.IconColor = Color.Red;
		this.closeLocal.Location = new Point(753, 12);
		this.closeLocal.Name = "closeLocal";
		this.closeLocal.PressedColor = Color.Purple;
		this.closeLocal.ShadowDecoration.Parent = this.closeLocal;
		this.closeLocal.Size = new Size(35, 43);
		this.closeLocal.TabIndex = 1;
		this.minimizeLocal.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
		this.minimizeLocal.BackColor = Color.Transparent;
		this.minimizeLocal.BorderColor = Color.Transparent;
		this.minimizeLocal.ControlBoxStyle =  Siticone.UI.WinForms.Enums.ControlBoxStyle.Windows10;
		this.minimizeLocal.ControlBoxType = 0;
		this.minimizeLocal.FillColor = Color.Transparent;
		this.minimizeLocal.HoveredState.Parent = this.minimizeLocal;
		this.minimizeLocal.IconColor = Color.Red;
		this.minimizeLocal.Location = new Point(710, 12);
		this.minimizeLocal.Name = "minimizeLocal";
		this.minimizeLocal.PressedColor = Color.Purple;
		this.minimizeLocal.ShadowDecoration.Parent = this.minimizeLocal;
		this.minimizeLocal.Size = new Size(37, 43);
		this.minimizeLocal.TabIndex = 2;
		this.localMarketBox.Font = new Font("Meiryo UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
		this.localMarketBox.Location = new Point(249, 155);
		this.localMarketBox.MaximumSize = new Size(302, 160);
		this.localMarketBox.Multiline = true;
		this.localMarketBox.Name = "localMarketBox";
		this.localMarketBox.ReadOnly = true;
		this.localMarketBox.Size = new Size(302, 159);
		this.localMarketBox.TabIndex = 3;
		this.localMarketBox.Text = "Possible File Corruption or Missing Market File! (Market.json)";
		this.thisData.BackColor = Color.Transparent;
		this.thisData.Font = new Font("Meiryo UI", 15.75f, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
		this.thisData.ForeColor = Color.White;
		this.thisData.Location = new Point(212, 108);
		this.thisData.Name = "thisData";
		this.thisData.Size = new Size(383, 28);
		this.thisData.TabIndex = 4;
		this.thisData.Text = "This is the Data in your Market file";
		this.localMarketIcon.BackColor = Color.Transparent;
		this.localMarketIcon.Image = (Image)componentResourceManager.GetObject("localMarketIcon.Image");
		this.localMarketIcon.Location = new Point(12, 12);
		this.localMarketIcon.Name = "localMarketIcon";
		this.localMarketIcon.ShadowDecoration.Parent = this.localMarketIcon;
		this.localMarketIcon.Size = new Size(40, 35);
		this.localMarketIcon.TabIndex = 5;
		this.localMarketIcon.TabStop = false;
		this.startLocal.Animated = true;
		this.startLocal.CheckedState.Parent = this.startLocal;
		this.startLocal.CustomImages.Parent = this.startLocal;
		this.startLocal.FillColor = Color.Navy;
		this.startLocal.FillColor2 = Color.FromArgb(192, 0, 192);
		this.startLocal.Font = new Font("Meiryo UI", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
		this.startLocal.ForeColor = Color.White;
		this.startLocal.HoverState.Parent = this.startLocal;
		this.startLocal.Location = new Point(249, 325);
		this.startLocal.Name = "startLocal";
		this.startLocal.ShadowDecoration.Parent = this.startLocal;
		this.startLocal.Size = new Size(302, 55);
		this.startLocal.TabIndex = 6;
		this.startLocal.Text = "Start Unlocker";
		this.startLocal.Click += this.startLocal_Click;
		this.localStatus.AutoSize = true;
		this.localStatus.Font = new Font("Meiryo UI", 11.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		this.localStatus.ForeColor = Color.White;
		this.localStatus.Location = new Point(299, 392);
		this.localStatus.Name = "localStatus";
		this.localStatus.Size = new Size(198, 19);
		this.localStatus.TabIndex = 7;
		this.localStatus.Text = "Info: Module Initialized";
		this.hideButton.Animated = true;
		this.hideButton.AutoRoundedCorners = true;
		this.hideButton.BorderRadius = 20;
		this.hideButton.CheckedState.Parent = this.hideButton;
		this.hideButton.CustomImages.Parent = this.hideButton;
		this.hideButton.FillColor = Color.FromArgb(192, 0, 192);
		this.hideButton.FillColor2 = Color.Navy;
		this.hideButton.Font = new Font("Meiryo UI", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
		this.hideButton.ForeColor = Color.White;
		this.hideButton.HoverState.Parent = this.hideButton;
		this.hideButton.Location = new Point(557, 12);
		this.hideButton.Name = "hideButton";
		this.hideButton.ShadowDecoration.Parent = this.hideButton;
		this.hideButton.Size = new Size(147, 43);
		this.hideButton.TabIndex = 8;
		this.hideButton.Text = "Hide at Tray";
		this.hideButton.Click += this.hideButton_Click;
		this.trayLocal.Icon = (Icon)componentResourceManager.GetObject("trayLocal.Icon");
		this.trayLocal.Text = "Local Market";
		this.trayLocal.Visible = true;
		this.trayLocal.MouseClick += this.trayLocal_MouseClick;
		this.drag.BackColor = Color.Transparent;
		this.drag.BorderColor = Color.Transparent;
		this.drag.CheckedState.Parent = this.drag;
		this.drag.CustomImages.Parent = this.drag;
		this.drag.FillColor = Color.Transparent;
		this.drag.Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
		this.drag.ForeColor = Color.White;
		this.drag.HoveredState.Parent = this.drag;
		this.drag.Location = new Point(728, 376);
		this.drag.Name = "drag";
		this.drag.ShadowDecoration.Mode =  Siticone.UI.WinForms.Enums.ShadowMode.Circle;
		this.drag.ShadowDecoration.Parent = this.drag;
		this.drag.Size = new Size(86, 85);
		this.drag.TabIndex = 12;
		this.drag.Text = "=";
		this.siticoneDragControl1.TargetControl = this.drag;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		this.BackColor = Color.Black;
		this.BackgroundImage = (Image)componentResourceManager.GetObject("$this.BackgroundImage");
		this.BackgroundImageLayout = ImageLayout.Zoom;
		base.ClientSize = new Size(800, 444);
		base.Controls.Add(this.drag);
		base.Controls.Add(this.hideButton);
		base.Controls.Add(this.localStatus);
		base.Controls.Add(this.startLocal);
		base.Controls.Add(this.localMarketIcon);
		base.Controls.Add(this.thisData);
		base.Controls.Add(this.localMarketBox);
		base.Controls.Add(this.minimizeLocal);
		base.Controls.Add(this.closeLocal);
		base.Controls.Add(this.label1);
		this.DoubleBuffered = true;
		base.FormBorderStyle = FormBorderStyle.None;
		base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		base.Name = "LocalMarket";
		base.StartPosition = FormStartPosition.CenterScreen;
		this.Text = "Local Market";
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
