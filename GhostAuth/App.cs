using System.Collections.Generic;

namespace GhostAuth;

internal class App
{
	public static string Error = null;

	public static Dictionary<string, string> Variables = new Dictionary<string, string>();

	public static string GrabVariable(string name)
	{
		try
		{
			if (User.ID != null || User.HWID != null || User.IP != null || !Constants.Breached)
			{
				return Variables[name];
			}
			Constants.Breached = true;
			return "Woah! I don't recognize you, how did you got in?";
		}
		catch
		{
			return "N/A";
		}
	}
}
