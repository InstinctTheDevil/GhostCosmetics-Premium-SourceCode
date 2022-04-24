using System;
using System.Windows.Forms;
using GhostAuth;

namespace Premium;

internal static class Program
{
	[STAThread]
	private static void Main()
	{
		OnProgramStart.Initialize("GhostCosmetics Premium", "910485", "u5aQDiW7HGjhEpAfmwVjp5EcnXvdD6uRn5g", "2.5.0");
		Application.EnableVisualStyles();
		Application.SetCompatibleTextRenderingDefault(defaultValue: false);
		Application.Run(new Login());
	}
}
