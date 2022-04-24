namespace Premium;

internal class GhostCurrencies
{
	public class Rootobject
	{
		public List[] list { get; set; }
	}

	public class List
	{
		public float balance { get; set; }

		public string currency { get; set; }
	}
}
