using UnityEngine;
using System.Collections;

namespace Kogarasi.Admob {
	public class AdmobNullInterface : IAdmob {

		public void Init( string android_id, string ios_id ){}
		public void SetVisibility( bool visibility ){}

	}
}