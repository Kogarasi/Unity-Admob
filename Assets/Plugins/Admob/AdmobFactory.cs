
namespace Kogarasi.Admob {

	public class AdmobFactory {

		public static IAdmob create(){

#if UNITY_EDITOR
			return new AdmobNullInterface();
#elif UNITY_ANDROID
			return new AdmobAndroidInterface();
#elif UNITY_IPHONE
			return new AdmobIOSInterface();
#else 
			return new AdmobNullInterface();
#endif
		}
	}
}