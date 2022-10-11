using System;
using System.Windows.Forms;

namespace KeyAuth
{
	// Token: 0x02000008 RID: 8
	internal static class Program
	{
		// Token: 0x060000B4 RID: 180 RVA: 0x00018C12 File Offset: 0x00018C12
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Login());
		}
	}
}
