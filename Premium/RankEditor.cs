using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using GhostAuth;
using Guna.UI2.WinForms;
using Newtonsoft.Json;
using RestSharp;
using Siticone.UI.WinForms;

namespace Premium
{
	// Token: 0x02000028 RID: 40
	public class RankEditor : Form
	{
		// Token: 0x06000101 RID: 257
		[DllImport("Gdi32.dll")]
		private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

		// Token: 0x06000102 RID: 258 RVA: 0x00012734 File Offset: 0x00010934
		public RankEditor()
		{
			this.InitializeComponent();
			string text = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
			char[] array = new char[8];
			Random random = new Random();
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = text[random.Next(text.Length)];
			}
			string text2 = new string(array);
			this.Text = text2;
			base.Region = Region.FromHrgn(RankEditor.CreateRoundRectRgn(0, 0, base.Width, base.Height, 15, 15));
		}

		// Token: 0x06000103 RID: 259 RVA: 0x00002486 File Offset: 0x00000686
		private void label1_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000104 RID: 260 RVA: 0x000127C4 File Offset: 0x000109C4
		private void add2slasher_Click(object sender, EventArgs e)
		{
			API.Log(User.Username, "2 Pips Granted; Slasher");
			RestClient restClient = new RestClient("https://steam.live.bhvrdbd.com/api/v1/ranks/pips");
			restClient.Timeout = -1;
			RestRequest restRequest = new RestRequest(Method.PUT);
			restRequest.AddHeader("Content-Type", "application/json; charset=utf-8");
			restClient.UserAgent = "DeadByDaylight/++DeadByDaylight+Live-CL-404154 Windows/10.0.19042.1.768.64bit";
			restRequest.AddHeader("Content-Length", "53");
			restRequest.AddHeader("x-kraken-client-version", "4.5.0");
			restRequest.AddHeader("x-kraken-client-provider", "steam");
			restRequest.AddHeader("x-kraken-client-platform", "steam");
			restRequest.AddCookie("bhvrSession", Dashboard.bhvrSession);
			restRequest.AddHeader("Accept-Encoding", "deflate, gzip");
			restRequest.AddHeader("Accept", "*/*");
			restRequest.AddHeader("Host", "steam.live.bhvrdbd.com");
			string value = "{\"survivorPips\":0,\"killerPips\":2,\"forceReset\":false}";
			restRequest.AddParameter("application/json; charset=utf-8", value, ParameterType.RequestBody);
			string content = restClient.Execute(restRequest).Content;
			if (content.Contains("not"))
			{
				MessageBox.Show("The provided bhvrSession is not valid, please do not launch your game if you were doing so and generate a new session");
				API.Log(User.Username, "Invalid bhvrSession at 2 Pips Granted (Slasher)");
			}
			JsonConvert.DeserializeObject<RankList>(content);
			this.slasherPipsLabel.Text = RankList.slasherPips;
			this.camperPipsLabel.Text = RankList.camperPips;
		}

		// Token: 0x06000105 RID: 261 RVA: 0x00012970 File Offset: 0x00010B70
		private void remove2slasher_Click(object sender, EventArgs e)
		{
			API.Log(User.Username, "2 Pips Removed; Slasher");
			RestClient restClient = new RestClient("https://steam.live.bhvrdbd.com/api/v1/ranks/pips");
			restClient.Timeout = -1;
			RestRequest restRequest = new RestRequest(Method.PUT);
			restRequest.AddHeader("Content-Type", "application/json; charset=utf-8");
			restClient.UserAgent = "DeadByDaylight/++DeadByDaylight+Live-CL-404154 Windows/10.0.19042.1.768.64bit";
			restRequest.AddHeader("Content-Length", "53");
			restRequest.AddHeader("x-kraken-client-version", "4.5.0");
			restRequest.AddHeader("x-kraken-client-provider", "steam");
			restRequest.AddHeader("x-kraken-client-platform", "steam");
			restRequest.AddCookie("bhvrSession", Dashboard.bhvrSession);
			restRequest.AddHeader("Accept-Encoding", "deflate, gzip");
			restRequest.AddHeader("Accept", "*/*");
			restRequest.AddHeader("Host", "steam.live.bhvrdbd.com");
			string value = "{\"survivorPips\":0,\"killerPips\":-2,\"forceReset\":false}";
			restRequest.AddParameter("application/json; charset=utf-8", value, ParameterType.RequestBody);
			string content = restClient.Execute(restRequest).Content;
			if (content.Contains("not"))
			{
				MessageBox.Show("The provided bhvrSession is not valid, please do not launch your game if you were doing so and generate a new session");
				API.Log(User.Username, "Invalid bhvrSession at 2 Pips Removed (Slasher)");
			}
			JsonConvert.DeserializeObject<RankList>(content);
			this.slasherPipsLabel.Text = RankList.slasherPips;
			this.camperPipsLabel.Text = RankList.camperPips;
		}

		// Token: 0x06000106 RID: 262 RVA: 0x00012B1C File Offset: 0x00010D1C
		private void add2camper_Click(object sender, EventArgs e)
		{
			API.Log(User.Username, "2 Pips Granted; Camper");
			RestClient restClient = new RestClient("https://steam.live.bhvrdbd.com/api/v1/ranks/pips");
			restClient.Timeout = -1;
			RestRequest restRequest = new RestRequest(Method.PUT);
			restRequest.AddHeader("Content-Type", "application/json; charset=utf-8");
			restClient.UserAgent = "DeadByDaylight/++DeadByDaylight+Live-CL-404154 Windows/10.0.19042.1.768.64bit";
			restRequest.AddHeader("Content-Length", "53");
			restRequest.AddHeader("x-kraken-client-version", "4.5.0");
			restRequest.AddHeader("x-kraken-client-provider", "steam");
			restRequest.AddHeader("x-kraken-client-platform", "steam");
			restRequest.AddCookie("bhvrSession", Dashboard.bhvrSession);
			restRequest.AddHeader("Accept-Encoding", "deflate, gzip");
			restRequest.AddHeader("Accept", "*/*");
			restRequest.AddHeader("Host", "steam.live.bhvrdbd.com");
			string value = "{\"survivorPips\":2,\"killerPips\":0,\"forceReset\":false}";
			restRequest.AddParameter("application/json; charset=utf-8", value, ParameterType.RequestBody);
			string content = restClient.Execute(restRequest).Content;
			if (content.Contains("not"))
			{
				MessageBox.Show("The provided bhvrSession is not valid, please do not launch your game if you were doing so and generate a new session");
				API.Log(User.Username, "Invalid bhvrSession at 2 Pips Granted (Camper)");
			}
			JsonConvert.DeserializeObject<RankList>(content);
			this.slasherPipsLabel.Text = RankList.slasherPips;
			this.camperPipsLabel.Text = RankList.camperPips;
		}

		// Token: 0x06000107 RID: 263 RVA: 0x00012CC8 File Offset: 0x00010EC8
		private void remove2camper_Click(object sender, EventArgs e)
		{
			API.Log(User.Username, "2 Pips Removed; Camper");
			RestClient restClient = new RestClient("https://steam.live.bhvrdbd.com/api/v1/ranks/pips");
			restClient.Timeout = -1;
			RestRequest restRequest = new RestRequest(Method.PUT);
			restRequest.AddHeader("Content-Type", "application/json; charset=utf-8");
			restClient.UserAgent = "DeadByDaylight/++DeadByDaylight+Live-CL-404154 Windows/10.0.19042.1.768.64bit";
			restRequest.AddHeader("Content-Length", "53");
			restRequest.AddHeader("x-kraken-client-version", "4.5.0");
			restRequest.AddHeader("x-kraken-client-provider", "steam");
			restRequest.AddHeader("x-kraken-client-platform", "steam");
			restRequest.AddCookie("bhvrSession", Dashboard.bhvrSession);
			restRequest.AddHeader("Accept-Encoding", "deflate, gzip");
			restRequest.AddHeader("Accept", "*/*");
			restRequest.AddHeader("Host", "steam.live.bhvrdbd.com");
			string value = "{\"survivorPips\":-2,\"killerPips\":0,\"forceReset\":false}";
			restRequest.AddParameter("application/json; charset=utf-8", value, ParameterType.RequestBody);
			string content = restClient.Execute(restRequest).Content;
			if (content.Contains("not"))
			{
				MessageBox.Show("The provided bhvrSession is not valid, please do not launch your game if you were doing so and generate a new session");
				API.Log(User.Username, "Invalid bhvrSession at 2 Pips Removed (Camper)");
			}
			JsonConvert.DeserializeObject<RankList>(content);
			this.slasherPipsLabel.Text = RankList.slasherPips;
			this.camperPipsLabel.Text = RankList.camperPips;
		}

		// Token: 0x06000108 RID: 264 RVA: 0x00012E74 File Offset: 0x00011074
		private void resetBoth_Click(object sender, EventArgs e)
		{
			API.Log(User.Username, "Rank Reset Requested");
			RestClient restClient = new RestClient("https://steam.live.bhvrdbd.com/api/v1/ranks/pips");
			restClient.Timeout = -1;
			RestRequest restRequest = new RestRequest(Method.PUT);
			restRequest.AddHeader("Content-Type", "application/json; charset=utf-8");
			restClient.UserAgent = "DeadByDaylight/++DeadByDaylight+Live-CL-404154 Windows/10.0.19042.1.768.64bit";
			restRequest.AddHeader("Content-Length", "53");
			restRequest.AddHeader("x-kraken-client-version", "4.5.0");
			restRequest.AddHeader("x-kraken-client-provider", "steam");
			restRequest.AddHeader("x-kraken-client-platform", "steam");
			restRequest.AddCookie("bhvrSession", Dashboard.bhvrSession);
			restRequest.AddHeader("Accept-Encoding", "deflate, gzip");
			restRequest.AddHeader("Accept", "*/*");
			restRequest.AddHeader("Host", "steam.live.bhvrdbd.com");
			string value = "{\"survivorPips\":-2,\"killerPips\":0,\"forceReset\":false}";
			restRequest.AddParameter("application/json; charset=utf-8", value, ParameterType.RequestBody);
			string content = restClient.Execute(restRequest).Content;
			if (content.Contains("not"))
			{
				MessageBox.Show("The provided bhvrSession is not valid, please do not launch your game if you were doing so and generate a new session");
				API.Log(User.Username, "Invalid bhvrSession at Rank Reset");
			}
			MessageBox.Show("This may not work for every account!");
			JsonConvert.DeserializeObject<RankList>(content);
			this.slasherPipsLabel.Text = RankList.slasherPips;
			this.camperPipsLabel.Text = RankList.camperPips;
		}

		// Token: 0x06000109 RID: 265 RVA: 0x00002B27 File Offset: 0x00000D27
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600010A RID: 266 RVA: 0x00013030 File Offset: 0x00011230
		private void InitializeComponent()
		{
			this.components = new Container();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(RankEditor));
			this.RankTitle = new Label();
			this.closeRank = new SiticoneControlBox();
			this.minimizeRank = new SiticoneControlBox();
			this.slasherIcon = new PictureBox();
			this.add2slasher = new Guna2GradientTileButton();
			this.remove2slasher = new Guna2GradientTileButton();
			this.remove2camper = new Guna2GradientTileButton();
			this.add2camper = new Guna2GradientTileButton();
			this.resetBoth = new Guna2GradientTileButton();
			this.camperIcon = new PictureBox();
			this.camperPipsLabel = new Label();
			this.pipsLabel = new Label();
			this.slasherPipsLabel = new Label();
			this.pipsLabel2 = new Label();
			this.rankStatus = new Label();
			this.dragButton = new SiticoneRoundedButton();
			this.dragDriver = new SiticoneDragControl(this.components);
			((ISupportInitialize)this.slasherIcon).BeginInit();
			((ISupportInitialize)this.camperIcon).BeginInit();
			base.SuspendLayout();
			this.RankTitle.AutoSize = true;
			this.RankTitle.BackColor = Color.Transparent;
			this.RankTitle.Font = new Font("Meiryo UI", 14.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.RankTitle.ForeColor = Color.White;
			this.RankTitle.Location = new Point(12, 12);
			this.RankTitle.Name = "RankTitle";
			this.RankTitle.Size = new Size(152, 24);
			this.RankTitle.TabIndex = 0;
			this.RankTitle.Text = "Rank Changer";
			this.closeRank.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.closeRank.BackColor = Color.Transparent;
			this.closeRank.ControlBoxStyle =  Siticone.UI.WinForms.Enums.ControlBoxStyle.Windows10;
			this.closeRank.FillColor = Color.Transparent;
			this.closeRank.HoveredState.Parent = this.closeRank;
			this.closeRank.IconColor = Color.DarkViolet;
			this.closeRank.Location = new Point(658, 12);
			this.closeRank.Name = "closeRank";
			this.closeRank.PressedColor = Color.Red;
			this.closeRank.ShadowDecoration.Parent = this.closeRank;
			this.closeRank.Size = new Size(43, 35);
			this.closeRank.TabIndex = 1;
			this.minimizeRank.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.minimizeRank.BackColor = Color.Transparent;
			this.minimizeRank.ControlBoxStyle =  Siticone.UI.WinForms.Enums.ControlBoxStyle.Windows10;
			this.minimizeRank.ControlBoxType = 0;
			this.minimizeRank.FillColor = Color.Transparent;
			this.minimizeRank.HoveredState.Parent = this.minimizeRank;
			this.minimizeRank.IconColor = Color.DarkViolet;
			this.minimizeRank.Location = new Point(609, 12);
			this.minimizeRank.Name = "minimizeRank";
			this.minimizeRank.PressedColor = Color.Red;
			this.minimizeRank.ShadowDecoration.Parent = this.minimizeRank;
			this.minimizeRank.Size = new Size(43, 35);
			this.minimizeRank.TabIndex = 2;
			this.slasherIcon.Image = (Image)componentResourceManager.GetObject("slasherIcon.Image");
			this.slasherIcon.Location = new Point(202, 59);
			this.slasherIcon.Name = "slasherIcon";
			this.slasherIcon.Size = new Size(90, 81);
			this.slasherIcon.SizeMode = PictureBoxSizeMode.Zoom;
			this.slasherIcon.TabIndex = 3;
			this.slasherIcon.TabStop = false;
			this.add2slasher.Animated = true;
			this.add2slasher.AutoRoundedCorners = true;
			this.add2slasher.BorderRadius = 21;
			this.add2slasher.CheckedState.Parent = this.add2slasher;
			this.add2slasher.CustomImages.Parent = this.add2slasher;
			this.add2slasher.FillColor = Color.Indigo;
			this.add2slasher.FillColor2 = Color.DarkSlateBlue;
			this.add2slasher.Font = new Font("Meiryo UI", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.add2slasher.ForeColor = Color.White;
			this.add2slasher.HoverState.Parent = this.add2slasher;
			this.add2slasher.Location = new Point(188, 157);
			this.add2slasher.Name = "add2slasher";
			this.add2slasher.ShadowDecoration.Parent = this.add2slasher;
			this.add2slasher.Size = new Size(117, 44);
			this.add2slasher.TabIndex = 4;
			this.add2slasher.Text = "+2 Pips";
			this.add2slasher.Click += this.add2slasher_Click;
			this.remove2slasher.Animated = true;
			this.remove2slasher.AutoRoundedCorners = true;
			this.remove2slasher.BorderRadius = 21;
			this.remove2slasher.CheckedState.Parent = this.remove2slasher;
			this.remove2slasher.CustomImages.Parent = this.remove2slasher;
			this.remove2slasher.FillColor = Color.Indigo;
			this.remove2slasher.FillColor2 = Color.DarkSlateBlue;
			this.remove2slasher.Font = new Font("Meiryo UI", 11.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.remove2slasher.ForeColor = Color.White;
			this.remove2slasher.HoverState.Parent = this.remove2slasher;
			this.remove2slasher.Location = new Point(188, 218);
			this.remove2slasher.Name = "remove2slasher";
			this.remove2slasher.ShadowDecoration.Parent = this.remove2slasher;
			this.remove2slasher.Size = new Size(117, 44);
			this.remove2slasher.TabIndex = 5;
			this.remove2slasher.Text = "-2 Pips";
			this.remove2slasher.Click += this.remove2slasher_Click;
			this.remove2camper.Animated = true;
			this.remove2camper.AutoRoundedCorners = true;
			this.remove2camper.BorderRadius = 21;
			this.remove2camper.CheckedState.Parent = this.remove2camper;
			this.remove2camper.CustomImages.Parent = this.remove2camper;
			this.remove2camper.FillColor = Color.Indigo;
			this.remove2camper.FillColor2 = Color.DarkSlateBlue;
			this.remove2camper.Font = new Font("Meiryo UI", 11.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.remove2camper.ForeColor = Color.White;
			this.remove2camper.HoverState.Parent = this.remove2camper;
			this.remove2camper.Location = new Point(397, 218);
			this.remove2camper.Name = "remove2camper";
			this.remove2camper.ShadowDecoration.Parent = this.remove2camper;
			this.remove2camper.Size = new Size(117, 44);
			this.remove2camper.TabIndex = 6;
			this.remove2camper.Text = "-2 Pips";
			this.remove2camper.Click += this.remove2camper_Click;
			this.add2camper.Animated = true;
			this.add2camper.AutoRoundedCorners = true;
			this.add2camper.BorderRadius = 21;
			this.add2camper.CheckedState.Parent = this.add2camper;
			this.add2camper.CustomImages.Parent = this.add2camper;
			this.add2camper.FillColor = Color.Indigo;
			this.add2camper.FillColor2 = Color.DarkSlateBlue;
			this.add2camper.Font = new Font("Meiryo UI", 11.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.add2camper.ForeColor = Color.White;
			this.add2camper.HoverState.Parent = this.add2camper;
			this.add2camper.Location = new Point(397, 157);
			this.add2camper.Name = "add2camper";
			this.add2camper.ShadowDecoration.Parent = this.add2camper;
			this.add2camper.Size = new Size(117, 44);
			this.add2camper.TabIndex = 7;
			this.add2camper.Text = "+2 Pips";
			this.add2camper.Click += this.add2camper_Click;
			this.resetBoth.Animated = true;
			this.resetBoth.AutoRoundedCorners = true;
			this.resetBoth.BackColor = Color.Transparent;
			this.resetBoth.BorderColor = Color.Transparent;
			this.resetBoth.BorderRadius = 21;
			this.resetBoth.CheckedState.Parent = this.resetBoth;
			this.resetBoth.CustomImages.Parent = this.resetBoth;
			this.resetBoth.FillColor = Color.Indigo;
			this.resetBoth.FillColor2 = Color.MediumSlateBlue;
			this.resetBoth.Font = new Font("Meiryo UI", 11.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.resetBoth.ForeColor = Color.White;
			this.resetBoth.HoverState.Parent = this.resetBoth;
			this.resetBoth.Location = new Point(301, 12);
			this.resetBoth.Name = "resetBoth";
			this.resetBoth.ShadowDecoration.Parent = this.resetBoth;
			this.resetBoth.Size = new Size(117, 44);
			this.resetBoth.TabIndex = 8;
			this.resetBoth.Text = "Reset Ranks";
			this.resetBoth.Click += this.resetBoth_Click;
			this.camperIcon.Image = (Image)componentResourceManager.GetObject("camperIcon.Image");
			this.camperIcon.Location = new Point(408, 59);
			this.camperIcon.Name = "camperIcon";
			this.camperIcon.Size = new Size(90, 81);
			this.camperIcon.SizeMode = PictureBoxSizeMode.Zoom;
			this.camperIcon.TabIndex = 9;
			this.camperIcon.TabStop = false;
			this.camperPipsLabel.AutoSize = true;
			this.camperPipsLabel.Font = new Font("Meiryo UI", 26.25f, FontStyle.Bold);
			this.camperPipsLabel.ForeColor = Color.White;
			this.camperPipsLabel.Location = new Point(511, 276);
			this.camperPipsLabel.Name = "camperPipsLabel";
			this.camperPipsLabel.Size = new Size(40, 44);
			this.camperPipsLabel.TabIndex = 10;
			this.camperPipsLabel.Text = "?";
			this.pipsLabel.AutoSize = true;
			this.pipsLabel.Font = new Font("Meiryo UI", 10f, FontStyle.Bold);
			this.pipsLabel.ForeColor = Color.White;
			this.pipsLabel.Location = new Point(476, 285);
			this.pipsLabel.Name = "pipsLabel";
			this.pipsLabel.Size = new Size(38, 18);
			this.pipsLabel.TabIndex = 11;
			this.pipsLabel.Text = "pips";
			this.slasherPipsLabel.AutoSize = true;
			this.slasherPipsLabel.Font = new Font("Meiryo UI", 26.25f, FontStyle.Bold);
			this.slasherPipsLabel.ForeColor = Color.White;
			this.slasherPipsLabel.Location = new Point(114, 276);
			this.slasherPipsLabel.Name = "slasherPipsLabel";
			this.slasherPipsLabel.Size = new Size(40, 44);
			this.slasherPipsLabel.TabIndex = 12;
			this.slasherPipsLabel.Text = "?";
			this.slasherPipsLabel.Click += this.label1_Click;
			this.pipsLabel2.AutoSize = true;
			this.pipsLabel2.Font = new Font("Meiryo UI", 10f, FontStyle.Bold);
			this.pipsLabel2.ForeColor = Color.White;
			this.pipsLabel2.Location = new Point(174, 285);
			this.pipsLabel2.Name = "pipsLabel2";
			this.pipsLabel2.Size = new Size(38, 18);
			this.pipsLabel2.TabIndex = 13;
			this.pipsLabel2.Text = "pips";
			this.rankStatus.AutoSize = true;
			this.rankStatus.Font = new Font("Meiryo UI", 8.25f, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
			this.rankStatus.ForeColor = Color.White;
			this.rankStatus.Location = new Point(317, 289);
			this.rankStatus.Name = "rankStatus";
			this.rankStatus.Size = new Size(92, 14);
			this.rankStatus.TabIndex = 14;
			this.rankStatus.Text = "Status: Ready!";
			this.dragButton.BackColor = Color.Transparent;
			this.dragButton.BorderColor = Color.Transparent;
			this.dragButton.CheckedState.Parent = this.dragButton;
			this.dragButton.CustomImages.Parent = this.dragButton;
			this.dragButton.FillColor = Color.Transparent;
			this.dragButton.Font = new Font("Meiryo UI", 10.75f, FontStyle.Bold);
			this.dragButton.ForeColor = Color.White;
			this.dragButton.HoveredState.Parent = this.dragButton;
			this.dragButton.Location = new Point(609, 256);
			this.dragButton.Name = "dragButton";
			this.dragButton.ShadowDecoration.Parent = this.dragButton;
			this.dragButton.Size = new Size(134, 96);
			this.dragButton.TabIndex = 15;
			this.dragButton.Text = "=";
			this.dragDriver.TargetControl = this.dragButton;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = Color.Black;
			this.BackgroundImage = (Image)componentResourceManager.GetObject("$this.BackgroundImage");
			this.BackgroundImageLayout = ImageLayout.Stretch;
			base.ClientSize = new Size(713, 329);
			base.Controls.Add(this.dragButton);
			base.Controls.Add(this.rankStatus);
			base.Controls.Add(this.pipsLabel2);
			base.Controls.Add(this.slasherPipsLabel);
			base.Controls.Add(this.pipsLabel);
			base.Controls.Add(this.camperPipsLabel);
			base.Controls.Add(this.camperIcon);
			base.Controls.Add(this.resetBoth);
			base.Controls.Add(this.add2camper);
			base.Controls.Add(this.remove2camper);
			base.Controls.Add(this.remove2slasher);
			base.Controls.Add(this.add2slasher);
			base.Controls.Add(this.slasherIcon);
			base.Controls.Add(this.minimizeRank);
			base.Controls.Add(this.closeRank);
			base.Controls.Add(this.RankTitle);
			this.DoubleBuffered = true;
			base.FormBorderStyle = FormBorderStyle.None;
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "RankEditor";
			this.Text = "Corruption!";
			((ISupportInitialize)this.slasherIcon).EndInit();
			((ISupportInitialize)this.camperIcon).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000132 RID: 306
		private IContainer components;

		// Token: 0x04000133 RID: 307
		private Label RankTitle;

		// Token: 0x04000134 RID: 308
		private SiticoneControlBox closeRank;

		// Token: 0x04000135 RID: 309
		private SiticoneControlBox minimizeRank;

		// Token: 0x04000136 RID: 310
		private PictureBox slasherIcon;

		// Token: 0x04000137 RID: 311
		private Guna2GradientTileButton add2slasher;

		// Token: 0x04000138 RID: 312
		private Guna2GradientTileButton remove2slasher;

		// Token: 0x04000139 RID: 313
		private Guna2GradientTileButton remove2camper;

		// Token: 0x0400013A RID: 314
		private Guna2GradientTileButton add2camper;

		// Token: 0x0400013B RID: 315
		private Guna2GradientTileButton resetBoth;

		// Token: 0x0400013C RID: 316
		private PictureBox camperIcon;

		// Token: 0x0400013D RID: 317
		private Label camperPipsLabel;

		// Token: 0x0400013E RID: 318
		private Label pipsLabel;

		// Token: 0x0400013F RID: 319
		private Label slasherPipsLabel;

		// Token: 0x04000140 RID: 320
		private Label pipsLabel2;

		// Token: 0x04000141 RID: 321
		private Label rankStatus;

		// Token: 0x04000142 RID: 322
		private SiticoneRoundedButton dragButton;

		// Token: 0x04000143 RID: 323
		private SiticoneDragControl dragDriver;
	}
}
