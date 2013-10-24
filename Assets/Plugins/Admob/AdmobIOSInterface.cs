using UnityEngine;
using System;
using System.Collections;
using System.Runtime.InteropServices;


namespace Kogarasi.Admob {
	public class AdmobIOSInterface : IAdmob {

		private IntPtr instance;

		public void Init( string android_id, string ios_id ){
			instance = _AdmobPlugin_Init( ios_id );

		}
		public void SetVisibility( bool visibility ){
			_AdmobPlugin_SetVisibility( instance, visibility );
		}

		[DllImport("__Internal")]
		private static extern IntPtr _AdmobPlugin_Init( string admob_id );

		[DllImport("__Internal")]
		private static extern void _AdmobPlugin_SetVisibility( IntPtr instance, bool visibility );
	}
}