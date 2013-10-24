
namespace Kogarasi.Admob {

	public interface IAdmob {

		void Init( string android_id, string ios_id );
		void SetVisibility( bool visibility );
	}
}