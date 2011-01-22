using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackRain.Common.Contracts
{
	public interface INamed
	{
		#region Properties

		string Name { get; }

		#endregion
	}
}