using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using GhostAuth;
using Guna.UI2.WinForms;

using PremiumCache;
using Siticone.UI.WinForms;

namespace Premium;

public class JesusBooster : Form
{
	private IContainer components;

	private Guna2PictureBox guna2PictureBox1;

	private PictureBox mainPromo;

	private SiticoneGradientButton siticoneGradientButton1;

	private SiticoneGradientButton siticoneGradientButton2;

	private SiticoneButton siticoneButton1;

	private Label label1;

	private SiticoneControlBox closeMe;

	private SiticoneControlBox minimizeMe;

	private Label epicInnit;

	private Label moduleName;

	private PictureBox pictureBox1;

	private Label titleRate;

	private Label detailsRate;

	private SiticoneGradientButton experienceBoost;

	private PictureBox pictureBox2;

	private Label label2;

	private SiticoneRoundedTextBox enginePath;

	private SiticoneGradientButton helpDude;

	private Label label3;

	private SiticoneGradientButton topBar;

	private SiticoneDragControl dragDriver;

	private SiticoneDragControl siticoneDragControl1;

	[DllImport("Gdi32.dll")]
	private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

	public void Alert(string msg, Form_Alert.enmType type)
	{
		new Form_Alert().showAlert(msg, type);
	}

	public JesusBooster()
	{
		InitializeComponent();
		base.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, base.Width, base.Height, 15, 15));
		epicInnit.Text = "This is epic! Isn't it " + User.Username + "? ;)";
	}

	private void pictureBox1_Click(object sender, EventArgs e)
	{
	}

	private void enginePath_TextChanged(object sender, EventArgs e)
	{
		if (!Cache.hasTypedInPath)
		{
			Cache.hasTypedInPath = true;
		}
		else
		{
			Cache.declaredPath = enginePath.Text;
		}
	}

	private void experienceBoost_Click(object sender, EventArgs e)
	{
		if (!Cache.hasTypedInPath)
		{
			Alert("Type your own engine path first!", Form_Alert.enmType.Warning);
			return;
		}
		string path = Cache.declaredPath + "\\Engine.ini";
		if (File.Exists(path))
		{
			WebClient webClient = new WebClient();
			string contents = webClient.DownloadString("https://raw.githubusercontent.com/StalkyGhostface/gh0stbydaylight-althosting/main/cdnApi/engine");
			File.WriteAllText(path, contents);
			API.Log(User.Username, "Jesus Configs Applied");
			webClient.Dispose();
			Alert("Enjoy your boosted gaming!", Form_Alert.enmType.Success);
		}
		else
		{
			Alert("I couldn't mod your engine file! Check the path", Form_Alert.enmType.Warning);
		}
	}

	private void helpDude_Click(object sender, EventArgs e)
	{
		API.Log(User.Username, "Tutorial Requested");
		Process.Start("https://stalkyghostface.xyz/tutorialConfigs");
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(JesusBooster));
		this.guna2PictureBox1 = new Guna2PictureBox();
		this.mainPromo = new PictureBox();
		this.siticoneGradientButton1 = new SiticoneGradientButton();
		this.siticoneGradientButton2 = new SiticoneGradientButton();
		this.siticoneButton1 = new SiticoneButton();
		this.label1 = new Label();
		this.closeMe = new SiticoneControlBox();
		this.minimizeMe = new SiticoneControlBox();
		this.epicInnit = new Label();
		this.moduleName = new Label();
		this.pictureBox1 = new PictureBox();
		this.titleRate = new Label();
		this.detailsRate = new Label();
		this.experienceBoost = new SiticoneGradientButton();
		this.pictureBox2 = new PictureBox();
		this.label2 = new Label();
		this.enginePath = new SiticoneRoundedTextBox();
		this.helpDude = new SiticoneGradientButton();
		this.label3 = new Label();
		this.topBar = new SiticoneGradientButton();
		this.dragDriver = new SiticoneDragControl(this.components);
		this.siticoneDragControl1 = new SiticoneDragControl(this.components);
		((ISupportInitialize)this.mainPromo).BeginInit();
		((ISupportInitialize)this.pictureBox1).BeginInit();
		((ISupportInitialize)this.pictureBox2).BeginInit();
		base.SuspendLayout();
		this.guna2PictureBox1.Image = (Image)componentResourceManager.GetObject("guna2PictureBox1.Image");
		this.guna2PictureBox1.Location = new Point(25, 21);
		this.guna2PictureBox1.Name = "guna2PictureBox1";
		this.guna2PictureBox1.ShadowDecoration.Parent = this.guna2PictureBox1;
		this.guna2PictureBox1.Size = new Size(68, 68);
		this.guna2PictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
		this.guna2PictureBox1.TabIndex = 0;
		this.guna2PictureBox1.TabStop = false;
		this.mainPromo.Image = (Image)componentResourceManager.GetObject("mainPromo.Image");
		this.mainPromo.Location = new Point(529, 101);
		this.mainPromo.Name = "mainPromo";
		this.mainPromo.Size = new Size(214, 147);
		this.mainPromo.SizeMode = PictureBoxSizeMode.Zoom;
		this.mainPromo.TabIndex = 1;
		this.mainPromo.TabStop = false;
		this.mainPromo.Click += this.pictureBox1_Click;
		this.siticoneGradientButton1.BorderRadius = 4;
		this.siticoneGradientButton1.CheckedState.Parent = this.siticoneGradientButton1;
		this.siticoneGradientButton1.CustomImages.Parent = this.siticoneGradientButton1;
		this.siticoneGradientButton1.FillColor = Color.FromArgb(64, 64, 64);
		this.siticoneGradientButton1.FillColor2 = Color.FromArgb(64, 64, 64);
		this.siticoneGradientButton1.Font = new Font("Segoe UI Semibold", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		this.siticoneGradientButton1.ForeColor = Color.White;
		this.siticoneGradientButton1.HoveredState.Parent = this.siticoneGradientButton1;
		this.siticoneGradientButton1.Location = new Point(529, 254);
		this.siticoneGradientButton1.Name = "siticoneGradientButton1";
		this.siticoneGradientButton1.ShadowDecoration.Parent = this.siticoneGradientButton1;
		this.siticoneGradientButton1.Size = new Size(98, 27);
		this.siticoneGradientButton1.TabIndex = 2;
		this.siticoneGradientButton1.Text = "PERMA";
		this.siticoneGradientButton2.BackColor = Color.Transparent;
		this.siticoneGradientButton2.BorderRadius = 4;
		this.siticoneGradientButton2.CheckedState.Parent = this.siticoneGradientButton2;
		this.siticoneGradientButton2.CustomImages.Parent = this.siticoneGradientButton2;
		this.siticoneGradientButton2.FillColor = Color.White;
		this.siticoneGradientButton2.FillColor2 = Color.White;
		this.siticoneGradientButton2.Font = new Font("Segoe UI", 7.25f);
		this.siticoneGradientButton2.ForeColor = Color.Black;
		this.siticoneGradientButton2.HoveredState.Parent = this.siticoneGradientButton2;
		this.siticoneGradientButton2.Location = new Point(529, 287);
		this.siticoneGradientButton2.Name = "siticoneGradientButton2";
		this.siticoneGradientButton2.ShadowDecoration.Parent = this.siticoneGradientButton2;
		this.siticoneGradientButton2.Size = new Size(74, 27);
		this.siticoneGradientButton2.TabIndex = 3;
		this.siticoneGradientButton2.Text = "SAFE";
		this.siticoneButton1.CheckedState.Parent = this.siticoneButton1;
		this.siticoneButton1.CustomImages.Parent = this.siticoneButton1;
		this.siticoneButton1.FillColor = Color.Gray;
		this.siticoneButton1.Font = new Font("Segoe UI", 9f);
		this.siticoneButton1.ForeColor = Color.White;
		this.siticoneButton1.HoveredState.Parent = this.siticoneButton1;
		this.siticoneButton1.Location = new Point(112, 50);
		this.siticoneButton1.Name = "siticoneButton1";
		this.siticoneButton1.ShadowDecoration.Parent = this.siticoneButton1;
		this.siticoneButton1.Size = new Size(661, 1);
		this.siticoneButton1.TabIndex = 4;
		this.label1.AutoSize = true;
		this.label1.Font = new Font("Segoe UI Semibold", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		this.label1.ForeColor = Color.White;
		this.label1.Location = new Point(629, 34);
		this.label1.Name = "label1";
		this.label1.Size = new Size(144, 13);
		this.label1.TabIndex = 5;
		this.label1.Text = "dev by StalkyGhostface <3";
		this.closeMe.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
		this.closeMe.BackColor = Color.Transparent;
		this.closeMe.ControlBoxStyle =  Siticone.UI.WinForms.Enums.ControlBoxStyle.Windows10;
		this.closeMe.FillColor = Color.Transparent;
		this.closeMe.HoveredState.Parent = this.closeMe;
		this.closeMe.IconColor = Color.White;
		this.closeMe.Location = new Point(749, 4);
		this.closeMe.Name = "closeMe";
		this.closeMe.ShadowDecoration.Parent = this.closeMe;
		this.closeMe.Size = new Size(39, 27);
		this.closeMe.TabIndex = 6;
		this.minimizeMe.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
		this.minimizeMe.BackColor = Color.Transparent;
		this.minimizeMe.ControlBoxStyle =  Siticone.UI.WinForms.Enums.ControlBoxStyle.Windows10;
		this.minimizeMe.ControlBoxType = 0;
		this.minimizeMe.FillColor = Color.Transparent;
		this.minimizeMe.HoveredState.Parent = this.minimizeMe;
		this.minimizeMe.IconColor = Color.White;
		this.minimizeMe.Location = new Point(707, 4);
		this.minimizeMe.Name = "minimizeMe";
		this.minimizeMe.ShadowDecoration.Parent = this.minimizeMe;
		this.minimizeMe.Size = new Size(36, 27);
		this.minimizeMe.TabIndex = 7;
		this.epicInnit.AutoSize = true;
		this.epicInnit.Font = new Font("Segoe UI", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		this.epicInnit.ForeColor = Color.White;
		this.epicInnit.Location = new Point(109, 21);
		this.epicInnit.Name = "epicInnit";
		this.epicInnit.Size = new Size(101, 13);
		this.epicInnit.TabIndex = 8;
		this.epicInnit.Text = "This is epic! Isn't it";
		this.moduleName.AutoSize = true;
		this.moduleName.Font = new Font("Segoe UI Semibold", 17.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		this.moduleName.ForeColor = Color.White;
		this.moduleName.Location = new Point(109, 63);
		this.moduleName.Name = "moduleName";
		this.moduleName.Size = new Size(153, 31);
		this.moduleName.TabIndex = 9;
		this.moduleName.Text = "Jesus Configs";
		this.pictureBox1.Image = (Image)componentResourceManager.GetObject("pictureBox1.Image");
		this.pictureBox1.Location = new Point(555, 366);
		this.pictureBox1.Name = "pictureBox1";
		this.pictureBox1.Size = new Size(48, 72);
		this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
		this.pictureBox1.TabIndex = 10;
		this.pictureBox1.TabStop = false;
		this.titleRate.AutoSize = true;
		this.titleRate.Font = new Font("Segoe UI Black", 9.25f, FontStyle.Bold);
		this.titleRate.ForeColor = Color.White;
		this.titleRate.Location = new Point(609, 361);
		this.titleRate.Name = "titleRate";
		this.titleRate.Size = new Size(161, 17);
		this.titleRate.TabIndex = 11;
		this.titleRate.Text = "Competitive Players +18";
		this.detailsRate.AutoSize = true;
		this.detailsRate.Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
		this.detailsRate.ForeColor = Color.Gray;
		this.detailsRate.Location = new Point(609, 378);
		this.detailsRate.MaximumSize = new Size(134, 0);
		this.detailsRate.MinimumSize = new Size(134, 0);
		this.detailsRate.Name = "detailsRate";
		this.detailsRate.Size = new Size(134, 60);
		this.detailsRate.TabIndex = 12;
		this.detailsRate.Text = "Spins, Jukes, Mindgames, Boosted, Hate, and Violent Chases";
		this.experienceBoost.BackColor = Color.Transparent;
		this.experienceBoost.BorderRadius = 4;
		this.experienceBoost.CheckedState.Parent = this.experienceBoost;
		this.experienceBoost.CustomImages.Parent = this.experienceBoost;
		this.experienceBoost.FillColor = Color.White;
		this.experienceBoost.FillColor2 = Color.White;
		this.experienceBoost.Font = new Font("Segoe UI", 9.25f);
		this.experienceBoost.ForeColor = Color.Black;
		this.experienceBoost.HoveredState.Parent = this.experienceBoost;
		this.experienceBoost.Location = new Point(529, 320);
		this.experienceBoost.Name = "experienceBoost";
		this.experienceBoost.ShadowDecoration.Parent = this.experienceBoost;
		this.experienceBoost.Size = new Size(241, 38);
		this.experienceBoost.TabIndex = 13;
		this.experienceBoost.Text = "BOOST MY GAME";
		this.experienceBoost.Click += this.experienceBoost_Click;
		this.pictureBox2.Image = (Image)componentResourceManager.GetObject("pictureBox2.Image");
		this.pictureBox2.Location = new Point(99, 101);
		this.pictureBox2.Name = "pictureBox2";
		this.pictureBox2.Size = new Size(412, 229);
		this.pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
		this.pictureBox2.TabIndex = 14;
		this.pictureBox2.TabStop = false;
		this.label2.AutoSize = true;
		this.label2.Font = new Font("Segoe UI Semibold", 17.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		this.label2.ForeColor = Color.White;
		this.label2.Location = new Point(93, 333);
		this.label2.Name = "label2";
		this.label2.Size = new Size(326, 31);
		this.label2.TabIndex = 15;
		this.label2.Text = "Type in your Engine files path:";
		this.enginePath.Cursor = Cursors.IBeam;
		this.enginePath.DefaultText = "C:\\Users\\Name\\AppData\\Local\\DeadByDaylight\\Saved\\Config\\";
		this.enginePath.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
		this.enginePath.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
		this.enginePath.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
		this.enginePath.DisabledState.Parent = this.enginePath;
		this.enginePath.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
		this.enginePath.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
		this.enginePath.FocusedState.Parent = this.enginePath;
		this.enginePath.HoveredState.BorderColor = Color.FromArgb(94, 148, 255);
		this.enginePath.HoveredState.Parent = this.enginePath;
		this.enginePath.Location = new Point(99, 367);
		this.enginePath.Name = "enginePath";
		this.enginePath.PasswordChar = '\0';
		this.enginePath.PlaceholderText = "";
		this.enginePath.SelectedText = "";
		this.enginePath.ShadowDecoration.Parent = this.enginePath;
		this.enginePath.Size = new Size(412, 36);
		this.enginePath.TabIndex = 16;
		this.enginePath.TextChanged += this.enginePath_TextChanged;
		this.helpDude.BackColor = Color.Transparent;
		this.helpDude.BorderRadius = 4;
		this.helpDude.CheckedState.Parent = this.helpDude;
		this.helpDude.CustomImages.Parent = this.helpDude;
		this.helpDude.FillColor = Color.Gainsboro;
		this.helpDude.FillColor2 = Color.Gainsboro;
		this.helpDude.Font = new Font("Segoe UI", 9.25f);
		this.helpDude.ForeColor = Color.Black;
		this.helpDude.HoveredState.Parent = this.helpDude;
		this.helpDude.Location = new Point(202, 409);
		this.helpDude.Name = "helpDude";
		this.helpDude.ShadowDecoration.Parent = this.helpDude;
		this.helpDude.Size = new Size(217, 35);
		this.helpDude.TabIndex = 17;
		this.helpDude.Text = "HELP ME! I DONT KNOW MY PATH";
		this.helpDude.Click += this.helpDude_Click;
		this.label3.AutoSize = true;
		this.label3.Font = new Font("Segoe UI", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		this.label3.ForeColor = Color.White;
		this.label3.Location = new Point(609, 293);
		this.label3.Name = "label3";
		this.label3.Size = new Size(88, 13);
		this.label3.TabIndex = 18;
		this.label3.Text = "Boosted + Cool";
		this.topBar.BackColor = Color.Transparent;
		this.topBar.BorderRadius = 4;
		this.topBar.CheckedState.Parent = this.topBar;
		this.topBar.CustomImages.Parent = this.topBar;
		this.topBar.FillColor = Color.FromArgb(20, 20, 20);
		this.topBar.FillColor2 = Color.FromArgb(20, 20, 20);
		this.topBar.Font = new Font("Segoe UI", 9.25f);
		this.topBar.ForeColor = Color.Black;
		this.topBar.HoveredState.Parent = this.topBar;
		this.topBar.Location = new Point(371, 4);
		this.topBar.Name = "topBar";
		this.topBar.ShadowDecoration.Parent = this.topBar;
		this.topBar.Size = new Size(344, 30);
		this.topBar.TabIndex = 19;
		this.dragDriver.TargetControl = this.topBar;
		this.siticoneDragControl1.TargetControl = null;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		this.BackColor = Color.FromArgb(20, 20, 20);
		base.ClientSize = new Size(800, 450);
		base.Controls.Add(this.topBar);
		base.Controls.Add(this.label3);
		base.Controls.Add(this.helpDude);
		base.Controls.Add(this.enginePath);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.pictureBox2);
		base.Controls.Add(this.experienceBoost);
		base.Controls.Add(this.detailsRate);
		base.Controls.Add(this.titleRate);
		base.Controls.Add(this.pictureBox1);
		base.Controls.Add(this.moduleName);
		base.Controls.Add(this.epicInnit);
		base.Controls.Add(this.minimizeMe);
		base.Controls.Add(this.closeMe);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.siticoneButton1);
		base.Controls.Add(this.siticoneGradientButton2);
		base.Controls.Add(this.siticoneGradientButton1);
		base.Controls.Add(this.mainPromo);
		base.Controls.Add(this.guna2PictureBox1);
		this.Cursor = Cursors.Cross;
		base.FormBorderStyle = FormBorderStyle.None;
		base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		base.Name = "JesusBooster";
		this.Text = "Jesus Configs";
		((ISupportInitialize)this.mainPromo).EndInit();
		((ISupportInitialize)this.pictureBox1).EndInit();
		((ISupportInitialize)this.pictureBox2).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
