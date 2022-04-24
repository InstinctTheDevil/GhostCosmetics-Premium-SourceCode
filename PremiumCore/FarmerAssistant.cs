using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows.Forms;
using GhostAuth;
using Newtonsoft.Json;
using Premium;
using PremiumCache;
using RestSharp;

namespace PremiumCore;

internal class FarmerAssistant
{
	public static string cells;

	public static string bloodpoints;

	public static string shards;

	public static bool hasPassedFirstCheck;

	public void Alert(string msg, Form_Alert.enmType type)
	{
		new Form_Alert().showAlert(msg, type);
	}

	public static async void GetCurrenciesData(string url, string bhvrSession)
	{
		Uri baseAddress = new Uri(url);
		HttpClientHandler val = new HttpClientHandler();
		val.UseCookies = (false);
		HttpClientHandler handler = val;
		try
		{
			HttpClient val2 = new HttpClient((HttpMessageHandler)(object)handler);
			val2.BaseAddress = (baseAddress);
			HttpClient client = val2;
			try
			{
				HttpRequestMessage val3 = new HttpRequestMessage(HttpMethod.Get, "api/v1/wallet/currencies");
				val3.Headers.Add("Accept", "*/*");
				val3.Headers.Add("Accept-Encoding", "deflate, gzip");
				val3.Headers.Add("Cookie", "bhvrSession=" + bhvrSession);
				val3.Headers.Add("x-kraken-client-platform", "steam");
				val3.Headers.Add("x-kraken-client-provider", "steam");
				val3.Headers.Add("x-kraken-client-version", "4.5.0");
				val3.Headers.Add("User-Agent", "DeadByDaylight/++DeadByDaylight+Live-CL-404154 Windows/10.0.19042.1.768.64bit");
				GhostCurrencies.Rootobject rootobject = JsonConvert.DeserializeObject<GhostCurrencies.Rootobject>(await (await client.SendAsync(val3)).Content.ReadAsStringAsync());
				cells = rootobject.list[2].balance.ToString();
				bloodpoints = rootobject.list[7].balance.ToString();
				shards = rootobject.list[1].balance.ToString();
				Cache.cacheShards = rootobject.list[1].balance.ToString();
				Cache.cacheCells = rootobject.list[2].balance.ToString();
				Cache.cacheBloodpoints = rootobject.list[7].balance.ToString();
				string action = "User now has: " + rootobject.list[2].currency + ": " + rootobject.list[2].balance + rootobject.list[1].currency + " : " + rootobject.list[1].balance + rootobject.list[7].currency + ": " + rootobject.list[7].balance;
				API.Log(User.Username, action);
				hasPassedFirstCheck = true;
			}
			finally
			{
				((IDisposable)client)?.Dispose();
			}
		}
		finally
		{
			((IDisposable)handler)?.Dispose();
		}
	}

	public static void GhostFarmer99MIL(string url, string bhvrSession)
	{
		RestClient restClient = new RestClient(url + "/api/v1/extensions/wallet/migrateCurrencies");
		restClient.Timeout = -1;
		RestRequest restRequest = new RestRequest(Method.POST);
		restRequest.AddHeader("Accept-Encoding", " deflate, gzip");
		restRequest.AddHeader("Accept", " */*");
		restRequest.AddHeader("Content-Type", " application/json");
		restClient.UserAgent = " DeadByDaylight/++DeadByDaylight+Live-CL-321933 Windows/10.0.19041.1.768.64bit";
		restRequest.AddHeader("Host", " steam.live.bhvrdbd.com");
		restRequest.AddCookie("bhvrSession", Dashboard.bhvrSession);
		restRequest.AddHeader("Content-Length", " 70");
		string text = "{\"data\":{\"list\":[{\"balance\":99999999,\"currency\":\"BonusBloodpoints\"}]}}";
		restRequest.AddParameter(" application/json", text, ParameterType.RequestBody );
		if (restClient.Execute(restRequest).Content.Contains("false"))
		{
			MessageBox.Show("Your account is not elegible for this!");
			return;
		}
		MessageBox.Show("You should've received the bloodpoints, do bear in mind you won't see them in the counter above");
	}

	// Token: 0x06000004 RID: 4 RVA: 0x00002F08 File Offset: 0x00001108
	public static void GhostFarmer100K(string url, string bhvrSession)
	{
		RestClient restClient = new RestClient(url + "/api/v1/extensions/rewards/grantCurrency/");
		restClient.Timeout = -1;
		RestRequest restRequest = new RestRequest(Method.POST);
		restRequest.AddHeader("Host", "steam.live.bhvrdbd.com");
		restRequest.AddHeader("Accept", "*/*");
		restRequest.AddHeader("Accept-Encoding", " deflate, gzip");
		restRequest.AddCookie("bhvrSession", Dashboard.bhvrSession);
		restRequest.AddHeader("x-kraken-client-platform", "steam");
		restRequest.AddHeader("x-kraken-client-provider", "steam");
		restRequest.AddHeader("x-kraken-client-version", "4.5.0");
		restClient.UserAgent = " DeadByDaylight/++DeadByDaylight+Live-CL-404154 Windows/10.0.19042.1.768.64bit";
		restRequest.AddHeader("Content-Type", " application/json; charset=utf-8");
		restRequest.AddHeader("Content-Length", "93");
		string text = "{\"data\":{\"rewardType\":\"Story\", \"walletToGrant\":{ \"balance\":100000,\"currency\":\"Bloodpoints\"}}}";
		restRequest.AddParameter(" application/json; charset=utf-8", text, ParameterType.RequestBody );
		if (restClient.Execute(restRequest).Content.Contains("not"))
		{
			MessageBox.Show("Could not grant bloodpoints due to an invalid bhvrSession. Restart the client, generate a new session and do not open your game whilst doing this!", "Invalid Information!");
		}
	}

	// Token: 0x06000005 RID: 5 RVA: 0x00003078 File Offset: 0x00001278
	public static void GhostFarmer75k(string url, string bhvrSession)
	{
		RestClient restClient = new RestClient(url + "/api/v1/extensions/rewards/grantCurrency/");
		restClient.Timeout = -1;
		RestRequest restRequest = new RestRequest(Method.POST);
		restRequest.AddHeader("Host", "steam.live.bhvrdbd.com");
		restRequest.AddHeader("Accept", "*/*");
		restRequest.AddHeader("Accept-Encoding", " deflate, gzip");
		restRequest.AddCookie("bhvrSession", Dashboard.bhvrSession);
		restRequest.AddHeader("x-kraken-client-platform", "steam");
		restRequest.AddHeader("x-kraken-client-provider", "steam");
		restRequest.AddHeader("x-kraken-client-version", "4.5.0");
		restClient.UserAgent = " DeadByDaylight/++DeadByDaylight+Live-CL-404154 Windows/10.0.19042.1.768.64bit";
		restRequest.AddHeader("Content-Type", " application/json; charset=utf-8");
		restRequest.AddHeader("Content-Length", "92");
		string text = "{\"data\":{\"rewardType\":\"Story\", \"walletToGrant\":{ \"balance\":75000,\"currency\":\"Bloodpoints\"}}}";
		restRequest.AddParameter(" application/json; charset=utf-8", text, ParameterType.RequestBody );
		if (restClient.Execute(restRequest).Content.Contains("not"))
		{
			MessageBox.Show("Could not grant bloodpoints due to an invalid bhvrSession. Restart the client, generate a new session and do not open your game whilst doing this!", "Invalid Information!");
		}
	}

	// Token: 0x06000006 RID: 6 RVA: 0x000031E8 File Offset: 0x000013E8
	public static void GhostFarmer50k(string url, string bhvrSession)
	{
		RestClient restClient = new RestClient(url + "/api/v1/extensions/rewards/grantCurrency/");
		restClient.Timeout = -1;
		RestRequest restRequest = new RestRequest(Method.POST);
		restRequest.AddHeader("Host", "steam.live.bhvrdbd.com");
		restRequest.AddHeader("Accept", "*/*");
		restRequest.AddHeader("Accept-Encoding", " deflate, gzip");
		restRequest.AddCookie("bhvrSession", Dashboard.bhvrSession);
		restRequest.AddHeader("x-kraken-client-platform", "steam");
		restRequest.AddHeader("x-kraken-client-provider", "steam");
		restRequest.AddHeader("x-kraken-client-version", "4.5.0");
		restClient.UserAgent = " DeadByDaylight/++DeadByDaylight+Live-CL-404154 Windows/10.0.19042.1.768.64bit";
		restRequest.AddHeader("Content-Type", " application/json; charset=utf-8");
		restRequest.AddHeader("Content-Length", "92");
		string text = "{\"data\":{\"rewardType\":\"Story\", \"walletToGrant\":{ \"balance\":50000,\"currency\":\"Bloodpoints\"}}}";
		restRequest.AddParameter(" application/json; charset=utf-8", text, ParameterType.RequestBody );
		if (restClient.Execute(restRequest).Content.Contains("not"))
		{
			MessageBox.Show("Could not grant bloodpoints due to an invalid bhvrSession. Restart the client, generate a new session and do not open your game whilst doing this!", "Invalid Information!");
		}
	}

	// Token: 0x06000007 RID: 7 RVA: 0x00003358 File Offset: 0x00001558
	public static void GhostFarmer25k(string url, string bhvrSession)
	{
		RestClient restClient = new RestClient(url + "/api/v1/extensions/rewards/grantCurrency/");
		restClient.Timeout = -1;
		RestRequest restRequest = new RestRequest(Method.POST);
		restRequest.AddHeader("Host", "steam.live.bhvrdbd.com");
		restRequest.AddHeader("Accept", "*/*");
		restRequest.AddHeader("Accept-Encoding", " deflate, gzip");
		restRequest.AddCookie("bhvrSession", Dashboard.bhvrSession);
		restRequest.AddHeader("x-kraken-client-platform", "steam");
		restRequest.AddHeader("x-kraken-client-provider", "steam");
		restRequest.AddHeader("x-kraken-client-version", "4.5.0");
		restClient.UserAgent = " DeadByDaylight/++DeadByDaylight+Live-CL-404154 Windows/10.0.19042.1.768.64bit";
		restRequest.AddHeader("Content-Type", " application/json; charset=utf-8");
		restRequest.AddHeader("Content-Length", "92");
		string text = "{\"data\":{\"rewardType\":\"Story\", \"walletToGrant\":{ \"balance\":25000,\"currency\":\"Bloodpoints\"}}}";
		restRequest.AddParameter(" application/json; charset=utf-8", text, ParameterType.RequestBody );
		if (restClient.Execute(restRequest).Content.Contains("not"))
		{
			MessageBox.Show("Could not grant bloodpoints due to an invalid bhvrSession. Restart the client, generate a new session and do not open your game whilst doing this!", "Invalid Information!");
		}
	}

}

