using Fiddler;
using PremiumCache;

namespace Premium;

public static class GhostCore
{
	static GhostCore()
	{
		FiddlerApplication.BeforeRequest += new SessionStateHandler(GhostCore.GhostBeforeRequest);
		FiddlerApplication.ResetSessionCounter();
	}

	public static void Start()
	{
		CONFIG.IgnoreServerCertErrors = true;
		Cache.didUserLoggedInWithFiddler = true;
		FiddlerApplication.Startup(((FiddlerCoreStartupSettingsBuilder<FiddlerCoreStartupSettingsBuilder, FiddlerCoreStartupSettings>)(object)((FiddlerCoreStartupSettingsBuilder<FiddlerCoreStartupSettingsBuilder, FiddlerCoreStartupSettings>)(object)((FiddlerCoreStartupSettingsBuilder<FiddlerCoreStartupSettingsBuilder, FiddlerCoreStartupSettings>)(object)((FiddlerCoreStartupSettingsBuilder<FiddlerCoreStartupSettingsBuilder, FiddlerCoreStartupSettings>)(object)((FiddlerCoreStartupSettingsBuilder<FiddlerCoreStartupSettingsBuilder, FiddlerCoreStartupSettings>)(object)((FiddlerCoreStartupSettingsBuilder<FiddlerCoreStartupSettingsBuilder, FiddlerCoreStartupSettings>)new FiddlerCoreStartupSettingsBuilder()).ListenOnPort((ushort)777)).RegisterAsSystemProxy()).ChainToUpstreamGateway()).OptimizeThreadPool()).DecryptSSL()).Build());
	}

	public static void GhostBeforeRequest(Session oSession)
	{
		if (!(oSession.hostname == "grdk.live.bhvrdbd.com") && !(oSession.hostname == "steam.live.bhvrdbd.com"))
		{
			return;
		}
		if (oSession.uriContains("api/v1/inventories"))
		{
			Cache.sniffedSession = oSession.oRequest["Cookie"].Replace("bhvrSession=", "");
			if (oSession.uriContains("steam.live"))
			{
				Cache.identifiedPlatform = "steam.live";
			}
			else if (oSession.uriContains("grdk.live"))
			{
				Cache.identifiedPlatform = "grdk.live";
			}
			return;
		}
		if (Cache.profileSpoof)
		{
			if (oSession.uriContains("api/v1/players/me/states/FullProfile/binary"))
			{
				oSession.utilCreateResponseAndBypassServer();
				oSession.oResponse["Kraken-State-Schema-Version"] = "0";
				oSession.oResponse["Content-Type"] = "application/octet-stream";
				oSession.oResponse["Kraken-State-Version"] = "1";
				oSession.utilSetResponseBody(Cache.profileBinary);
				return;
			}
			if (oSession.uriContains("api/v1/players/me/states/binary?schemaVersion"))
			{
				oSession.utilCreateResponseAndBypassServer();
				oSession.utilSetResponseBody("{\"version\":1,\"stateName\":\"FullProfile\",\"schemaVersion\":0,\"playerId\":\"U-aeb214ca-1eba-4400-a164-2a495bcaa7f4\"}");
				return;
			}
		}
		if (Cache.seasonChanger && oSession.uriContains("/specialEventsContent.json"))
		{
			oSession.utilCreateResponseAndBypassServer();
			oSession.utilSetResponseBody(Cache.serverSeason);
		}
		else if (Cache.unbinderStatus && oSession.uriContains("/catalog.json"))
		{
			oSession.utilCreateResponseAndBypassServer();
			oSession.utilSetResponseBody(Cache.unbinderData);
		}
		else if (Cache.bloodyMary && oSession.uriContains("v1/wallet/withdraw"))
		{
			oSession.utilCreateResponseAndBypassServer();
			oSession.utilSetResponseBody("{\"userId\":\"null\",\"balance\":0,\"currency\":\"USCents\"}");
		}
	}
}
