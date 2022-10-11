using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Loader.Properties
{
	// Token: 0x02000002 RID: 2
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class Resources
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00002050
		internal Resources()
		{
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000002 RID: 2 RVA: 0x0000205C File Offset: 0x0000205C
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				bool flag = Resources.resourceMan == null;
				if (flag)
				{
					ResourceManager resourceManager = new ResourceManager("Loader.Properties.Resources", typeof(Resources).Assembly);
					Resources.resourceMan = resourceManager;
				}
				return Resources.resourceMan;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000003 RID: 3 RVA: 0x000020A4 File Offset: 0x000020A4
		// (set) Token: 0x06000004 RID: 4 RVA: 0x000020BB File Offset: 0x000020BB
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return Resources.resourceCulture;
			}
			set
			{
				Resources.resourceCulture = value;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000005 RID: 5 RVA: 0x000020C4 File Offset: 0x000020C4
		internal static Bitmap _2339_blurple_verified
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("2339-blurple-verified", Resources.resourceCulture);
				return (Bitmap)@object;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000006 RID: 6 RVA: 0x000020F4 File Offset: 0x000020F4
		internal static Bitmap _594ae766226e21723afbcb06b90e8311_removebg_preview
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("594ae766226e21723afbcb06b90e8311-removebg-preview", Resources.resourceCulture);
				return (Bitmap)@object;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000007 RID: 7 RVA: 0x00002124 File Offset: 0x00002124
		internal static Bitmap contacts_500px
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("contacts_500px", Resources.resourceCulture);
				return (Bitmap)@object;
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000008 RID: 8 RVA: 0x00002154 File Offset: 0x00002154
		internal static Bitmap discord_new_512px
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("discord_new_512px", Resources.resourceCulture);
				return (Bitmap)@object;
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000009 RID: 9 RVA: 0x00002184 File Offset: 0x00002184
		internal static Bitmap old_vmware_logo_500px
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("old_vmware_logo_500px", Resources.resourceCulture);
				return (Bitmap)@object;
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600000A RID: 10 RVA: 0x000021B4 File Offset: 0x000021B4
		internal static Bitmap png_transparent_profile_logo_computer_icons_user_user_blue_heroes_logo_removebg_preview
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("png-transparent-profile-logo-computer-icons-user-user-blue-heroes-logo-removebg-preview", Resources.resourceCulture);
				return (Bitmap)@object;
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600000B RID: 11 RVA: 0x000021E4 File Offset: 0x000021E4
		internal static Bitmap slideshare_512px
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("slideshare_512px", Resources.resourceCulture);
				return (Bitmap)@object;
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600000C RID: 12 RVA: 0x00002214 File Offset: 0x00002214
		internal static Bitmap support_500px
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("support_500px", Resources.resourceCulture);
				return (Bitmap)@object;
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600000D RID: 13 RVA: 0x00002244 File Offset: 0x00002244
		internal static Bitmap windows_10_96px
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("windows_10_96px", Resources.resourceCulture);
				return (Bitmap)@object;
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600000E RID: 14 RVA: 0x00002274 File Offset: 0x00002274
		internal static Bitmap winrar_500px
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("winrar_500px", Resources.resourceCulture);
				return (Bitmap)@object;
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600000F RID: 15 RVA: 0x000022A4 File Offset: 0x000022A4
		internal static Bitmap youtube_480px
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("youtube_480px", Resources.resourceCulture);
				return (Bitmap)@object;
			}
		}

		// Token: 0x04000001 RID: 1
		private static ResourceManager resourceMan;

		// Token: 0x04000002 RID: 2
		private static CultureInfo resourceCulture;
	}
}
