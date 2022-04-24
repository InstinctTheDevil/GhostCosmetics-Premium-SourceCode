using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using DiscordRPC;
using DiscordRPC.Events;
using DiscordRPC.IO;
using DiscordRPC.Logging;
using DiscordRPC.Message;
using Fiddler;
using GhostAuth;
using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Suite;

using PremiumCache;
using Siticone.UI.WinForms;
using Button = DiscordRPC.Button;

namespace Premium;

public class Dashboard : Form
{
	public static string bhvrSession = "pending";

	public static string appPath = AppDomain.CurrentDomain.BaseDirectory;

	public static string isUnbindEnabled = "false";

	public static string tryingToCaughtSkids = "this tool was made by your lovely stalky <3"; // cringe

	private IContainer components;

	private Guna2Button premiumLogo;

	private Label gcLabel;

	private SiticoneControlBox closeDash;

	private SiticoneControlBox minimizeDash;

	private Label visualName;

	private Label premiumDateLabel;

	private SiticoneCircleButton drag;

	private SiticoneDragControl siticoneDragControl1;

	private Label marketDay;

	private Label status;

	private Label lastDLClabel;

	private Guna2GradientTileButton igniteUnlocker;

	private Guna2GradientTileButton onlyDLCignite;

	private SiticoneLabel orSpecify;

	private Guna2GradientTileButton levelSpooferOpen;

	private Guna2GradientTileButton bloodpointsOpen;

	private Guna2GradientTileButton localMarketOpen;

	private Guna2GradientTileButton currenciesOpen;

	private Guna2GradientTileButton tempInjectorOpen;

	private Guna2GradientTileButton rankChanger;

	private SiticoneLabel whisperLabel;

	private Guna2GradientTileButton guna2GradientTileButton1;

	private NotifyIcon trayDashboard;

	private Guna2ImageButton discordRPC;

	private Guna2GradientTileButton safetyKill;

	private Label label1;

	private Guna2GradientTileButton spoofBloodweb;

	private SiticoneLabel publicSession;

	private SiticoneGradientPanel siticoneGradientPanel1;

	private SiticoneCirclePictureBox profilePicture;

	private Label uploadLabel;

	private Label usersLabel;

	private Label label9;

	private Label label8;

	private Label label7;

	private Label label6;

	private Label label5;

	private Label label4;

	private Label label3;

	private Label label2;

	private SiticoneGradientPanel panelTemp;

	private Label tempLabel;

	private SiticoneGradientPanel siticoneGradientPanel2;

	private Label label10;

	private Guna2GradientTileButton bootJesus;

	private Guna2GradientTileButton betaTrigger;

	[DllImport("Gdi32.dll")]
	private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

	public void Alert(string msg, Form_Alert.enmType type)
	{
		new Form_Alert().showAlert(msg, type);
	}

	public Dashboard()
	{
		InitializeComponent();
		base.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, base.Width, base.Height, 20, 20));
	//	profilePicture.Load(GhostAuth.User.ProfilePicture);
		GhostCore.Start();

		status.Text = "Connecting...";
		CertMaker.createRootCert();
		CertMaker.trustRootCert();
		if (!Cache.didUserLoggedInWithFiddler)
		{
			MessageBox.Show("Client was not able to initialize GhostCore successfully, restart or try running as admin!");
			((Control)(object)igniteUnlocker).Enabled = false;
			((Control)(object)levelSpooferOpen).Enabled = false;
			((Control)(object)currenciesOpen).Enabled = false;
			((Control)(object)onlyDLCignite).Enabled = false;
			((Control)(object)localMarketOpen).Enabled = false;
		}
		else
		{
			Cache.wasFiddlerValidated = true;
		}
		WebClient webClient = new WebClient();
		string text = webClient.DownloadString("https://raw.githubusercontent.com/StalkyGhostface/gh0stbydaylight-althosting/main/premiumApi/marketDate");
		marketDay.Text = text;
		status.Text = "Market Date loaded!";
		Alert("Almost There!...", Form_Alert.enmType.Info);
		status.Text = "Validating GhostAuth.Username...";
		visualName.Text = "Daddy Instinct";
		status.Text = "Username Validated!";
		status.Text = "Validating Premium date...";
		premiumDateLabel.Text = GhostAuth.User.RegisterDate;
		status.Text = "Premium Date Validated!";
		status.Text = "Fetching Last DLC...";
		string text2 = webClient.DownloadString("https://raw.githubusercontent.com/StalkyGhostface/gh0stbydaylight-althosting/main/premiumApi/lastDLC");
		lastDLClabel.Text = text2;
		status.Text = "Last DLC Loaded!";
		string totalUsers = ApplicationSettings.TotalUsers;
		usersLabel.Text = totalUsers;
		Cache.unbinderData = webClient.DownloadString("https://api.infinitygg.net/branch/beta/encSkins");
		string text3 = webClient.DownloadString("https://raw.githubusercontent.com/StalkyGhostface/gh0stbydaylight-althosting/main/premiumApi/whisper");
		((Control)(object)whisperLabel).Text = text3;
		status.Text = "Loaded!";
		status.Text = "Ready! (No Gens Mode)";
		((Control)(object)rankChanger).Enabled = false;
		((Control)(object)bloodpointsOpen).Enabled = false;
		((Control)(object)tempInjectorOpen).Enabled = false;
		string text4 = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
		char[] array = new char[16];
		Random random = new Random();
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = text4[random.Next(text4.Length)];
		}
		string text6 = (Text = new string(array));
		if (webClient.DownloadString("https://raw.githubusercontent.com/StalkyGhostface/gh0stbydaylight-althosting/main/premiumApi/isXmas").Contains("happy"))
		{
			gcLabel.Text = "Merry Christmas!";
		}
		if (webClient.DownloadString("https://raw.githubusercontent.com/StalkyGhostface/gh0stbydaylight-althosting/main/premiumApi/isChristmas").Contains("happy"))
		{
			gcLabel.Text = "Christmas Day!";
			MessageBox.Show("Wish you the best of Christmas days! Share the hapiness with your loved ones and remember you're the best present they can have ;)", "A message from Stalky");
			Process.Start("https://www.youtube.com/watch?v=aAkMkVFwAoo");
		}
		if (webClient.DownloadString("https://raw.githubusercontent.com/StalkyGhostface/gh0stbydaylight-althosting/main/premiumApi/isNewYear").Contains("2022"))
		{
			MessageBox.Show("2022 is with us, the last 2 years haven't been the best of all, but all of us have been able to go through all of this, now, it is time to congratulate ourselves and make every day, a better day.", "A message from Stalky");
			gcLabel.Text = "Happy New Year";
		}
		webClient.Dispose();
		Alert("Dashboard Initialized succesfully!", Form_Alert.enmType.Success);
	}

	private void Dashboard_FormClosing(object sender, FormClosingEventArgs e)
	{
		Alert("Bye bye!", Form_Alert.enmType.Info);
		API.Log("Daddy Instinct", "Session TERMINATED");
		CertMaker.removeFiddlerGeneratedCerts();
		FiddlerApplication.Shutdown();
		Environment.Exit(0);
	}

	private void guna2GradientTileButton1_Click(object sender, EventArgs e)
	{
		Hide();
		trayDashboard.Visible = true;
		Alert("Psst.. check system tray to open me again", Form_Alert.enmType.Success);
		API.Log("Daddy Instinct", "Incognito Mode Triggered");
	}

	private void trayDashboard_MouseClick(object sender, MouseEventArgs e)
	{
		Show();
		trayDashboard.Visible = false;
	}

	public static void FiddlerApplication_BeforeRequest(Session oSession)
	{
		oSession.bBufferResponse = true;
	}

	public static void FiddlerApplication_BeforeResponseEverything(Session oSession)
	{
		if (oSession.fullUrl.Contains("/api/v1/inventories"))
		{
			oSession.utilDecodeResponse();
			string text = new WebClient().DownloadString("https://raw.githubusercontent.com/StalkyGhostface/gh0stbydaylight-althosting/main/premiumApi/premiumMarket");
			oSession.utilSetResponseBody(text);
		}
	}

	public static void FiddlerApplication_BeforeResponseOnlyDLC(Session oSession)
	{
		if (oSession.fullUrl.Contains("/api/v1/inventories"))
		{
			oSession.utilDecodeResponse();
			string text = new WebClient().DownloadString("https://raw.githubusercontent.com/StalkyGhostface/gh0stbydaylight-althosting/main/premiumApi/onlyDLC");
			oSession.utilSetResponseBody(text);
		}
	}

	private void igniteUnlocker_Click(object sender, EventArgs e)
	{
		
	
		string text = "(ALL) Unlocker Ignited!";
		status.Text = text;
		API.Log("Daddy Instinct", "Core: Market (ALL) Provided");
		Alert("ALL Temp Unlocked; open your game!", Form_Alert.enmType.Success);
		((Control)(object)igniteUnlocker).Enabled = false;
		((Control)(object)onlyDLCignite).Enabled = false;
		Cache.unbinderStatus = false;
		new WebClient();
		FiddlerApplication.BeforeRequest +=(new SessionStateHandler(FiddlerApplication_BeforeRequest));
		FiddlerApplication.BeforeResponse +=(new SessionStateHandler(FiddlerApplication_BeforeResponseEverything));
	}

	private void onlyDLCignite_Click(object sender, EventArgs e)
	{
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Expected O, but got Unknown
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected O, but got Unknown
		string text = "(DLC) Unlocker Ignited!";
		status.Text = text;
		API.Log("Daddy Instinct", "Core: Market (DLC) Provided");
		MessageBox.Show("DLCs Temp Unlocked", "You can now start your game as normal, enjoy!");
		Alert("DLCs Temp Unlocked; open your game!", Form_Alert.enmType.Success);
		((Control)(object)onlyDLCignite).Enabled = false;
		((Control)(object)igniteUnlocker).Enabled = false;
		FiddlerApplication.BeforeRequest +=(new SessionStateHandler(FiddlerApplication_BeforeRequest));
		FiddlerApplication.BeforeResponse +=(new SessionStateHandler(FiddlerApplication_BeforeResponseOnlyDLC));
		FiddlerApplication.ResetSessionCounter();
	}

	private void downloadBypass_Click(object sender, EventArgs e)
	{
		MessageBox.Show("I don't want your accounts banned, for this reason this feature was disabled. Any SSL Bypass you found could be risky, up to you - Stalky");
		API.Log("Daddy Instinct", "Requested SSL Bypass - Denied");
	}

	private void localMarketOpen_Click(object sender, EventArgs e)
	{
		Alert("Initializing Local Market", Form_Alert.enmType.Info);
		string text = "Initializing Local Market..";
		status.Text = text;
		API.Log("Daddy Instinct", "Local Market Opened");
		text = "Initializing Local Market...";
		status.Text = text;
		new LocalMarket().Show();
		text = "Local Market Loaded!";
		status.Text = text;
	}

	private void discordRPC_Click(object sender, EventArgs e)
	{

		int num = -1;
		DiscordRpcClient discordRpcClient = new DiscordRpcClient("875915638617567273", num, null, true, null);
		discordRpcClient.Initialize();
		string text = "Initializing Rich Presence..";
		this.status.Text = text;
		WebClient webClient = new WebClient();
		string username = "Daddy Instinct";
		string state = "User: " + username;
		webClient.DownloadString("https://raw.githubusercontent.com/StalkyGhostface/gh0stbydaylight-althosting/main/premiumApi/discord");
		discordRpcClient.OnReady += delegate (object sender1, ReadyMessage msg)
		{
			this.Alert("Linked to: " + msg.User.Username, Form_Alert.enmType.Success);
		};
		discordRpcClient.SetPresence(new RichPresence
		{
			Details = "Cracked by instinct<3",
			State = state,
			Timestamps = Timestamps.Now,
			Assets = new Assets
			{
				LargeImageKey = "ghost",
				LargeImageText = "GhostCosmetics Premium",
				SmallImageKey = "warden",
				SmallImageText = "Stolen unlocker"
			},
			Buttons = new Button[]
			{
					new Button
					{
						Label = "Don't buy GC - Get the crack here",
						Url = "https://serenitysolutions.xyz/bypass"
					}
			}
		});
		text = "Rich Presence Active!";
		this.Alert("Thanks for using our presence!", Form_Alert.enmType.Info);
		this.status.Text = text;
	}

	private void levelSpooferOpen_Click(object sender, EventArgs e)
	{
		Alert("Initializing Level Spoofer", Form_Alert.enmType.Info);
		string text = "Initializing Level Spoofer..";
		status.Text = text;
		API.Log("Daddy Instinct", "Level Spoofer Opened");
		text = "Loading Level Spoofer...";
		status.Text = text;
		new LevelSpoofer().Show();
		text = "Level Spoofer Loaded!";
		status.Text = text;
	}

	private void currenciesOpen_Click(object sender, EventArgs e)
	{
		Alert("Initializing Currencies Spoofer", Form_Alert.enmType.Info);
		string text = "Initializing Currencies Spoofer..";
		status.Text = text;
		API.Log("Daddy Instinct", "Currencies Spoofer Opened");
		text = "Loading Currencies Spoofer...";
		status.Text = text;
		new CurrenciesSpoofer().Show();
		text = "Currencies Spoofer Loaded!";
		status.Text = text;
	}

	public void guna2GradientTileButton2_Click(object sender, EventArgs e)
	{
		Alert("Preparing the generator...", Form_Alert.enmType.Info);
		string obj = appPath + "\\xSlc0a0es.exe";
		status.Text = "Injecting...";
		API.Log("Daddy Instinct", "Generator Session Started");
		WebClient webClient = new WebClient();
		Thread.Sleep(1000);
		webClient.DownloadFile("https://cdn.discordapp.com/attachments/878003768317329500/889718896960081950/jslcoa0es.exe", appPath + "\\xSlc0a0es.exe");
		webClient.DownloadFile("https://cdn.discordapp.com/attachments/878003768317329500/889731288318218290/steam_api64.dll", appPath + "\\steam_api64.dll");
		webClient.DownloadFile("https://cdn.discordapp.com/attachments/878003768317329500/889731278025408532/steam_appid.txt", appPath + "\\steam_appid.txt");
		status.Text = "Preparing Generator";
		_ = appPath + "level.txt";
		string fileName = obj;
		Process obj2 = new Process
		{
			StartInfo = new ProcessStartInfo
			{
				UseShellExecute = true,
				FileName = fileName
			}
		};
		File.WriteAllText(appPath + "\\connection.txt", Text);
		obj2.Start();
		status.Text = "Generator Ready";
		Alert("Done! Follow the instructions on the gen.", Form_Alert.enmType.Success);
		Thread.Sleep(1000);
		obj2.WaitForExit();
		Alert("If the gen. didn't came up open a ticket!", Form_Alert.enmType.Info);
		if (File.Exists(appPath + "\\xSlc0a0es.exe"))
		{
			File.Delete(appPath + "\\xSlc0a0es.exe");
			status.Text = "Cleared!";
		}
		else
		{
			MessageBox.Show("Missing File!", "Security Error!");
			API.Log("Daddy Instinct", "Security Error triggered at Generator!");
			Environment.Exit(0);
		}
		if (File.Exists(appPath + "\\steam_api64.dll"))
		{
			File.Delete(appPath + "\\steam_api64.dll");
			status.Text = "Cleared! (2)";
		}
		else
		{
			MessageBox.Show("Missing API!", "Security Error!");
			API.Log("Daddy Instinct", "Security Error triggered at SteamAPI!");
			Environment.Exit(0);
		}
		if (File.Exists(appPath + "\\steam_appid.txt"))
		{
			File.Delete(appPath + "\\steam_appid.txt");
			status.Text = "Cleared! (3)";
		}
		else
		{
			MessageBox.Show("Missing Parameter!", "Security Error!");
			API.Log("Daddy Instinct", "Security Error triggered at Steam Parameter!");
			Environment.Exit(0);
		}
		status.Text = "Caching Session...";
		bhvrSession = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "\\ghostSession.txt");
		string text = "st4lky";
		API.Log("Daddy Instinct", "Generator Session Finalized /" + text);
		((Control)(object)rankChanger).Enabled = true;
		((Control)(object)bloodpointsOpen).Enabled = true;
		webClient.Dispose();
		status.Text = "Ready!";
		Alert("Session Saved", Form_Alert.enmType.Success);
	}

	public static void FiddlerApplication_BeforeResponseChatMessageDeprecated(Session oSession)
	{
		if (oSession.fullUrl.Contains("api/v1/profanityfilter/sanitizer/message"))
		{
			oSession.utilDecodeResponse();
			oSession.fullUrl = ("https://stalkyghostface.xyz/api/premium/safetyFilter");
		}
	}

	private void tempInjectorOpen_Click(object sender, EventArgs e)
	{
		MessageBox.Show("You opened the box too early! Not done yet ;(");
	}

	private void rankChanger_Click(object sender, EventArgs e)
	{
		Alert("Initializing Rank Editor", Form_Alert.enmType.Info);
		string text = "Initializing Rank Changer";
		status.Text = text;
		API.Log("Daddy Instinct", "Rank Changer Opened");
		text = "Loading Rank Changer";
		status.Text = text;
		new RankEditor().Show();
		text = "Rank Changer Loaded!";
		status.Text = text;
	}

	private void bloodpointsOpen_Click(object sender, EventArgs e)
	{
		Alert("Initializing Bloodpoints Generator", Form_Alert.enmType.Info);
		string text = "Initializing Bloodpoints Gen.";
		status.Text = text;
		API.Log("Daddy Instinct", "Bloodpints Gen. Opened");
		text = "Loading Bloodpoints Gen....";
		status.Text = text;
		new BloodpointsModule().Show();
		text = "Bloodpoints Gen Loaded!";
		status.Text = text;
	}

	private void spoofBloodweb_Click(object sender, EventArgs e)
	{
		string text = "Bloodweb Spoofing Ignited!";
		status.Text = text;
		API.Log("Daddy Instinct", "Core: BLOODWEB_Spoofer Ignited");
		MessageBox.Show("Bloodweb Spoofing started!", "You can now enable more modules, or start your game!");
		((Control)(object)spoofBloodweb).Enabled = false;
		Cache.bloodyMary = true;
	}

	private void uploadLabel_Click(object sender, EventArgs e)
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Filter = "Image Files(*.jpg; *.png; *.jpeg; *.gif; *.bmp; *.txt)|*.jpg; *.png; *.jpeg; *.gif; *.bmp; *.txt";
		if (openFileDialog.ShowDialog() == DialogResult.OK)
		{
			string path = Convert.ToBase64String(File.ReadAllBytes(openFileDialog.FileName));
			API.UploadPic("Daddy Instinct", path);
		}
	}

	private void bootJesus_Click(object sender, EventArgs e)
	{
		Alert("Initializing Jesus Configs", Form_Alert.enmType.Info);
		string text = "Initializing Jesus Confg.";
		status.Text = text;
		API.Log("Daddy Instinct", "Jesus Configs Opened");
		text = "Loading Jesus Conf.g.....";
		status.Text = text;
		new JesusBooster().Show();
		text = "Jesus Configs Loaded!";
		status.Text = text;
	}

	private void betaTrigger_Click(object sender, EventArgs e)
	{
		Alert("Initializing Beta Menu", Form_Alert.enmType.Info);
		string text = "Initializing Beta Menu";
		status.Text = text;
		API.Log("Daddy Instinct", "Beta Menu opened");
		text = "Loading Beta Menu";
		status.Text = text;
		new BetaInit().Show();
		text = "Beta Menu Loaded!";
		status.Text = text;
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Dashboard));
		this.premiumLogo = new Guna2Button();
		this.gcLabel = new Label();
		this.closeDash = new SiticoneControlBox();
		this.minimizeDash = new SiticoneControlBox();
		this.visualName = new Label();
		this.premiumDateLabel = new Label();
		this.drag = new SiticoneCircleButton();
		this.siticoneDragControl1 = new SiticoneDragControl(this.components);
		this.marketDay = new Label();
		this.status = new Label();
		this.lastDLClabel = new Label();
		this.igniteUnlocker = new Guna2GradientTileButton();
		this.onlyDLCignite = new Guna2GradientTileButton();
		this.orSpecify = new SiticoneLabel();
		this.levelSpooferOpen = new Guna2GradientTileButton();
		this.bloodpointsOpen = new Guna2GradientTileButton();
		this.localMarketOpen = new Guna2GradientTileButton();
		this.currenciesOpen = new Guna2GradientTileButton();
		this.tempInjectorOpen = new Guna2GradientTileButton();
		this.rankChanger = new Guna2GradientTileButton();
		this.whisperLabel = new SiticoneLabel();
		this.guna2GradientTileButton1 = new Guna2GradientTileButton();
		this.trayDashboard = new NotifyIcon(this.components);
		this.discordRPC = new Guna2ImageButton();
		this.safetyKill = new Guna2GradientTileButton();
		this.label1 = new Label();
		this.spoofBloodweb = new Guna2GradientTileButton();
		this.publicSession = new SiticoneLabel();
		this.siticoneGradientPanel1 = new SiticoneGradientPanel();
		this.label9 = new Label();
		this.label8 = new Label();
		this.label7 = new Label();
		this.label6 = new Label();
		this.label5 = new Label();
		this.label4 = new Label();
		this.label3 = new Label();
		this.label2 = new Label();
		this.usersLabel = new Label();
		this.uploadLabel = new Label();
		this.profilePicture = new SiticoneCirclePictureBox();
		this.panelTemp = new SiticoneGradientPanel();
		this.tempLabel = new Label();
		this.siticoneGradientPanel2 = new SiticoneGradientPanel();
		this.bootJesus = new Guna2GradientTileButton();
		this.label10 = new Label();
		this.betaTrigger = new Guna2GradientTileButton();
		this.siticoneGradientPanel1.SuspendLayout();
		this.panelTemp.SuspendLayout();
		this.siticoneGradientPanel2.SuspendLayout();
		base.SuspendLayout();
		this.premiumLogo.BackgroundImage = (Image)componentResourceManager.GetObject("premiumLogo.BackgroundImage");
		this.premiumLogo.BackgroundImageLayout = ImageLayout.Zoom;
		this.premiumLogo.CheckedState.Parent = this.premiumLogo;
		this.premiumLogo.CustomImages.Parent = this.premiumLogo;
		this.premiumLogo.FillColor = Color.Transparent;
		this.premiumLogo.Font = new Font("Segoe UI", 9f);
		this.premiumLogo.ForeColor = Color.White;
		this.premiumLogo.HoverState.Parent = this.premiumLogo;
		this.premiumLogo.Location = new Point(12, 12);
		this.premiumLogo.Name = "premiumLogo";
		this.premiumLogo.ShadowDecoration.Parent = this.premiumLogo;
		this.premiumLogo.Size = new Size(56, 47);
		this.premiumLogo.TabIndex = 0;
		this.gcLabel.AutoSize = true;
		this.gcLabel.Font = new Font("Microsoft Sans Serif", 15f, FontStyle.Bold);
		this.gcLabel.ForeColor = Color.White;
		this.gcLabel.Location = new Point(64, 22);
		this.gcLabel.Name = "gcLabel";
		this.gcLabel.Size = new Size(134, 25);
		this.gcLabel.TabIndex = 1;
		this.gcLabel.Text = "GC Premium";
		this.closeDash.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
		this.closeDash.BackColor = Color.Transparent;
		this.closeDash.BorderColor = Color.Transparent;
		this.closeDash.ControlBoxStyle =  Siticone.UI.WinForms.Enums.ControlBoxStyle.Windows10;
		this.closeDash.FillColor = Color.Transparent;
		this.closeDash.HoveredState.Parent = this.closeDash;
		this.closeDash.IconColor = Color.Fuchsia;
		this.closeDash.Location = new Point(739, 0);
		this.closeDash.Name = "closeDash";
		this.closeDash.PressedColor = Color.Purple;
		this.closeDash.ShadowDecoration.Parent = this.closeDash;
		this.closeDash.Size = new Size(29, 47);
		this.closeDash.TabIndex = 2;
		this.minimizeDash.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
		this.minimizeDash.BackColor = Color.Transparent;
		this.minimizeDash.ControlBoxStyle =  Siticone.UI.WinForms.Enums.ControlBoxStyle.Custom;
		this.minimizeDash.ControlBoxType = 0;
		this.minimizeDash.FillColor = Color.Transparent;
		this.minimizeDash.HoveredState.Parent = this.minimizeDash;
		this.minimizeDash.IconColor = Color.Fuchsia;
		this.minimizeDash.Location = new Point(704, 0);
		this.minimizeDash.Name = "minimizeDash";
		this.minimizeDash.PressedColor = Color.Purple;
		this.minimizeDash.ShadowDecoration.Parent = this.minimizeDash;
		this.minimizeDash.Size = new Size(29, 47);
		this.minimizeDash.TabIndex = 3;
		this.visualName.AutoSize = true;
		this.visualName.BackColor = Color.Transparent;
		this.visualName.Font = new Font("Segoe UI Black", 10f, FontStyle.Bold);
		this.visualName.ForeColor = Color.White;
		this.visualName.Location = new Point(18, 9);
		this.visualName.Name = "visualName";
		this.visualName.Size = new Size(77, 19);
		this.visualName.TabIndex = 5;
		this.visualName.Text = "Loading,,,";
		this.visualName.TextAlign = ContentAlignment.MiddleCenter;
		this.premiumDateLabel.AutoSize = true;
		this.premiumDateLabel.BackColor = Color.Transparent;
		this.premiumDateLabel.Font = new Font("Segoe UI Black", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
		this.premiumDateLabel.ForeColor = Color.White;
		this.premiumDateLabel.Location = new Point(123, 126);
		this.premiumDateLabel.Name = "premiumDateLabel";
		this.premiumDateLabel.Size = new Size(68, 15);
		this.premiumDateLabel.TabIndex = 9;
		this.premiumDateLabel.Text = "Loading,,,";
		this.drag.BackColor = Color.Transparent;
		this.drag.BorderColor = Color.Transparent;
		this.drag.CheckedState.Parent = this.drag;
		this.drag.Cursor = Cursors.SizeAll;
		this.drag.CustomImages.Parent = this.drag;
		this.drag.FillColor = Color.Transparent;
		this.drag.Font = new Font("Segoe UI Semibold", 12f, FontStyle.Bold | FontStyle.Italic);
		this.drag.ForeColor = Color.White;
		this.drag.HoveredState.Parent = this.drag;
		this.drag.Location = new Point(686, 398);
		this.drag.Name = "drag";
		this.drag.ShadowDecoration.Mode =  Siticone.UI.WinForms.Enums.ShadowMode.Circle;
		this.drag.ShadowDecoration.Parent = this.drag;
		this.drag.Size = new Size(101, 97);
		this.drag.TabIndex = 11;
		this.drag.Text = "=";
		this.siticoneDragControl1.TargetControl = this.drag;
		this.marketDay.AutoSize = true;
		this.marketDay.BackColor = Color.Transparent;
		this.marketDay.Font = new Font("Segoe UI Black", 9f, FontStyle.Bold);
		this.marketDay.ForeColor = Color.White;
		this.marketDay.Location = new Point(418, 124);
		this.marketDay.Name = "marketDay";
		this.marketDay.Size = new Size(68, 15);
		this.marketDay.TabIndex = 13;
		this.marketDay.Text = "Loading,,,";
		this.status.AutoSize = true;
		this.status.BackColor = Color.Transparent;
		this.status.Font = new Font("Segoe UI Black", 9f, FontStyle.Bold);
		this.status.ForeColor = Color.White;
		this.status.Location = new Point(123, 48);
		this.status.Name = "status";
		this.status.Size = new Size(68, 15);
		this.status.TabIndex = 15;
		this.status.Text = "Loading,,,";
		this.lastDLClabel.AutoSize = true;
		this.lastDLClabel.BackColor = Color.Transparent;
		this.lastDLClabel.Font = new Font("Segoe UI Black", 9f, FontStyle.Bold);
		this.lastDLClabel.ForeColor = Color.White;
		this.lastDLClabel.Location = new Point(330, 48);
		this.lastDLClabel.Name = "lastDLClabel";
		this.lastDLClabel.Size = new Size(68, 15);
		this.lastDLClabel.TabIndex = 17;
		this.lastDLClabel.Text = "Loading,,,";
		this.igniteUnlocker.Animated = true;
		this.igniteUnlocker.AutoRoundedCorners = true;
		this.igniteUnlocker.BackColor = Color.Transparent;
		this.igniteUnlocker.BorderColor = Color.Transparent;
		this.igniteUnlocker.BorderRadius = 22;
		this.igniteUnlocker.CheckedState.Parent = this.igniteUnlocker;
		this.igniteUnlocker.Cursor = Cursors.AppStarting;
		this.igniteUnlocker.CustomImages.Parent = this.igniteUnlocker;
		this.igniteUnlocker.FillColor = Color.FromArgb(64, 0, 64);
		this.igniteUnlocker.FillColor2 = Color.FromArgb(0, 0, 64);
		this.igniteUnlocker.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
		this.igniteUnlocker.ForeColor = Color.White;
		this.igniteUnlocker.HoverState.Parent = this.igniteUnlocker;
		this.igniteUnlocker.Location = new Point(220, 35);
		this.igniteUnlocker.Name = "igniteUnlocker";
		this.igniteUnlocker.PressedColor = Color.DarkRed;
		this.igniteUnlocker.ShadowDecoration.Parent = this.igniteUnlocker;
		this.igniteUnlocker.Size = new Size(105, 47);
		this.igniteUnlocker.TabIndex = 18;
		this.igniteUnlocker.Text = "Unlock ALL";
		this.igniteUnlocker.Click += this.igniteUnlocker_Click;
		this.onlyDLCignite.Animated = true;
		this.onlyDLCignite.AutoRoundedCorners = true;
		this.onlyDLCignite.BackColor = Color.Transparent;
		this.onlyDLCignite.BorderRadius = 22;
		this.onlyDLCignite.CheckedState.Parent = this.onlyDLCignite;
		this.onlyDLCignite.Cursor = Cursors.AppStarting;
		this.onlyDLCignite.CustomImages.Parent = this.onlyDLCignite;
		this.onlyDLCignite.FillColor = Color.FromArgb(64, 0, 64);
		this.onlyDLCignite.FillColor2 = Color.FromArgb(0, 0, 64);
		this.onlyDLCignite.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
		this.onlyDLCignite.ForeColor = Color.White;
		this.onlyDLCignite.HoverState.Parent = this.onlyDLCignite;
		this.onlyDLCignite.Location = new Point(351, 35);
		this.onlyDLCignite.Name = "onlyDLCignite";
		this.onlyDLCignite.PressedColor = Color.DarkRed;
		this.onlyDLCignite.ShadowDecoration.Parent = this.onlyDLCignite;
		this.onlyDLCignite.Size = new Size(72, 47);
		this.onlyDLCignite.TabIndex = 19;
		this.onlyDLCignite.Text = "Only DLCs";
		this.onlyDLCignite.Click += this.onlyDLCignite_Click;
		this.orSpecify.BackColor = Color.Transparent;
		this.orSpecify.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
		this.orSpecify.ForeColor = Color.White;
		this.orSpecify.IsSelectionEnabled = false;
		this.orSpecify.Location = new Point(331, 50);
		this.orSpecify.Name = "orSpecify";
		this.orSpecify.Size = new Size(14, 15);
		this.orSpecify.TabIndex = 20;
		this.orSpecify.Text = "or";
		this.levelSpooferOpen.Animated = true;
		this.levelSpooferOpen.AutoRoundedCorners = true;
		this.levelSpooferOpen.BorderRadius = 22;
		this.levelSpooferOpen.CheckedState.Parent = this.levelSpooferOpen;
		this.levelSpooferOpen.Cursor = Cursors.Cross;
		this.levelSpooferOpen.CustomImages.Parent = this.levelSpooferOpen;
		this.levelSpooferOpen.FillColor = Color.FromArgb(64, 0, 64);
		this.levelSpooferOpen.FillColor2 = Color.DarkBlue;
		this.levelSpooferOpen.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		this.levelSpooferOpen.ForeColor = Color.White;
		this.levelSpooferOpen.HoverState.Parent = this.levelSpooferOpen;
		this.levelSpooferOpen.Location = new Point(14, 35);
		this.levelSpooferOpen.Name = "levelSpooferOpen";
		this.levelSpooferOpen.ShadowDecoration.Parent = this.levelSpooferOpen;
		this.levelSpooferOpen.Size = new Size(103, 47);
		this.levelSpooferOpen.TabIndex = 21;
		this.levelSpooferOpen.Text = "Level Spoofer";
		this.levelSpooferOpen.Click += this.levelSpooferOpen_Click;
		this.bloodpointsOpen.Animated = true;
		this.bloodpointsOpen.AutoRoundedCorners = true;
		this.bloodpointsOpen.BackColor = Color.Transparent;
		this.bloodpointsOpen.BorderRadius = 22;
		this.bloodpointsOpen.CheckedState.Parent = this.bloodpointsOpen;
		this.bloodpointsOpen.CustomImages.Parent = this.bloodpointsOpen;
		this.bloodpointsOpen.FillColor = Color.Navy;
		this.bloodpointsOpen.FillColor2 = Color.FromArgb(192, 0, 192);
		this.bloodpointsOpen.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold);
		this.bloodpointsOpen.ForeColor = Color.White;
		this.bloodpointsOpen.HoverState.Parent = this.bloodpointsOpen;
		this.bloodpointsOpen.Location = new Point(12, 22);
		this.bloodpointsOpen.Name = "bloodpointsOpen";
		this.bloodpointsOpen.ShadowDecoration.Parent = this.bloodpointsOpen;
		this.bloodpointsOpen.Size = new Size(86, 47);
		this.bloodpointsOpen.TabIndex = 22;
		this.bloodpointsOpen.Text = "Bloodpoints Generator";
		this.bloodpointsOpen.Click += this.bloodpointsOpen_Click;
		this.localMarketOpen.Animated = true;
		this.localMarketOpen.AutoRoundedCorners = true;
		this.localMarketOpen.BorderRadius = 22;
		this.localMarketOpen.CheckedState.Parent = this.localMarketOpen;
		this.localMarketOpen.Cursor = Cursors.Cross;
		this.localMarketOpen.CustomImages.Parent = this.localMarketOpen;
		this.localMarketOpen.FillColor = Color.FromArgb(0, 0, 64);
		this.localMarketOpen.FillColor2 = Color.FromArgb(64, 0, 64);
		this.localMarketOpen.Font = new Font("Microsoft Sans Serif", 11.75f, FontStyle.Bold);
		this.localMarketOpen.ForeColor = Color.White;
		this.localMarketOpen.HoverState.Parent = this.localMarketOpen;
		this.localMarketOpen.Location = new Point(220, 88);
		this.localMarketOpen.Name = "localMarketOpen";
		this.localMarketOpen.ShadowDecoration.Parent = this.localMarketOpen;
		this.localMarketOpen.Size = new Size(105, 47);
		this.localMarketOpen.TabIndex = 23;
		this.localMarketOpen.Text = "Use your own Market";
		this.localMarketOpen.Click += this.localMarketOpen_Click;
		this.currenciesOpen.Animated = true;
		this.currenciesOpen.AutoRoundedCorners = true;
		this.currenciesOpen.BorderRadius = 22;
		this.currenciesOpen.CheckedState.Parent = this.currenciesOpen;
		this.currenciesOpen.Cursor = Cursors.Cross;
		this.currenciesOpen.CustomImages.Parent = this.currenciesOpen;
		this.currenciesOpen.FillColor = Color.Blue;
		this.currenciesOpen.FillColor2 = Color.Purple;
		this.currenciesOpen.Font = new Font("Microsoft Sans Serif", 11.25f, FontStyle.Bold);
		this.currenciesOpen.ForeColor = Color.White;
		this.currenciesOpen.HoverState.Parent = this.currenciesOpen;
		this.currenciesOpen.Location = new Point(14, 88);
		this.currenciesOpen.Name = "currenciesOpen";
		this.currenciesOpen.ShadowDecoration.Parent = this.currenciesOpen;
		this.currenciesOpen.Size = new Size(103, 47);
		this.currenciesOpen.TabIndex = 24;
		this.currenciesOpen.Text = "Currencies Spoofer";
		this.currenciesOpen.Click += this.currenciesOpen_Click;
		this.tempInjectorOpen.Animated = true;
		this.tempInjectorOpen.AutoRoundedCorners = true;
		this.tempInjectorOpen.BorderRadius = 22;
		this.tempInjectorOpen.CheckedState.Parent = this.tempInjectorOpen;
		this.tempInjectorOpen.Cursor = Cursors.Cross;
		this.tempInjectorOpen.CustomImages.Parent = this.tempInjectorOpen;
		this.tempInjectorOpen.FillColor = Color.FromArgb(0, 0, 192);
		this.tempInjectorOpen.FillColor2 = Color.DarkMagenta;
		this.tempInjectorOpen.Font = new Font("Microsoft Sans Serif", 11.25f, FontStyle.Bold);
		this.tempInjectorOpen.ForeColor = Color.White;
		this.tempInjectorOpen.HoverState.Parent = this.tempInjectorOpen;
		this.tempInjectorOpen.Location = new Point(123, 88);
		this.tempInjectorOpen.Name = "tempInjectorOpen";
		this.tempInjectorOpen.ShadowDecoration.Parent = this.tempInjectorOpen;
		this.tempInjectorOpen.Size = new Size(92, 47);
		this.tempInjectorOpen.TabIndex = 26;
		this.tempInjectorOpen.Text = "Temp. Save Injector";
		this.tempInjectorOpen.Click += this.tempInjectorOpen_Click;
		this.rankChanger.Animated = true;
		this.rankChanger.AutoRoundedCorners = true;
		this.rankChanger.BackColor = Color.Transparent;
		this.rankChanger.BorderRadius = 22;
		this.rankChanger.CheckedState.Parent = this.rankChanger;
		this.rankChanger.Cursor = Cursors.Cross;
		this.rankChanger.CustomImages.Parent = this.rankChanger;
		this.rankChanger.FillColor = Color.FromArgb(0, 0, 192);
		this.rankChanger.FillColor2 = Color.FromArgb(64, 0, 64);
		this.rankChanger.Font = new Font("Microsoft Sans Serif", 12.25f, FontStyle.Bold);
		this.rankChanger.ForeColor = Color.White;
		this.rankChanger.HoverState.Parent = this.rankChanger;
		this.rankChanger.Location = new Point(101, 22);
		this.rankChanger.Name = "rankChanger";
		this.rankChanger.ShadowDecoration.Parent = this.rankChanger;
		this.rankChanger.Size = new Size(84, 47);
		this.rankChanger.TabIndex = 27;
		this.rankChanger.Text = "Rank Changer";
		this.rankChanger.Click += this.rankChanger_Click;
		this.whisperLabel.BackColor = Color.Transparent;
		this.whisperLabel.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
		this.whisperLabel.ForeColor = Color.White;
		this.whisperLabel.IsSelectionEnabled = false;
		this.whisperLabel.Location = new Point(24, 398);
		this.whisperLabel.MaximumSize = new Size(201, 50);
		this.whisperLabel.Name = "whisperLabel";
		this.whisperLabel.Size = new Size(53, 15);
		this.whisperLabel.TabIndex = 28;
		this.whisperLabel.Text = "Whoops!";
		this.guna2GradientTileButton1.Animated = true;
		this.guna2GradientTileButton1.AutoRoundedCorners = true;
		this.guna2GradientTileButton1.BorderRadius = 22;
		this.guna2GradientTileButton1.CheckedState.Parent = this.guna2GradientTileButton1;
		this.guna2GradientTileButton1.Cursor = Cursors.Cross;
		this.guna2GradientTileButton1.CustomImages.Parent = this.guna2GradientTileButton1;
		this.guna2GradientTileButton1.FillColor = Color.DarkMagenta;
		this.guna2GradientTileButton1.FillColor2 = Color.Navy;
		this.guna2GradientTileButton1.Font = new Font("Microsoft Sans Serif", 12.25f, FontStyle.Bold);
		this.guna2GradientTileButton1.ForeColor = Color.White;
		this.guna2GradientTileButton1.HoverState.Parent = this.guna2GradientTileButton1;
		this.guna2GradientTileButton1.Location = new Point(332, 12);
		this.guna2GradientTileButton1.Name = "guna2GradientTileButton1";
		this.guna2GradientTileButton1.ShadowDecoration.Parent = this.guna2GradientTileButton1;
		this.guna2GradientTileButton1.Size = new Size(95, 47);
		this.guna2GradientTileButton1.TabIndex = 29;
		this.guna2GradientTileButton1.Text = "Hide at Tray";
		this.guna2GradientTileButton1.Click += this.guna2GradientTileButton1_Click;
		this.trayDashboard.Icon = (Icon)componentResourceManager.GetObject("trayDashboard.Icon");
		this.trayDashboard.Text = "Dashboard";
		this.trayDashboard.Visible = true;
		this.trayDashboard.MouseClick += this.trayDashboard_MouseClick;
		this.discordRPC.BackColor = Color.Transparent;
		this.discordRPC.BackgroundImage = (Image)componentResourceManager.GetObject("discordRPC.BackgroundImage");
		this.discordRPC.BackgroundImageLayout = ImageLayout.Stretch;
		this.discordRPC.CheckedState.Parent = this.discordRPC;
		this.discordRPC.HoverState.Parent = this.discordRPC;
		this.discordRPC.Location = new Point(426, 0);
		this.discordRPC.Name = "discordRPC";
		this.discordRPC.PressedState.Parent = this.discordRPC;
		this.discordRPC.Size = new Size(66, 59);
		this.discordRPC.TabIndex = 30;
		this.discordRPC.Click += this.discordRPC_Click;
		this.safetyKill.Animated = true;
		this.safetyKill.AutoRoundedCorners = true;
		this.safetyKill.BackColor = Color.Transparent;
		this.safetyKill.BorderColor = Color.Transparent;
		this.safetyKill.BorderRadius = 22;
		this.safetyKill.CheckedState.Parent = this.safetyKill;
		this.safetyKill.Cursor = Cursors.Cross;
		this.safetyKill.CustomImages.Parent = this.safetyKill;
		this.safetyKill.FillColor = Color.FromArgb(0, 0, 64);
		this.safetyKill.FillColor2 = Color.FromArgb(64, 0, 64);
		this.safetyKill.Font = new Font("Microsoft Sans Serif", 12.75f, FontStyle.Bold);
		this.safetyKill.ForeColor = Color.White;
		this.safetyKill.HoverState.Parent = this.safetyKill;
		this.safetyKill.Location = new Point(456, 246);
		this.safetyKill.Name = "safetyKill";
		this.safetyKill.ShadowDecoration.Parent = this.safetyKill;
		this.safetyKill.Size = new Size(91, 47);
		this.safetyKill.TabIndex = 31;
		this.safetyKill.Text = "Generate Session";
		this.safetyKill.Click += this.guna2GradientTileButton2_Click;
		this.label1.AutoSize = true;
		this.label1.BackColor = Color.Transparent;
		this.label1.Font = new Font("Microsoft Sans Serif", 9.25f, FontStyle.Bold | FontStyle.Italic);
		this.label1.ForeColor = Color.White;
		this.label1.Location = new Point(489, 9);
		this.label1.Name = "label1";
		this.label1.Size = new Size(201, 16);
		this.label1.TabIndex = 32;
		this.label1.Text = "Steam, MS and Epic Ready!";
		this.spoofBloodweb.Animated = true;
		this.spoofBloodweb.AutoRoundedCorners = true;
		this.spoofBloodweb.BorderRadius = 22;
		this.spoofBloodweb.CheckedState.Parent = this.spoofBloodweb;
		this.spoofBloodweb.CustomImages.Parent = this.spoofBloodweb;
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
		this.spoofBloodweb.Text = "Spoof Bloodweb";
		this.spoofBloodweb.Click += this.spoofBloodweb_Click;
		this.publicSession.BackColor = Color.Transparent;
		this.publicSession.Font = new Font("Microsoft Sans Serif", 8.25f);
		this.publicSession.ForeColor = Color.White;
		this.publicSession.IsSelectionEnabled = false;
		this.publicSession.Location = new Point(284, 465);
		this.publicSession.Name = "publicSession";
		this.publicSession.Size = new Size(202, 15);
		this.publicSession.TabIndex = 34;
		this.publicSession.Text = "ghostSession not found; illegal connection";
		this.siticoneGradientPanel1.BorderRadius = 7;
		this.siticoneGradientPanel1.Controls.Add(this.label9);
		this.siticoneGradientPanel1.Controls.Add(this.label8);
		this.siticoneGradientPanel1.Controls.Add(this.label7);
		this.siticoneGradientPanel1.Controls.Add(this.label6);
		this.siticoneGradientPanel1.Controls.Add(this.label5);
		this.siticoneGradientPanel1.Controls.Add(this.label4);
		this.siticoneGradientPanel1.Controls.Add(this.label3);
		this.siticoneGradientPanel1.Controls.Add(this.label2);
		this.siticoneGradientPanel1.Controls.Add(this.usersLabel);
		this.siticoneGradientPanel1.Controls.Add(this.uploadLabel);
		this.siticoneGradientPanel1.Controls.Add(this.profilePicture);
		this.siticoneGradientPanel1.Controls.Add(this.visualName);
		this.siticoneGradientPanel1.Controls.Add(this.marketDay);
		this.siticoneGradientPanel1.Controls.Add(this.premiumDateLabel);
		this.siticoneGradientPanel1.Controls.Add(this.status);
		this.siticoneGradientPanel1.Controls.Add(this.lastDLClabel);
		this.siticoneGradientPanel1.Cursor = Cursors.Cross;
		this.siticoneGradientPanel1.FillColor = Color.Black;
		this.siticoneGradientPanel1.FillColor2 = Color.Purple;
		this.siticoneGradientPanel1.GradientMode = LinearGradientMode.ForwardDiagonal;
		this.siticoneGradientPanel1.Location = new Point(12, 65);
		this.siticoneGradientPanel1.Name = "siticoneGradientPanel1";
		this.siticoneGradientPanel1.ShadowDecoration.Parent = this.siticoneGradientPanel1;
		this.siticoneGradientPanel1.Size = new Size(543, 166);
		this.siticoneGradientPanel1.TabIndex = 35;
		this.label9.AutoSize = true;
		this.label9.BackColor = Color.Transparent;
		this.label9.Font = new Font("Segoe UI Black", 8.75f, FontStyle.Bold);
		this.label9.ForeColor = Color.White;
		this.label9.Location = new Point(436, 108);
		this.label9.Name = "label9";
		this.label9.Size = new Size(53, 15);
		this.label9.TabIndex = 28;
		this.label9.Text = "D A T E:";
		this.label8.AutoSize = true;
		this.label8.BackColor = Color.Transparent;
		this.label8.Font = new Font("Segoe UI Black", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		this.label8.ForeColor = Color.White;
		this.label8.Location = new Point(422, 91);
		this.label8.Name = "label8";
		this.label8.Size = new Size(84, 17);
		this.label8.TabIndex = 27;
		this.label8.Text = "M A R K E T";
		this.label7.AutoSize = true;
		this.label7.BackColor = Color.Transparent;
		this.label7.Font = new Font("Segoe UI Black", 8.75f, FontStyle.Bold);
		this.label7.ForeColor = Color.White;
		this.label7.Location = new Point(290, 108);
		this.label7.Name = "label7";
		this.label7.Size = new Size(61, 15);
		this.label7.TabIndex = 26;
		this.label7.Text = "U S E R S:";
		this.label6.AutoSize = true;
		this.label6.BackColor = Color.Transparent;
		this.label6.Font = new Font("Segoe UI Black", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		this.label6.ForeColor = Color.White;
		this.label6.Location = new Point(278, 91);
		this.label6.Name = "label6";
		this.label6.Size = new Size(98, 17);
		this.label6.TabIndex = 25;
		this.label6.Text = "P R E M I U M";
		this.label5.AutoSize = true;
		this.label5.BackColor = Color.Transparent;
		this.label5.Font = new Font("Segoe UI Black", 8.75f, FontStyle.Bold);
		this.label5.ForeColor = Color.White;
		this.label5.Location = new Point(139, 108);
		this.label5.Name = "label5";
		this.label5.Size = new Size(59, 15);
		this.label5.TabIndex = 24;
		this.label5.Text = "S I N C E:";
		this.label4.AutoSize = true;
		this.label4.BackColor = Color.Transparent;
		this.label4.Font = new Font("Segoe UI Black", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		this.label4.ForeColor = Color.White;
		this.label4.Location = new Point(123, 91);
		this.label4.Name = "label4";
		this.label4.Size = new Size(98, 17);
		this.label4.TabIndex = 23;
		this.label4.Text = "P R E M I U M";
		this.label3.AutoSize = true;
		this.label3.BackColor = Color.Transparent;
		this.label3.Font = new Font("Segoe UI Black", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		this.label3.ForeColor = Color.White;
		this.label3.Location = new Point(330, 31);
		this.label3.Name = "label3";
		this.label3.Size = new Size(85, 17);
		this.label3.TabIndex = 22;
		this.label3.Text = "L A S T DLC:";
		this.label2.AutoSize = true;
		this.label2.BackColor = Color.Transparent;
		this.label2.Font = new Font("Segoe UI Black", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		this.label2.ForeColor = Color.White;
		this.label2.Location = new Point(123, 31);
		this.label2.Name = "label2";
		this.label2.Size = new Size(82, 17);
		this.label2.TabIndex = 21;
		this.label2.Text = "S T A T U S:";
		this.usersLabel.AutoSize = true;
		this.usersLabel.BackColor = Color.Transparent;
		this.usersLabel.Font = new Font("Segoe UI Black", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
		this.usersLabel.ForeColor = Color.White;
		this.usersLabel.Location = new Point(302, 124);
		this.usersLabel.Name = "usersLabel";
		this.usersLabel.Size = new Size(68, 15);
		this.usersLabel.TabIndex = 20;
		this.usersLabel.Text = "Loading,,,";
		this.uploadLabel.AutoSize = true;
		this.uploadLabel.BackColor = Color.Transparent;
		this.uploadLabel.Cursor = Cursors.VSplit;
		this.uploadLabel.Font = new Font("Segoe UI", 8.25f, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
		this.uploadLabel.ForeColor = SystemColors.ControlLight;
		this.uploadLabel.Location = new Point(36, 126);
		this.uploadLabel.Name = "uploadLabel";
		this.uploadLabel.Size = new Size(45, 13);
		this.uploadLabel.TabIndex = 19;
		this.uploadLabel.Text = "Upload";
		this.uploadLabel.Click += this.uploadLabel_Click;
		this.profilePicture.BackColor = Color.Transparent;
		this.profilePicture.Image = (Image)componentResourceManager.GetObject("profilePicture.Image");
		this.profilePicture.Location = new Point(12, 31);
		this.profilePicture.Name = "profilePicture";
		this.profilePicture.ShadowDecoration.Mode = Siticone.UI.WinForms.Enums.ShadowMode.Circle;
		this.profilePicture.ShadowDecoration.Parent = this.profilePicture;
		this.profilePicture.Size = new Size(93, 92);
		this.profilePicture.SizeMode = PictureBoxSizeMode.StretchImage;
		this.profilePicture.TabIndex = 18;
		this.profilePicture.TabStop = false;
		this.panelTemp.BackColor = Color.Transparent;
		this.panelTemp.BorderRadius = 10;
		this.panelTemp.Controls.Add(this.tempLabel);
		this.panelTemp.Controls.Add(this.levelSpooferOpen);
		this.panelTemp.Controls.Add(this.spoofBloodweb);
		this.panelTemp.Controls.Add(this.igniteUnlocker);
		this.panelTemp.Controls.Add(this.onlyDLCignite);
		this.panelTemp.Controls.Add(this.localMarketOpen);
		this.panelTemp.Controls.Add(this.tempInjectorOpen);
		this.panelTemp.Controls.Add(this.currenciesOpen);
		this.panelTemp.Controls.Add(this.orSpecify);
		this.panelTemp.FillColor = Color.FromArgb(64, 64, 64);
		this.panelTemp.FillColor2 = Color.DarkGray;
		this.panelTemp.Location = new Point(24, 246);
		this.panelTemp.Name = "panelTemp";
		this.panelTemp.ShadowDecoration.Parent = this.panelTemp;
		this.panelTemp.Size = new Size(426, 138);
		this.panelTemp.TabIndex = 36;
		this.tempLabel.AutoSize = true;
		this.tempLabel.Font = new Font("Segoe UI", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		this.tempLabel.ForeColor = Color.White;
		this.tempLabel.Location = new Point(187, 5);
		this.tempLabel.Name = "tempLabel";
		this.tempLabel.Size = new Size(55, 17);
		this.tempLabel.TabIndex = 34;
		this.tempLabel.Text = "T E M P";
		this.siticoneGradientPanel2.BorderRadius = 12;
		this.siticoneGradientPanel2.Controls.Add(this.bootJesus);
		this.siticoneGradientPanel2.Controls.Add(this.label10);
		this.siticoneGradientPanel2.Controls.Add(this.bloodpointsOpen);
		this.siticoneGradientPanel2.Controls.Add(this.rankChanger);
		this.siticoneGradientPanel2.FillColor = Color.Gray;
		this.siticoneGradientPanel2.FillColor2 = Color.FromArgb(64, 64, 64);
		this.siticoneGradientPanel2.Location = new Point(262, 387);
		this.siticoneGradientPanel2.Name = "siticoneGradientPanel2";
		this.siticoneGradientPanel2.ShadowDecoration.Parent = this.siticoneGradientPanel2;
		this.siticoneGradientPanel2.Size = new Size(283, 76);
		this.siticoneGradientPanel2.TabIndex = 37;
		this.bootJesus.Animated = true;
		this.bootJesus.AutoRoundedCorners = true;
		this.bootJesus.BackColor = Color.Transparent;
		this.bootJesus.BorderColor = Color.Transparent;
		this.bootJesus.BorderRadius = 22;
		this.bootJesus.CheckedState.Parent = this.bootJesus;
		this.bootJesus.Cursor = Cursors.Cross;
		this.bootJesus.CustomImages.Parent = this.bootJesus;
		this.bootJesus.FillColor = Color.FromArgb(0, 0, 64);
		this.bootJesus.FillColor2 = Color.FromArgb(64, 0, 64);
		this.bootJesus.Font = new Font("Microsoft Sans Serif", 12.75f, FontStyle.Bold);
		this.bootJesus.ForeColor = Color.White;
		this.bootJesus.HoverState.Parent = this.bootJesus;
		this.bootJesus.Location = new Point(189, 22);
		this.bootJesus.Name = "bootJesus";
		this.bootJesus.ShadowDecoration.Parent = this.bootJesus;
		this.bootJesus.Size = new Size(91, 47);
		this.bootJesus.TabIndex = 36;
		this.bootJesus.Text = "Jesus Configs";
		this.bootJesus.Click += this.bootJesus_Click;
		this.label10.AutoSize = true;
		this.label10.BackColor = Color.Transparent;
		this.label10.Font = new Font("Segoe UI", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		this.label10.ForeColor = Color.White;
		this.label10.Location = new Point(117, 2);
		this.label10.Name = "label10";
		this.label10.Size = new Size(68, 17);
		this.label10.TabIndex = 35;
		this.label10.Text = "P E R M A";
		this.betaTrigger.Animated = true;
		this.betaTrigger.AutoRoundedCorners = true;
		this.betaTrigger.BackColor = Color.Transparent;
		this.betaTrigger.BorderColor = Color.Transparent;
		this.betaTrigger.BorderRadius = 22;
		this.betaTrigger.CheckedState.Parent = this.betaTrigger;
		this.betaTrigger.Cursor = Cursors.Cross;
		this.betaTrigger.CustomImages.Parent = this.betaTrigger;
		this.betaTrigger.FillColor = Color.FromArgb(0, 0, 64);
		this.betaTrigger.FillColor2 = Color.FromArgb(64, 0, 64);
		this.betaTrigger.Font = new Font("Microsoft Sans Serif", 12.75f, FontStyle.Bold);
		this.betaTrigger.ForeColor = Color.White;
		this.betaTrigger.HoverState.Parent = this.betaTrigger;
		this.betaTrigger.Location = new Point(456, 296);
		this.betaTrigger.Name = "betaTrigger";
		this.betaTrigger.ShadowDecoration.Parent = this.betaTrigger;
		this.betaTrigger.Size = new Size(91, 47);
		this.betaTrigger.TabIndex = 38;
		this.betaTrigger.Text = "Beta Features";
		this.betaTrigger.Click += this.betaTrigger_Click;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		this.BackColor = Color.Black;
		this.BackgroundImage = (Image)componentResourceManager.GetObject("$this.BackgroundImage");
		this.BackgroundImageLayout = ImageLayout.Stretch;
		base.ClientSize = new Size(780, 481);
		base.Controls.Add(this.betaTrigger);
		base.Controls.Add(this.siticoneGradientPanel2);
		base.Controls.Add(this.panelTemp);
		base.Controls.Add(this.safetyKill);
		base.Controls.Add(this.siticoneGradientPanel1);
		base.Controls.Add(this.publicSession);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.discordRPC);
		base.Controls.Add(this.guna2GradientTileButton1);
		base.Controls.Add(this.whisperLabel);
		base.Controls.Add(this.drag);
		base.Controls.Add(this.minimizeDash);
		base.Controls.Add(this.closeDash);
		base.Controls.Add(this.gcLabel);
		base.Controls.Add(this.premiumLogo);
		this.DoubleBuffered = true;
		base.FormBorderStyle = FormBorderStyle.None;
		base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		base.Name = "Dashboard";
		base.Opacity = 0.99;
		base.StartPosition = FormStartPosition.CenterScreen;
		this.Text = "Dashboard";
		base.FormClosing += this.Dashboard_FormClosing;
		this.siticoneGradientPanel1.ResumeLayout(false);
		this.siticoneGradientPanel1.PerformLayout();
		this.panelTemp.ResumeLayout(false);
		this.panelTemp.PerformLayout();
		this.siticoneGradientPanel2.ResumeLayout(false);
		this.siticoneGradientPanel2.PerformLayout();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
