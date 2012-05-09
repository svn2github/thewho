using System;

namespace Thewho.Model
{
	public class UserGroup
	{
		private Int32 _iD;

		public Int32 ID
		{
			get { return _iD; }
			set { _iD = value; }
		}

		private String _groupName;

		public String GroupName
		{
			get { return _groupName; }
			set { _groupName = value; }
		}

		private Int32 _fID;

		public Int32 FID
		{
			get { return _fID; }
			set { _fID = value; }
		}

		private DateTime _addTime;

		public DateTime AddTime
		{
			get { return _addTime; }
			set { _addTime = value; }
		}

		private Byte _status;

		public Byte Status
		{
			get { return _status; }
			set { _status = value; }
		}

	}
}
