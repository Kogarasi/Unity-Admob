using UnityEngine;

namespace Kogarasi.Admob{
#if UNITY_ANDROID

	public class AdmobAndroidInterface : IAdmob {

		AndroidJavaObject adView = null;

		public void Init( string android_id, string ios_id ){
			adView = new AndroidJavaObject( "com.kogarasi.unity.admob.AdmobPlugin" );
			adView.Call( "Init", android_id );

		}

		public void SetVisibility( bool visibility ){
			adView.Call( "setVisibility", visibility );
		}
	}
#endif
}