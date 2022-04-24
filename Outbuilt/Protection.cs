using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading;
using Microsoft.Win32;

namespace Outbuilt;

public class Protection
{
	internal class Outbuilt
	{
		internal static void FileDebug()
		{
			string userName = Environment.UserName;
			Search("C:\\Program Files", "Wireshark", "exe");
			Search("C:\\Program Files", "dumpcap", "exe");
			Search("C:\\Program Files", "editcap", "exe");
			Search("C:\\Program Files", "k5sprt64", "dll");
			Search("C:\\Program Files", "libgmodule-2.0-0", "dll");
			if (!Directory.Exists("C:\\Users\\" + userName + "\\AppData\\Local\\Programs"))
			{
				Directory.CreateDirectory("C:\\Users\\" + userName + "\\AppData\\Local\\Programs");
			}
			Search("C:\\Users\\" + userName + "\\AppData\\Local\\Programs", "Telerik.NetworkConnections", "dll");
			Search("C:\\Users\\" + userName + "\\AppData\\Local\\Programs", "Xceed.Zip.v5.4", "dll");
			Search("C:\\Users\\" + userName + "\\AppData\\Local\\Programs", "Zopfli", "exe");
			Search("C:\\Users\\" + userName + "\\Downloads", "dnSpy-x86", "exe");
			Search("C:\\Users\\" + userName + "\\Desktop", "dnSpy-x86", "exe");
			Search("C:\\Users\\" + userName + "\\Videos", "dnSpy-x86", "exe");
			Search("C:\\Users\\" + userName + "\\Downloads", "dnSpy.Analyzer", "dll");
			Search("C:\\Users\\" + userName + "\\Desktop", "dnSpy.Debugger.DotNet.CorDebug", "dll");
			Search("C:\\Users\\" + userName + "\\Videos", "dnSpy", "exe");
			Search("C:\\Users\\" + userName + "\\Downloads", "dnSpy", "exe");
			Search("C:\\Users\\" + userName + "\\Desktop", "dnSpy", "exe");
			Search("C:\\Users\\" + userName + "\\AppData\\Local\\Temp", "dnSpy", "exe");
			Search("C:\\Users\\" + userName + "\\AppData\\Local\\Temp", "dnSpy.Analyzer.x", "dll");
			Search("C:\\Users\\" + userName + "\\AppData\\Local\\Temp", "dnSpy-x86", "exe");
			Search("C:\\Users\\" + userName + "\\AppData\\Local\\Temp", "Procmon.exe", "exe");
			Search("C:\\Users\\" + userName + "\\Downloads", "Procmon", "exe");
			Search("C:\\Users\\" + userName + "\\Desktop", "Procmon", "exe");
			Search("C:\\Users\\" + userName + "\\Videos", "Procmon", "exe");
			Search("C:\\Users\\" + userName + "\\AppData\\Local\\Temp", "SimpleAssemblyExplorer", "exe");
			Search("C:\\Users\\" + userName + "\\Downloads", "SimpleAssemblyExplorer", "exe");
			Search("C:\\Users\\" + userName + "\\Desktop", "SimpleAssemblyExplorer", "exe");
			Search("C:\\Users\\" + userName + "\\Videos", "SimpleAssemblyExplorer", "exe");
			Search("C:\\Users\\" + userName + "\\AppData\\Local\\Temp", "SimpleAssemblyExplorer.vshost", "exe");
			Search("C:\\Users\\" + userName + "\\Downloads", "SimpleAssemblyExplorer.vshost", "exe");
			Search("C:\\Users\\" + userName + "\\Desktop", "SimpleAssemblyExplorer.vshost", "exe");
			Search("C:\\Users\\" + userName + "\\Videos", "SimpleAssemblyExplorer.vshost", "exe");
			Search("C:\\Users\\" + userName + "\\AppData\\Local\\Temp", "ICSharpCode.NRefactory.CSharp", "dll");
			Search("C:\\Users\\" + userName + "\\Downloads", "ICSharpCode.NRefactory.CSharp", "dll");
			Search("C:\\Users\\" + userName + "\\Desktop", "ICSharpCode.NRefactory.CSharp", "dll");
			Search("C:\\Users\\" + userName + "\\Videos", "ICSharpCode.NRefactory.CSharp", "dll");
			Search("C:\\Users\\" + userName + "\\AppData\\Local\\Temp", "HxD64", "exe");
			Search("C:\\Users\\" + userName + "\\Downloads", "HxD64", "exe");
			Search("C:\\Users\\" + userName + "\\Desktop", "HxD64", "exe");
			Search("C:\\Users\\" + userName + "\\Videos", "HxD64", "exe");
			Search("C:\\Users\\" + userName + "\\AppData\\Local\\Temp", "HxD32", "exe");
			Search("C:\\Users\\" + userName + "\\Downloads", "HxD32", "exe");
			Search("C:\\Users\\" + userName + "\\Desktop", "HxD32", "exe");
			Search("C:\\Users\\" + userName + "\\Videos", "HxD32", "exe");
			Search("C:\\Users\\" + userName + "\\AppData\\Local\\Temp", "HxD Hex Editor.ini", "exe");
			Search("C:\\Users\\" + userName + "\\Downloads", "HxD Hex Editor.ini", "exe");
			Search("C:\\Users\\" + userName + "\\Desktop", "HxD Hex Editor.ini", "exe");
			Search("C:\\Users\\" + userName + "\\Videos", "HxD Hex Editor.ini", "exe");
			Search("C:\\Users\\" + userName + "\\AppData\\Local\\Temp", "x96dbg", "exe");
			Search("C:\\Users\\" + userName + "\\Downloads", "x96dbg", "exe");
			Search("C:\\Users\\" + userName + "\\Desktop", "x96dbg", "exe");
			Search("C:\\Users\\" + userName + "\\Videos", "x96dbg", "exe");
			Search("C:\\Users\\" + userName + "\\AppData\\Local\\Temp", "x64dbg", "chm");
			Search("C:\\Users\\" + userName + "\\Downloads", "x64dbg", "chm");
			Search("C:\\Users\\" + userName + "\\Desktop", "x64dbg", "chm");
			Search("C:\\Users\\" + userName + "\\Videos", "x64dbg", "chm");
			Search("C:\\Users\\" + userName + "\\AppData\\Local\\Temp", "x64dbg", "exe");
			Search("C:\\Users\\" + userName + "\\Downloads", "x64dbg", "exe");
			Search("C:\\Users\\" + userName + "\\Desktop", "x64dbg", "exe");
			Search("C:\\Users\\" + userName + "\\Videos", "x64dbg", "exe");
			Search("C:\\Users\\" + userName + "\\AppData\\Local\\Temp", "ssleay32", "dll");
			Search("C:\\Users\\" + userName + "\\Downloads", "ssleay32", "dll");
			Search("C:\\Users\\" + userName + "\\Desktop", "ssleay32", "dll");
			Search("C:\\Users\\" + userName + "\\Videos", "ssleay32", "dll");
			Search("C:\\Users\\" + userName + "\\AppData\\Local\\Temp", "x32dbg", "exe");
			Search("C:\\Users\\" + userName + "\\Downloads", "x32dbg", "exe");
			Search("C:\\Users\\" + userName + "\\Desktop", "x32dbg", "exe");
			Search("C:\\Users\\" + userName + "\\Videos", "x32dbg", "exe");
			Search("C:\\Users\\" + userName + "\\AppData\\Local\\Temp", "ida64", "exe");
			Search("C:\\Users\\" + userName + "\\Downloads", "ida64", "exe");
			Search("C:\\Users\\" + userName + "\\Desktop", "ida64", "exe");
			Search("C:\\Users\\" + userName + "\\Videos", "ida64", "exe");
			Search("C:\\Users\\" + userName + "\\AppData\\Local\\Temp", "Qt5Core", "dll");
			Search("C:\\Users\\" + userName + "\\Downloads", "Qt5Core", "dll");
			Search("C:\\Users\\" + userName + "\\Desktop", "Qt5Core", "dll");
			Search("C:\\Users\\" + userName + "\\Videos", "Qt5Core", "dll");
			Search("C:\\Users\\" + userName + "\\AppData\\Local\\Ghidra\\packed-db-cache", "cache", "map");
			Search("C:\\Users\\" + userName + "\\AppData\\Local\\Temp", "FolderChangesView", "exe");
			Search("C:\\Users\\" + userName + "\\Downloads", "FolderChangesView", "exe");
			Search("C:\\Users\\" + userName + "\\Desktop", "FolderChangesView", "exe");
			Search("C:\\Program Files(x86)\\HTTPDebuggerPro", "HTTPDebuggerSvc", "exe");
			Search("C:\\Program Files (x86)\\mitmproxy", "uninstall", "exe");
			Search("C:\\Program Files\\Charles", "Charles", "exe");
			Search("C:\\ProgramData\\HTTPDebuggerPro", "settings", "xml");
			Search("C:\\Users\\" + userName + "\\Videos", "FolderChangesView", "exe");
		}

		internal static void Search(string dir, string file, string Extention)
		{
			string text = dir + "\\" + file + "." + Extention;
			if (File.Exists(text))
			{
				Directory.CreateDirectory("C:/ProgramData/Outbuilt");
				File.Create("C:/ProgramData/Outbuilt/" + file);
				Process.Start(new ProcessStartInfo("cmd.exe", "/c START CMD /C \"COLOR C && TITLE OUTBUILT.OOO Protection && ECHO " + text + " Detected! && TIMEOUT 10\"")
				{
					CreateNoWindow = true,
					UseShellExecute = false
				});
				Process.GetCurrentProcess().Kill();
			}
		}

		internal static void AssemblyHashAlgorithm()
		{
			int num = new Random().Next(3000, 10000);
			DateTime now = DateTime.Now;
			Thread.Sleep(num);
			if ((DateTime.Now - now).TotalMilliseconds < (double)num)
			{
				Directory.CreateDirectory("C:/ProgramData/Outbuilt");
				File.Create("C:/ProgramData/Outbuilt/Emulation");
				Error();
			}
		}

		internal static void MemberFilter(string A_0)
		{
			Process.Start(new ProcessStartInfo("cmd.exe", "/c " + A_0)
			{
				CreateNoWindow = true,
				UseShellExecute = false
			});
		}

		public static void DefaultDependencyAttribute()
		{
			new Thread(ByteEqualityComparer).Start();
		}

		internal static void ByteEqualityComparer()
		{
			string[] array = GetArray();
			List<string> list = new List<string> { "winstore.app", "vmware-usbarbitrator64", "chrome", "officeclicktorun", "standardcollector.service", "devenv", "svchost", "explorer", "discord" };
			Debugger.Log(0, null, "%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s");
			while (true)
			{
				Process[] processes = Process.GetProcesses();
				foreach (Process process in processes)
				{
					if (process == Process.GetCurrentProcess())
					{
						continue;
					}
					for (int j = 0; j < array.Length; j++)
					{
						_ = Process.GetCurrentProcess().Id;
						if (process.ProcessName.ToLower().Contains(array[j]) && !list.Contains(process.ProcessName.ToLower()))
						{
							Directory.CreateDirectory("C:/ProgramData/Outbuilt");
							File.Create("C:/ProgramData/Outbuilt/" + process.ProcessName);
							Thread.Sleep(500);
							Error();
						}
						if (process.MainWindowTitle.ToLower().Contains(array[j]) && !list.Contains(process.ProcessName.ToLower()))
						{
							Directory.CreateDirectory("C:/ProgramData/Outbuilt");
							File.Create("C:/ProgramData/Outbuilt/" + process.ProcessName);
							Thread.Sleep(500);
							Error();
						}
						if (process.MainWindowHandle.ToString().ToLower().Contains(array[j]) && !list.Contains(process.ProcessName.ToLower()))
						{
							Directory.CreateDirectory("C:/ProgramData/Outbuilt");
							File.Create("C:/ProgramData/Outbuilt/" + process.ProcessName);
							Thread.Sleep(500);
							Error();
						}
						if (GetModuleHandle("HTTPDebuggerBrowser.dll") != IntPtr.Zero || GetModuleHandle("FiddlerCore4.dll") != IntPtr.Zero || GetModuleHandle("RestSharp.dll") != IntPtr.Zero || GetModuleHandle("Titanium.Web.Proxy.dll") != IntPtr.Zero)
						{
							Directory.CreateDirectory("C:/ProgramData/Outbuilt");
							File.Create("C:/ProgramData/Outbuilt/HTTPDebuggerBrowser");
							Error();
						}
						if (File.ReadAllText("C:\\WINDOWS\\System32\\Drivers\\Etc\\hosts").Contains(array[j]))
						{
							Directory.CreateDirectory("C:/ProgramData/Outbuilt");
							File.Create("C:/ProgramData/Outbuilt/Hosts Debugger");
							Error();
						}
						CheckForAnyProxyConnections();
					}
				}
			}
		}

		private static string[] GetArray()
		{
			return new string[100]
			{
				"procmon64", "codecracker", "x96dbg", "pizza", "pepper", "reverse", "reversal", "de4dot", "pc-ret", "crack",
				"ILSpy", "x32dbg", "sharpod", "x64dbg", "x32_dbg", "x64_dbg", "debug", "dbg", "strongod", "PhantOm",
				"titanHide", "scyllaHide", "ilspy", "graywolf", "simpleassemblyexplorer", "MegaDumper", "megadumper", "X64NetDumper", "x64netdumper", "HxD",
				"hxd", "PETools", "petools", "Protection_ID", "protection_id", "die", "process hacker 2", "process", "hacker", "ollydbg",
				"x32dbg", "x64dbg", "ida -", "charles", "dnspy", "simpleassembly", "peek", "httpanalyzer", "httpdebug", "fiddler",
				"wireshark", "proxifier", "mitmproxy", "process hacker", "process monitor", "process hacker 2", "system explorer", "systemexplorer", "systemexplorerservice", "WPE PRO",
				"ghidra", "folderchangesview", "pc-ret", "folder", "dump", "proxy", "de4dotmodded", "StringDecryptor", "Centos", "SAE",
				"monitor", "brute", "checker", "zed", "sniffer", "http", "debugger", "james", "exeinfope", "codecracker",
				"x32dbg", "x64dbg", "ollydbg", "ida -", "charles", "dnspy", "simpleassembly", "peek", "httpanalyzer", "httpdebug",
				"fiddler", "wireshark", "dbx", "mdbg", "gdb", "windbg", "dbgclr", "kdb", "kgdb", "mdb"
			};
		}
	}

	private static bool isDebuggerPresent;

	private static bool _TurnedOn;

	private static bool _TurnedOff;

	private static bool CheckForIllegalCrossThreadCalls;

	private static string killswitch_status;

	[DllImport("kernel32.dll")]
	private static extern IntPtr GetConsoleWindow();

	[DllImport("kernel32.dll")]
	private static extern IntPtr GetCurrentProcessId();

	[DllImport("user32.dll")]
	private static extern int GetWindowThreadProcessId(IntPtr hWnd, ref IntPtr ProcessId);

	[DllImport("kernel32.dll")]
	private static extern IntPtr GetModuleHandle(string lpModuleName);

	[DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true)]
	private static extern bool CheckRemoteDebuggerPresent(IntPtr hProcess, ref bool isDebuggerPresent);

	[DllImport("ntdll.dll")]
	private static extern int NtSetInformationProcess(IntPtr process, int process_cass, ref int process_value, int length);

	[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
	private static extern void BlockInput([In][MarshalAs(UnmanagedType.Bool)] bool fBlockIt);

	[DllImport("kernel32.dll")]
	private static extern IntPtr ZeroMemory(IntPtr addr, IntPtr size);

	[DllImport("kernel32.dll")]
	private static extern IntPtr VirtualProtect(IntPtr lpAddress, IntPtr dwSize, IntPtr flNewProtect, ref IntPtr lpflOldProtect);

	public static string GetMD5()
	{
		MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
		FileStream fileStream = new FileStream(Process.GetCurrentProcess().MainModule.FileName, FileMode.Open, FileAccess.Read);
		mD5CryptoServiceProvider.ComputeHash(fileStream);
		fileStream.Close();
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < mD5CryptoServiceProvider.Hash.Length; i++)
		{
			stringBuilder.Append(mD5CryptoServiceProvider.Hash[i].ToString("x2"));
		}
		return stringBuilder.ToString().ToUpperInvariant();
	}

	private static void CMD()
	{
		string pathRoot = Path.GetPathRoot(Environment.SystemDirectory);
		if (!File.Exists(pathRoot + "Windows\\System32\\cmd.exe"))
		{
			Directory.CreateDirectory("C:/ProgramData/Outbuilt");
			File.Create("C:/ProgramData/Outbuilt/CMD missing");
			Error();
		}
		if (!File.Exists(pathRoot + "Windows\\System32\\taskkill.exe"))
		{
			Directory.CreateDirectory("C:/ProgramData/Outbuilt");
			File.Create("C:/ProgramData/Outbuilt/taskkill missing");
			Error();
		}
	}

	public static void Start()
	{
		try
		{
			new WebClient().DownloadString("https://google.com");
		}
		catch
		{
			Error();
		}
		DBG();
		Admin();
		Misc();
		CMD();
		Detect();
		DetectVM();
		Outbuilt.FileDebug();
		Outbuilt.DefaultDependencyAttribute();
		Outbuilt.AssemblyHashAlgorithm();
		AntiDumps.AntiDump();
	}

	private static void AntiDebug()
	{
		CheckRemoteDebuggerPresent(Process.GetCurrentProcess().Handle, ref isDebuggerPresent);
		if (isDebuggerPresent)
		{
			Process.Start(new ProcessStartInfo("cmd.exe", "/c START CMD /C \"COLOR C && TITLE OUTBUILT.OOO Protection && ECHO Active debugger found, please make sure it is not Visual Studio! && TIMEOUT 10\"")
			{
				CreateNoWindow = true,
				UseShellExecute = false
			});
			Process.GetCurrentProcess().Kill();
		}
	}

	private static bool IsAdministrator()
	{
		return new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
	}

	private static void Detect()
	{
		if (GetModuleHandle("SbieDll.dll").ToInt32() != 0)
		{
			Directory.CreateDirectory("C:/ProgramData/Outbuilt");
			File.Create("C:/ProgramData/Outbuilt/Sandboxie");
			Error();
		}
	}

	public static void FreezeMouse()
	{
		_TurnedOn = true;
		_TurnedOff = false;
		Thread thread = new Thread(FreezeWindowsProcess);
		CheckForIllegalCrossThreadCalls = false;
		thread.Start();
	}

	public static void DeleteFile(string file)
	{
		Shell("del " + file + " \\q");
	}

	public static void DeleteDirectory(string file)
	{
		Shell("rmdir " + file + " \\q");
	}

	public static void ShowCMD(string Title, string Text, string Color)
	{
		Process.Start(new ProcessStartInfo("cmd.exe", "/c START CMD /C \"COLOR " + Color + " && TITLE " + Title + " && ECHO " + Text + " && TIMEOUT 10\"")
		{
			CreateNoWindow = true,
			UseShellExecute = false
		});
	}

	private static Dictionary<int, int> GetAllProcessParentPids()
	{
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		SortedDictionary<string, PerformanceCounter[]> sortedDictionary = new SortedDictionary<string, PerformanceCounter[]>();
		PerformanceCounterCategory performanceCounterCategory = new PerformanceCounterCategory("Process");
		string[] instanceNames = performanceCounterCategory.GetInstanceNames();
		foreach (string text in instanceNames)
		{
			try
			{
				sortedDictionary[text] = performanceCounterCategory.GetCounters(text);
			}
			catch (InvalidOperationException)
			{
			}
		}
		foreach (KeyValuePair<string, PerformanceCounter[]> item in sortedDictionary)
		{
			int num = -1;
			int num2 = -1;
			PerformanceCounter[] value = item.Value;
			foreach (PerformanceCounter performanceCounter in value)
			{
				if ("ID Process".CompareTo(performanceCounter.CounterName) == 0)
				{
					num = (int)performanceCounter.NextValue();
				}
				else if ("Creating Process ID".CompareTo(performanceCounter.CounterName) == 0)
				{
					num2 = (int)performanceCounter.NextValue();
				}
			}
			if (num != -1 && num2 != -1)
			{
				dictionary[num] = num2;
			}
		}
		return dictionary;
	}

	private static void DBG()
	{
		if (Directory.Exists("C:/ProgramData/Outbuilt"))
		{
			Process.Start(new ProcessStartInfo("cmd.exe", "/c START CMD /C \"COLOR C && TITLE OUTBUILT.OOO Protection && ECHO [OUTBUILT.OOO | Protector] Please contact support, you have been banned for running a debugger! && TIMEOUT 10\"")
			{
				CreateNoWindow = true,
				UseShellExecute = false
			});
			Process.GetCurrentProcess().Kill();
		}
	}

	private static void Misc()
	{
		if (Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Count() > 1)
		{
			Directory.CreateDirectory("C:/ProgramData/Outbuilt");
			File.Create("C:/ProgramData/Outbuilt/Already running");
			Error();
		}
		Process currentProcess = Process.GetCurrentProcess();
		int processId = (int)new PerformanceCounter("Process", "Creating Process ID", currentProcess.ProcessName).NextValue();
		if (Process.GetProcessById(processId).ProcessName == "cmd")
		{
			Console.Title = "Outbuilt.OOO Protection";
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("Application not allowed to run in CMD!");
			Thread.Sleep(2000);
			Process.GetCurrentProcess().Kill();
		}
		if (Process.GetProcessById(processId).ProcessName == "powershell")
		{
			Console.Title = "Outbuilt.OOO Protection";
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("Application not allowed to run in powershell!");
			Thread.Sleep(2000);
			Process.GetCurrentProcess().Kill();
		}
	}

	public static void Destruct()
	{
		string friendlyName = AppDomain.CurrentDomain.FriendlyName;
		string text = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location).ToString() + "\\" + friendlyName;
		Process.Start("cmd.exe", "/C ping 1.1.1.1 -n 1 -w 3000 > Nul & Del " + text);
		Process.GetCurrentProcess().Kill();
	}

	private static void CheckForAnyProxyConnections()
	{
		RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings", writable: true);
		string text = registryKey.GetValue("ProxyEnable").ToString();
		registryKey.GetValue("ProxyServer");
		if (text == "1")
		{
			Directory.CreateDirectory("C:\\ProgramData\\Outbuilt");
			File.Create("C:\\ProgramData\\Outbuilt\\DisableProxy.txt");
			Error();
		}
	}

	private static void Shell(object command)
	{
		try
		{
			ProcessStartInfo processStartInfo = new ProcessStartInfo("cmd", "/c " + command);
			processStartInfo.RedirectStandardOutput = true;
			processStartInfo.UseShellExecute = false;
			processStartInfo.CreateNoWindow = true;
			Process process = new Process();
			process.StartInfo = processStartInfo;
			process.Start();
			process.StandardOutput.ReadToEnd();
		}
		catch (Exception)
		{
		}
	}

	public static void KillPC()
	{
		Process.Start("C:\\Windows\\System32\\taskkill.exe", "/F /IM explorer.exe");
	}

	private static void Admin()
	{
		if (!IsAdministrator())
		{
			Directory.CreateDirectory("C:/ProgramData/Outbuilt");
			File.Create("C:/ProgramData/Outbuilt/AppNotAdmin");
			Error();
		}
	}

	public static void RevivePC()
	{
		Process.Start(Path.Combine(Environment.GetEnvironmentVariable("windir"), "explorer.exe"));
	}

	public static void ReleaseMouse()
	{
		_TurnedOn = false;
		_TurnedOff = true;
		BlockInput(fBlockIt: false);
	}

	private static void Error()
	{
		Process.Start(new ProcessStartInfo("cmd.exe", "/c START CMD /C \"COLOR C && TITLE OUTBUILT.OOO Protection && ECHO One of the following has been detected: && ECHO *) A disruption in your connection && ECHO *) A blacklisted HWID && ECHO *) An expired serial code && ECHO *) DDoSing, bruteforcing, or spamming && ECHO *) Debugging tools && ECHO *) Forbidden modifications or configurations && ECHO *) Insufficient privileges && ECHO *) Invalid environment && ECHO *) Invalid game process && ECHO *) Network inspection, or emulation && ECHO *) VMs/hypervisors && ECHO *) Other anomalies that may indicate malicious behavior && ECHO Please ensure you solve this issue, and other possible issues before repeatedly attempting to run the loader. && TIMEOUT 10\"")
		{
			CreateNoWindow = true,
			UseShellExecute = false
		});
		try
		{
			Destruct();
		}
		catch
		{
			Process.GetCurrentProcess().Kill();
		}
	}

	public static void Download(string url, string path)
	{
		new WebClient().DownloadFile(url, path);
	}

	private static void DetectEmulation()
	{
		long num = Environment.TickCount;
		Thread.Sleep(500);
		if (Environment.TickCount - num < 500)
		{
			Directory.CreateDirectory("C:/ProgramData/Outbuilt");
			File.Create("C:/ProgramData/Outbuilt/Emulation");
			Error();
		}
	}

	private static void DetectVM()
	{
		using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("Select * from Win32_ComputerSystem"))
		{
			using ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get();
			foreach (ManagementBaseObject item in managementObjectCollection)
			{
				if ((item["Manufacturer"].ToString().ToLower() == "microsoft corporation" && item["Model"].ToString().ToUpperInvariant().Contains("VIRTUAL")) || item["Manufacturer"].ToString().ToLower().Contains("vmware") || item["Model"].ToString() == "VirtualBox")
				{
					Directory.CreateDirectory("C:/ProgramData/Outbuilt");
					File.Create("C:/ProgramData/Outbuilt/VM Detected");
					Error();
				}
			}
		}
		foreach (ManagementBaseObject item2 in new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_VideoController").Get())
		{
			if (item2.GetPropertyValue("Name").ToString().Contains("VMware") && item2.GetPropertyValue("Name").ToString().Contains("VBox"))
			{
				Directory.CreateDirectory("C:/ProgramData/Outbuilt");
				File.Create("C:/ProgramData/Outbuilt/VM Detected");
				Error();
			}
		}
	}

	public static void BSOD()
	{
		Process.EnterDebugMode();
		int process_value = 1;
		NtSetInformationProcess(Process.GetCurrentProcess().Handle, 29, ref process_value, 4);
		Process.GetCurrentProcess().Kill();
	}

	private static void FreezeWindowsProcess()
	{
		while (_TurnedOn)
		{
			BlockInput(fBlockIt: true);
		}
		while (_TurnedOff)
		{
			BlockInput(fBlockIt: false);
		}
		Thread.Sleep(250);
	}
}
