using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace GhostAuth;

internal class OnProgramStart
{
	public static string AID;

	public static string Secret;

	public static string Version;

	public static string Name;

	public static string Salt;

	public static void Initialize(string name, string aid, string secret, string version)
	{
		if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(aid) || string.IsNullOrWhiteSpace(secret) || string.IsNullOrWhiteSpace(version))
		{
			MessageBox.Show("Missing APP Parameters; Report to Stalky (GhostAPI: L 140)");
			Process.GetCurrentProcess().Kill();
		}
		AID = aid;
		Secret = secret;
		Version = version;
		Name = name;
		string[] array = new string[0];
		using WebClient webClient = new WebClient();
		try
		{
			webClient.Proxy = null;
			Security.Start();
			array = Encryption.DecryptService(Encoding.Default.GetString(webClient.UploadValues(Constants.ApiUrl, new NameValueCollection
			{
				["token"] = Encryption.EncryptService(Constants.Token),
				["timestamp"] = Encryption.EncryptService(DateTime.Now.ToString()),
				["aid"] = Encryption.APIService(AID),
				["session_id"] = Constants.IV,
				["api_id"] = Constants.APIENCRYPTSALT,
				["api_key"] = Constants.APIENCRYPTKEY,
				["session_key"] = Constants.Key,
				["secret"] = Encryption.APIService(Secret),
				["type"] = Encryption.APIService("start")
			}))).Split("|".ToCharArray());
			if (Security.MaliciousCheck(array[1]))
			{
				MessageBox.Show("GhostAuth: Malicious Activity! (L 170)", Name);
				Process.GetCurrentProcess().Kill();
			}
			if (Constants.Breached)
			{
				MessageBox.Show("GhostAuth: Malicious Activity! (L 175)", Name);
				Process.GetCurrentProcess().Kill();
			}
			if (array[0] != Constants.Token)
			{
				MessageBox.Show("GhostAuth: Triggered a Security Error! (L 180)");
				Process.GetCurrentProcess().Kill();
			}
			switch (array[2])
			{
			case "success":
				Constants.Initialized = true;
				if (array[3] == "Enabled")
				{
					ApplicationSettings.Status = true;
				}
				if (array[4] == "Enabled")
				{
					ApplicationSettings.DeveloperMode = true;
				}
				ApplicationSettings.Hash = array[5];
				ApplicationSettings.Version = array[6];
				ApplicationSettings.Update_Link = array[7];
				if (array[8] == "Enabled")
				{
					ApplicationSettings.Freemode = true;
				}
				if (array[9] == "Enabled")
				{
					ApplicationSettings.Login = true;
				}
				ApplicationSettings.Name = array[10];
				if (array[11] == "Enabled")
				{
					ApplicationSettings.Register = true;
				}
				ApplicationSettings.TotalUsers = array[13];
				if (ApplicationSettings.DeveloperMode)
				{
					MessageBox.Show("GhostDev Mode active! If you are a normal user ignore this (L 203)");
					File.Create(Environment.CurrentDirectory + "/integrity.log").Close();
					string contents = Security.Integrity(Process.GetCurrentProcess().MainModule.FileName);
					File.WriteAllText(Environment.CurrentDirectory + "/integrity.log", contents);
					MessageBox.Show("GhostDev: Integrity Validated and Provided");
				}
				else
				{
					if (array[12] == "Enabled" && ApplicationSettings.Hash != Security.Integrity(Process.GetCurrentProcess().MainModule.FileName))
					{
						MessageBox.Show("Failed to verify integrity! Maybe try re-downloading? (L 215)");
						Process.GetCurrentProcess().Kill();
					}
					if (ApplicationSettings.Version != Version)
					{
						MessageBox.Show("Update " + ApplicationSettings.Version + " available, redirecting to update! (L 221)");
						Process.Start(ApplicationSettings.Update_Link);
						Process.GetCurrentProcess().Kill();
					}
				}
				if (!ApplicationSettings.Status)
				{
					MessageBox.Show("Premium seems to have been disabled! You can use Free edition meanwhile (L 229)");
					Process.GetCurrentProcess().Kill();
				}
				break;
			case "binderror":
				MessageBox.Show(Encryption.Decode("RmFpbGVkIHRvIGJpbmQgdG8gc2VydmVyLCBjaGVjayB5b3VyIEFJRCAmIFNlY3JldCBpbiB5b3VyIGNvZGUh"));
				Process.GetCurrentProcess().Kill();
				return;
			case "banned":
				MessageBox.Show("GhostAuth: Application seems to be banned!" + Environment.NewLine + "Report to Stalky please (L 238)");
				Process.GetCurrentProcess().Kill();
				return;
			}
			Security.End();
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
			Process.GetCurrentProcess().Kill();
		}
	}
}
