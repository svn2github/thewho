using System;

namespace Thewho.Model
{
	public class UserInfo
	{
		private Int32 _iD;

		public Int32 ID
		{
			get { return _iD; }
			set { _iD = value; }
		}

		private String _trueName;

		public String TrueName
		{
			get { return _trueName; }
			set { _trueName = value; }
		}

		private String _email;

		public String Email
		{
			get { return _email; }
			set { _email = value; }
		}

		private Int32 _groupID;

		public Int32 GroupID
		{
			get { return _groupID; }
			set { _groupID = value; }
		}

		private Byte _sex;

		public Byte Sex
		{
			get { return _sex; }
			set { _sex = value; }
		}

		private DateTime _birthday;

		public DateTime Birthday
		{
			get { return _birthday; }
			set { _birthday = value; }
		}

		private String _regIp;

		public String RegIp
		{
			get { return _regIp; }
			set { _regIp = value; }
		}

		private DateTime _regTime;

		public DateTime RegTime
		{
			get { return _regTime; }
			set { _regTime = value; }
		}

		private Byte _status;

		public Byte Status
		{
			get { return _status; }
			set { _status = value; }
		}

	}
}
