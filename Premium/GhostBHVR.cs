using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Premium;

internal class GhostBHVR
{
	public static async Task<bool> ValidateSession(string url, string bhvrSession)
	{
		_ = 1;
		try
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
					if (JsonConvert.DeserializeObject<GhostCurrencies.Rootobject>(await (await client.SendAsync(val3)).Content.ReadAsStringAsync()).list != null)
					{
						MessageBox.Show("bhvrSession was successfully validated");
						return true;
					}
					MessageBox.Show("Couldn't validate bhvrSession, your game might be opened (?)");
					return false;
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
		catch (Exception ex)
		{
			MessageBox.Show("Could not validate session / " + ex.Message);
			if (ex.InnerException != null)
			{
				MessageBox.Show("Could not validate session / " + ex.InnerException.Message);
			}
			return false;
		}
	}

	public static async void FetchCurrencies(string url, string bhvrSession)
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
				JsonConvert.DeserializeObject<GhostCurrencies.Rootobject>(await (await client.SendAsync(val3)).Content.ReadAsStringAsync());
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

	public static async Task<GhostCurrencies.Rootobject> FetchCurrenciesList(string url, string bhvrSession)
	{
		Uri baseAddress = new Uri(url);
		HttpClientHandler val = new HttpClientHandler();
		val.UseCookies = (false);
		HttpClientHandler handler = val;
		GhostCurrencies.Rootobject result;
		try
		{
			HttpClient val2 = new HttpClient((HttpMessageHandler)(object)handler);
			val2.BaseAddress = (baseAddress);
			HttpClient client = val2;
			try
			{
				HttpRequestMessage val3 = new HttpRequestMessage(HttpMethod.Get, "api/v1/wallet/currencies");
				val3.Headers.Add("Cookie", "bhvrSession=" + bhvrSession);
				result = JsonConvert.DeserializeObject<GhostCurrencies.Rootobject>(await (await client.SendAsync(val3)).Content.ReadAsStringAsync());
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
		return result;
	}
}
