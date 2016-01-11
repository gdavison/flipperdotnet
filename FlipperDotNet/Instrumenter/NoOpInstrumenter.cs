﻿using FlipperDotNet.Instrumenter;

namespace FlipperDotNet.Instrumenter
{
	public class NoOpInstrumenter : IInstrumenter
	{
		public IInstrumentationToken Instrument(string name, InstrumentationPayload payload)
		{
			return new InstrumentationToken();
		}

		internal class InstrumentationToken : IInstrumentationToken
		{
			public void Dispose()
			{ }
		}
	}
}

