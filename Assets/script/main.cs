using UnityEngine;
using System.Collections;

public class main : MonoBehaviour {

	private float fwidth=900;
	private float fheight=600;
	public float width;
	public float height;
	public float sw;
	public float sh;
	public GUIStyle buttonStyle;
	public float buttonsize=25;
	public float buttonsize2=17;
	public float aspect;

	public Texture[] buttonTexture;
	public GameObject[] charTexture;
	public GUIText[] menu;
	public GUIText[] text1;

	public int stop;
	public int stopmusic;
	public GameObject[] music;

	public int r;

	public int TextDeg;
	public int Textv;
	public int TextP;
	public string[] chartext;



	public int[] maplv;
	public int day;
	public int syuueki;
	public int syuueki2;
	public int syuueki3;
	public int money;
	public int money2;
	public int money3;

	public string[] buttonmoney;
	public string[] buttonmoney1;

	public string[] savemaplv1;
	public string savemaplv;

	public string savemoney;
	public string[] savemoneys;
	public int[] savemoneyi;
	public int[] mapsyuueki;

	public int[] mapste1;


	public float startTime = 2.0f;
	public float timer;

	private string Data1 = "trbsaveday";
	private string Data2 = "trbmoney";
	private string Data3 = "trbsyuueki";
	private string Data4 = "trbmoney2";
	private string Data5 = "trbsyuueki2";

	private string Data6 = "trbmaplv";
	private string Data7 = "trbmapmapmoney";

	public int save3;
	public int score;
	public int savesyuu;
	private string savesyuueki = "savesyuu";
	private string savescore = "savescore";

	public int upscore;

	const string IMOBILE_ICON_PID = "25576";
	const string IMOBILE_ICON_MID = "217102";
	const string IMOBILE_ICON_SID = "628803";

	#if UNITY_IPHONE || UNITY_ANDROID && !UNITY_EDITOR
	private AppCCloud appCCloud;
	#endif
	// Use this for initialization
	void Start () {
		
		width = Screen.width;
		height = Screen.height;
		aspect = width / height;
		sw = width / fwidth;
		sh = height / fheight;
		aspect = width / height;
		if (aspect <= 1.55) {
		}
		if (aspect <= 1.6 && aspect > 1.45) {
			sw = width / (fwidth + 50);
		}
		if (aspect <= 1.7 && aspect > 1.6) {
			sw = width / (fwidth + 70);
		}
		if (aspect > 1.7) {
			sw = width / (fwidth + 110);
		}
		buttonsize = buttonsize * sw;
		buttonsize2 = buttonsize2 * sw;

		day = PlayerPrefs.GetInt(Data1, 1);
		money = PlayerPrefs.GetInt(Data2, 100);
		syuueki = PlayerPrefs.GetInt(Data3, 0);
		money2 = PlayerPrefs.GetInt(Data4, 0);
		syuueki2 = PlayerPrefs.GetInt(Data5, 0);
		savemaplv = PlayerPrefs.GetString(Data6, "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0");
		savemoney = PlayerPrefs.GetString(Data7, "0,50,0,1500,0,10000,0,50000,0,200000,0,500000,0,1000000,0,3000000,0,7000000,0,15000000,0,30000000,0,50000000,0,80000000,0,1,2,3,5,10,20,50,99");
		savesyuu= PlayerPrefs.GetInt("scorepara1", 1);
		score = PlayerPrefs.GetInt("scoremoney1", 1);
		save3=PlayerPrefs.GetInt("trbsave3", 0);



		if (save3 == 0) {
			if(score>1000000000){
				money2+=10;
				score-=1000000000;
			}
			if(score>500000000){
				money2+=5;
				score-=500000000;
			}
			if(score>500000000){
				money2+=5;
				score-=500000000;
			}
			if(score>300000000){
				money2+=3;
				score-=300000000;
			}
			if(score>300000000){
				money2+=3;
				score-=300000000;
			}
			if(score>200000000){
				money2+=2;
				score-=200000000;
			}
			if(score>200000000){
				money2+=2;
				score-=200000000;
			}
			if(score>200000000){
				money2+=2;
				score-=200000000;
			}
			if(score>100000000){
				money2+=1;
				score-=100000000;
			}
			if(score>100000000){
				money2+=1;
				score-=100000000;
			}
			if(score>0){
			money+=score;
			}
			if(score!=1){
			money+=10000000;
			}
			PlayerPrefs.SetInt ("trbsave3",1);
		}

		savemaplv1 = savemaplv.Split(new char[] {','});
		for(int i=0;i<25;i++){
			maplv[i] = int.Parse(savemaplv1[i]);
		}
		savemoneys = savemoney.Split(new char[] {','});
		for(int i=0;i<35;i++){
			savemoneyi[i] = int.Parse(savemoneys[i]);
		}

		upscore=PlayerPrefs.GetInt("trbup1", 0);
		if (upscore == 0) {
			money=money*10;
			syuueki=syuueki*100;
			money2=money2*10;
			syuueki2=syuueki2*10;
			upscore=1;
			savemoneyi[34]=99;
			savemoneyi[33]=50;
			savemoneyi[32]=20;
			savemoneyi[31]=10;
			savemoneyi[30]=5;
			savemoneyi[29]=3;
			savemoneyi[28]=2;
			
		}
		music[0]=GameObject.Find("BGM");

		reset();
		syuuekik ();
		moneyk ();
		mapmoneyk ();
		texts ();
		#if UNITY_IPHONE || UNITY_ANDROID && !UNITY_EDITOR
		appCCloud = new AppCCloud().SetMK_iOS ("b9f1782ce997529736a29a35c1eac9b07cfb8963")
			.On (AppCCloud.API.Gamers) // GAMERS機能 ON // アイテムSTORE機能 ON
				.Start ();
		#endif
	}

	
	private void reset()
	{
		timer = startTime;
	}

	// Update is called once per frame
	void Update () {
		menu [1].text = day.ToString ();
		menu [2].text = syuueki.ToString ();
		if (syuueki2 > 0) {
						menu [2].text = syuueki2.ToString () +"億"+ syuueki.ToString ();
				}
		if (syuueki3 > 0) {
			menu [2].text = syuueki3.ToString () +"京"+syuueki2.ToString () +"億"+ syuueki.ToString ();
		}
		menu [3].text = money.ToString ();
		if (money2 > 0) {
			menu [3].text = money2.ToString () +"億"+ money.ToString ();
		}
		if (money3 > 0) {
			menu [3].text = money3.ToString () +"京"+money2.ToString () +"億"+ money.ToString ();
		}
		timer -= Time.deltaTime;
		if (timer <= 0.0f) {
						dayk ();
						syuuekik ();
			            datasave ();
			            mapmoneyk ();
			            moneyk();
			texts();
			timer=2.0f;
				}
	}

	public void datasave(){
		for(int i=0;i<25;i++){
			savemaplv1[i]=maplv[i].ToString ();
		}
		savemaplv = string.Join(",", savemaplv1);

		for(int i=0;i<35;i++){
			savemoneys[i]=savemoneyi[i].ToString ();
		}
		savemoney = string.Join(",", savemoneys);

		PlayerPrefs.SetInt (Data1,day);
		PlayerPrefs.SetInt (Data2,money);
		PlayerPrefs.SetInt (Data3,syuueki);
		PlayerPrefs.SetInt (Data4,money2);
		PlayerPrefs.SetInt (Data5,syuueki2);
		PlayerPrefs.SetString (Data6,savemaplv);
		PlayerPrefs.SetString (Data7,savemoney);
		PlayerPrefs.SetInt("trbup1",upscore);
	}

	public void dayk(){
		day += 1;
		}

	public void syuuekik(){

		if (syuueki >= 100000000) {
		syuueki2 += 1;
		syuueki -= 100000000;
				}
		if (syuueki2 >= 100000000) {
			syuueki2 = 100000000;
		}
		if (syuueki3 >= 1000000000) {
			syuueki3 = 999999999;
		}
		money += syuueki;
		money2 += syuueki2;
		money3 += syuueki3;
	}
	public void moneyk(){
				if (money >= 100000000) {
						money2 += 1;
						money -= 100000000;
				}
				if (money2 >= 100000000) {
						money2 = 100000000;
				}
				if (money3 >= 1000000000) {
						money3 = 999999999;
				}
				mapste1 [3] = 1;
				for (int i=2; i<=21; i++) {
						if (maplv [i] >= 1) {
								mapste1 [3] += maplv [i] * i - 1;
						}
				}
				if (mapste1 [3] >= 1000000000) {
						mapste1 [3] = 999999999;
				}
				buttonmoney [1] = mapste1 [3].ToString ();
		}

	public void mapmoneyk(){
		for(int i=0;i<26;i++){
		savemoneys [i] = savemoneyi [i].ToString ();
		}
		for(int i=0;i<14;i++){
			savemoneys [i*2] = savemoneyi [i*2].ToString ()+"億";
		}
		for(int i=0;i<14;i++){
			if(savemoneyi [i*2]==0){
			savemoneys [i*2] ="";
			}
		}
		for(int i=27;i<35;i++){
			savemoneys [i] = savemoneyi [i].ToString ()+"億";
		}

		}


	public void texts(){
		if(TextDeg<25){
			Destroy(charTexture[0]);
			Textv=0;
			for(int i=2;i<21;i++){
				if(maplv[i]>0){
			Textv+=1;
				}
			}
			TextDeg=Random.Range (1,5+Textv);
		ctexts ();
		for (int i=1; i<5+Textv; i++) {

						if (TextDeg == i) {
					        charTexture[0] = (GameObject)GameObject.Instantiate(charTexture[i]);
							text1 [2].text = chartext [i];		
						}
				}

		}
		if (TextDeg >= 30&&TextP==0) {
			Destroy(charTexture[0]);
			for (int i=30; i<49; i++) {
				if(TextDeg == i) {
					charTexture[0] = (GameObject)GameObject.Instantiate(charTexture[i-25]);
					ctexts1(i-20);
					text1[2].text=chartext [0];
				}
			}
		}
	}

	public void ctexts(){
		chartext [1] = "霊夢\n　うぅ…今日のご飯もたくあんだけか…";
		chartext [2] = "霊夢\n　それにしても人っ子一人いないわね…";
		chartext [3] = "霊夢\n　うぅ…今日のご飯はめざし一匹か…";
		chartext [4] = "霊夢\n　お札かと思ったらただの葉っぱだったわ…";
		chartext [0] = "霊夢\n　今日のご飯は梅干しだけか…";
		chartext [5] = "魔理沙\n　霧雨魔法店は今日も品ぞろえ豊富だぜ\n　（調合に失敗したヤツばっかりだけどな）";
		chartext [6] = "チルノ\n　えーっと500円もらってアイスの値段が\n　350円だからお釣りは…あれ？？？";
		chartext [7] = "パチュリー\n　ゲホゲホ…\n\n霊夢\n　（自分でやらなくても小悪魔に\nやらせればいいのに）";
		chartext [8] = "文\n　号外号外～何とあの博麗霊夢が\n\n霊夢\n　あぁ？";
		chartext [9] = "みょん\n　売り上げのほとんどがゆゆこさまが\n　食べた分なんですが…";
		chartext [10] = "妹紅\n　あぁそこはね、あれがああなって…\n\n霊夢\n　意外と繁盛して意外とちゃんと\n　教えてる…だと…？";
		chartext [11] = "萃香\n　Ｚｚｚ…\n\n霊夢\n　起きろ";
		chartext [12] = "霊夢\n　（グ～…）美味しそうね…ちょっともらおうかしら…\n秋姉妹\n　こらぁ！";
		chartext [13] = "ナズーリン\n　やれやれせっかく開店したというのに\n　ご主人しかこないね";
		chartext [14] = "こころ\n　お面販売中…\n\n霊夢\n　さっさと希望の面にしなさいよ…";
		chartext [15] = "レミリア\n　さぁわたしのかりすまにおそれひれふすがいい！\n\n霊夢\n　（案の定紅魔館でみたことあるやつばっかりね…）";
		chartext [16] = "さとり\n　…見えました。ではまずここをでたら…\n\n霊夢\n　（というかほぼさとりがやってんだけど\nこいしどこいった）";
		chartext [17] = "輝夜\n　あーやっぱだりぃわ…\n\n霊夢\n　とかいいつつわざわざここまで来てるのね…";
		chartext [18] = "幽香\n　～♪\n\n霊夢\n　上機嫌だと逆に怖いわ…";
		chartext [19] = "早苗\n　すわこ様帽子にかなこ様人形\n　100分の1御柱はいかがですかー！";
		chartext [20] = "聖\n　南無南無\n\n霊夢\n　すごい皆ムキムキになってんだけど…";
		chartext [21] = "神子\n　ふむ参ったな\n　予想以上に人が来て私一人だとさばききれない";
		chartext [22] = "フラン・こいし・ぬえ\n　キャハハハハハハハハ\n\n霊夢\n　これはひどい";
		chartext [23] = "夢美\n　素敵な発明品いかが～？";
		chartext [24] = "霊夢\n　賽銭箱新調したけどお賽銭は増えないわね…";

		}
	public void ctexts1(int i){
		if (i == 10) {
			chartext [0] = "魔理沙\n　よぅ霊夢！相変わらず寂れてんなぁこの神社";
			chartext [1] = "霊夢\n　ほぅ…とりあえずそこ動くな";
			chartext [2] = "魔理沙\n　冗談だよ\n参拝客が来なさ過ぎてろくにご飯も食べられない\n　可哀想な貧乏巫女のために一肌脱ごうと思ってな";
			chartext [3] = "霊夢\n　…なによ";
			chartext [4] = "魔理沙\n　出店だよ出店！ほら祭りとかでよくあるだろ？\n　出店者を募って店を境内に出すんだよ。\n　賑やかになれば参拝客が増えるだろうし\n　ついでに出店者からショバ代とれば一石二鳥ってわけさ";
			chartext [5] = "霊夢\n　………………いやあんた神聖な境内でそんなこと";
			chartext [6] = "魔理沙\n　餓死しそうなレベルで貧困極めてるんだから\n　流石にご神体？とかからも許してもらえるだろ";
			chartext [7] = "霊夢\n　…ぐぐぐ…仕方ないか…";
			chartext [8] = "魔理沙\n　私の取り分は2割でいいぜ";
			chartext [9] = "霊夢\n　ピンはねするんかい！";
		}
		if (i == 11) {
			chartext [0] = "チルノ\n　れいむー";
			chartext [1] = "霊夢\n　あらチルノじゃない";
			chartext [2] = "チルノ\n　好きなお店つくってもいいって聞いたぞ！\n　ホントか！？";
			chartext [3] = "霊夢\n　公序良俗に反しないならね";
			chartext [4] = "チルノ\n　こーじょ？なにそれうまいのか？";
			chartext [5] = "大ちゃん\n　他の人に迷惑かけないようにしよってことだよ\n　チルノちゃん";
			chartext [6] = "霊夢\n　まぁ変な店じゃなかったらいいってことよ";
			chartext [7] = "チルノ\n　それなら大丈夫！\n　アイス屋やろうと思ってるから！";
			chartext [8] = "霊夢\n　あぁそれなら大丈夫ね。";
			chartext [9] = "チルノ\n　さっそく開店準備だー！";
			chartext [10] = "大ちゃん\n　あ、待ってよチルノちゃん！";
			chartext [11] = "霊夢\n　しかし計算できないあいつに\n　経営なんてできるのか…？";
		}
		if (i == 12) {
			chartext [0] = "パチュリー\n　ケホッケホッ";
			chartext [1] = "霊夢\n　あれ？パチュリーじゃない\n　珍しいわねここにくるなんて";
			chartext [2] = "パチュリー\n　えぇ…魔理沙に頼まれてね…ゲホッゲホ\n　『本を盗られるのと自分で売るの\n　好きな方選んでいいぜ☆』って";
			chartext [3] = "霊夢\n　相変わらず鬼畜ねあいつも";
			chartext [4] = "パチュリー\n　まぁ、本を盗まれるよりマシだわ…ゴホッゴホッ";
			chartext [5] = "霊夢\n　っていうかアンタ喘息大丈夫なの？";
			chartext [6] = "パチュリー\n　無理かも…（パタッ）";
			chartext [7] = "霊夢\n　パチュリー！！";
		}
		if (i == 13) {
			chartext [0] = "文\n　やぁやぁ霊夢さん";
			chartext [1] = "霊夢\n　何だ文か何か用？";
			chartext [2] = "文\n　いやー面白そうなことしてると聞きまして！\n　私もお店開いていいですか？";
			chartext [3] = "霊夢\n　どうせ新聞屋なんでしょ？";
			chartext [4] = "文\n　これでますます文々。新聞も\n　ますます売り上げが！";
			chartext [5] = "霊夢\n　もともと対して売れてもないし\n　人気もないでしょうに";
			chartext [6] = "文\n　「」";
		}
		if (i == 14) {
			chartext [0] = "みょん\n　たのもー！";
			chartext [1] = "霊夢\n　道場破りか？（スチャッ）";
			chartext [2] = "みょん\n　違いますよ！とりあえず札おろしてください";
			chartext [3] = "霊夢\n　あんたもお店を？";
			chartext [4] = "みょん\n　えぇちょっと家計が苦しくて。\n　ゆゆこさまの食費だけで支出の9割は\n　いきますからね";
			chartext [5] = "霊夢\n　私もそんだけおなかいっぱい食べてみたいわ…";
			chartext [6] = "みょん\n　お団子屋にするので良かったら\n　食べに来てください";
			chartext [7] = "霊夢\n　よし、ショバ代として毎日お団子をただで…";
			chartext [8] = "みょん\n　ちゃんとお金は払ってください！";
		}
		if (i == 15) {
			chartext [0] = "妹紅\n　よぉ霊夢";
			chartext [1] = "霊夢\n　あっもこたん";
			chartext [2] = "妹紅\n　もこたんゆーな。\n　ちょっと店開きたいんだけどいいか？";
			chartext [3] = "霊夢\n　そりゃ構わないけど何する気？";
			chartext [4] = "妹紅\n　ここにも寺子屋を作ろうかと思ってるんだけど";
			chartext [5] = "霊夢\n　寺子屋ぁ？こんなところでわざわざ\n　勉強しようなんてやついるわけないじゃない";
			chartext [6] = "妹紅\n　定職につけ定職につけってけーねがうるさいんだよ…";
			chartext [7] = "霊夢\n　(ここで店開くのは定職なのか…？）";
			chartext [8] = "妹紅\n　そんなのでこの先どうするんだーとか嫁の貰い手がーとか\n　なんなら私が貰ってやってもーとか私も案外まんざらじゃーないとか（ｒｙ\n　まぁポーズだけでもとっておこうかと思って";
			chartext [9] = "霊夢\n　「」";
		}
		if (i == 16) {
			chartext [0] = "萃香\n　れいむ～わたしもおみせやるぞ～";
			chartext [1] = "霊夢\n　朝から酔っぱらってるあんたにできるのか…";
			chartext [2] = "萃香\n　らいじょうぶ～おさけふるまうだけらし～";
			chartext [3] = "霊夢\n　まぁぴったりっちゃぴったりだけど";
			chartext [4] = "萃香\n　いざとなれば能力使えば客は確保できるし";
			chartext [5] = "霊夢\n　おい！";
		}
		if (i == 17) {
			chartext [0] = "穣子\n　穣子です";
			chartext [1] = "静葉\n　静葉です";
			chartext [2] = "秋姉妹\n　秋と言えば私たち！秋姉妹です";
			chartext [3] = "霊夢\n　いや今秋じゃないけど";
			chartext [4] = "穣子\n　私たちが秋と言えば秋なの！";
			chartext [5] = "霊夢\n　まぁいいけどさ…目立ちたいだけなら帰れ";
			chartext [6] = "静葉\n　もちろん出店しにきたんですよ！これです";
			chartext [7] = "霊夢\n　八百屋？";
			chartext [8] = "静葉\n　いや野菜の無人販売所ですよ";
			chartext [9] = "霊夢\n　無人て。ぱくられそうだけど実際どうなのよ？";
			chartext [10] = "穣子\n　そんな不届きものには私たちがじきじきに神罰ですよ！";
			chartext [11] = "霊夢\n　まぁ神社で盗み働くやつもいないか";
			chartext [12] = "穣子\n　むしろ霊夢さんが盗まないかが一番心配ですけど";
			chartext [13] = "霊夢\n　…";
			chartext [14] = "静葉\n　否定しないの！？";
		}
		if (i == 18) {
			chartext [0] = "ナズーリン\n　邪魔するよ";
			chartext [1] = "霊夢\n　邪魔するなら帰ってや～";
			chartext [2] = "ナズーリン\n　あいよ…っていらないからそういうのは";
			chartext [3] = "霊夢\n　はいはい…で、あんたもお店を？";
			chartext [4] = "ナズーリン\n　あぁ。簡単に言ってしまえば何でも屋かな。\n　探し物専門だけどね";
			chartext [5] = "霊夢\n　いつもやってるものね。飽きない？";
			chartext [6] = "ナズーリン\n　まぁそれも仕事のうちだからね。";
			chartext [7] = "霊夢\n　じゃせいぜい頑張ってね";
			chartext [8] = "ナズーリン\n　うちのご主人ももう少ししっかり\n　してくれればいいんだが";
		}
		if (i == 19) {
			chartext [0] = "こころ\n　…";
			chartext [1] = "霊夢\n　…おわぁ！びっくりした！";
			chartext [2] = "こころ\n　こんにちは…";
			chartext [3] = "霊夢\n　なんか今日テンション低いわね…";
			chartext [4] = "こころ\n　お面屋やりたい…";
			chartext [5] = "霊夢\n　別にいいけど…まさかあんたのやつ\n　売る気じゃないでしょうね";
			chartext [6] = "こころ\n　複製用に型とってるから今手元に\n　ほとんどないの…";
			chartext [7] = "霊夢\n　あぁだからやたらテンション低いのか…";
		}
		if (i == 20) {
			chartext [0] = "レミリア\n　れいむ！！わたしもおみせ！！";
			chartext [1] = "霊夢\n　いきなりうるせぇ！";
			chartext [2] = "咲夜\n　すみませんかなり張り切ってまして";
			chartext [3] = "霊夢\n　そりゃいいけど何する気よ";
			chartext [4] = "レミリア\n　それはもちろんわたしのあふれでる\n　かりすまをしょみんに";
			chartext [5] = "霊夢\n　絶対流行らないでしょ…";
			chartext [6] = "咲夜\n　私が進言しました";
			chartext [7] = "霊夢\n　お前のせいか！";
			chartext [8] = "咲夜\n　ﾋｿﾋｿ（いざとなればうちのメイドを\n客として派遣しますし）";
			chartext [9] = "霊夢\n　サクラかい…";
		}
		if (i == 21) {
			chartext [0] = "さとり\n　こんにちは";
			chartext [1] = "霊夢\n　あぁ…ひｋ";
			chartext [2] = "さとり\n　『引き籠りが何の用？』ですか、\n　実はこいしがお店をやりたいと言ってまして";
			chartext [3] = "霊夢\n　いやいやあいｔ";
			chartext [4] = "さとり\n　『どう考えてもただのきまぐれだけどできんの？』\n　大丈夫ですよ私も手伝いますから";
			chartext [5] = "霊夢\n　…だいたい何ｓ";
			chartext [6] = "さとり\n　『何する気？』まぁ占いですね";
			chartext [7] = "霊夢\n　…いんｔ";
			chartext [8] = "さとり\n　いんちきではありません深層心理から\n　本人もわからない悩みを解決したりですね…";
			chartext [9] = "霊夢\n　…";
			chartext [10] = "さとり\n　…『わーすごーい絶対成功するわねー\n　さとりさま下僕にしてください』";
			chartext [11] = "霊夢\n　思ってねーよ";
		}
		if (i == 22) {
			chartext [0] = "輝夜\n　こんにちはー";
			chartext [1] = "霊夢\n　な、引きこもりのアンタが何でこんなところに！？";
			chartext [2] = "輝夜\n　失礼ね！私もお店開きたいなって思って";
			chartext [3] = "霊夢\n　嘘でしょニートのアンタが…";
			chartext [4] = "輝夜\n　うるさいわよ！\n　ほらもこたんもやってるらしいじゃない？";
			chartext [5] = "霊夢\n　あぁ寺子屋やってるわね";
			chartext [6] = "輝夜\n　そうなのよね～だから最近忙しいのかあんまり\n　勝負してないのよ\n　だから私もお店作って売り上げで\n　勝負することにしたわ";
			chartext [7] = "霊夢\n　そりゃ平和でよかったわ";
			chartext [8] = "輝夜\n　とりあえずこのえーりんの研究所から\n　パクってきた怪しげな薬を売ーろっと";
			chartext [9] = "霊夢\n　やめとけ！";
		}
		if (i == 23) {
			chartext [0] = "幽香\n　面白そうなことやってるわねぇ";
			chartext [1] = "霊夢\n　げっ…";
			chartext [2] = "幽香\n　私もお店やろうかしら";
			chartext [3] = "霊夢\n　アンタいたら神社自体に客こなくなるっつーの";
			chartext [4] = "幽香\n　そんなことないわよ雑魚に興味はないし…";
			chartext [5] = "霊夢\n　いやいやいるだけで威圧感はんぱないわよ";
			chartext [6] = "幽香\n　そういえばここには結構強いやつらが集まってるわねぇ（スッ）";
			chartext [7] = "霊夢\n　おいやめろ傘構えんな！";
			chartext [8] = "幽香\n　一応冗談よ。まぁ花屋やる予定なんだけど店番には\n　リグルかメディにやらせるわ";
			chartext [9] = "霊夢\n　それなら大丈夫か…";
			chartext [10] = "幽香\n　買って枯らしたやつはぶち殺しにいくけどね";
			chartext [11] = "霊夢\n　マジで買うやついなくなるわよ…";
		}
		if (i == 24) {
			chartext [0] = "早苗\n　霊夢さん！何て事をしてくれたんですか！";
			chartext [1] = "霊夢\n　あん？";
			chartext [2] = "早苗\n　あん？じゃありません！\n　お陰様で守谷に対する信仰が減ってきてる\n　じゃないですか！";
			chartext [3] = "霊夢\n　ね、狙いどおりよ";
			chartext [4] = "早苗\n　前年比2％減ですけどね！";
			chartext [5] = "霊夢\n　参拝者多すぎだろ…";
			chartext [6] = "早苗\n　というわけでウチもここで守谷グッズ販売します";
			chartext [7] = "霊夢\n　分社化すんな！";
		}
		if (i == 25) {
			chartext [0] = "聖\n　こんにちは～";
			chartext [1] = "霊夢\n　あ、商売敵その２";
			chartext [2] = "聖\n　…酷い言い草ですね。今すぐ南無三しても\n いいのですが今日は別の要件です";
			chartext [3] = "霊夢\n　えーあんたも店開くの？";
			chartext [4] = "聖\n　えぇせっかくなので。体操教室でも開こうかと";
			chartext [5] = "霊夢\n　体操教室ねぇ";
			chartext [6] = "聖\n　アンチエイジングは大切ですよ？";
			chartext [7] = "霊夢\n　さすがBB…";
			chartext [8] = "聖\n　南無三ー！！";
		}
		if (i == 26) {
			chartext [0] = "神子\n　すごいな大分繁盛してるようじゃないか";
			chartext [1] = "霊夢\n　あ、商売敵その３";
			chartext [2] = "神子\n　あぁ、守谷の連中と聖もお店を\n 開いているんだろう？";
			chartext [3] = "霊夢\n　まさかあんたも？";
			chartext [4] = "神子\n　耳かきサ―ビスのお店でも開こうかと";
			chartext [5] = "霊夢\n　耳かき…？";
			chartext [6] = "神子\n　私の教えをしっかり聞いてもらうためにも\n 必要だろう";
			chartext [7] = "霊夢\n　耳かきねぇ…";
			chartext [8] = "神子\n　なんなら君にもやってやろうか？ほらこっちに（ﾎﾟﾝﾎﾟﾝ）";
			chartext [9] = "霊夢\n　まぁいいけど。\n …ふぉぉぉぉぉ～…これやばいわ…";
		}
		if (i == 27) {
			chartext [0] = "フラン\n　こんにちはー！";
			chartext [1] = "こいし\n　こんにちわ～❤";
			chartext [2] = "ぬえ\n　こんにちは";
			chartext [3] = "霊夢\n　あれ？あんた達そろってどうしたの";
			chartext [4] = "ぬえ\n　私達もお店やろうかと思いまして";
			chartext [5] = "霊夢\n　いいけど…\nフランって外出許可出てるの？";
			chartext [6] = "フラン\n　お館8割くらい壊したらあっさり許可してくれたよ？";
			chartext [7] = "霊夢\n　あっさりじゃないわよそれ…\n　というかこいしってさとりと\n　店やってんじゃなかったっけ";
			chartext [8] = "こいし\n　お姉ちゃん頑張ってるから大丈夫！";
			chartext [9] = "霊夢\n　はぁ…まぁいいわ。そもそも何の店よ？";
			chartext [10] = "フラン\n　私達と一緒に遊ぶの！";
			chartext [11] = "霊夢\n　いやEX×3とか死ぬだろ…";
		}
		if (i == 28) {
			chartext [0] = "夢美\n　久しぶり～";
			chartext [1] = "霊夢\n　は？";
			chartext [2] = "夢美\n　え？";
			chartext [3] = "霊夢\n　いやあんた誰よ？";
			chartext [4] = "夢美\n　え？覚えてない？ほら私よ岡崎夢美！";
			chartext [5] = "霊夢\n　知らないけど…";
			chartext [6] = "夢美\n　な、なんてこと…こうなったら…！(ﾏﾝﾄﾊﾞｻｧ)";
			chartext [7] = "霊夢\n　…？…あ、あー！そのマント！\n　確か何でも一つ願いを叶えるとか言ってた！";
			chartext [8] = "夢美\n　…マントつけないと判別してもらえないのかしら…";
		}
	}
	
	public void OnGUI() {
		GUI.skin.button.fontSize =(int)buttonsize2;

		if (stopmusic == 0) {
			if (GUI.Button (new Rect (390 * sw, 5 * sh, 100 * sw, 50 * sh), "音楽OFF")) {
				music[0].GetComponent<AudioSource>().Stop();
				stopmusic=1;
			}
		}
		if (stopmusic == 1) {
			if (GUI.Button (new Rect (390 * sw, 5 * sh, 100 * sw, 50 * sh), "音楽ON")) {
				music[0].GetComponent<AudioSource>().Play();
				stopmusic=0;
			}
		}

		if (TextDeg >= 30) {
			if (GUI.Button (new Rect (620 * sw, 555 * sh, 100 * sw, 50 * sh), "次へ")) {
				TextP+=1;
				if(TextDeg==30&&TextP>9){
					TextDeg=1;
					TextP=0;
				}
				if(TextDeg==31&&TextP>11){
					TextDeg=1;
					TextP=0;
				}
				if(TextDeg==32&&TextP>7){
					TextDeg=1;
					TextP=0;
				}
				if(TextDeg==33&&TextP>6){
					TextDeg=1;
					TextP=0;
				}
				if(TextDeg==34&&TextP>8){
					TextDeg=1;
					TextP=0;
				}
				if(TextDeg==35&&TextP>9){
					TextDeg=1;
					TextP=0;
				}
				if(TextDeg==36&&TextP>5){
					TextDeg=1;
					TextP=0;
				}
				if(TextDeg==37&&TextP>14){
					TextDeg=1;
					TextP=0;
				}
				if(TextDeg==38&&TextP>8){
					TextDeg=1;
					TextP=0;
				}
				if(TextDeg==39&&TextP>7){
					TextDeg=1;
					TextP=0;
				}
				if(TextDeg==40&&TextP>9){
					TextDeg=1;
					TextP=0;
				}
				if(TextDeg==41&&TextP>11){
					TextDeg=1;
					TextP=0;
				}
				if(TextDeg==42&&TextP>9){
					TextDeg=1;
					TextP=0;
				}
				if(TextDeg==43&&TextP>11){
					TextDeg=1;
					TextP=0;
				}
				if(TextDeg==44&&TextP>7){
					TextDeg=1;
					TextP=0;
				}
				if(TextDeg==45&&TextP>8){
					TextDeg=1;
					TextP=0;
				}
				if(TextDeg==46&&TextP>9){
					TextDeg=1;
					TextP=0;
				}
				if(TextDeg==47&&TextP>11){
					TextDeg=1;
					TextP=0;
				}
				if(TextDeg==48&&TextP>8){
					TextDeg=1;
					TextP=0;
				}
				if(TextDeg>=30){
				text1[2].text=chartext [TextP];
				}
			}
		}
		
		#if UNITY_IPHONE || UNITY_ANDROID && !UNITY_EDITOR
		if (GUI.Button (new Rect (850*sw,480*sh, 100*sw, 50*sh), "ﾗﾝｷﾝｸﾞ起動")) {
			appCCloud.Gamers.SetLeaderBoard(1902, money2);
			appCCloud.Gamers.SetLeaderBoard(1903, money);
			appCCloud.Gamers.OpenGamersView();
		}
		#endif

		if (GUI.Button (new Rect (850 * sw, 560 * sh, 100 * sw, 50 * sh), "ﾃﾞｰﾀﾘｾｯﾄ")) {
			r=1;
		}
		if (r == 1) {
			if (GUI.Button (new Rect (160 * sw, 500 * sh, 200 * sw, 100 * sh), "リセットする")) {
				day=1;
				money=100;
				syuueki=10;
				money2=0;
				syuueki2=0;
				savemaplv="0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
				savemoney="0,50,0,1500,0,10000,0,50000,0,200000,0,500000,0,1000000,0,3000000,0,7000000,0,15000000,0,30000000,0,50000000,0,80000000,0,1,2,3,5,10,20,50,99";
				PlayerPrefs.SetInt ("trbsave3",0);
				PlayerPrefs.SetInt (Data1,1);
				PlayerPrefs.SetInt (Data2,100);
				PlayerPrefs.SetInt (Data3,10);
				PlayerPrefs.SetInt (Data4,0);
				PlayerPrefs.SetInt (Data5,0);
				PlayerPrefs.SetString (Data6,"0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0");
				PlayerPrefs.SetString (Data7,"0,50,0,1500,0,10000,0,50000,0,200000,0,500000,0,1000000,0,3000000,0,7000000,0,15000000,0,30000000,0,50000000,0,80000000,0,1,2,3,5,10,20,50,99");
				FadeManager.Instance.LoadLevel("main",1.0f);
				r = 0;
			}
			if (GUI.Button (new Rect (500 * sw, 500 * sh, 200 * sw, 100 * sh), "キャンセル")) {
				r = 0;
			}
				}

		GUI.skin.button.fontSize =(int)buttonsize;
		for(int i=0;i<7;i++){
		if (GUI.Button (new Rect (5* sw, (65+(i*58))* sh, 55 * sw, 55 * sh), buttonTexture[i])) {

				}
		}
		if (GUI.Button (new Rect (60* sw, 65* sh, 225 * sw, 55 * sh), "購入費用:0\n所持金+:"+buttonmoney[1]+"\nお金を拾います")) {
			money+=mapste1[3];
		}
		if (GUI.Button (new Rect (60* sw, 123* sh, 225 * sw, 55 * sh), "購入費用:"+savemoneys[2]+savemoneys[1]+"\n収益金+:"+(mapsyuueki[1].ToString())+"\n境内を綺麗にします")) {
			if(money2>0){
				if(money2>=savemoneyi[2]&&money>savemoneyi[1]){
				money2-=savemoneyi[2];
				money2-=1;
				money+=100000000;
				money-=savemoneyi[1];
				syuueki+=mapsyuueki[1];
				savemoneyi[1]+=(int)(savemoneyi[1]*0.1);
					maplv[1]+=1;
					if(savemoneyi[1]>99999999){
						savemoneyi[2]+=1;
						savemoneyi[1]-=100000000;
					}
				if(savemoneyi[2]>99999999){
					savemoneyi[2]=100000000;
				}
				}
				mapmoneyk ();
				moneyk();

			}
			if(money2>0&&savemoneyi[2]==0){
					money2-=1;
					money+=100000000;
					money-=savemoneyi[1];
					syuueki+=mapsyuueki[1];
					savemoneyi[1]+=(int)(savemoneyi[1]*0.1);
				maplv[1]+=1;
					if(savemoneyi[1]>99999999){
						savemoneyi[2]+=1;
						savemoneyi[1]-=100000000;
					}
					if(savemoneyi[2]>99999999){
						savemoneyi[2]=100000000;
				}
				mapmoneyk ();
				moneyk();
			}
			if(money2==0){
				if(savemoneyi[2]==0&&money>savemoneyi[1]){
				money-=savemoneyi[1];
				syuueki+=mapsyuueki[1];
				savemoneyi[1]+=(int)(savemoneyi[1]*0.1);
					maplv[1]+=1;
			    if(savemoneyi[1]>99999999){
					savemoneyi[2]+=1;
					savemoneyi[1]-=100000000;
				}
					if(savemoneyi[2]>99999999){
						savemoneyi[2]=100000000;
					}
					mapmoneyk ();
					moneyk();
				}
			}
		}
		if (GUI.Button (new Rect (60* sw, 181* sh, 225 * sw, 55 * sh), "購入費用:"+savemoneys[4]+savemoneys[3]+"\n収益金+:"+(mapsyuueki[2].ToString())+"\n魔理沙が魔法店を出店します")) {
			if(money2>0){
				if(money2>=savemoneyi[4]&&money>savemoneyi[3]){
					money2-=savemoneyi[4];
					money2-=1;
					money+=100000000;
					money-=savemoneyi[3];
					syuueki+=mapsyuueki[2];
					savemoneyi[3]+=(int)(savemoneyi[3]*0.1);
					if(maplv[2]==0){
						TextDeg=30;
					}
					maplv[2]+=1;
					if(savemoneyi[3]>99999999){
						savemoneyi[4]+=1;
						savemoneyi[3]-=100000000;
					}
					if(savemoneyi[4]>99999999){
						savemoneyi[4]=100000000;
					}
					mapmoneyk ();
					moneyk();
				}
			}
			if(money2>0&&savemoneyi[4]==0){
				money2-=1;
				money+=100000000;
				money-=savemoneyi[3];
				syuueki+=mapsyuueki[2];
				savemoneyi[3]+=(int)(savemoneyi[3]*0.1);
				if(maplv[2]==0){
					TextDeg=30;
				}
				maplv[2]+=1;
				if(savemoneyi[3]>99999999){
					savemoneyi[4]+=1;
					savemoneyi[3]-=100000000;
				}
				if(savemoneyi[4]>99999999){
					savemoneyi[4]=100000000;
				}
				mapmoneyk ();
				moneyk();
			}
			if(money2==0){
				if(savemoneyi[4]==0&&money>savemoneyi[3]){
					money-=savemoneyi[3];
					syuueki+=mapsyuueki[2];
					savemoneyi[3]+=(int)(savemoneyi[3]*0.1);
					if(maplv[2]==0){
						TextDeg=30;
					}
					maplv[2]+=1;
					if(savemoneyi[3]>99999999){
						savemoneyi[4]+=1;
						savemoneyi[3]-=100000000;
					}
					if(savemoneyi[4]>99999999){
						savemoneyi[4]=100000000;
					}
					mapmoneyk ();
					moneyk();
				}
			}
		}
		if (GUI.Button (new Rect (60* sw, 239* sh, 225 * sw, 55 * sh), "購入費用:"+savemoneys[6]+savemoneys[5]+"\n収益金+:"+(mapsyuueki[3].ToString())+"\nチルノがアイス屋を出店します")) {
			if(money2>0){
				if(money2>=savemoneyi[6]&&money>savemoneyi[5]){
					money2-=savemoneyi[6];
					money2-=1;
					money+=100000000;
					money-=savemoneyi[5];
					syuueki+=mapsyuueki[3];
					savemoneyi[5]+=(int)(savemoneyi[5]*0.1);
					if(maplv[3]==0){
						TextDeg=31;
					}
					maplv[3]+=1;
					if(savemoneyi[5]>99999999){
						savemoneyi[6]+=1;
						savemoneyi[5]-=100000000;
					}
					if(savemoneyi[6]>99999999){
						savemoneyi[6]=100000000;
					}
					mapmoneyk ();
					moneyk();
				}
			}
			if(money2>0&&savemoneyi[6]==0){
				money2-=1;
				money+=100000000;
				money-=savemoneyi[6];
				syuueki+=mapsyuueki[3];
				savemoneyi[5]+=(int)(savemoneyi[5]*0.1);
				if(maplv[3]==0){
					TextDeg=31;
				}
				maplv[3]+=1;
				if(savemoneyi[5]>99999999){
					savemoneyi[6]+=1;
					savemoneyi[5]-=100000000;
				}
				if(savemoneyi[6]>99999999){
					savemoneyi[6]=100000000;
				}
				mapmoneyk ();
				moneyk();
			}
			if(money2==0){
				if(savemoneyi[6]==0&&money>savemoneyi[5]){
					money-=savemoneyi[5];
					syuueki+=mapsyuueki[3];
					savemoneyi[5]+=(int)(savemoneyi[5]*0.1);
					if(maplv[3]==0){
						TextDeg=31;
					}
					maplv[3]+=1;
					if(savemoneyi[5]>99999999){
						savemoneyi[6]+=1;
						savemoneyi[5]-=100000000;
					}
					if(savemoneyi[6]>99999999){
						savemoneyi[6]=100000000;
					}
					mapmoneyk ();
					moneyk();
				}
			}
		}
		if (GUI.Button (new Rect (60* sw, 297* sh, 225 * sw, 55 * sh), "購入費用:"+savemoneys[8]+savemoneys[7]+"\n収益金+:"+(mapsyuueki[4].ToString())+"\nパチェが古本屋を出店します")) {
			if(money2>0){
				if(money2>=savemoneyi[8]&&money>savemoneyi[7]){
					money2-=savemoneyi[8];
					money2-=1;
					money+=100000000;
					money-=savemoneyi[7];
					syuueki+=mapsyuueki[4];
					savemoneyi[7]+=(int)(savemoneyi[7]*0.2);
					if(maplv[4]==0){
						TextDeg=32;
					}
					maplv[4]+=1;
					if(savemoneyi[7]>99999999){
						savemoneyi[8]+=1;
						savemoneyi[7]-=100000000;
					}
					if(savemoneyi[8]>99999999){
						savemoneyi[8]=100000000;
					}
					mapmoneyk ();
					moneyk();
				}
			}
			if(money2>0&&savemoneyi[8]==0){
				money2-=1;
				money+=100000000;
				money-=savemoneyi[7];
				syuueki+=mapsyuueki[4];
				savemoneyi[7]+=(int)(savemoneyi[7]*0.2);
				if(maplv[4]==0){
					TextDeg=32;
				}
				maplv[4]+=1;
				if(savemoneyi[7]>99999999){
					savemoneyi[8]+=1;
					savemoneyi[7]-=100000000;
				}
				if(savemoneyi[8]>99999999){
					savemoneyi[8]=100000000;
				}
				mapmoneyk ();
				moneyk();
			}
			if(money2==0){
				if(savemoneyi[8]==0&&money>savemoneyi[7]){
					money-=savemoneyi[7];
					syuueki+=mapsyuueki[4];
					savemoneyi[7]+=(int)(savemoneyi[7]*0.2);
					if(maplv[4]==0){
						TextDeg=32;
					}
					maplv[4]+=1;
					if(savemoneyi[7]>99999999){
						savemoneyi[8]+=1;
						savemoneyi[7]-=100000000;
					}
					if(savemoneyi[8]>99999999){
						savemoneyi[8]=100000000;
					}
					mapmoneyk ();
					moneyk();
				}
			}
		}
		if (GUI.Button (new Rect (60* sw, 355* sh, 225 * sw, 55 * sh), "購入費用:"+savemoneys[10]+savemoneys[9]+"\n収益金+:"+(mapsyuueki[5].ToString())+"\n文が新聞屋を出店します")) {
			if(money2>0){
				if(money2>=savemoneyi[10]&&money>savemoneyi[9]){
					money2-=savemoneyi[10];
					money2-=1;
					money+=100000000;
					money-=savemoneyi[9];
					syuueki+=mapsyuueki[5];
					savemoneyi[9]+=(int)(savemoneyi[9]*0.2);
					if(maplv[5]==0){
						TextDeg=33;
					}
					maplv[5]+=1;
					if(savemoneyi[9]>99999999){
						savemoneyi[10]+=1;
						savemoneyi[9]-=100000000;
					}
					if(savemoneyi[10]>99999999){
						savemoneyi[10]=100000000;
					}
					mapmoneyk ();
					moneyk();
				}
			}
			if(money2>0&&savemoneyi[10]==0){
				money2-=1;
				money+=100000000;
				money-=savemoneyi[9];
				syuueki+=mapsyuueki[5];
				savemoneyi[9]+=(int)(savemoneyi[9]*0.2);
				if(maplv[5]==0){
					TextDeg=33;
				}
				maplv[5]+=1;
				if(savemoneyi[9]>99999999){
					savemoneyi[10]+=1;
					savemoneyi[9]-=100000000;
				}
				if(savemoneyi[10]>99999999){
					savemoneyi[10]=100000000;
				}
				mapmoneyk ();
				moneyk();
			}
			if(money2==0){
				if(savemoneyi[10]==0&&money>savemoneyi[9]){
					money-=savemoneyi[9];
					syuueki+=mapsyuueki[5];
					savemoneyi[9]+=(int)(savemoneyi[9]*0.2);
					if(maplv[5]==0){
						TextDeg=33;
					}
					maplv[5]+=1;
					if(savemoneyi[9]>99999999){
						savemoneyi[10]+=1;
						savemoneyi[9]-=100000000;
					}
					if(savemoneyi[10]>99999999){
						savemoneyi[10]=100000000;
					}
					mapmoneyk ();
					moneyk();
				}
			}
		}
		if (GUI.Button (new Rect (60* sw, 413* sh, 225 * sw, 55 * sh), "購入費用:"+savemoneys[12]+savemoneys[11]+"\n収益金+:"+(mapsyuueki[6].ToString())+"\nみょんが団子屋を出店します")) {
			if(money2>0){
				if(money2>=savemoneyi[12]&&money>savemoneyi[11]){
					money2-=savemoneyi[12];
					money2-=1;
					money+=100000000;
					money-=savemoneyi[12];
					syuueki+=mapsyuueki[6];
					savemoneyi[11]+=(int)(savemoneyi[11]*0.2);
					if(maplv[6]==0){
						TextDeg=34;
					}
					maplv[6]+=1;
					if(savemoneyi[11]>99999999){
						savemoneyi[12]+=1;
						savemoneyi[11]-=100000000;
					}
					if(savemoneyi[12]>99999999){
						savemoneyi[12]=100000000;
					}
					mapmoneyk ();
					moneyk();
				}
			}
			if(money2>0&&savemoneyi[12]==0){
				money2-=1;
				money+=100000000;
				money-=savemoneyi[11];
				syuueki+=mapsyuueki[6];
				savemoneyi[11]+=(int)(savemoneyi[11]*0.2);
				if(maplv[6]==0){
					TextDeg=34;
				}
				maplv[6]+=1;
				if(savemoneyi[11]>99999999){
					savemoneyi[12]+=1;
					savemoneyi[11]-=100000000;
				}
				if(savemoneyi[12]>99999999){
					savemoneyi[12]=100000000;
				}
				mapmoneyk ();
				moneyk();
			}
			if(money2==0){
				if(savemoneyi[12]==0&&money>savemoneyi[11]){
					money-=savemoneyi[11];
					syuueki+=mapsyuueki[6];
					savemoneyi[11]+=(int)(savemoneyi[11]*0.2);
					if(maplv[6]==0){
						TextDeg=34;
					}
					maplv[6]+=1;
					if(savemoneyi[11]>99999999){
						savemoneyi[12]+=1;
						savemoneyi[11]-=100000000;
					}
					if(savemoneyi[12]>99999999){
						savemoneyi[12]=100000000;
					}
					mapmoneyk ();
					moneyk();
				}
			}
		}

		for(int i=0;i<7;i++){
			if (GUI.Button (new Rect (305* sw, (65+(i*58))* sh, 55 * sw, 55 * sh), buttonTexture[i+7])) {
			}
		}
		if (GUI.Button (new Rect (360* sw, 65* sh, 225 * sw, 55 * sh), "購入費用:"+savemoneys[14]+savemoneys[13]+"\n収益金+:"+(mapsyuueki[7].ToString())+"\n妹紅が寺子屋を出店します")) {
			if(money2>0){
				if(money2>=savemoneyi[14]&&money>savemoneyi[13]){
					money2-=savemoneyi[14];
					money2-=1;
					money+=100000000;
					money-=savemoneyi[13];
					syuueki+=mapsyuueki[7];
					savemoneyi[13]+=(int)(savemoneyi[13]*0.3);
					if(maplv[7]==0){
						TextDeg=35;
					}
					maplv[7]+=1;
					if(savemoneyi[13]>99999999){
						savemoneyi[14]+=1;
						savemoneyi[13]-=100000000;
					}
					if(savemoneyi[14]>99999999){
						savemoneyi[14]=100000000;
					}
					mapmoneyk ();
					moneyk();
				}
			}
			if(money2>0&&savemoneyi[14]==0){
				money2-=1;
				money+=100000000;
				money-=savemoneyi[13];
				syuueki+=mapsyuueki[7];
				savemoneyi[13]+=(int)(savemoneyi[13]*0.3);
				if(maplv[7]==0){
					TextDeg=35;
				}
				maplv[7]+=1;
				if(savemoneyi[13]>99999999){
					savemoneyi[14]+=1;
					savemoneyi[13]-=100000000;
				}
				if(savemoneyi[14]>99999999){
					savemoneyi[14]=100000000;
				}
				mapmoneyk ();
				moneyk();
			}
			if(money2==0){
				if(savemoneyi[14]==0&&money>savemoneyi[13]){
					money-=savemoneyi[13];
					syuueki+=mapsyuueki[7];
					savemoneyi[13]+=(int)(savemoneyi[13]*0.3);
					if(maplv[7]==0){
						TextDeg=35;
					}
					maplv[7]+=1;
					if(savemoneyi[13]>99999999){
						savemoneyi[14]+=1;
						savemoneyi[13]-=100000000;
					}
					if(savemoneyi[14]>99999999){
						savemoneyi[14]=100000000;
					}
					mapmoneyk ();
					moneyk();
				}
			}
		}
		if (GUI.Button (new Rect (360* sw, 123* sh, 225 * sw, 55 * sh), "購入費用:"+savemoneys[16]+savemoneys[15]+"\n収益金+:"+(mapsyuueki[8].ToString())+"\n萃香が酒屋を出店します")) {
			if(money2>0){
				if(money2>=savemoneyi[16]&&money>savemoneyi[15]){
					money2-=savemoneyi[16];
					money2-=1;
					money+=100000000;
					money-=savemoneyi[15];
					syuueki+=mapsyuueki[8];
					savemoneyi[15]+=(int)(savemoneyi[15]*0.3);
					if(maplv[8]==0){
						TextDeg=36;
					}
					maplv[8]+=1;
					if(savemoneyi[15]>99999999){
						savemoneyi[16]+=1;
						savemoneyi[15]-=100000000;
					}
					if(savemoneyi[16]>99999999){
						savemoneyi[16]=100000000;
					}
					mapmoneyk ();
					moneyk();
				}
			}
			if(money2>0&&savemoneyi[4]==0){
				money2-=1;
				money+=100000000;
				money-=savemoneyi[15];
				syuueki+=mapsyuueki[8];
				savemoneyi[15]+=(int)(savemoneyi[15]*0.3);
				if(maplv[8]==0){
					TextDeg=36;
				}
				maplv[8]+=1;
				if(savemoneyi[15]>99999999){
					savemoneyi[16]+=1;
					savemoneyi[15]-=100000000;
				}
				if(savemoneyi[16]>99999999){
					savemoneyi[16]=100000000;
				}
				mapmoneyk ();
				moneyk();
			}
			if(money2==0){
				if(savemoneyi[16]==0&&money>savemoneyi[15]){
					money-=savemoneyi[15];
					syuueki+=mapsyuueki[8];
					savemoneyi[15]+=(int)(savemoneyi[15]*0.3);
					if(maplv[8]==0){
						TextDeg=36;
					}
					maplv[8]+=1;
					if(savemoneyi[15]>99999999){
						savemoneyi[16]+=1;
						savemoneyi[15]-=100000000;
					}
					if(savemoneyi[16]>99999999){
						savemoneyi[16]=100000000;
					}
					mapmoneyk ();
					moneyk();
				}
			}
		}
		if (GUI.Button (new Rect (360* sw, 181* sh, 225 * sw, 55 * sh), "購入費用:"+savemoneys[18]+savemoneys[17]+"\n収益金+:"+(mapsyuueki[9].ToString())+"\n秋姉妹が八百屋を出店します")) {
			if(money2>0){
				if(money2>=savemoneyi[18]&&money>savemoneyi[17]){
					money2-=savemoneyi[18];
					money2-=1;
					money+=100000000;
					money-=savemoneyi[18];
					syuueki+=mapsyuueki[9];
					savemoneyi[17]+=(int)(savemoneyi[17]*0.3);
					if(maplv[9]==0){
						TextDeg=37;
					}
					maplv[9]+=1;
					if(savemoneyi[17]>99999999){
						savemoneyi[18]+=1;
						savemoneyi[17]-=100000000;
					}
					if(savemoneyi[18]>99999999){
						savemoneyi[18]=100000000;
					}
					mapmoneyk ();
					moneyk();
				}
			}
			if(money2>0&&savemoneyi[18]==0){
				money2-=1;
				money+=100000000;
				money-=savemoneyi[17];
				syuueki+=mapsyuueki[9];
				savemoneyi[17]+=(int)(savemoneyi[17]*0.3);
				if(maplv[9]==0){
					TextDeg=37;
				}
				maplv[9]+=1;
				if(savemoneyi[17]>99999999){
					savemoneyi[18]+=1;
					savemoneyi[17]-=100000000;
				}
				if(savemoneyi[18]>99999999){
					savemoneyi[18]=100000000;
				}
				mapmoneyk ();
				moneyk();
			}
			if(money2==0){
				if(savemoneyi[18]==0&&money>savemoneyi[17]){
					money-=savemoneyi[17];
					syuueki+=mapsyuueki[9];
					savemoneyi[17]+=(int)(savemoneyi[17]*0.3);
					if(maplv[9]==0){
						TextDeg=37;
					}
					maplv[9]+=1;
					if(savemoneyi[17]>99999999){
						savemoneyi[18]+=1;
						savemoneyi[17]-=100000000;
					}
					if(savemoneyi[18]>99999999){
						savemoneyi[18]=100000000;
					}
					mapmoneyk ();
					moneyk();
				}
			}
		}
		if (GUI.Button (new Rect (360* sw, 239* sh, 225 * sw, 55 * sh), "購入費用:"+savemoneys[20]+savemoneys[19]+"\n収益金+:"+(mapsyuueki[10].ToString())+"\nナズが何でも屋を出店します")) {
			if(money2>0){
				if(money2>=savemoneyi[20]&&money>savemoneyi[19]){
					money2-=savemoneyi[20];
					money2-=1;
					money+=100000000;
					money-=savemoneyi[19];
					syuueki+=mapsyuueki[10];
					savemoneyi[19]+=(int)(savemoneyi[19]*0.4);
					if(maplv[10]==0){
						TextDeg=38;
					}
					maplv[10]+=1;
					if(savemoneyi[19]>99999999){
						savemoneyi[20]+=1;
						savemoneyi[19]-=100000000;
					}
					if(savemoneyi[20]>99999999){
						savemoneyi[20]=100000000;
					}
					mapmoneyk ();
					moneyk();
				}
			}
			if(money2>0&&savemoneyi[20]==0){
				money2-=1;
				money+=100000000;
				money-=savemoneyi[19];
				syuueki+=mapsyuueki[10];
				savemoneyi[19]+=(int)(savemoneyi[19]*0.4);
				if(maplv[10]==0){
					TextDeg=38;
				}
				maplv[10]+=1;
				if(savemoneyi[19]>99999999){
					savemoneyi[20]+=1;
					savemoneyi[19]-=100000000;
				}
				if(savemoneyi[20]>99999999){
					savemoneyi[20]=100000000;
				}
				mapmoneyk ();
				moneyk();
			}
			if(money2==0){
				if(savemoneyi[20]==0&&money>savemoneyi[19]){
					money-=savemoneyi[19];
					syuueki+=mapsyuueki[10];
					savemoneyi[19]+=(int)(savemoneyi[19]*0.4);
					if(maplv[10]==0){
						TextDeg=38;
					}
					maplv[10]+=1;
					if(savemoneyi[19]>99999999){
						savemoneyi[20]+=1;
						savemoneyi[19]-=100000000;
					}
					if(savemoneyi[20]>99999999){
						savemoneyi[20]=100000000;
					}
					mapmoneyk ();
					moneyk();
				}
			}
		}
		if (GUI.Button (new Rect (360* sw, 297* sh, 225 * sw, 55 * sh), "購入費用:"+savemoneys[22]+savemoneys[21]+"\n収益金+:"+(mapsyuueki[11].ToString())+"\nこころがお面屋を出店します")) {
			if(money2>0){
				if(money2>=savemoneyi[22]&&money>savemoneyi[21]){
					money2-=savemoneyi[22];
					money2-=1;
					money+=100000000;
					money-=savemoneyi[21];
					syuueki+=mapsyuueki[11];
					savemoneyi[21]+=(int)(savemoneyi[21]*0.4);
					if(maplv[11]==0){
						TextDeg=39;
					}
					maplv[11]+=1;
					if(savemoneyi[21]>99999999){
						savemoneyi[22]+=1;
						savemoneyi[21]-=100000000;
					}
					if(savemoneyi[22]>99999999){
						savemoneyi[22]=100000000;
					}
					mapmoneyk ();
					moneyk();
				}
			}
			if(money2>0&&savemoneyi[22]==0){
				money2-=1;
				money+=100000000;
				money-=savemoneyi[21];
				syuueki+=mapsyuueki[11];
				savemoneyi[21]+=(int)(savemoneyi[21]*0.4);
				if(maplv[11]==0){
					TextDeg=39;
				}
				maplv[11]+=1;
				if(savemoneyi[21]>99999999){
					savemoneyi[22]+=1;
					savemoneyi[21]-=100000000;
				}
				if(savemoneyi[22]>99999999){
					savemoneyi[22]=100000000;
				}
				mapmoneyk ();
				moneyk();
			}
			if(money2==0){
				if(savemoneyi[22]==0&&money>savemoneyi[21]){
					money-=savemoneyi[21];
					syuueki+=mapsyuueki[11];
					savemoneyi[21]+=(int)(savemoneyi[21]*0.4);
					if(maplv[11]==0){
						TextDeg=39;
					}
					maplv[11]+=1;
					if(savemoneyi[21]>99999999){
						savemoneyi[22]+=1;
						savemoneyi[21]-=100000000;
					}
					if(savemoneyi[22]>99999999){
						savemoneyi[22]=100000000;
					}
					mapmoneyk ();
					moneyk();
				}
			}
		}
		if (GUI.Button (new Rect (360* sw, 355* sh, 225 * sw, 55 * sh), "購入費用:"+savemoneys[24]+savemoneys[23]+"\n収益金+:"+(mapsyuueki[12].ToString())+"\nレミリアが教室を出店します")) {
			if(money2>0){
				if(money2>=savemoneyi[24]&&money>savemoneyi[23]){
					money2-=savemoneyi[24];
					money2-=1;
					money+=100000000;
					money-=savemoneyi[23];
					syuueki+=mapsyuueki[12];
					savemoneyi[23]+=(int)(savemoneyi[23]*0.5);
					if(maplv[12]==0){
						TextDeg=40;
					}
					maplv[12]+=1;
					if(savemoneyi[23]>99999999){
						savemoneyi[24]+=1;
						savemoneyi[23]-=100000000;
					}
					if(savemoneyi[24]>99999999){
						savemoneyi[24]=100000000;
					}
					mapmoneyk ();
					moneyk();
				}
			}
			if(money2>0&&savemoneyi[24]==0){
				money2-=1;
				money+=100000000;
				money-=savemoneyi[23];
				syuueki+=mapsyuueki[12];
				savemoneyi[23]+=(int)(savemoneyi[23]*0.5);
				if(maplv[12]==0){
					TextDeg=40;
				}
				maplv[12]+=1;
				if(savemoneyi[23]>99999999){
					savemoneyi[24]+=1;
					savemoneyi[23]-=100000000;
				}
				if(savemoneyi[24]>99999999){
					savemoneyi[24]=100000000;
				}
				mapmoneyk ();
				moneyk();
			}
			if(money2==0){
				if(savemoneyi[24]==0&&money>savemoneyi[23]){
					money-=savemoneyi[23];
					syuueki+=mapsyuueki[12];
					savemoneyi[23]+=(int)(savemoneyi[23]*0.5);
					if(maplv[12]==0){
						TextDeg=40;
					}
					maplv[12]+=1;
					if(savemoneyi[23]>99999999){
						savemoneyi[24]+=1;
						savemoneyi[23]-=100000000;
					}
					if(savemoneyi[24]>99999999){
						savemoneyi[24]=100000000;
					}
					mapmoneyk ();
					moneyk();
				}
			}
		}
		if (GUI.Button (new Rect (360* sw, 413* sh, 225 * sw, 55 * sh), "購入費用:"+savemoneys[26]+savemoneys[25]+"\n収益金+:"+(mapsyuueki[13].ToString())+"\nさとりが占い屋出店します")) {
			if(money2>0){
				if(money2>=savemoneyi[26]&&money>=savemoneyi[25]){
					money2-=savemoneyi[26];
					money2-=1;
					money+=100000000;
					money-=savemoneyi[25];
					syuueki+=mapsyuueki[13];
					savemoneyi[25]+=(int)(savemoneyi[25]*0.5);
					if(maplv[13]==0){
						TextDeg=41;
					}
					maplv[13]+=1;
					if(savemoneyi[25]>99999999){
						savemoneyi[26]+=1;
						savemoneyi[25]-=100000000;
					}
					if(savemoneyi[26]>99999999){
						savemoneyi[26]=100000000;
					}
					mapmoneyk ();
					moneyk();
				}
			}
			if(money2>0&&savemoneyi[26]==0){
				money2-=1;
				money+=100000000;
				money-=savemoneyi[25];
				syuueki+=mapsyuueki[13];
				savemoneyi[25]+=(int)(savemoneyi[25]*0.5);
				if(maplv[13]==0){
					TextDeg=41;
				}
				maplv[13]+=1;
				if(savemoneyi[25]>99999999){
					savemoneyi[26]+=1;
					savemoneyi[25]-=100000000;
				}
				if(savemoneyi[26]>99999999){
					savemoneyi[26]=100000000;
				}
				mapmoneyk ();
				moneyk();
			}
			if(money2==0){
				if(savemoneyi[26]==0&&money>savemoneyi[25]){
					money-=savemoneyi[26];
					syuueki+=mapsyuueki[13];
					savemoneyi[25]+=(int)(savemoneyi[25]*0.5);
					if(maplv[13]==0){
						TextDeg=41;
					}
					maplv[13]+=1;
					if(savemoneyi[25]>99999999){
						savemoneyi[26]+=1;
						savemoneyi[25]-=100000000;
					}
					if(savemoneyi[26]>99999999){
						savemoneyi[26]=100000000;
					}
					mapmoneyk ();
					moneyk();
				}
			}
		}

		for(int i=0;i<8;i++){
			if (GUI.Button (new Rect (605* sw, (7+(i*58))* sh, 55 * sw, 55 * sh), buttonTexture[i+14])) {
			}
		}
		if (GUI.Button (new Rect (660* sw, 7* sh, 215 * sw, 55 * sh), "購入費用:"+savemoneys[27]+"\n収益金+:"+(mapsyuueki[14].ToString())+"\n輝夜が薬屋を出店します")) {
			if(money2>0){
				if(money2>=savemoneyi[27]){
					money2-=savemoneyi[27];
					syuueki+=mapsyuueki[14];
					savemoneyi[27]+=(int)(savemoneyi[27]);
					if(maplv[14]==0){
						TextDeg=42;
					}
					maplv[14]+=1;
					if(savemoneyi[27]>99999999){
						savemoneyi[27]=100000000;
					}
					mapmoneyk ();
					moneyk();
				}
			}
		}
		if (GUI.Button (new Rect (660* sw, 65* sh, 215 * sw, 55 * sh), "購入費用:"+savemoneys[28]+"\n収益金+:"+(mapsyuueki[15].ToString())+"\n幽香が花屋を出店します")) {
			if(money2>0){
				if(money2>=savemoneyi[28]){
					money2-=savemoneyi[28];
					syuueki+=mapsyuueki[15];
					savemoneyi[28]+=(int)(savemoneyi[28]);
					if(maplv[15]==0){
						TextDeg=43;
					}
					maplv[15]+=1;
					if(savemoneyi[28]>99999999){
						savemoneyi[28]=100000000;
					}
					mapmoneyk ();
					moneyk();
				}
			}
		}
		if (GUI.Button (new Rect (660* sw, 123* sh, 215 * sw, 55 * sh), "購入費用:"+savemoneys[29]+"\n収益金+:"+(mapsyuueki[16].ToString())+"\n早苗がグッズ販売を行います")) {
			if(money2>0){
				if(money2>=savemoneyi[29]){
					money2-=savemoneyi[29];
					syuueki+=mapsyuueki[16];
					savemoneyi[29]+=(int)(savemoneyi[29]);
					if(maplv[16]==0){
						TextDeg=44;
					}
					maplv[16]+=1;
					if(savemoneyi[29]>99999999){
						savemoneyi[29]=100000000;
					}
					mapmoneyk ();
					moneyk();
				}
			}
		}
		if (GUI.Button (new Rect (660* sw, 181* sh, 215 * sw, 55 * sh), "購入費用:"+savemoneys[30]+"\n収益金+:"+(mapsyuueki[17].ToString())+"\n聖が教室を開きます")) {
			if(money2>0){
				if(money2>=savemoneyi[30]){
					money2-=savemoneyi[30];
					syuueki+=mapsyuueki[17];
					savemoneyi[30]+=(int)(savemoneyi[30]);
					if(maplv[17]==0){
						TextDeg=45;
					}
					maplv[17]+=1;
					if(savemoneyi[30]>99999999){
						savemoneyi[30]=100000000;
					}
					mapmoneyk ();
					moneyk();
				}
			}
		}
		if (GUI.Button (new Rect (660* sw, 239* sh, 215 * sw, 55 * sh), "購入費用:"+savemoneys[31]+"\n収益金+:"+(mapsyuueki[18].ToString())+"\n神子がサービス店を出店します")) {
			if(money2>0){
				if(money2>=savemoneyi[31]){
					money2-=savemoneyi[31];
					syuueki+=mapsyuueki[18];
					savemoneyi[31]+=(int)(savemoneyi[31]);
					if(maplv[18]==0){
						TextDeg=46;
					}
					maplv[18]+=1;
					if(savemoneyi[31]>99999999){
						savemoneyi[31]=100000000;
					}
					mapmoneyk ();
					moneyk();
				}
			}
		}
		if (GUI.Button (new Rect (660* sw, 297* sh, 215 * sw, 55 * sh), "購入費用:"+savemoneys[32]+"\n収益金+:"+(mapsyuueki[19].ToString())+"\nEX3人娘が出店します")) {
			if(money2>0){
				if(money2>=savemoneyi[32]){
					money2-=savemoneyi[32];
					syuueki+=mapsyuueki[19];
					savemoneyi[32]+=(int)(savemoneyi[32]);
					if(maplv[19]==0){
						TextDeg=47;
					}
					maplv[19]+=1;
					if(savemoneyi[32]>99999999){
						savemoneyi[32]=100000000;
					}
					mapmoneyk ();
					moneyk();
				}
			}
		}
		if (GUI.Button (new Rect (660* sw, 355* sh, 215 * sw, 55 * sh), "購入費用:"+savemoneys[33]+"\n収益金+:"+(mapsyuueki[20].ToString())+"\n岡崎教授が道具屋を出店します")) {
			if(money2>0){
				if(money2>=savemoneyi[33]){
					money2-=savemoneyi[33];
					syuueki+=mapsyuueki[20];
					savemoneyi[33]+=(int)(savemoneyi[33]);
					if(maplv[20]==0){
						TextDeg=48;
					}
					maplv[20]+=1;
					if(savemoneyi[33]>99999999){
						savemoneyi[33]=100000000;
					}
					mapmoneyk ();
					moneyk();
				}
			}
		}
		if (GUI.Button (new Rect (660* sw, 413* sh, 215 * sw, 55 * sh), "購入費用:"+savemoneys[34]+"\n収益金+:"+(mapsyuueki[21].ToString())+"\n賽銭箱を新しくします")) {
			if(money2>0){
				if(money2>=savemoneyi[34]){
					money2-=savemoneyi[34];
					syuueki+=mapsyuueki[21];
					savemoneyi[34]+=(int)(savemoneyi[34]);
					maplv[21]+=1;
					if(savemoneyi[34]>99999999){
						savemoneyi[34]=100000000;
					}
					mapmoneyk ();
					moneyk();
					FadeManager.Instance.LoadLevel("ending",1.0f);
				}
			}
		}


}
}
