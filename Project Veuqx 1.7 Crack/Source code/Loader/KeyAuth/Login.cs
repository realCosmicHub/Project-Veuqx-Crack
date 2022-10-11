using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Siticone.UI.AnimatorNS;
using Siticone.UI.WinForms;

namespace KeyAuth
{
	// Token: 0x02000007 RID: 7
	public partial class Login : Form
	{
		// Token: 0x060000A3 RID: 163 RVA: 0x000172E8 File Offset: 0x000172E8
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

		// Token: 0x060000A4 RID: 164
		[DllImport("Gdi32.dll")]
		private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

		// Token: 0x060000A5 RID: 165 RVA: 0x00017608 File Offset: 0x00017608
		public Login()
		{
			this.InitializeComponent();
			base.FormBorderStyle = FormBorderStyle.None;
			base.Region = Region.FromHrgn(Login.CreateRoundRectRgn(0, 0, base.Width, base.Height, 30, 30));
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x00017656 File Offset: 0x00017656


		// Token: 0x060000A7 RID: 167 RVA: 0x00017664 File Offset: 0x00017664
		private void guna2Panel1_Paint(object sender, PaintEventArgs e)
		{
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x00017667 File Offset: 0x00017667
		private void siticoneControlBox2_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x0001766C File Offset: 0x0001766C

		// Token: 0x060000AA RID: 170 RVA: 0x00017798 File Offset: 0x00017798
		private static string random_string()
		{
			string text = null;
			Random random = new Random();
			for (int i = 0; i < 5; i++)
			{
				text += Convert.ToChar(Convert.ToInt32(Math.Floor(26.0 * random.NextDouble() + 65.0))).ToString();
			}
			return text;
		}

		// Token: 0x060000AB RID: 171 RVA: 0x00017801 File Offset: 0x00017801
		private void key_TextChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x060000AC RID: 172 RVA: 0x00017804 File Offset: 0x00017804
		private void label2_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x060000AD RID: 173 RVA: 0x00017807 File Offset: 0x00017807
		private void key_TextChanged_1(object sender, EventArgs e)
		{
		}

		void meinvideo()
		{
			Process.Start("https://www.youtube.com/watch?v=apPsjYs6HmE");
		}

		// Token: 0x060000AE RID: 174 RVA: 0x0001780C File Offset: 0x0001780C
		private void Login_Load(object sender, EventArgs e)
		{
			meinvideo();
			Login.KeyAuthApp.init();
			bool flag = !Login.KeyAuthApp.response.success;
			if (flag)
			{
				MessageBox.Show(Login.KeyAuthApp.response.message);
				Environment.Exit(0);
			}
			bool flag2 = Login.KeyAuthApp.response.message == "Your Version is Old!";
			if (flag2)
			{
				bool flag3 = !string.IsNullOrEmpty(Login.KeyAuthApp.app_data.downloadLink);
				if (flag3)
				{
					DialogResult dialogResult = MessageBox.Show("Yes to open file in browser\nNo to download file automatically", "Auto update", MessageBoxButtons.YesNo);
					DialogResult dialogResult2 = dialogResult;
					DialogResult dialogResult3 = dialogResult2;
					if (dialogResult3 != DialogResult.Yes)
					{
						if (dialogResult3 != DialogResult.No)
						{
							MessageBox.Show("[ERROR] Old Version");
							Environment.Exit(0);
						}
						else
						{
							WebClient webClient = new WebClient();
							string text = Application.ExecutablePath;
							string str = Login.random_string();
							text = text.Replace(".exe", "-" + str + ".exe");
							webClient.DownloadFile(Login.KeyAuthApp.app_data.downloadLink, text);
							Process.Start(text);
							Process.Start(new ProcessStartInfo
							{
								Arguments = "/C choice /C Y /N /D Y /T 3 & Del \"" + Application.ExecutablePath + "\"",
								WindowStyle = ProcessWindowStyle.Hidden,
								CreateNoWindow = true,
								FileName = "cmd.exe"
							});
							Environment.Exit(0);
						}
					}
					else
					{
						Process.Start(Login.KeyAuthApp.app_data.downloadLink);
						Environment.Exit(0);
					}
				}
				MessageBox.Show("Version of this program does not match the one online. Furthermore, the download link online isn't set. You will need to manually obtain the download link from the developer");
				Thread.Sleep(2500);
				Environment.Exit(0);
				Login.KeyAuthApp.check();
			}
		}

		// Token: 0x060000AF RID: 175 RVA: 0x000179C4 File Offset: 0x000179C4
		private void LoginBtn_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Login will not work", "Cracked by Cosmic", MessageBoxButtons.OK);

        }

		// Token: 0x060000B0 RID: 176 RVA: 0x00017A34 File Offset: 0x00017A34

		// Token: 0x040000E8 RID: 232
		public static api KeyAuthApp = new api("", "", "", "1.7");
	}
}
