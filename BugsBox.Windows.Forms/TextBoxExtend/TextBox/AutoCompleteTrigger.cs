using System;
using System.Windows.Forms;

namespace BugsBox.Windows.Forms.Input
{
	/// <summary>
	/// Summary description for AutoCompleteTrigger.
	/// </summary>
	[Serializable]
	public abstract class AutoCompleteTrigger
	{
		public virtual TriggerState OnTextChanged(string text)
		{
			return TriggerState.None;
		}
		
		public virtual TriggerState OnCommandKey(Keys keyData)
		{
			return TriggerState.None;
		}
	}
}
