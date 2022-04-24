using Newtonsoft.Json;

namespace Premium;

internal class RankList
{
	[JsonProperty("killerPips")]
	public static string slasherPips { get; set; }

	[JsonProperty("survivorPips")]
	public static string camperPips { get; set; }
}
