using System;
using System.ComponentModel;
using System.Drawing;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using GhostAuth;
using Guna.UI2.WinForms;

using PremiumCore;
using Siticone.UI.WinForms;

namespace Premium;

public class BloodpointsModule : Form
{
	private IContainer components;

	private SiticoneGradientPanel soFarPanel;

	private Label globalPoints;

	private Label soFarBps;

	private SiticoneGradientPanel siticoneGradientPanel1;

	private Label bloodCounter;

	private Guna2PictureBox guna2PictureBox1;

	private Label shardsCounter;

	private Guna2PictureBox shardsBox;

	private Guna2PictureBox cellsBox;

	private Label cellsCounter;

	private Label label1;

	private Guna2PictureBox guna2PictureBox2;

	private SiticoneControlBox closeBox;

	private SiticoneControlBox minimize;

	private Label label2;

	private SiticoneDragControl dragBps;

	private SiticoneGradientButton attempt;

	private SiticoneGradientButton grant100k;

	private SiticoneGradientButton grant75k;

	private SiticoneGradientButton siticoneGradientButton4;

	private SiticoneGradientButton grant50k;

	private SiticoneGradientButton grant25k;

	[DllImport("Gdi32.dll")]
	private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

	public void Alert(string msg, Form_Alert.enmType type)
	{
		new Form_Alert().showAlert(msg, type);
	}

	public BloodpointsModule()
	{
		InitializeComponent();
		base.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, base.Width, base.Height, 20, 20));
		Alert("Fetching Currencies...", Form_Alert.enmType.Info);
		WebClient webClient = new WebClient();
		string text = webClient.DownloadString("https://raw.githubusercontent.com/StalkyGhostface/gh0stbydaylight-althosting/main/premiumApi/bpsWording");
		globalPoints.Text = text;
		webClient.Dispose();
		FarmerAssistant.GetCurrenciesData("https://steam.live.bhvrdbd.com", Dashboard.bhvrSession);
		Thread.Sleep(2000);
		if (FarmerAssistant.hasPassedFirstCheck)
		{
			cellsCounter.Text = FarmerAssistant.cells;
			shardsCounter.Text = FarmerAssistant.shards;
			bloodCounter.Text = FarmerAssistant.bloodpoints;
			Alert("Done!", Form_Alert.enmType.Success);
			return;
		}
		Alert("This is taking longer than usual!", Form_Alert.enmType.Warning);
		Function();
		Thread.Sleep(2500);
		cellsCounter.Text = FarmerAssistant.cells;
		shardsCounter.Text = FarmerAssistant.shards;
		bloodCounter.Text = FarmerAssistant.bloodpoints;
		Alert("Done!", Form_Alert.enmType.Success);
		Alert("If you can't see the currencies click refresh!", Form_Alert.enmType.Warning);
	}

	private void soFarPanel_Paint(object sender, PaintEventArgs e)
	{
	}

	private async void Function()
	{
		while (FarmerAssistant.hasPassedFirstCheck)
		{
			await Task.Delay(1);
		}
	}

	private void label1_Click(object sender, EventArgs e)
	{
		FarmerAssistant.GetCurrenciesData("https://steam.live.bhvrdbd.com", Dashboard.bhvrSession);
		Thread.Sleep(3500);
		cellsCounter.Text = FarmerAssistant.cells;
		shardsCounter.Text = FarmerAssistant.shards;
		bloodCounter.Text = FarmerAssistant.bloodpoints;
		Alert("Refreshed!", Form_Alert.enmType.Success);
	}

	private void grant75k_Click(object sender, EventArgs e)
	{
		FarmerAssistant.GhostFarmer75k("https://steam.live.bhvrdbd.com", Dashboard.bhvrSession);
		Alert("Granted 75k Bloodpoints!", Form_Alert.enmType.Success);
		FarmerAssistant.GetCurrenciesData("https://steam.live.bhvrdbd.com", Dashboard.bhvrSession);
		API.Log(User.Username, "Generated 75k BPS");
	}

	private void siticoneGradientButton4_Click(object sender, EventArgs e)
	{
		FarmerAssistant.GhostFarmer99MIL("https://steam.live.bhvrdbd.com", Dashboard.bhvrSession);
		Alert("Closed Transaction", Form_Alert.enmType.Info);
	}

	private void siticoneGradientButton2_Click(object sender, EventArgs e)
	{
		FarmerAssistant.GhostFarmer100K("https://steam.live.bhvrdbd.com", Dashboard.bhvrSession);
		Alert("Granted 100k Bloodpoints!", Form_Alert.enmType.Success);
		FarmerAssistant.GetCurrenciesData("https://steam.live.bhvrdbd.com", Dashboard.bhvrSession);
		API.Log(User.Username, "Generated 100k BPS");
	}

	private void grant50k_Click(object sender, EventArgs e)
	{
		FarmerAssistant.GhostFarmer50k("https://steam.live.bhvrdbd.com", Dashboard.bhvrSession);
		Alert("Granted 50k Bloodpoints!", Form_Alert.enmType.Success);
		FarmerAssistant.GetCurrenciesData("https://steam.live.bhvrdbd.com", Dashboard.bhvrSession);
		API.Log(User.Username, "Generated 50k BPS");
	}

	private void grant25k_Click(object sender, EventArgs e)
	{
		FarmerAssistant.GhostFarmer25k("https://steam.live.bhvrdbd.com", Dashboard.bhvrSession);
		Alert("Granted 25k Bloodpoints!", Form_Alert.enmType.Success);
		FarmerAssistant.GetCurrenciesData("https://steam.live.bhvrdbd.com", Dashboard.bhvrSession);
		API.Log(User.Username, "Generated 25k BPS");
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(BloodpointsModule));
		this.soFarPanel = new SiticoneGradientPanel();
		this.guna2PictureBox2 = new Guna2PictureBox();
		this.globalPoints = new Label();
		this.soFarBps = new Label();
		this.siticoneGradientPanel1 = new SiticoneGradientPanel();
		this.label1 = new Label();
		this.bloodCounter = new Label();
		this.guna2PictureBox1 = new Guna2PictureBox();
		this.shardsCounter = new Label();
		this.cellsBox = new Guna2PictureBox();
		this.shardsBox = new Guna2PictureBox();
		this.cellsCounter = new Label();
		this.closeBox = new SiticoneControlBox();
		this.minimize = new SiticoneControlBox();
		this.label2 = new Label();
		this.dragBps = new SiticoneDragControl(this.components);
		this.attempt = new SiticoneGradientButton();
		this.grant100k = new SiticoneGradientButton();
		this.grant75k = new SiticoneGradientButton();
		this.siticoneGradientButton4 = new SiticoneGradientButton();
		this.grant50k = new SiticoneGradientButton();
		this.grant25k = new SiticoneGradientButton();
		this.soFarPanel.SuspendLayout();
		this.siticoneGradientPanel1.SuspendLayout();
		base.SuspendLayout();
		this.soFarPanel.BackColor = Color.Transparent;
		this.soFarPanel.BorderRadius = 21;
		this.soFarPanel.Controls.Add(this.guna2PictureBox2);
		this.soFarPanel.Controls.Add(this.globalPoints);
		this.soFarPanel.Controls.Add(this.soFarBps);
		this.soFarPanel.Cursor = Cursors.SizeAll;
		this.soFarPanel.FillColor = Color.Magenta;
		this.soFarPanel.FillColor2 = Color.Purple;
		this.soFarPanel.Location = new Point(-1, 352);
		this.soFarPanel.Name = "soFarPanel";
		this.soFarPanel.ShadowDecoration.Parent = this.soFarPanel;
		this.soFarPanel.Size = new Size(820, 74);
		this.soFarPanel.TabIndex = 0;
		this.soFarPanel.Paint += this.soFarPanel_Paint;
		this.guna2PictureBox2.BackColor = Color.Transparent;
		this.guna2PictureBox2.Image = (Image)componentResourceManager.GetObject("guna2PictureBox2.Image");
		this.guna2PictureBox2.Location = new Point(400, 5);
		this.guna2PictureBox2.Name = "guna2PictureBox2";
		this.guna2PictureBox2.ShadowDecoration.Parent = this.guna2PictureBox2;
		this.guna2PictureBox2.Size = new Size(46, 44);
		this.guna2PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
		this.guna2PictureBox2.TabIndex = 6;
		this.guna2PictureBox2.TabStop = false;
		this.globalPoints.AutoSize = true;
		this.globalPoints.BackColor = Color.Transparent;
		this.globalPoints.Font = new Font("Segoe UI", 12.75f, FontStyle.Bold);
		this.globalPoints.ForeColor = Color.White;
		this.globalPoints.Location = new Point(452, 17);
		this.globalPoints.Name = "globalPoints";
		this.globalPoints.Size = new Size(125, 23);
		this.globalPoints.TabIndex = 1;
		this.globalPoints.Text = "500 000 so far";
		this.soFarBps.AutoSize = true;
		this.soFarBps.BackColor = Color.Transparent;
		this.soFarBps.Font = new Font("Segoe UI Black", 14.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		this.soFarBps.ForeColor = Color.White;
		this.soFarBps.Location = new Point(86, 15);
		this.soFarBps.Name = "soFarBps";
		this.soFarBps.Size = new Size(308, 25);
		this.soFarBps.TabIndex = 0;
		this.soFarBps.Text = "Premium users have generated:";
		this.siticoneGradientPanel1.BorderRadius = 21;
		this.siticoneGradientPanel1.Controls.Add(this.label1);
		this.siticoneGradientPanel1.Controls.Add(this.bloodCounter);
		this.siticoneGradientPanel1.Controls.Add(this.guna2PictureBox1);
		this.siticoneGradientPanel1.Controls.Add(this.shardsCounter);
		this.siticoneGradientPanel1.Controls.Add(this.cellsBox);
		this.siticoneGradientPanel1.Controls.Add(this.shardsBox);
		this.siticoneGradientPanel1.Controls.Add(this.cellsCounter);
		this.siticoneGradientPanel1.FillColor = Color.Magenta;
		this.siticoneGradientPanel1.FillColor2 = Color.Purple;
		this.siticoneGradientPanel1.Location = new Point(127, 48);
		this.siticoneGradientPanel1.Name = "siticoneGradientPanel1";
		this.siticoneGradientPanel1.ShadowDecoration.Parent = this.siticoneGradientPanel1;
		this.siticoneGradientPanel1.Size = new Size(539, 76);
		this.siticoneGradientPanel1.TabIndex = 1;
		this.label1.AutoSize = true;
		this.label1.BackColor = Color.Transparent;
		this.label1.Font = new Font("Segoe UI Semibold", 8.25f, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
		this.label1.ForeColor = Color.White;
		this.label1.Location = new Point(199, 60);
		this.label1.Name = "label1";
		this.label1.Size = new Size(152, 13);
		this.label1.TabIndex = 7;
		this.label1.Text = "click me to refresh currencies";
		this.label1.Click += this.label1_Click;
		this.bloodCounter.AutoSize = true;
		this.bloodCounter.BackColor = Color.Transparent;
		this.bloodCounter.Font = new Font("Segoe UI", 12.75f, FontStyle.Bold);
		this.bloodCounter.ForeColor = Color.White;
		this.bloodCounter.Location = new Point(254, 25);
		this.bloodCounter.Name = "bloodCounter";
		this.bloodCounter.Size = new Size(50, 23);
		this.bloodCounter.TabIndex = 6;
		this.bloodCounter.Text = "error";
		this.guna2PictureBox1.BackColor = Color.Transparent;
		this.guna2PictureBox1.Image = (Image)componentResourceManager.GetObject("guna2PictureBox1.Image");
		this.guna2PictureBox1.Location = new Point(202, 13);
		this.guna2PictureBox1.Name = "guna2PictureBox1";
		this.guna2PictureBox1.ShadowDecoration.Parent = this.guna2PictureBox1;
		this.guna2PictureBox1.Size = new Size(46, 44);
		this.guna2PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
		this.guna2PictureBox1.TabIndex = 5;
		this.guna2PictureBox1.TabStop = false;
		this.shardsCounter.AutoSize = true;
		this.shardsCounter.BackColor = Color.Transparent;
		this.shardsCounter.Font = new Font("Segoe UI", 12.75f, FontStyle.Bold);
		this.shardsCounter.ForeColor = Color.White;
		this.shardsCounter.Location = new Point(408, 25);
		this.shardsCounter.Name = "shardsCounter";
		this.shardsCounter.Size = new Size(50, 23);
		this.shardsCounter.TabIndex = 4;
		this.shardsCounter.Text = "error";
		this.cellsBox.BackColor = Color.Transparent;
		this.cellsBox.Image = (Image)componentResourceManager.GetObject("cellsBox.Image");
		this.cellsBox.Location = new Point(29, 13);
		this.cellsBox.Name = "cellsBox";
		this.cellsBox.ShadowDecoration.Parent = this.cellsBox;
		this.cellsBox.Size = new Size(46, 44);
		this.cellsBox.SizeMode = PictureBoxSizeMode.StretchImage;
		this.cellsBox.TabIndex = 2;
		this.cellsBox.TabStop = false;
		this.shardsBox.BackColor = Color.Transparent;
		this.shardsBox.Image = (Image)componentResourceManager.GetObject("shardsBox.Image");
		this.shardsBox.Location = new Point(356, 13);
		this.shardsBox.Name = "shardsBox";
		this.shardsBox.ShadowDecoration.Parent = this.shardsBox;
		this.shardsBox.Size = new Size(46, 44);
		this.shardsBox.SizeMode = PictureBoxSizeMode.StretchImage;
		this.shardsBox.TabIndex = 3;
		this.shardsBox.TabStop = false;
		this.cellsCounter.AutoSize = true;
		this.cellsCounter.BackColor = Color.Transparent;
		this.cellsCounter.Font = new Font("Segoe UI", 12.75f, FontStyle.Bold);
		this.cellsCounter.ForeColor = Color.White;
		this.cellsCounter.Location = new Point(81, 25);
		this.cellsCounter.Name = "cellsCounter";
		this.cellsCounter.Size = new Size(50, 23);
		this.cellsCounter.TabIndex = 1;
		this.cellsCounter.Text = "error";
		this.closeBox.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
		this.closeBox.BackColor = Color.Transparent;
		this.closeBox.FillColor = Color.Transparent;
		this.closeBox.HoveredState.Parent = this.closeBox;
		this.closeBox.IconColor = Color.White;
		this.closeBox.Location = new Point(762, 13);
		this.closeBox.Name = "closeBox";
		this.closeBox.PressedColor = Color.Red;
		this.closeBox.ShadowDecoration.Parent = this.closeBox;
		this.closeBox.Size = new Size(45, 29);
		this.closeBox.TabIndex = 2;
		this.minimize.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
		this.minimize.BackColor = Color.Transparent;
		this.minimize.BorderColor = Color.Transparent;
		this.minimize.ControlBoxType = 0;
		this.minimize.FillColor = Color.Transparent;
		this.minimize.HoveredState.Parent = this.minimize;
		this.minimize.IconColor = Color.White;
		this.minimize.Location = new Point(727, 13);
		this.minimize.Name = "minimize";
		this.minimize.PressedColor = Color.Red;
		this.minimize.ShadowDecoration.Parent = this.minimize;
		this.minimize.Size = new Size(45, 29);
		this.minimize.TabIndex = 3;
		this.label2.AutoSize = true;
		this.label2.BackColor = Color.Transparent;
		this.label2.Font = new Font("Segoe UI Black", 14.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		this.label2.ForeColor = Color.White;
		this.label2.Location = new Point(13, 13);
		this.label2.Name = "label2";
		this.label2.Size = new Size(226, 25);
		this.label2.TabIndex = 4;
		this.label2.Text = "Bloodpoints Generator";
		this.dragBps.TargetControl = this.soFarPanel;
		this.attempt.BackColor = Color.Transparent;
		this.attempt.BorderColor = Color.Transparent;
		this.attempt.BorderRadius = 10;
		this.attempt.CheckedState.Parent = this.attempt;
		this.attempt.CustomImages.Parent = this.attempt;
		this.attempt.FillColor = Color.FromArgb(0, 0, 64);
		this.attempt.FillColor2 = Color.FromArgb(64, 0, 64);
		this.attempt.Font = new Font("Segoe UI Black", 11.75f, FontStyle.Bold);
		this.attempt.ForeColor = Color.White;
		this.attempt.HoveredState.Parent = this.attempt;
		this.attempt.Location = new Point(396, 141);
		this.attempt.Name = "attempt";
		this.attempt.ShadowDecoration.Parent = this.attempt;
		this.attempt.Size = new Size(210, 49);
		this.attempt.TabIndex = 5;
		this.attempt.Text = "+1 Million Bloodpoints";
		this.grant100k.BackColor = Color.Transparent;
		this.grant100k.BorderColor = Color.Transparent;
		this.grant100k.BorderRadius = 10;
		this.grant100k.CheckedState.Parent = this.grant100k;
		this.grant100k.CustomImages.Parent = this.grant100k;
		this.grant100k.FillColor = Color.Purple;
		this.grant100k.FillColor2 = Color.Navy;
		this.grant100k.Font = new Font("Segoe UI Black", 11.75f, FontStyle.Bold);
		this.grant100k.ForeColor = Color.White;
		this.grant100k.HoveredState.Parent = this.grant100k;
		this.grant100k.Location = new Point(180, 205);
		this.grant100k.Name = "grant100k";
		this.grant100k.ShadowDecoration.Parent = this.grant100k;
		this.grant100k.Size = new Size(210, 49);
		this.grant100k.TabIndex = 6;
		this.grant100k.Text = "+100k Bloodpoints";
		this.grant100k.Click += this.siticoneGradientButton2_Click;
		this.grant75k.BackColor = Color.Transparent;
		this.grant75k.BorderColor = Color.Transparent;
		this.grant75k.BorderRadius = 10;
		this.grant75k.CheckedState.Parent = this.grant75k;
		this.grant75k.CustomImages.Parent = this.grant75k;
		this.grant75k.FillColor = Color.Purple;
		this.grant75k.FillColor2 = Color.Navy;
		this.grant75k.Font = new Font("Segoe UI Black", 11.75f, FontStyle.Bold);
		this.grant75k.ForeColor = Color.White;
		this.grant75k.HoveredState.Parent = this.grant75k;
		this.grant75k.Location = new Point(396, 205);
		this.grant75k.Name = "grant75k";
		this.grant75k.ShadowDecoration.Parent = this.grant75k;
		this.grant75k.Size = new Size(210, 49);
		this.grant75k.TabIndex = 7;
		this.grant75k.Text = "+75k Bloodpoints";
		this.grant75k.Click += this.grant75k_Click;
		this.siticoneGradientButton4.BackColor = Color.Transparent;
		this.siticoneGradientButton4.BorderColor = Color.Transparent;
		this.siticoneGradientButton4.BorderRadius = 10;
		this.siticoneGradientButton4.CheckedState.Parent = this.siticoneGradientButton4;
		this.siticoneGradientButton4.CustomImages.Parent = this.siticoneGradientButton4;
		this.siticoneGradientButton4.FillColor = Color.FromArgb(0, 0, 64);
		this.siticoneGradientButton4.FillColor2 = Color.FromArgb(64, 0, 64);
		this.siticoneGradientButton4.Font = new Font("Segoe UI Black", 11.75f, FontStyle.Bold);
		this.siticoneGradientButton4.ForeColor = Color.White;
		this.siticoneGradientButton4.HoveredState.Parent = this.siticoneGradientButton4;
		this.siticoneGradientButton4.Location = new Point(183, 141);
		this.siticoneGradientButton4.Name = "siticoneGradientButton4";
		this.siticoneGradientButton4.ShadowDecoration.Parent = this.siticoneGradientButton4;
		this.siticoneGradientButton4.Size = new Size(210, 49);
		this.siticoneGradientButton4.TabIndex = 8;
		this.siticoneGradientButton4.Text = "+100 Million Bloodpoints";
		this.siticoneGradientButton4.Click += this.siticoneGradientButton4_Click;
		this.grant50k.BackColor = Color.Transparent;
		this.grant50k.BorderColor = Color.Transparent;
		this.grant50k.BorderRadius = 10;
		this.grant50k.CheckedState.Parent = this.grant50k;
		this.grant50k.CustomImages.Parent = this.grant50k;
		this.grant50k.FillColor = Color.FromArgb(192, 0, 192);
		this.grant50k.FillColor2 = Color.FromArgb(0, 0, 192);
		this.grant50k.Font = new Font("Segoe UI Black", 11.75f, FontStyle.Bold);
		this.grant50k.ForeColor = Color.White;
		this.grant50k.HoveredState.Parent = this.grant50k;
		this.grant50k.Location = new Point(180, 269);
		this.grant50k.Name = "grant50k";
		this.grant50k.ShadowDecoration.Parent = this.grant50k;
		this.grant50k.Size = new Size(210, 49);
		this.grant50k.TabIndex = 9;
		this.grant50k.Text = "+50k Bloodpoints";
		this.grant50k.Click += this.grant50k_Click;
		this.grant25k.BackColor = Color.Transparent;
		this.grant25k.BorderColor = Color.Transparent;
		this.grant25k.BorderRadius = 10;
		this.grant25k.CheckedState.Parent = this.grant25k;
		this.grant25k.CustomImages.Parent = this.grant25k;
		this.grant25k.FillColor = Color.Fuchsia;
		this.grant25k.FillColor2 = Color.Blue;
		this.grant25k.Font = new Font("Segoe UI Black", 11.75f, FontStyle.Bold);
		this.grant25k.ForeColor = Color.White;
		this.grant25k.HoveredState.Parent = this.grant25k;
		this.grant25k.Location = new Point(396, 269);
		this.grant25k.Name = "grant25k";
		this.grant25k.ShadowDecoration.Parent = this.grant25k;
		this.grant25k.Size = new Size(210, 49);
		this.grant25k.TabIndex = 10;
		this.grant25k.Text = "+25k Bloodpoints";
		this.grant25k.Click += this.grant25k_Click;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		this.BackColor = Color.Black;
		this.BackgroundImage = (Image)componentResourceManager.GetObject("$this.BackgroundImage");
		this.BackgroundImageLayout = ImageLayout.Stretch;
		base.ClientSize = new Size(819, 413);
		base.Controls.Add(this.grant25k);
		base.Controls.Add(this.grant50k);
		base.Controls.Add(this.siticoneGradientButton4);
		base.Controls.Add(this.grant75k);
		base.Controls.Add(this.grant100k);
		base.Controls.Add(this.attempt);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.minimize);
		base.Controls.Add(this.closeBox);
		base.Controls.Add(this.siticoneGradientPanel1);
		base.Controls.Add(this.soFarPanel);
		this.DoubleBuffered = true;
		base.FormBorderStyle = FormBorderStyle.None;
		base.Name = "BloodpointsModule";
		this.Text = "BloodpointsModule";
		this.soFarPanel.ResumeLayout(false);
		this.soFarPanel.PerformLayout();
		this.siticoneGradientPanel1.ResumeLayout(false);
		this.siticoneGradientPanel1.PerformLayout();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
