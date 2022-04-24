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

public class CurrenciesSpoofer : Form
{
	protected static string configsPath = Dashboard.appPath + "\\Configs\\currencies.txt";

	public static string configs = File.ReadAllText(configsPath);

	private IContainer components;

	private Label label1;

	private System.Windows.Forms.PictureBox pictureBox1;

	private SiticoneControlBox closeCurrencies;

	private SiticoneControlBox minimizeCurrencies;

	private SiticoneTextBox display693;

	private Guna2GradientTileButton startCurrencies;

	private Guna2GradientTileButton modifyConfigs;

	private Label currenciesStatus;

	private Guna2GradientTileButton hideCurrencies;

	private NotifyIcon trayHider;

	private SiticoneButton dragCurrencies;

	private SiticoneDragControl dragControl;

	public CurrenciesSpoofer()
	{
		InitializeComponent();
		string text = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
		char[] array = new char[15];
		Random random = new Random();
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = text[random.Next(text.Length)];
		}
		string text3 = (Text = new string(array));
	}

	private void CurrenciesSpoofer_Load(object sender, EventArgs e)
	{
		if (File.Exists(configsPath))
		{
			display693.Text = configs;
		}
		API.Log(User.Username, "Currencies_Spoof Bypass Requested!");
		currenciesStatus.Text = "Info: Loaded!";
	}

	private void modifyConfigs_Click(object sender, EventArgs e)
	{
		currenciesStatus.Text = "Info: Modifyng Configs...";
		string fileName = configsPath;
		Process process = new Process();
		process.StartInfo = new ProcessStartInfo
		{
			UseShellExecute = true,
			FileName = fileName
		};
		process.Start();
		process.WaitForExit();
		display693.Text = configs;
		currenciesStatus.Text = "Info: Configs Modified!";
	}

	public static void FiddlerApplication_BeforeRequst(Session oSession)
	{
		oSession.bBufferResponse = true;
	}

	public static void FiddlerApplication_BeforeResponseCurrenciesSpoofer(Session oSession)
	{
		if (oSession.fullUrl.Contains("/api/v1/wallet/currencies"))
		{
			oSession.utilDecodeResponse();
			oSession.utilSetResponseBody(configs);
		}
	}

	private void startCurrencies_Click(object sender, EventArgs e)
	{

		currenciesStatus.Text = "Info: Requesting Key...";
		API.Log(User.Username, "Currencies Spoofer ignited");
		currenciesStatus.Text = "Info: Igniting Spoofer...";
		FiddlerApplication.BeforeRequest += (new SessionStateHandler(FiddlerApplication_BeforeRequst));
		FiddlerApplication.BeforeResponse += (new SessionStateHandler(FiddlerApplication_BeforeResponseCurrenciesSpoofer));
		currenciesStatus.Text = "Info: Spoofer Active!";
	}

	private void hideCurrencies_Click(object sender, EventArgs e)
	{
		Hide();
		trayHider.Visible = true;
		MessageBox.Show("Now Hidden at Tray", "Click Currencies Spoofer Icon at tray to open again!");
		API.Log(User.Username, "Incognito Mode Triggered at Currencies_Spoofer");
	}

	private void trayHider_MouseClick(object sender, MouseEventArgs e)
	{
		Show();
		trayHider.Visible = false;
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(CurrenciesSpoofer));
		this.label1 = new Label();
		this.pictureBox1 = new System.Windows.Forms.PictureBox();
		this.closeCurrencies = new SiticoneControlBox();
		this.minimizeCurrencies = new SiticoneControlBox();
		this.display693 = new SiticoneTextBox();
		this.startCurrencies = new Guna2GradientTileButton();
		this.modifyConfigs = new Guna2GradientTileButton();
		this.currenciesStatus = new Label();
		this.hideCurrencies = new Guna2GradientTileButton();
		this.trayHider = new NotifyIcon(this.components);
		this.dragCurrencies = new SiticoneButton();
		this.dragControl = new SiticoneDragControl(this.components);
		((ISupportInitialize)this.pictureBox1).BeginInit();
		base.SuspendLayout();
		this.label1.AutoSize = true;
		this.label1.Font = new Font("Meiryo UI", 14f, FontStyle.Bold);
		this.label1.ForeColor = Color.White;
		this.label1.Location = new Point(73, 22);
		this.label1.Name = "label1";
		this.label1.Size = new Size(201, 24);
		this.label1.TabIndex = 0;
		this.label1.Text = "Currencies Spoofer";
		this.pictureBox1.Image = (Image)componentResourceManager.GetObject("pictureBox1.Image");
		this.pictureBox1.Location = new Point(13, 3);
		this.pictureBox1.Name = "pictureBox1";
		this.pictureBox1.Size = new Size(54, 62);
		this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
		this.pictureBox1.TabIndex = 1;
		this.pictureBox1.TabStop = false;
		this.closeCurrencies.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
		this.closeCurrencies.BackColor = Color.Transparent;
		this.closeCurrencies.BorderColor = Color.Transparent;
		this.closeCurrencies.ControlBoxStyle = Siticone.UI.WinForms.Enums.ControlBoxStyle.Windows10;
		this.closeCurrencies.FillColor = Color.Transparent;
		this.closeCurrencies.HoveredState.Parent = this.closeCurrencies;
		this.closeCurrencies.IconColor = Color.Red;
		this.closeCurrencies.Location = new Point(747, 3);
		this.closeCurrencies.Name = "closeCurrencies";
		this.closeCurrencies.ShadowDecoration.Parent = this.closeCurrencies;
		this.closeCurrencies.Size = new Size(25, 43);
		this.closeCurrencies.TabIndex = 2;
		this.minimizeCurrencies.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
		this.minimizeCurrencies.BackColor = Color.Transparent;
		this.minimizeCurrencies.BorderColor = Color.Transparent;
		this.minimizeCurrencies.ControlBoxStyle =  Siticone.UI.WinForms.Enums.ControlBoxStyle.Windows10;
		this.minimizeCurrencies.ControlBoxType = 0;
		this.minimizeCurrencies.FillColor = Color.Transparent;
		this.minimizeCurrencies.HoveredState.Parent = this.minimizeCurrencies;
		this.minimizeCurrencies.IconColor = Color.Red;
		this.minimizeCurrencies.Location = new Point(716, 3);
		this.minimizeCurrencies.Name = "minimizeCurrencies";
		this.minimizeCurrencies.ShadowDecoration.Parent = this.minimizeCurrencies;
		this.minimizeCurrencies.Size = new Size(25, 43);
		this.minimizeCurrencies.TabIndex = 3;
		this.display693.Cursor = Cursors.IBeam;
		this.display693.DefaultText = "";
		this.display693.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
		this.display693.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
		this.display693.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
		this.display693.DisabledState.Parent = this.display693;
		this.display693.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
		this.display693.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
		this.display693.FocusedState.Parent = this.display693;
		this.display693.HoveredState.BorderColor = Color.FromArgb(94, 148, 255);
		this.display693.HoveredState.Parent = this.display693;
		this.display693.Location = new Point(13, 90);
		this.display693.Multiline = true;
		this.display693.Name = "display693";
		this.display693.PasswordChar = '\0';
		this.display693.PlaceholderForeColor = Color.Gray;
		this.display693.PlaceholderText = "Possible Corruption (!) Could not find configs file!";
		this.display693.SelectedText = "";
		this.display693.ShadowDecoration.Parent = this.display693;
		this.display693.Size = new Size(261, 155);
		this.display693.TabIndex = 4;
		this.startCurrencies.CheckedState.Parent = this.startCurrencies;
		this.startCurrencies.CustomImages.Parent = this.startCurrencies;
		this.startCurrencies.FillColor = Color.Purple;
		this.startCurrencies.FillColor2 = Color.FromArgb(0, 0, 192);
		this.startCurrencies.Font = new Font("Meiryo UI", 14.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		this.startCurrencies.ForeColor = Color.White;
		this.startCurrencies.HoverState.Parent = this.startCurrencies;
		this.startCurrencies.Location = new Point(12, 257);
		this.startCurrencies.Name = "startCurrencies";
		this.startCurrencies.ShadowDecoration.Parent = this.startCurrencies;
		this.startCurrencies.Size = new Size(261, 47);
		this.startCurrencies.TabIndex = 5;
		this.startCurrencies.Text = "Start Spoofer";
		this.startCurrencies.Click += this.startCurrencies_Click;
		this.modifyConfigs.CheckedState.Parent = this.modifyConfigs;
		this.modifyConfigs.CustomImages.Parent = this.modifyConfigs;
		this.modifyConfigs.Font = new Font("Meiryo UI", 14.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		this.modifyConfigs.ForeColor = Color.White;
		this.modifyConfigs.HoverState.Parent = this.modifyConfigs;
		this.modifyConfigs.Location = new Point(12, 310);
		this.modifyConfigs.Name = "modifyConfigs";
		this.modifyConfigs.ShadowDecoration.Parent = this.modifyConfigs;
		this.modifyConfigs.Size = new Size(262, 48);
		this.modifyConfigs.TabIndex = 6;
		this.modifyConfigs.Text = "Modify Configs";
		this.modifyConfigs.Click += this.modifyConfigs_Click;
		this.currenciesStatus.AutoSize = true;
		this.currenciesStatus.Font = new Font("Meiryo UI", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
		this.currenciesStatus.ForeColor = Color.White;
		this.currenciesStatus.Location = new Point(12, 388);
		this.currenciesStatus.Name = "currenciesStatus";
		this.currenciesStatus.Size = new Size(114, 15);
		this.currenciesStatus.TabIndex = 7;
		this.currenciesStatus.Text = "Status: Injecting";
		this.hideCurrencies.Animated = true;
		this.hideCurrencies.AutoRoundedCorners = true;
		this.hideCurrencies.BorderRadius = 22;
		this.hideCurrencies.CheckedState.Parent = this.hideCurrencies;
		this.hideCurrencies.CustomImages.Parent = this.hideCurrencies;
		this.hideCurrencies.FillColor = Color.Purple;
		this.hideCurrencies.FillColor2 = Color.FromArgb(0, 0, 192);
		this.hideCurrencies.Font = new Font("Meiryo UI", 10.25f, FontStyle.Bold);
		this.hideCurrencies.ForeColor = Color.White;
		this.hideCurrencies.HoverState.Parent = this.hideCurrencies;
		this.hideCurrencies.Location = new Point(280, 12);
		this.hideCurrencies.Name = "hideCurrencies";
		this.hideCurrencies.ShadowDecoration.Parent = this.hideCurrencies;
		this.hideCurrencies.Size = new Size(116, 47);
		this.hideCurrencies.TabIndex = 8;
		this.hideCurrencies.Text = "Hide at Tray";
		this.hideCurrencies.Click += this.hideCurrencies_Click;
		this.trayHider.Icon = (Icon)componentResourceManager.GetObject("trayHider.Icon");
		this.trayHider.Text = "Currencies Spoofer";
		this.trayHider.Visible = true;
		this.trayHider.MouseClick += this.trayHider_MouseClick;
		this.dragCurrencies.BackColor = Color.Transparent;
		this.dragCurrencies.BorderColor = Color.Transparent;
		this.dragCurrencies.CheckedState.Parent = this.dragCurrencies;
		this.dragCurrencies.CustomImages.Parent = this.dragCurrencies;
		this.dragCurrencies.FillColor = Color.Transparent;
		this.dragCurrencies.Font = new Font("Meiryo UI", 11.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		this.dragCurrencies.ForeColor = Color.White;
		this.dragCurrencies.HoveredState.Parent = this.dragCurrencies;
		this.dragCurrencies.Location = new Point(673, 371);
		this.dragCurrencies.Name = "dragCurrencies";
		this.dragCurrencies.PressedColor = Color.Transparent;
		this.dragCurrencies.ShadowDecoration.Parent = this.dragCurrencies;
		this.dragCurrencies.Size = new Size(151, 74);
		this.dragCurrencies.TabIndex = 9;
		this.dragCurrencies.Text = "=";
		this.dragControl.TargetControl = this.dragCurrencies;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		this.BackColor = Color.Black;
		this.BackgroundImage = (Image)componentResourceManager.GetObject("$this.BackgroundImage");
		this.BackgroundImageLayout = ImageLayout.Stretch;
		base.ClientSize = new Size(784, 432);
		base.Controls.Add(this.dragCurrencies);
		base.Controls.Add(this.hideCurrencies);
		base.Controls.Add(this.currenciesStatus);
		base.Controls.Add(this.modifyConfigs);
		base.Controls.Add(this.startCurrencies);
		base.Controls.Add(this.display693);
		base.Controls.Add(this.minimizeCurrencies);
		base.Controls.Add(this.closeCurrencies);
		base.Controls.Add(this.pictureBox1);
		base.Controls.Add(this.label1);
		this.DoubleBuffered = true;
		base.FormBorderStyle = FormBorderStyle.None;
		base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		base.Name = "CurrenciesSpoofer";
		base.Opacity = 0.98;
		base.StartPosition = FormStartPosition.CenterParent;
		this.Text = "Corruption (?)";
		base.Load += this.CurrenciesSpoofer_Load;
		((ISupportInitialize)this.pictureBox1).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
