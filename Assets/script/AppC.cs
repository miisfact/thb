using UnityEngine;
using System.Collections;

public class AppC : MonoBehaviour {

	private static AppCCloud appCCloud;
	
	void Awake() {
		// appC cloud開始：使用するAPIをセット
		// iOSはコードから.SetMK_iOS(media_key)でメディアキーをセット
		// AndroidはAndroidManifest.xmlへメディアキーを記述してください
		appCCloud = new AppCCloud().SetMK_iOS ("b9f1782ce997529736a29a35c1eac9b07cfb8963")
			.On (AppCCloud.API.Purchase) // アイテムSTORE機能 ON
				.On (AppCCloud.API.Gamers) // GAMERS機能 ON
				.Start ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
