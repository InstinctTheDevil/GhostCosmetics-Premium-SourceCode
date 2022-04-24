using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Outbuilt;

internal class AntiDumps
{
	private static int[] sectiontabledwords = new int[7] { 8, 12, 16, 20, 24, 28, 36 };

	private static int[] peheaderbytes = new int[2] { 26, 27 };

	private static int[] peheaderwords = new int[12]
	{
		4, 22, 24, 64, 66, 68, 70, 72, 74, 76,
		92, 94
	};

	private static int[] peheaderdwords = new int[27]
	{
		0, 8, 12, 16, 22, 28, 32, 40, 44, 52,
		60, 76, 80, 84, 88, 96, 100, 104, 108, 112,
		116, 260, 264, 268, 272, 276, 284
	};

	[DllImport("kernel32.dll")]
	private static extern IntPtr ZeroMemory(IntPtr addr, IntPtr size);

	[DllImport("kernel32.dll")]
	private static extern IntPtr VirtualProtect(IntPtr lpAddress, IntPtr dwSize, IntPtr flNewProtect, ref IntPtr lpflOldProtect);

	private static void EraseSection(IntPtr address, int size)
	{
		IntPtr intPtr = (IntPtr)size;
		IntPtr lpflOldProtect = default(IntPtr);
		VirtualProtect(address, intPtr, (IntPtr)64, ref lpflOldProtect);
		ZeroMemory(address, intPtr);
		IntPtr lpflOldProtect2 = default(IntPtr);
		VirtualProtect(address, intPtr, lpflOldProtect, ref lpflOldProtect2);
	}

	public static void AntiDump()
	{
		IntPtr baseAddress = Process.GetCurrentProcess().MainModule.BaseAddress;
		int num = Marshal.ReadInt32((IntPtr)(baseAddress.ToInt32() + 60));
		short num2 = Marshal.ReadInt16((IntPtr)(baseAddress.ToInt32() + num + 6));
		EraseSection(baseAddress, 30);
		for (int i = 0; i < peheaderdwords.Length; i++)
		{
			EraseSection((IntPtr)(baseAddress.ToInt32() + num + peheaderdwords[i]), 4);
		}
		for (int j = 0; j < peheaderwords.Length; j++)
		{
			EraseSection((IntPtr)(baseAddress.ToInt32() + num + peheaderwords[j]), 2);
		}
		for (int k = 0; k < peheaderbytes.Length; k++)
		{
			EraseSection((IntPtr)(baseAddress.ToInt32() + num + peheaderbytes[k]), 1);
		}
		int num3 = 0;
		int num4 = 0;
		while (num3 <= num2)
		{
			if (num4 == 0)
			{
				EraseSection((IntPtr)(baseAddress.ToInt32() + num + 250 + 40 * num3 + 32), 2);
			}
			EraseSection((IntPtr)(baseAddress.ToInt32() + num + 250 + 40 * num3 + sectiontabledwords[num4]), 4);
			num4++;
			if (num4 == sectiontabledwords.Length)
			{
				num3++;
				num4 = 0;
			}
		}
	}
}
