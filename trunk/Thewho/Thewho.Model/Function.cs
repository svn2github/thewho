using System;

namespace Thewho.Model
{
	public class Function
	{
		private Int32 _iD;

		public Int32 ID
		{
			get { return _iD; }
			set { _iD = value; }
		}

		private String _functionName;

		public String FunctionName
		{
			get { return _functionName; }
			set { _functionName = value; }
		}

		private String _functionUrl;

		public String FunctionUrl
		{
			get { return _functionUrl; }
			set { _functionUrl = value; }
		}

		private Int32 _fID;

		public Int32 FID
		{
			get { return _fID; }
			set { _fID = value; }
		}

		private String _remark;

		public String Remark
		{
			get { return _remark; }
			set { _remark = value; }
		}

		private Byte _functionType;

		public Byte FunctionType
		{
			get { return _functionType; }
			set { _functionType = value; }
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
