using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace GhostAuth;

internal class API
{
	public static void Log(string username, string action)
	{
		if (!Constants.Initialized)
		{
			MessageBox.Show("Application has not been initialized! Do that first (L 259)", OnProgramStart.Name);
			Process.GetCurrentProcess().Kill();
		}
		if (string.IsNullOrWhiteSpace(action))
		{
			MessageBox.Show("GhostAuth: Missing log information! (L 264)", ApplicationSettings.Name);
			Process.GetCurrentProcess().Kill();
		}
		_ = new string[0];
		using WebClient webClient = new WebClient();
		try
		{
			Security.Start();
			webClient.Proxy = null;
			Encryption.DecryptService(Encoding.Default.GetString(webClient.UploadValues(Constants.ApiUrl, new NameValueCollection
			{
				["token"] = Encryption.EncryptService(Constants.Token),
				["aid"] = Encryption.APIService(OnProgramStart.AID),
				["username"] = Encryption.APIService(username),
				["pcuser"] = Encryption.APIService(Environment.UserName),
				["session_id"] = Constants.IV,
				["api_id"] = Constants.APIENCRYPTSALT,
				["api_key"] = Constants.APIENCRYPTKEY,
				["data"] = Encryption.APIService(action),
				["session_key"] = Constants.Key,
				["secret"] = Encryption.APIService(OnProgramStart.Secret),
				["type"] = Encryption.APIService("log")
			}))).Split("|".ToCharArray());
			Security.End();
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, OnProgramStart.Name);
			Process.GetCurrentProcess().Kill();
		}
	}

	public static void UploadPic(string username, string path)
	{
		if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(path))
		{
			MessageBox.Show("Your picture's information is not valid. Make sure you are uploading an actual picture!", ApplicationSettings.Name);
			Process.GetCurrentProcess().Kill();
		}
		_ = new string[0];
		using WebClient webClient = new WebClient();
		try
		{
			webClient.Proxy = null;
			Security.Start();
			switch (Encryption.DecryptService(Encoding.Default.GetString(webClient.UploadValues(Constants.ApiUrl, new NameValueCollection
			{
				["token"] = Encryption.EncryptService(Constants.Token),
				["timestamp"] = Encryption.EncryptService(DateTime.Now.ToString()),
				["aid"] = Encryption.APIService(OnProgramStart.AID),
				["username"] = Encryption.APIService(username),
				["picbytes"] = Encryption.APIService(path),
				["session_id"] = Constants.IV,
				["api_id"] = Constants.APIENCRYPTSALT,
				["api_key"] = Constants.APIENCRYPTKEY,
				["session_key"] = Constants.Key,
				["secret"] = Encryption.APIService(OnProgramStart.Secret),
				["type"] = Encryption.APIService("uploadpic")
			}))).Split("|".ToCharArray())[0])
			{
			case "success":
				MessageBox.Show("Your charmy profile picture is up and ready", OnProgramStart.Name);
				Security.End();
				break;
			case "permissions":
				MessageBox.Show("Database Subscription error occured", OnProgramStart.Name);
				Security.End();
				break;
			case "maxsize":
				MessageBox.Show("Image cannot be greater than 1 MB, please use some tool to compress it", OnProgramStart.Name);
				Security.End();
				break;
			case "failed":
				MessageBox.Show("An unknown error occured whilst trying to upload your profile picture", OnProgramStart.Name);
				Security.End();
				break;
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, OnProgramStart.Name);
			Process.GetCurrentProcess().Kill();
		}
	}

	public static bool AIO(string AIO)
	{
		if (AIOLogin(AIO))
		{
			return true;
		}
		if (AIORegister(AIO))
		{
			return true;
		}
		return false;
	}

	public static bool AIOLogin(string AIO)
	{
		if (!Constants.Initialized)
		{
			MessageBox.Show("Aplication has not been Initialized, do that first (L 319)", OnProgramStart.Name);
			Process.GetCurrentProcess().Kill();
		}
		if (string.IsNullOrWhiteSpace(AIO))
		{
			MessageBox.Show("Missing user login information! (L 324)", ApplicationSettings.Name);
			Process.GetCurrentProcess().Kill();
		}
		string[] array = new string[0];
		using WebClient webClient = new WebClient();
		try
		{
			Security.Start();
			webClient.Proxy = null;
			array = Encryption.DecryptService(Encoding.Default.GetString(webClient.UploadValues(Constants.ApiUrl, new NameValueCollection
			{
				["token"] = Encryption.EncryptService(Constants.Token),
				["timestamp"] = Encryption.EncryptService(DateTime.Now.ToString()),
				["aid"] = Encryption.APIService(OnProgramStart.AID),
				["session_id"] = Constants.IV,
				["api_id"] = Constants.APIENCRYPTSALT,
				["api_key"] = Constants.APIENCRYPTKEY,
				["username"] = Encryption.APIService(AIO),
				["password"] = Encryption.APIService(AIO),
				["hwid"] = Encryption.APIService(Constants.HWID()),
				["session_key"] = Constants.Key,
				["secret"] = Encryption.APIService(OnProgramStart.Secret),
				["type"] = Encryption.APIService("login")
			}))).Split("|".ToCharArray());
			if (array[0] != Constants.Token)
			{
				MessageBox.Show("Alarms! A security error has been triggered! (GA L 352)", OnProgramStart.Name);
				Process.GetCurrentProcess().Kill();
			}
			if (Security.MaliciousCheck(array[1]))
			{
				MessageBox.Show("Doctor! Possible Malicious Activity was found (GA L 357)", OnProgramStart.Name);
				Process.GetCurrentProcess().Kill();
			}
			if (Constants.Breached)
			{
				MessageBox.Show("Nurse? Possible Malicious Activity was found! (GA L 362)");
				Process.GetCurrentProcess().Kill();
			}
			switch (array[2])
			{
			case "success":
			{
				Security.End();
				User.ID = array[3];
				User.Username = array[4];
				User.Password = array[5];
				User.Email = array[6];
				User.HWID = array[7];
				User.UserVariable = array[8];
				User.Rank = array[9];
				User.IP = array[10];
				User.Expiry = array[11];
				User.LastLogin = array[12];
				User.RegisterDate = array[13];
				string text = array[14];
				User.ProfilePicture = array[15];
				string[] array2 = text.Split('~');
				for (int i = 0; i < array2.Length; i++)
				{
					string[] array3 = array2[i].Split('^');
					try
					{
						App.Variables.Add(array3[0], array3[1]);
					}
					catch
					{
					}
				}
				return true;
			}
			case "invalid_details":
				Security.End();
				return false;
			case "time_expired":
				MessageBox.Show("F in the chat, your subscription has expired ;(", ApplicationSettings.Name);
				Security.End();
				return false;
			case "hwid_updated":
				MessageBox.Show("A new PC was binded, open GC Premium again! (L 403)", ApplicationSettings.Name);
				Security.End();
				return false;
			case "invalid_hwid":
				MessageBox.Show("Your GhostAccount is binded to another PC, ask for an HWID Reset!", ApplicationSettings.Name);
				Security.End();
				return false;
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, ApplicationSettings.Name);
			Security.End();
			Process.GetCurrentProcess().Kill();
		}
		return false;
	}

	public static bool AIORegister(string AIO)
	{
		if (!Constants.Initialized)
		{
			MessageBox.Show("GC Premium has not been initialized, do that first! (L 426)", OnProgramStart.Name);
			Security.End();
			Process.GetCurrentProcess().Kill();
		}
		if (string.IsNullOrWhiteSpace(AIO))
		{
			MessageBox.Show("Invalid registrar information! Try again! (GAPI L 432)", ApplicationSettings.Name);
			Process.GetCurrentProcess().Kill();
		}
		_ = new string[0];
		using WebClient webClient = new WebClient();
		try
		{
			Security.Start();
			webClient.Proxy = null;
			string[] array = Encryption.DecryptService(Encoding.Default.GetString(webClient.UploadValues(Constants.ApiUrl, new NameValueCollection
			{
				["token"] = Encryption.EncryptService(Constants.Token),
				["timestamp"] = Encryption.EncryptService(DateTime.Now.ToString()),
				["aid"] = Encryption.APIService(OnProgramStart.AID),
				["session_id"] = Constants.IV,
				["api_id"] = Constants.APIENCRYPTSALT,
				["api_key"] = Constants.APIENCRYPTKEY,
				["session_key"] = Constants.Key,
				["secret"] = Encryption.APIService(OnProgramStart.Secret),
				["type"] = Encryption.APIService("register"),
				["username"] = Encryption.APIService(AIO),
				["password"] = Encryption.APIService(AIO),
				["email"] = Encryption.APIService(AIO),
				["license"] = Encryption.APIService(AIO),
				["hwid"] = Encryption.APIService(Constants.HWID())
			}))).Split("|".ToCharArray());
			if (array[0] != Constants.Token)
			{
				MessageBox.Show("Woah Alarms! A security error has been triggered! (GA L 463)", OnProgramStart.Name);
				Security.End();
				Process.GetCurrentProcess().Kill();
			}
			if (Security.MaliciousCheck(array[1]))
			{
				MessageBox.Show("Scientist! We found malicious activity! (GA L 469)", OnProgramStart.Name);
			}
			if (Constants.Breached)
			{
				MessageBox.Show("Surgeon! We encountered some malicious activity! (GA L 473)", OnProgramStart.Name);
				Process.GetCurrentProcess().Kill();
			}
			Security.End();
			string text = array[2];
			if (text == "success")
			{
				return true;
			}
			if (text == "error")
			{
				return false;
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, ApplicationSettings.Name);
			Process.GetCurrentProcess().Kill();
		}
		return false;
	}

	public static bool Login(string username, string password)
	{
		if (!Constants.Initialized)
		{
			MessageBox.Show("GC Premium Login has not been initialized!", OnProgramStart.Name);
			Process.GetCurrentProcess().Kill();
		}
		if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
		{
			MessageBox.Show("Missing user login information! Try again!", ApplicationSettings.Name);
			Process.GetCurrentProcess().Kill();
		}
		string[] array = new string[0];
		using WebClient webClient = new WebClient();
		try
		{
			Security.Start();
			webClient.Proxy = null;
			array = Encryption.DecryptService(Encoding.Default.GetString(webClient.UploadValues(Constants.ApiUrl, new NameValueCollection
			{
				["token"] = Encryption.EncryptService(Constants.Token),
				["timestamp"] = Encryption.EncryptService(DateTime.Now.ToString()),
				["aid"] = Encryption.APIService(OnProgramStart.AID),
				["session_id"] = Constants.IV,
				["api_id"] = Constants.APIENCRYPTSALT,
				["api_key"] = Constants.APIENCRYPTKEY,
				["username"] = Encryption.APIService(username),
				["password"] = Encryption.APIService(password),
				["hwid"] = Encryption.APIService(Constants.HWID()),
				["session_key"] = Constants.Key,
				["secret"] = Encryption.APIService(OnProgramStart.Secret),
				["type"] = Encryption.APIService("login")
			}))).Split("|".ToCharArray());
			if (array[0] != Constants.Token)
			{
				MessageBox.Show("Police! A security error has been triggered! (GA L 531)", OnProgramStart.Name);
				Process.GetCurrentProcess().Kill();
			}
			if (Security.MaliciousCheck(array[1]))
			{
				MessageBox.Show("Hospital! We saw some malicious activity! (GA L 536)", OnProgramStart.Name);
				Process.GetCurrentProcess().Kill();
			}
			if (Constants.Breached)
			{
				MessageBox.Show("Clinic! I found some malicious activity! (GA L 541)", OnProgramStart.Name);
				Process.GetCurrentProcess().Kill();
			}
			switch (array[2])
			{
			case "success":
			{
				User.ID = array[3];
				User.Username = array[4];
				User.Password = array[5];
				User.Email = array[6];
				User.HWID = array[7];
				User.UserVariable = array[8];
				User.Rank = array[9];
				User.IP = array[10];
				User.Expiry = array[11];
				User.LastLogin = array[12];
				User.RegisterDate = array[13];
				string text = array[14];
				User.ProfilePicture = array[15];
				string[] array2 = text.Split('~');
				for (int i = 0; i < array2.Length; i++)
				{
					string[] array3 = array2[i].Split('^');
					try
					{
						App.Variables.Add(array3[0], array3[1]);
					}
					catch
					{
					}
				}
				Security.End();
				return true;
			}
			case "invalid_details":
				MessageBox.Show("Oh oh! Your username or password are incorrect :o", ApplicationSettings.Name);
				Security.End();
				return false;
			case "time_expired":
				MessageBox.Show("F in the chat, your subscription expired ;(", ApplicationSettings.Name);
				Security.End();
				return false;
			case "hwid_updated":
				MessageBox.Show("New PC has been binded, restart the app!", ApplicationSettings.Name);
				Security.End();
				return false;
			case "invalid_hwid":
				MessageBox.Show("Whoops! Your GhostAccount is binded to another PC, ask for an HWID Reset", ApplicationSettings.Name);
				Security.End();
				return false;
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, ApplicationSettings.Name);
			Security.End();
			Process.GetCurrentProcess().Kill();
		}
		return false;
	}

	public static bool Register(string username, string password, string email, string license)
	{
		if (!Constants.Initialized)
		{
			MessageBox.Show("Initialize GC Premium First!", OnProgramStart.Name);
			Security.End();
			Process.GetCurrentProcess().Kill();
		}
		if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(license))
		{
			MessageBox.Show("Invalid registrar information! Try Again :)", ApplicationSettings.Name);
			Process.GetCurrentProcess().Kill();
		}
		_ = new string[0];
		using WebClient webClient = new WebClient();
		try
		{
			Security.Start();
			webClient.Proxy = null;
			string[] array = Encryption.DecryptService(Encoding.Default.GetString(webClient.UploadValues(Constants.ApiUrl, new NameValueCollection
			{
				["token"] = Encryption.EncryptService(Constants.Token),
				["timestamp"] = Encryption.EncryptService(DateTime.Now.ToString()),
				["aid"] = Encryption.APIService(OnProgramStart.AID),
				["session_id"] = Constants.IV,
				["api_id"] = Constants.APIENCRYPTSALT,
				["api_key"] = Constants.APIENCRYPTKEY,
				["session_key"] = Constants.Key,
				["secret"] = Encryption.APIService(OnProgramStart.Secret),
				["type"] = Encryption.APIService("register"),
				["username"] = Encryption.APIService(username),
				["password"] = Encryption.APIService(password),
				["email"] = Encryption.APIService(email),
				["license"] = Encryption.APIService(license),
				["hwid"] = Encryption.APIService(Constants.HWID())
			}))).Split("|".ToCharArray());
			if (array[0] != Constants.Token)
			{
				MessageBox.Show("911, I saw security errors! (GA L 643)", OnProgramStart.Name);
				Security.End();
				Process.GetCurrentProcess().Kill();
			}
			if (Security.MaliciousCheck(array[1]))
			{
				MessageBox.Show("Paramedics! Malicious Activity over here! (GA L 649)", OnProgramStart.Name);
				Process.GetCurrentProcess().Kill();
			}
			if (Constants.Breached)
			{
				MessageBox.Show("Nurse! Malicious Activity here and here! (GA L 654)", OnProgramStart.Name);
			}
			switch (array[2])
			{
			case "success":
				Security.End();
				return true;
			case "invalid_license":
				MessageBox.Show("Hmm.. I could not find that license!", ApplicationSettings.Name);
				Security.End();
				return false;
			case "email_used":
				MessageBox.Show("Coincidence? Email has already been used by an user!", ApplicationSettings.Name);
				Security.End();
				return false;
			case "invalid_username":
				MessageBox.Show("Twins! You entered an invalid/used username :o", ApplicationSettings.Name);
				Security.End();
				return false;
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, ApplicationSettings.Name);
			Process.GetCurrentProcess().Kill();
		}
		return false;
	}

	public static bool ExtendSubscription(string username, string password, string license)
	{
		if (!Constants.Initialized)
		{
			MessageBox.Show("Initialize GC Premium first! (GA L 687)", OnProgramStart.Name);
			Process.GetCurrentProcess().Kill();
		}
		if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(license))
		{
			MessageBox.Show("Hmm.. Invalid registrar information!", ApplicationSettings.Name);
			Process.GetCurrentProcess().Kill();
		}
		_ = new string[0];
		using WebClient webClient = new WebClient();
		try
		{
			Security.Start();
			webClient.Proxy = null;
			string[] array = Encryption.DecryptService(Encoding.Default.GetString(webClient.UploadValues(Constants.ApiUrl, new NameValueCollection
			{
				["token"] = Encryption.EncryptService(Constants.Token),
				["timestamp"] = Encryption.EncryptService(DateTime.Now.ToString()),
				["aid"] = Encryption.APIService(OnProgramStart.AID),
				["session_id"] = Constants.IV,
				["api_id"] = Constants.APIENCRYPTSALT,
				["api_key"] = Constants.APIENCRYPTKEY,
				["session_key"] = Constants.Key,
				["secret"] = Encryption.APIService(OnProgramStart.Secret),
				["type"] = Encryption.APIService("extend"),
				["username"] = Encryption.APIService(username),
				["password"] = Encryption.APIService(password),
				["license"] = Encryption.APIService(license)
			}))).Split("|".ToCharArray());
			if (array[0] != Constants.Token)
			{
				MessageBox.Show("Soldiers! A security error was triggered! (GA L 720)", OnProgramStart.Name);
				Security.End();
				Process.GetCurrentProcess().Kill();
			}
			if (Security.MaliciousCheck(array[1]))
			{
				MessageBox.Show("Scientist! We got some malicious activity! (GA L 726)", OnProgramStart.Name);
				Process.GetCurrentProcess().Kill();
			}
			if (Constants.Breached)
			{
				MessageBox.Show("Labs! We saw malicious activity! (GA L 731)", OnProgramStart.Name);
				Process.GetCurrentProcess().Kill();
			}
			switch (array[2])
			{
			case "success":
				Security.End();
				return true;
			case "invalid_token":
				MessageBox.Show("GhostAPI: Invalid OAuth Token! Try Again (GAPI L 740)", ApplicationSettings.Name);
				Security.End();
				return false;
			case "invalid_details":
				MessageBox.Show("Invalid user details! (GA L 744)", ApplicationSettings.Name);
				Security.End();
				return false;
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, ApplicationSettings.Name);
			Process.GetCurrentProcess().Kill();
		}
		return false;
	}
}
