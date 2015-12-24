using UnityEngine;
using System.Collections;
using NendUnityPlugin.AD;

public class afi : MonoBehaviour {

	const string IMOBILE_ICON_PID = "25576";
	const string IMOBILE_ICON_MID = "217102";
	const string IMOBILE_ICON_SID = "628803";
	
	const string IMOBILE_INTERSTITIAL_PID = "25576";
	const string IMOBILE_INTERSTITIAL_MID = "217102";
	const string IMOBILE_INTERSTITIAL_SID = "695517";
	// Use this for initialization

	const string IMOBILE_BANNER_PID = "25576";
	const string IMOBILE_BANNER_MID = "237286";
	const string IMOBILE_BANNER_SID = "695841";

	void Start () {
		#if UNITY_IPHONE || UNITY_ANDROID && !UNITY_EDITOR
		// スポット情報を設定します
		IMobileSdkAdsUnityPlugin.registerInline(IMOBILE_BANNER_PID, IMOBILE_BANNER_MID, IMOBILE_BANNER_SID);
		// 広告の取得を開始します
		IMobileSdkAdsUnityPlugin.start(IMOBILE_BANNER_SID);
		// 広告の表示位置を指定して表示します(画面中央下)
		IMobileSdkAdsUnityPlugin.show(IMOBILE_BANNER_SID,
		                              IMobileSdkAdsUnityPlugin.AdType.BANNER,
		                              IMobileSdkAdsUnityPlugin.AdAlignPosition.CENTER,
		                              IMobileSdkAdsUnityPlugin.AdValignPosition.BOTTOM);

		NendAdInterstitial.Instance.Load("5b3604a63d9e8c7ca2f34920eca24e2122f7a1e7", "504900");
		// 通常表示
		NendAdInterstitial.Instance.Show();

		#endif

	}
	
	// Update is called once per frame
	void Update () {
	

	}
}
