using System;

namespace Thewho.Model
{
	public class UserLogin
	{
		private Int32 _iD;

		public Int32 ID
		{
			get { return _iD; }
			set { _iD = value; }
		}

		private Int32 _uID;

		public Int32 UID
		{
			get { return _uID; }
			set { _uID = value; }
		}

		private String _email;

		public String Email
		{
			get { return _email; }
			set { _email = value; }
		}

		private DateTime _loginTime;

		public DateTime LoginTime
		{
			get { return _loginTime; }
			set { _loginTime = value; }
		}

		private String _loginIp;

		public String LoginIp
		{
			get { return _loginIp; }
			set { _loginIp = value; }
		}

		private Byte _result;

		public Byte Result
		{
			get { return _result; }
			set { _result = value; }
		}

	}
}
