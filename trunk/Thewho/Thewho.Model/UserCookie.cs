using System;

namespace Thewho.Model
{
	public class UserCookie
	{
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

		private String _password;

		public String Password
		{
			get { return _password; }
			set { _password = value; }
		}

		private String _salt;

		public String Salt
		{
			get { return _salt; }
			set { _salt = value; }
		}

		private DateTime _outTime;

		public DateTime OutTime
		{
			get { return _outTime; }
			set { _outTime = value; }
		}

	}
}
