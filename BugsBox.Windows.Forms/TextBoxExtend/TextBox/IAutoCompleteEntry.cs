using System;

namespace BugsBox.Windows.Forms.Input
{
	/// <summary>
	/// Summary description for IAutoCompleteEntry.
	/// </summary>
	public interface IAutoCompleteEntry
	{
		string[] MatchStrings
		{
			get;
		}

	}
}
