using System;

namespace Thewho.Model
{
	public class Permission
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

		private Int32 _functionID;

		public Int32 FunctionID
		{
			get { return _functionID; }
			set { _functionID = value; }
		}

		private Byte _type;

		public Byte Type
		{
			get { return _type; }
			set { _type = value; }
		}

		private DateTime _addtime;

		public DateTime Addtime
		{
			get { return _addtime; }
			set { _addtime = value; }
		}

		private Byte _status;

		public Byte Status
		{
			get { return _status; }
			set { _status = value; }
		}

	}
}
