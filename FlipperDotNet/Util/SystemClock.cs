﻿using System;

namespace FlipperDotNet.Util
{
	public class SystemClock : IClock
	{
		public DateTime Now {
			get{ return DateTime.Now; }
		}
	}
}

