using UnityEngine;
using System.Collections;

public class endtext : MonoBehaviour {

	public GUIText txt;
	public GUIText txtchar;
	public int t;
	float time = 0.0f;


	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
						time = time + Time.deltaTime;
						if (time >= 2.0f) {
								Text ();
								time = -2;
						} else {
								txt = this.GetComponent<GUIText> ();
						}


		}
	void Text(){
				txt = this.GetComponent<GUIText> ();
				if (t == 0) {
						txtchar.text = "紫";
						txt.text = "ここも随分賑やかになったわねぇ";
						t = 1;
				} else if (t == 1) {
						txtchar.text = "霊夢";
						txt.text = "あ、紫じゃない。まだ冬眠の時期じゃなかったっけ";
						t = 2;
				} else if (t == 2) {
						txtchar.text = "紫";
						txt.text = "ふふ、何だか楽しそうだったからつい、ね。\n魔理沙がどうかしたの？";
						t = 3;
				} else if (t == 3) {
						txtchar.text = "霊夢";
						txt.text = "お金儲けできるかと思ったから店やってんのにさぁ";
						t = 4;
				} else if (t == 4) {
						txtchar.text = "紫";
						txt.text = "あら、この様子だと大分潤ったんじゃないの？";
						time = -1;
						t = 5;
				} else if (t == 5) {
						txtchar.text = "霊夢";
						txt.text = "結局施設の維持費やら何やらで\n私の手元にはほとんどお金残ってないっつーの";
						t = 6;
				} else if (t == 6) {
						txt.text = "ま、新しいお賽銭箱に替えれただけでもマシかな";
						t = 7;
				} else if (t == 7) {
						txtchar.text = " ";
						txt.text = "おーいれいむー";
						t = 8;
				} else if (t == 8) {
						txtchar.text = "紫"; 
						txt.text = "表で誰か呼んでるわよ？";
						t = 9;
				} else if (t == 9) {
						txtchar.text = "霊夢";
			            txt.text = "そーみたいね。はいはい今いくわー";
						t = 10;
				} else if (t == 10) {
						txtchar.text = " ";
						txt.text = "こうして今日もいつもと変わらないけど\nちょっとだけ賑やかになった博麗神社で\n霊夢の一日が始まるのであった\n               　　　　                                    おしまい ";
			            time = -30;
			            t=11; 
		        } else if (t == 11) {
			             t = 0;
			            FadeManager.Instance.LoadLevel("main",1.0f);
				}


		         

		}


	}

