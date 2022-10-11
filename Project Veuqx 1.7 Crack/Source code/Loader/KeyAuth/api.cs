using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace KeyAuth
{
	// Token: 0x02000003 RID: 3
	public class api
	{
		// Token: 0x06000010 RID: 16 RVA: 0x000022D4 File Offset: 0x000022D4
		public api(string name, string ownerid, string secret, string version)
		{
			bool flag = string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(ownerid) || string.IsNullOrWhiteSpace(secret) || string.IsNullOrWhiteSpace(version);
			if (flag)
			{
				api.error("[ERROR] Connect Veuqx Support!");
				Environment.Exit(0);
			}
			this.name = name;
			this.ownerid = ownerid;
			this.secret = secret;
			this.version = version;
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00002374 File Offset: 0x00002374
		public void init()
		{
			this.enckey = encryption.sha256(encryption.iv_key());
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("init"));
			nameValueCollection["ver"] = encryption.encrypt(this.version, this.secret, text);
			nameValueCollection["hash"] = api.checksum(Process.GetCurrentProcess().MainModule.FileName);
			nameValueCollection["enckey"] = encryption.encrypt(this.enckey, this.secret, text);
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			NameValueCollection post_data = nameValueCollection;
			string text2 = api.req(post_data);
			bool flag = text2 == "KeyAuth_Invalid";
			if (flag)
			{
				api.error("[ERROR] Connect Veuqx Support! (Application)");
				Environment.Exit(0);
			}
			text2 = encryption.decrypt(text2, this.secret, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			bool success = response_structure.success;
			if (success)
			{
				this.load_app_data(response_structure.appinfo);
				this.sessionid = response_structure.sessionid;
				this.initzalized = true;
			}
			else
			{
				bool flag2 = response_structure.message == "[ERROR] Old Version!";
				if (flag2)
				{
					this.app_data.downloadLink = response_structure.download;
				}
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000012 RID: 18 RVA: 0x00002518 File Offset: 0x00002518
		public static bool IsDebugRelease
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06000013 RID: 19 RVA: 0x0000252C File Offset: 0x0000252C
		public void Checkinit()
		{
			bool flag = !this.initzalized;
			if (flag)
			{
				bool isDebugRelease = api.IsDebugRelease;
				if (isDebugRelease)
				{
					api.error("[ERROR] Connect Veuqx Support!, Wifi or ...");
				}
				else
				{
					api.error("[ERROR] Connect Veuqx Support!, initialize first");
				}
			}
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002570 File Offset: 0x00002570
		public void register(string username, string pass, string key)
		{
			this.Checkinit();
			string value = WindowsIdentity.GetCurrent().User.Value;
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("register"));
			nameValueCollection["username"] = encryption.encrypt(username, this.enckey, text);
			nameValueCollection["pass"] = encryption.encrypt(pass, this.enckey, text);
			nameValueCollection["key"] = encryption.encrypt(key, this.enckey, text);
			nameValueCollection["hwid"] = encryption.encrypt(value, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			NameValueCollection post_data = nameValueCollection;
			string text2 = api.req(post_data);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			bool success = response_structure.success;
			if (success)
			{
				this.load_user_data(response_structure.info);
			}
		}

		// Token: 0x06000015 RID: 21 RVA: 0x000026E4 File Offset: 0x000026E4
		public void login(string username, string pass)
		{
			this.Checkinit();
			string value = WindowsIdentity.GetCurrent().User.Value;
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("login"));
			nameValueCollection["username"] = encryption.encrypt(username, this.enckey, text);
			nameValueCollection["pass"] = encryption.encrypt(pass, this.enckey, text);
			nameValueCollection["hwid"] = encryption.encrypt(value, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			NameValueCollection post_data = nameValueCollection;
			string text2 = api.req(post_data);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			bool success = response_structure.success;
			if (success)
			{
				this.load_user_data(response_structure.info);
			}
		}

		// Token: 0x06000016 RID: 22 RVA: 0x0000283C File Offset: 0x0000283C
		public void upgrade(string username, string key)
		{
			this.Checkinit();
			string value = WindowsIdentity.GetCurrent().User.Value;
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("upgrade"));
			nameValueCollection["username"] = encryption.encrypt(username, this.enckey, text);
			nameValueCollection["key"] = encryption.encrypt(key, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			NameValueCollection post_data = nameValueCollection;
			string text2 = api.req(post_data);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			response_structure.success = false;
			this.load_response_struct(response_structure);
		}

		// Token: 0x06000017 RID: 23 RVA: 0x0000296C File Offset: 0x0000296C
		public void license(string key)
		{
			this.Checkinit();
			string value = WindowsIdentity.GetCurrent().User.Value;
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("license"));
			nameValueCollection["key"] = encryption.encrypt(key, this.enckey, text);
			nameValueCollection["hwid"] = encryption.encrypt(value, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			NameValueCollection post_data = nameValueCollection;
			string text2 = api.req(post_data);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			bool success = response_structure.success;
			if (success)
			{
				this.load_user_data(response_structure.info);
			}
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00002AAC File Offset: 0x00002AAC
		public void check()
		{
			this.Checkinit();
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("check"));
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			NameValueCollection post_data = nameValueCollection;
			string text2 = api.req(post_data);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure data = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(data);
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00002B8C File Offset: 0x00002B8C
		public void setvar(string var, string data)
		{
			this.Checkinit();
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("setvar"));
			nameValueCollection["var"] = encryption.encrypt(var, this.enckey, text);
			nameValueCollection["data"] = encryption.encrypt(data, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			NameValueCollection post_data = nameValueCollection;
			string text2 = api.req(post_data);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure data2 = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(data2);
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00002CA0 File Offset: 0x00002CA0
		public string getvar(string var)
		{
			this.Checkinit();
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("getvar"));
			nameValueCollection["var"] = encryption.encrypt(var, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			NameValueCollection post_data = nameValueCollection;
			string text2 = api.req(post_data);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			bool success = response_structure.success;
			string result;
			if (success)
			{
				result = response_structure.response;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00002DB8 File Offset: 0x00002DB8
		public void ban()
		{
			this.Checkinit();
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("ban"));
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			NameValueCollection post_data = nameValueCollection;
			string text2 = api.req(post_data);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure data = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(data);
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00002E98 File Offset: 0x00002E98
		public string var(string varid)
		{
			this.Checkinit();
			string value = WindowsIdentity.GetCurrent().User.Value;
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("var"));
			nameValueCollection["varid"] = encryption.encrypt(varid, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			NameValueCollection post_data = nameValueCollection;
			string text2 = api.req(post_data);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			bool success = response_structure.success;
			string result;
			if (success)
			{
				result = response_structure.message;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00002FC4 File Offset: 0x00002FC4
		public List<api.msg> chatget(string channelname)
		{
			this.Checkinit();
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("chatget"));
			nameValueCollection["channel"] = encryption.encrypt(channelname, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			NameValueCollection post_data = nameValueCollection;
			string text2 = api.req(post_data);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			bool success = response_structure.success;
			List<api.msg> result;
			if (success)
			{
				result = response_structure.messages;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600001E RID: 30 RVA: 0x000030DC File Offset: 0x000030DC
		public bool chatsend(string msg, string channelname)
		{
			this.Checkinit();
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("chatsend"));
			nameValueCollection["message"] = encryption.encrypt(msg, this.enckey, text);
			nameValueCollection["channel"] = encryption.encrypt(channelname, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			NameValueCollection post_data = nameValueCollection;
			string text2 = api.req(post_data);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			return response_structure.success;
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00003208 File Offset: 0x00003208
		public bool checkblack()
		{
			this.Checkinit();
			string value = WindowsIdentity.GetCurrent().User.Value;
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("checkblacklist"));
			nameValueCollection["hwid"] = encryption.encrypt(value, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			NameValueCollection post_data = nameValueCollection;
			string text2 = api.req(post_data);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			return response_structure.success;
		}

		// Token: 0x06000020 RID: 32 RVA: 0x0000332C File Offset: 0x0000332C
		public string webhook(string webid, string param, string body = "", string conttype = "")
		{
			this.Checkinit();
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("webhook"));
			nameValueCollection["webid"] = encryption.encrypt(webid, this.enckey, text);
			nameValueCollection["params"] = encryption.encrypt(param, this.enckey, text);
			nameValueCollection["body"] = encryption.encrypt(body, this.enckey, text);
			nameValueCollection["conttype"] = encryption.encrypt(conttype, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			NameValueCollection post_data = nameValueCollection;
			string text2 = api.req(post_data);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			bool success = response_structure.success;
			string result;
			if (success)
			{
				result = response_structure.response;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00003490 File Offset: 0x00003490
		public byte[] download(string fileid)
		{
			this.Checkinit();
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("file"));
			nameValueCollection["fileid"] = encryption.encrypt(fileid, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			NameValueCollection post_data = nameValueCollection;
			string text2 = api.req(post_data);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			bool success = response_structure.success;
			byte[] result;
			if (success)
			{
				result = encryption.str_to_byte_arr(response_structure.contents);
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000022 RID: 34 RVA: 0x000035AC File Offset: 0x000035AC
		public void log(string message)
		{
			this.Checkinit();
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("log"));
			nameValueCollection["pcuser"] = encryption.encrypt(Environment.UserName, this.enckey, text);
			nameValueCollection["message"] = encryption.encrypt(message, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			NameValueCollection post_data = nameValueCollection;
			api.req(post_data);
		}

		// Token: 0x06000023 RID: 35 RVA: 0x000036A0 File Offset: 0x000036A0
		public static string checksum(string filename)
		{
			string result;
			using (MD5 md = MD5.Create())
			{
				using (FileStream fileStream = File.OpenRead(filename))
				{http://keyauth.win/api/1.0/
					byte[] value = md.ComputeHash(fileStream);
					result = BitConverter.ToString(value).Replace("-", "").ToLowerInvariant();
				}
			}
			return result;
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00003720 File Offset: 0x00003720
		public static void error(string message)
		{
			MessageBox.Show(message, "Project Veuqx", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			Environment.Exit(0);
		}

		// Token: 0x06000025 RID: 37 RVA: 0x0000373C File Offset: 0x0000373C
		private static string req(NameValueCollection post_data)
		{
			string result;
			try
			{
				using (WebClient webClient = new WebClient())
				{
					byte[] bytes = webClient.UploadValues("https://keyauth.win/api/1.0/", post_data);
					result = Encoding.Default.GetString(bytes);
				}
			}
			catch (WebException ex)
			{
				HttpWebResponse httpWebResponse = (HttpWebResponse)ex.Response;
				HttpStatusCode statusCode = httpWebResponse.StatusCode;
				HttpStatusCode httpStatusCode = statusCode;
				if (httpStatusCode != (HttpStatusCode)429)
				{
					api.error("[ERROR] Connect Veuqx Support!");
					Environment.Exit(0);
					result = "";
				}
				else
				{
					Thread.Sleep(1000);
					result = api.req(post_data);
				}
			}
			return result;
		}

		// Token: 0x06000026 RID: 38 RVA: 0x000037EC File Offset: 0x000037EC
		private void load_app_data(api.app_data_structure data)
		{
			this.app_data.numUsers = data.numUsers;
			this.app_data.numOnlineUsers = data.numOnlineUsers;
			this.app_data.numKeys = data.numKeys;
			this.app_data.version = data.version;
			this.app_data.customerPanelLink = data.customerPanelLink;
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00003854 File Offset: 0x00003854
		private void load_user_data(api.user_data_structure data)
		{
			this.user_data.username = data.username;
			this.user_data.ip = data.ip;
			this.user_data.hwid = data.hwid;
			this.user_data.createdate = data.createdate;
			this.user_data.lastlogin = data.lastlogin;
			this.user_data.subscriptions = data.subscriptions;
		}

		// Token: 0x06000028 RID: 40 RVA: 0x000038D0 File Offset: 0x000038D0
		public string expirydaysleft()
		{
			this.Checkinit();
			DateTime d = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Local);
			d = d.AddSeconds((double)long.Parse(this.user_data.subscriptions[0].expiry)).ToLocalTime();
			TimeSpan timeSpan = d - DateTime.Now;
			return Convert.ToString(timeSpan.Days.ToString() + " Days " + timeSpan.Hours.ToString() + " Hours Left");
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00003968 File Offset: 0x00003968
		private void load_response_struct(api.response_structure data)
		{
			this.response.success = data.success;
			this.response.message = data.message;
		}

		// Token: 0x04000003 RID: 3
		public string name;

		// Token: 0x04000004 RID: 4
		public string ownerid;

		// Token: 0x04000005 RID: 5
		public string secret;

		// Token: 0x04000006 RID: 6
		public string version;

		// Token: 0x04000007 RID: 7
		private string sessionid;

		// Token: 0x04000008 RID: 8
		private string enckey;

		// Token: 0x04000009 RID: 9
		private bool initzalized;

		// Token: 0x0400000A RID: 10
		public api.app_data_class app_data = new api.app_data_class();

		// Token: 0x0400000B RID: 11
		public api.user_data_class user_data = new api.user_data_class();

		// Token: 0x0400000C RID: 12
		public api.response_class response = new api.response_class();

		// Token: 0x0400000D RID: 13
		private json_wrapper response_decoder = new json_wrapper(new api.response_structure());

		// Token: 0x0200000A RID: 10
		[DataContract]
		private class response_structure
		{
			// Token: 0x17000010 RID: 16
			// (get) Token: 0x060000B8 RID: 184 RVA: 0x00018C66 File Offset: 0x00018C66
			// (set) Token: 0x060000B9 RID: 185 RVA: 0x00018C6E File Offset: 0x00018C6E
			[DataMember]
			public bool success { get; set; }

			// Token: 0x17000011 RID: 17
			// (get) Token: 0x060000BA RID: 186 RVA: 0x00018C77 File Offset: 0x00018C77
			// (set) Token: 0x060000BB RID: 187 RVA: 0x00018C7F File Offset: 0x00018C7F
			[DataMember]
			public string sessionid { get; set; }

			// Token: 0x17000012 RID: 18
			// (get) Token: 0x060000BC RID: 188 RVA: 0x00018C88 File Offset: 0x00018C88
			// (set) Token: 0x060000BD RID: 189 RVA: 0x00018C90 File Offset: 0x00018C90
			[DataMember]
			public string contents { get; set; }

			// Token: 0x17000013 RID: 19
			// (get) Token: 0x060000BE RID: 190 RVA: 0x00018C99 File Offset: 0x00018C99
			// (set) Token: 0x060000BF RID: 191 RVA: 0x00018CA1 File Offset: 0x00018CA1
			[DataMember]
			public string response { get; set; }

			// Token: 0x17000014 RID: 20
			// (get) Token: 0x060000C0 RID: 192 RVA: 0x00018CAA File Offset: 0x00018CAA
			// (set) Token: 0x060000C1 RID: 193 RVA: 0x00018CB2 File Offset: 0x00018CB2
			[DataMember]
			public string message { get; set; }

			// Token: 0x17000015 RID: 21
			// (get) Token: 0x060000C2 RID: 194 RVA: 0x00018CBB File Offset: 0x00018CBB
			// (set) Token: 0x060000C3 RID: 195 RVA: 0x00018CC3 File Offset: 0x00018CC3
			[DataMember]
			public string download { get; set; }

			// Token: 0x17000016 RID: 22
			// (get) Token: 0x060000C4 RID: 196 RVA: 0x00018CCC File Offset: 0x00018CCC
			// (set) Token: 0x060000C5 RID: 197 RVA: 0x00018CD4 File Offset: 0x00018CD4
			[DataMember(IsRequired = false, EmitDefaultValue = false)]
			public api.user_data_structure info { get; set; }

			// Token: 0x17000017 RID: 23
			// (get) Token: 0x060000C6 RID: 198 RVA: 0x00018CDD File Offset: 0x00018CDD
			// (set) Token: 0x060000C7 RID: 199 RVA: 0x00018CE5 File Offset: 0x00018CE5
			[DataMember(IsRequired = false, EmitDefaultValue = false)]
			public api.app_data_structure appinfo { get; set; }

			// Token: 0x17000018 RID: 24
			// (get) Token: 0x060000C8 RID: 200 RVA: 0x00018CEE File Offset: 0x00018CEE
			// (set) Token: 0x060000C9 RID: 201 RVA: 0x00018CF6 File Offset: 0x00018CF6
			[DataMember]
			public List<api.msg> messages { get; set; }
		}

		// Token: 0x0200000B RID: 11
		public class msg
		{
			// Token: 0x17000019 RID: 25
			// (get) Token: 0x060000CB RID: 203 RVA: 0x00018D08 File Offset: 0x00018D08
			// (set) Token: 0x060000CC RID: 204 RVA: 0x00018D10 File Offset: 0x00018D10
			public string message { get; set; }

			// Token: 0x1700001A RID: 26
			// (get) Token: 0x060000CD RID: 205 RVA: 0x00018D19 File Offset: 0x00018D19
			// (set) Token: 0x060000CE RID: 206 RVA: 0x00018D21 File Offset: 0x00018D21
			public string author { get; set; }

			// Token: 0x1700001B RID: 27
			// (get) Token: 0x060000CF RID: 207 RVA: 0x00018D2A File Offset: 0x00018D2A
			// (set) Token: 0x060000D0 RID: 208 RVA: 0x00018D32 File Offset: 0x00018D32
			public string timestamp { get; set; }
		}

		// Token: 0x0200000C RID: 12
		[DataContract]
		private class user_data_structure
		{
			// Token: 0x1700001C RID: 28
			// (get) Token: 0x060000D2 RID: 210 RVA: 0x00018D44 File Offset: 0x00018D44
			// (set) Token: 0x060000D3 RID: 211 RVA: 0x00018D4C File Offset: 0x00018D4C
			[DataMember]
			public string username { get; set; }

			// Token: 0x1700001D RID: 29
			// (get) Token: 0x060000D4 RID: 212 RVA: 0x00018D55 File Offset: 0x00018D55
			// (set) Token: 0x060000D5 RID: 213 RVA: 0x00018D5D File Offset: 0x00018D5D
			[DataMember]
			public string ip { get; set; }

			// Token: 0x1700001E RID: 30
			// (get) Token: 0x060000D6 RID: 214 RVA: 0x00018D66 File Offset: 0x00018D66
			// (set) Token: 0x060000D7 RID: 215 RVA: 0x00018D6E File Offset: 0x00018D6E
			[DataMember]
			public string hwid { get; set; }

			// Token: 0x1700001F RID: 31
			// (get) Token: 0x060000D8 RID: 216 RVA: 0x00018D77 File Offset: 0x00018D77
			// (set) Token: 0x060000D9 RID: 217 RVA: 0x00018D7F File Offset: 0x00018D7F
			[DataMember]
			public string createdate { get; set; }

			// Token: 0x17000020 RID: 32
			// (get) Token: 0x060000DA RID: 218 RVA: 0x00018D88 File Offset: 0x00018D88
			// (set) Token: 0x060000DB RID: 219 RVA: 0x00018D90 File Offset: 0x00018D90
			[DataMember]
			public string lastlogin { get; set; }

			// Token: 0x17000021 RID: 33
			// (get) Token: 0x060000DC RID: 220 RVA: 0x00018D99 File Offset: 0x00018D99
			// (set) Token: 0x060000DD RID: 221 RVA: 0x00018DA1 File Offset: 0x00018DA1
			[DataMember]
			public List<api.Data> subscriptions { get; set; }
		}

		// Token: 0x0200000D RID: 13
		[DataContract]
		private class app_data_structure
		{
			// Token: 0x17000022 RID: 34
			// (get) Token: 0x060000DF RID: 223 RVA: 0x00018DB3 File Offset: 0x00018DB3
			// (set) Token: 0x060000E0 RID: 224 RVA: 0x00018DBB File Offset: 0x00018DBB
			[DataMember]
			public string numUsers { get; set; }

			// Token: 0x17000023 RID: 35
			// (get) Token: 0x060000E1 RID: 225 RVA: 0x00018DC4 File Offset: 0x00018DC4
			// (set) Token: 0x060000E2 RID: 226 RVA: 0x00018DCC File Offset: 0x00018DCC
			[DataMember]
			public string numOnlineUsers { get; set; }

			// Token: 0x17000024 RID: 36
			// (get) Token: 0x060000E3 RID: 227 RVA: 0x00018DD5 File Offset: 0x00018DD5
			// (set) Token: 0x060000E4 RID: 228 RVA: 0x00018DDD File Offset: 0x00018DDD
			[DataMember]
			public string numKeys { get; set; }

			// Token: 0x17000025 RID: 37
			// (get) Token: 0x060000E5 RID: 229 RVA: 0x00018DE6 File Offset: 0x00018DE6
			// (set) Token: 0x060000E6 RID: 230 RVA: 0x00018DEE File Offset: 0x00018DEE
			[DataMember]
			public string version { get; set; }

			// Token: 0x17000026 RID: 38
			// (get) Token: 0x060000E7 RID: 231 RVA: 0x00018DF7 File Offset: 0x00018DF7
			// (set) Token: 0x060000E8 RID: 232 RVA: 0x00018DFF File Offset: 0x00018DFF
			[DataMember]
			public string customerPanelLink { get; set; }

			// Token: 0x17000027 RID: 39
			// (get) Token: 0x060000E9 RID: 233 RVA: 0x00018E08 File Offset: 0x00018E08
			// (set) Token: 0x060000EA RID: 234 RVA: 0x00018E10 File Offset: 0x00018E10
			[DataMember]
			public string downloadLink { get; set; }
		}

		// Token: 0x0200000E RID: 14
		public class app_data_class
		{
			// Token: 0x17000028 RID: 40
			// (get) Token: 0x060000EC RID: 236 RVA: 0x00018E22 File Offset: 0x00018E22
			// (set) Token: 0x060000ED RID: 237 RVA: 0x00018E2A File Offset: 0x00018E2A
			public string numUsers { get; set; }

			// Token: 0x17000029 RID: 41
			// (get) Token: 0x060000EE RID: 238 RVA: 0x00018E33 File Offset: 0x00018E33
			// (set) Token: 0x060000EF RID: 239 RVA: 0x00018E3B File Offset: 0x00018E3B
			public string numOnlineUsers { get; set; }

			// Token: 0x1700002A RID: 42
			// (get) Token: 0x060000F0 RID: 240 RVA: 0x00018E44 File Offset: 0x00018E44
			// (set) Token: 0x060000F1 RID: 241 RVA: 0x00018E4C File Offset: 0x00018E4C
			public string numKeys { get; set; }

			// Token: 0x1700002B RID: 43
			// (get) Token: 0x060000F2 RID: 242 RVA: 0x00018E55 File Offset: 0x00018E55
			// (set) Token: 0x060000F3 RID: 243 RVA: 0x00018E5D File Offset: 0x00018E5D
			public string version { get; set; }

			// Token: 0x1700002C RID: 44
			// (get) Token: 0x060000F4 RID: 244 RVA: 0x00018E66 File Offset: 0x00018E66
			// (set) Token: 0x060000F5 RID: 245 RVA: 0x00018E6E File Offset: 0x00018E6E
			public string customerPanelLink { get; set; }

			// Token: 0x1700002D RID: 45
			// (get) Token: 0x060000F6 RID: 246 RVA: 0x00018E77 File Offset: 0x00018E77
			// (set) Token: 0x060000F7 RID: 247 RVA: 0x00018E7F File Offset: 0x00018E7F
			public string downloadLink { get; set; }
		}

		// Token: 0x0200000F RID: 15
		public class user_data_class
		{
			// Token: 0x1700002E RID: 46
			// (get) Token: 0x060000F9 RID: 249 RVA: 0x00018E91 File Offset: 0x00018E91
			// (set) Token: 0x060000FA RID: 250 RVA: 0x00018E99 File Offset: 0x00018E99
			public string username { get; set; }

			// Token: 0x1700002F RID: 47
			// (get) Token: 0x060000FB RID: 251 RVA: 0x00018EA2 File Offset: 0x00018EA2
			// (set) Token: 0x060000FC RID: 252 RVA: 0x00018EAA File Offset: 0x00018EAA
			public string ip { get; set; }

			// Token: 0x17000030 RID: 48
			// (get) Token: 0x060000FD RID: 253 RVA: 0x00018EB3 File Offset: 0x00018EB3
			// (set) Token: 0x060000FE RID: 254 RVA: 0x00018EBB File Offset: 0x00018EBB
			public string hwid { get; set; }

			// Token: 0x17000031 RID: 49
			// (get) Token: 0x060000FF RID: 255 RVA: 0x00018EC4 File Offset: 0x00018EC4
			// (set) Token: 0x06000100 RID: 256 RVA: 0x00018ECC File Offset: 0x00018ECC
			public string createdate { get; set; }

			// Token: 0x17000032 RID: 50
			// (get) Token: 0x06000101 RID: 257 RVA: 0x00018ED5 File Offset: 0x00018ED5
			// (set) Token: 0x06000102 RID: 258 RVA: 0x00018EDD File Offset: 0x00018EDD
			public string lastlogin { get; set; }

			// Token: 0x17000033 RID: 51
			// (get) Token: 0x06000103 RID: 259 RVA: 0x00018EE6 File Offset: 0x00018EE6
			// (set) Token: 0x06000104 RID: 260 RVA: 0x00018EEE File Offset: 0x00018EEE
			public List<api.Data> subscriptions { get; set; }
		}

		// Token: 0x02000010 RID: 16
		public class Data
		{
			// Token: 0x17000034 RID: 52
			// (get) Token: 0x06000106 RID: 262 RVA: 0x00018F00 File Offset: 0x00018F00
			// (set) Token: 0x06000107 RID: 263 RVA: 0x00018F08 File Offset: 0x00018F08
			public string subscription { get; set; }

			// Token: 0x17000035 RID: 53
			// (get) Token: 0x06000108 RID: 264 RVA: 0x00018F11 File Offset: 0x00018F11
			// (set) Token: 0x06000109 RID: 265 RVA: 0x00018F19 File Offset: 0x00018F19
			public string expiry { get; set; }

			// Token: 0x17000036 RID: 54
			// (get) Token: 0x0600010A RID: 266 RVA: 0x00018F22 File Offset: 0x00018F22
			// (set) Token: 0x0600010B RID: 267 RVA: 0x00018F2A File Offset: 0x00018F2A
			public string timeleft { get; set; }
		}

		// Token: 0x02000011 RID: 17
		public class response_class
		{
			// Token: 0x17000037 RID: 55
			// (get) Token: 0x0600010D RID: 269 RVA: 0x00018F3C File Offset: 0x00018F3C
			// (set) Token: 0x0600010E RID: 270 RVA: 0x00018F44 File Offset: 0x00018F44
			public bool success { get; set; }

			// Token: 0x17000038 RID: 56
			// (get) Token: 0x0600010F RID: 271 RVA: 0x00018F4D File Offset: 0x00018F4D
			// (set) Token: 0x06000110 RID: 272 RVA: 0x00018F55 File Offset: 0x00018F55
			public string message { get; set; }
		}
	}
}
