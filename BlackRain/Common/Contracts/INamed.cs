using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackRain.Common.Contracts
{
	/// <summary>
	/// Describes a <see cref="Objects.WowObject"/> that contains a string name represented by a <see cref="Name"/>
	/// property.
	/// </summary>
	public interface INamed
	{
		#region Properties

		/// <summary>
		/// Gets the name of the <see cref="Objects.WowObject"/>
		/// </summary>
		string Name { get; }

		#endregion
	}
}