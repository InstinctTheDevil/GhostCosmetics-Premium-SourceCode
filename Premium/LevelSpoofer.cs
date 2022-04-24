using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Fiddler;
using GhostAuth;
using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Suite;
using Siticone.UI.WinForms;

namespace Premium;

public class LevelSpoofer : Form
{
	protected static string configsPath = Dashboard.appPath + "\\Configs\\level.txt";

	public static string configs = File.ReadAllText(configsPath);

	private IContainer components;

	private Label label1;

	private Guna2PictureBox guna2PictureBox1;

	private SiticoneControlBox closeControl;

	private SiticoneControlBox minimizeControl;

	private SiticoneLabel levelInstruction;

	private Guna2GradientTileButton hideButton;

	private Guna2GradientTileButton startLevelSpoofer;

	private Guna2GradientTileButton guna2GradientTileButton1;

	private SiticoneLabel levelStatus;

	private NotifyIcon hideTray;

	private SiticoneTextBox display953;

	private SiticoneCircleButton MilkyAndStalkyLoveLove;

	private SiticoneDragControl milkyAndStalkyForever;

	public LevelSpoofer()
	{
		InitializeComponent();
		string text = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
		char[] array = new char[14];
		Random random = new Random();
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = text[random.Next(text.Length)];
		}
		string text3 = (Text = new string(array));
	}

	private void LevelSpoofer_Load(object sender, EventArgs e)
	{
		if (File.Exists(configsPath))
		{
			display953.Text = (configs);
		}
		API.Log(User.Username, "Level_Spoof Bypass Requested!");
		((Control)(object)levelStatus).Text = "Info: Loaded!";
	}

	private void guna2GradientTileButton1_Click(object sender, EventArgs e)
	{
		((Control)(object)levelStatus).Text = "Info: Modifyng Configs...";
		string fileName = configsPath;
		Process process = new Process();
		process.StartInfo = new ProcessStartInfo
		{
			UseShellExecute = true,
			FileName = fileName
		};
		process.Start();
		process.WaitForExit();
		display953.Text = (configs);
		((Control)(object)levelStatus).Text = "Info: Configs Modified!";
	}

	public static void FiddlerApplication_BeforeRequest(Session oSession)
	{
		oSession.bBufferResponse = true;
	}

	public static void FiddlerApplication_BeforeResponseLevelSpoofer(Session oSession)
	{
		if (oSession.fullUrl.Contains("/api/v1/extensions/playerLevels/getPlayerLevel"))
		{
			oSession.utilDecodeResponse();
			oSession.utilSetResponseBody(configs);
		}
	}

	private void startLevelSpoofer_Click(object sender, EventArgs e)
	{
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Expected O, but got Unknown
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Expected O, but got Unknown
		((Control)(object)levelStatus).Text = "Info: Requesting Key...";
		API.Log(User.Username, "Level Spoofer ignited");
		((Control)(object)levelStatus).Text = "Info: Igniting Spoofer...";
		FiddlerApplication.BeforeRequest += (new SessionStateHandler(FiddlerApplication_BeforeRequest));
		FiddlerApplication.BeforeResponse += (new SessionStateHandler(FiddlerApplication_BeforeResponseLevelSpoofer));
		((Control)(object)levelStatus).Text = "Info: Spoofer Active!";
	}

	private void hideButton_Click(object sender, EventArgs e)
	{
		Hide();
		hideTray.Visible = true;
		MessageBox.Show("Now Hidden at Tray", "Click Level Spoofer Icon at tray to open again!");
		API.Log(User.Username, "Incognito Mode Triggered at Level_Spoofer");
	}

	private void hideTray_MouseClick(object sender, MouseEventArgs e)
	{
		Show();
		hideTray.Visible = false;
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(LevelSpoofer));
		this.label1 = new Label();
		this.guna2PictureBox1 = new Guna2PictureBox();
		this.closeControl = new SiticoneControlBox();
		this.minimizeControl = new SiticoneControlBox();
		this.levelInstruction = new SiticoneLabel();
		this.hideButton = new Guna2GradientTileButton();
		this.startLevelSpoofer = new Guna2GradientTileButton();
		this.guna2GradientTileButton1 = new Guna2GradientTileButton();
		this.levelStatus = new SiticoneLabel();
		this.hideTray = new NotifyIcon(this.components);
		this.display953 = new SiticoneTextBox();
		this.MilkyAndStalkyLoveLove = new SiticoneCircleButton();
		this.milkyAndStalkyForever = new SiticoneDragControl(this.components);
		base.SuspendLayout();
		this.label1.AutoSize = true;
		this.label1.BackColor = Color.Transparent;
		this.label1.Font = new Font("Meiryo UI", 16.75f, FontStyle.Bold);
		this.label1.ForeColor = Color.White;
		this.label1.Location = new Point(74, 22);
		this.label1.Name = "label1";
		this.label1.Size = new Size(179, 29);
		this.label1.TabIndex = 0;
		this.label1.Text = "Level Spoofer";
		this.guna2PictureBox1.BackColor = Color.Transparent;
		this.guna2PictureBox1.Image = (Image)componentResourceManager.GetObject("guna2PictureBox1.Image");
		this.guna2PictureBox1.Location = new Point(12, 12);
		this.guna2PictureBox1.Name = "guna2PictureBox1";
		this.guna2PictureBox1.ShadowDecoration.Parent = this.guna2PictureBox1;
		this.guna2PictureBox1.Size = new Size(56, 55);
		this.guna2PictureBox1.TabIndex = 1;
		this.guna2PictureBox1.TabStop = false;
		this.closeControl.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
		this.closeControl.BackColor = Color.Transparent;
		this.closeControl.BorderColor = Color.Transparent;
		this.closeControl.ControlBoxStyle =  Siticone.UI.WinForms.Enums.ControlBoxStyle.Windows10;
		this.closeControl.FillColor = Color.Transparent;
		this.closeControl.HoveredState.Parent = this.closeControl;
		this.closeControl.IconColor = Color.Red;
		this.closeControl.Location = new Point(742, 12);
		this.closeControl.Name = "closeControl";
		this.closeControl.ShadowDecoration.Parent = this.closeControl;
		this.closeControl.Size = new Size(30, 28);
		this.closeControl.TabIndex = 2;
		this.minimizeControl.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
		this.minimizeControl.BackColor = Color.Transparent;
		this.minimizeControl.BorderColor = Color.Transparent;
		this.minimizeControl.ControlBoxStyle =  Siticone.UI.WinForms.Enums.ControlBoxStyle.Windows10;
		this.minimizeControl.ControlBoxType = 0;
		this.minimizeControl.FillColor = Color.Transparent;
		this.minimizeControl.HoveredState.Parent = this.minimizeControl;
		this.minimizeControl.IconColor = Color.Red;
		this.minimizeControl.Location = new Point(705, 12);
		this.minimizeControl.Name = "minimizeControl";
		this.minimizeControl.ShadowDecoration.Parent = this.minimizeControl;
		this.minimizeControl.Size = new Size(31, 28);
		this.minimizeControl.TabIndex = 3;
		this.levelInstruction.BackColor = Color.Transparent;
		this.levelInstruction.Font = new Font("Meiryo UI", 15f, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
		this.levelInstruction.ForeColor = Color.White;
		this.levelInstruction.Location = new Point(305, 88);
		this.levelInstruction.Name = "levelInstruction";
		this.levelInstruction.Size = new Size(170, 27);
		this.levelInstruction.TabIndex = 5;
		this.levelInstruction.Text = "Spoofer Configs";
		this.hideButton.Animated = true;
		this.hideButton.AutoRoundedCorners = true;
		this.hideButton.BackColor = Color.Transparent;
		this.hideButton.BorderRadius = 20;
		this.hideButton.CheckedState.Parent = this.hideButton;
		this.hideButton.CustomImages.Parent = this.hideButton;
		this.hideButton.FillColor = Color.Navy;
		this.hideButton.FillColor2 = Color.FromArgb(192, 0, 192);
		this.hideButton.Font = new Font("Meiryo UI", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
		this.hideButton.ForeColor = Color.White;
		this.hideButton.HoverState.Parent = this.hideButton;
		this.hideButton.Location = new Point(552, 8);
		this.hideButton.Name = "hideButton";
		this.hideButton.ShadowDecoration.Parent = this.hideButton;
		this.hideButton.Size = new Size(147, 43);
		this.hideButton.TabIndex = 9;
		this.hideButton.Text = "Hide at Tray";
		this.hideButton.Click += this.hideButton_Click;
		this.startLevelSpoofer.Animated = true;
		this.startLevelSpoofer.CheckedState.Parent = this.startLevelSpoofer;
		this.startLevelSpoofer.CustomImages.Parent = this.startLevelSpoofer;
		this.startLevelSpoofer.FillColor = Color.Navy;
		this.startLevelSpoofer.FillColor2 = Color.FromArgb(192, 0, 192);
		this.startLevelSpoofer.Font = new Font("Meiryo UI", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
		this.startLevelSpoofer.ForeColor = Color.White;
		this.startLevelSpoofer.HoverState.Parent = this.startLevelSpoofer;
		this.startLevelSpoofer.Location = new Point(239, 288);
		this.startLevelSpoofer.Name = "startLevelSpoofer";
		this.startLevelSpoofer.ShadowDecoration.Parent = this.startLevelSpoofer;
		this.startLevelSpoofer.Size = new Size(152, 55);
		this.startLevelSpoofer.TabIndex = 10;
		this.startLevelSpoofer.Text = "Start Spoofer";
		this.startLevelSpoofer.Click += this.startLevelSpoofer_Click;
		this.guna2GradientTileButton1.Animated = true;
		this.guna2GradientTileButton1.CheckedState.Parent = this.guna2GradientTileButton1;
		this.guna2GradientTileButton1.CustomImages.Parent = this.guna2GradientTileButton1;
		this.guna2GradientTileButton1.FillColor = Color.FromArgb(192, 0, 192);
		this.guna2GradientTileButton1.FillColor2 = Color.Navy;
		this.guna2GradientTileButton1.Font = new Font("Meiryo UI", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
		this.guna2GradientTileButton1.ForeColor = Color.White;
		this.guna2GradientTileButton1.HoverState.Parent = this.guna2GradientTileButton1;
		this.guna2GradientTileButton1.Location = new Point(397, 288);
		this.guna2GradientTileButton1.Name = "guna2GradientTileButton1";
		this.guna2GradientTileButton1.ShadowDecoration.Parent = this.guna2GradientTileButton1;
		this.guna2GradientTileButton1.Size = new Size(141, 55);
		this.guna2GradientTileButton1.TabIndex = 11;
		this.guna2GradientTileButton1.Text = "Edit Configs";
		this.guna2GradientTileButton1.Click += this.guna2GradientTileButton1_Click;
		this.levelStatus.BackColor = Color.Transparent;
		this.levelStatus.Font = new Font("Meiryo UI", 11.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		this.levelStatus.ForeColor = Color.White;
		this.levelStatus.Location = new Point(319, 349);
		this.levelStatus.Name = "levelStatus";
		this.levelStatus.Size = new Size(135, 21);
		this.levelStatus.TabIndex = 12;
		this.levelStatus.Text = "Info: Injecting...";
		this.hideTray.Icon = (Icon)componentResourceManager.GetObject("hideTray.Icon");
		this.hideTray.Text = "Level Spoofer";
		this.hideTray.Visible = true;
		this.hideTray.MouseClick += this.hideTray_MouseClick;
		this.display953.Cursor = Cursors.IBeam;
		this.display953.DefaultText = "";
		this.display953.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
		this.display953.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
		this.display953.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
		this.display953.DisabledState.Parent = this.display953;
		this.display953.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
		this.display953.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
		this.display953.FocusedState.Parent = this.display953;
		this.display953.ForeColor = Color.Black;
		this.display953.HoveredState.BorderColor = Color.FromArgb(94, 148, 255);
		this.display953.HoveredState.Parent = this.display953;
		this.display953.Location = new Point(239, 131);
		this.display953.Name = "display953";
		this.display953.PasswordChar = '\0';
		this.display953.PlaceholderForeColor = Color.DarkGray;
		this.display953.PlaceholderText = "Missing Configs or Possible Corruption!";
		this.display953.SelectedText = "";
		this.display953.ShadowDecoration.Parent = this.display953;
		this.display953.Size = new Size(298, 143);
		this.display953.TabIndex = 13;
		this.MilkyAndStalkyLoveLove.BackColor = Color.Transparent;
		this.MilkyAndStalkyLoveLove.BorderColor = Color.Transparent;
		this.MilkyAndStalkyLoveLove.CheckedState.Parent = this.MilkyAndStalkyLoveLove;
		this.MilkyAndStalkyLoveLove.CustomImages.Parent = this.MilkyAndStalkyLoveLove;
		this.MilkyAndStalkyLoveLove.FillColor = Color.Transparent;
		this.MilkyAndStalkyLoveLove.Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
		this.MilkyAndStalkyLoveLove.ForeColor = Color.White;
		this.MilkyAndStalkyLoveLove.HoveredState.Parent = this.MilkyAndStalkyLoveLove;
		this.MilkyAndStalkyLoveLove.Location = new Point(692, 327);
		this.MilkyAndStalkyLoveLove.Name = "MilkyAndStalkyLoveLove";
		this.MilkyAndStalkyLoveLove.ShadowDecoration.Mode =   Siticone.UI.WinForms.Enums.ShadowMode.Circle;
		this.MilkyAndStalkyLoveLove.ShadowDecoration.Parent = this.MilkyAndStalkyLoveLove;
		this.MilkyAndStalkyLoveLove.Size = new Size(99, 93);
		this.MilkyAndStalkyLoveLove.TabIndex = 14;
		this.MilkyAndStalkyLoveLove.Text = "=";
		this.milkyAndStalkyForever.TargetControl = this.MilkyAndStalkyLoveLove;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		this.BackColor = Color.Black;
		this.BackgroundImage = (Image)componentResourceManager.GetObject("$this.BackgroundImage");
		this.BackgroundImageLayout = ImageLayout.Zoom;
		base.ClientSize = new Size(784, 405);
		base.Controls.Add(this.MilkyAndStalkyLoveLove);
		base.Controls.Add(this.display953);
		base.Controls.Add(this.levelStatus);
		base.Controls.Add(this.guna2GradientTileButton1);
		base.Controls.Add(this.startLevelSpoofer);
		base.Controls.Add(this.hideButton);
		base.Controls.Add(this.levelInstruction);
		base.Controls.Add(this.minimizeControl);
		base.Controls.Add(this.closeControl);
		base.Controls.Add(this.guna2PictureBox1);
		base.Controls.Add(this.label1);
		this.DoubleBuffered = true;
		base.FormBorderStyle = FormBorderStyle.None;
		base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		base.MaximizeBox = false;
		base.Name = "LevelSpoofer";
		this.Text = "Level Spoofer";
		base.Load += this.LevelSpoofer_Load;
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
