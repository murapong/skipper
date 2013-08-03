using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {
	
	private GameObject	player;
	public	GameObject	playerPre;
	public	float		min_XSize		=	300.0f;
	public	float		max_XSize		=	300.0f;
	public	float		min_YSize		=	50.0f;
	public	float		playerDedSize	=	50.0f;
	
	private bool		cameraDedFalg	=	false;
	private bool		playerDedFlag	=	false;	
	private Vector3		replayePos;
	
	private float		scoreTime		=	0.0f;		
	private int			scorePoint		=	0;
	private int			jumpingCount	=	0;
	private	int			fallCount		=	0;
	
	//Timer
	public	GUIStyle	timerCG_Style;
	public	GUIStyle	timerNameStyle;
	public	float		timerFontSize	=	5.0f;
	public	float		timerSize		=	180.0f;
	private float		baseScreenSize	=	100.0f;
	
	// Use this for initialization
	void Start () {
		player 				= GameObject.FindWithTag("Player");
		replayePos			= player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(!playerDedFlag){
			if(cameraDedFalg	== false){
				cameraDeadLineCheck();
			}else{
				playerDeadLineCheck();
			}
			if(timerSize - Time.time < 0.0f){
				playerDed();
			}
		}
	}
	
	void cameraDeadLineCheck(){
		if(player.transform.position.y	<	-min_YSize){
			sendCameraDed();
		}else if(player.transform.position.x	<	-min_XSize){
			sendCameraDed();
		}else if(player.transform.position.x	>	max_XSize){
			sendCameraDed();
		}
	}
	
	void playerDeadLineCheck(){
		if(player.transform.position.y	<	-(min_YSize + playerDedSize)){
			replayInit();
		}else if(player.transform.position.x	<	-(min_XSize + playerDedSize)){
			replayInit();
		}else if(player.transform.position.x	>	(max_XSize + playerDedSize)){
			replayInit();
		}
	}
	
	void replayInit(){
		Destroy(player);
		fallCount	+=	1;
		Instantiate(playerPre,replayePos,playerPre.transform.rotation);
		GameObject.FindWithTag("miniCamera").SendMessage("replay");
		GameObject.FindWithTag("MainCamera").SendMessage("replay");
		cameraDedFalg	=	false;
	}
	
	void sendCameraDed(){
		Debug.Log("OverSize");
		GameObject.FindWithTag("miniCamera").SendMessage("DeadChage");
		GameObject.FindWithTag("MainCamera").SendMessage("DeadChage");
		cameraDedFalg	=	true;
	}
	
	void playerDed(){
		Debug.Log("playerDed");
		Destroy(player);
		GameObject.FindWithTag("miniCamera").SendMessage("DeadChage");
		GameObject.FindWithTag("MainCamera").SendMessage("DeadChage");
		playerDedFlag	=	true;
	}
	
	void OnGUI(){
		if(playerDedFlag	== false){
			timerView();
		}else{
			continueGUI();
		}
	}
	
	void timerView(){
		float	time			=	Time.time;
		float	timeS			=	timerSize		-	time;
		timerNameStyle.fontSize	=	(int)(timerFontSize	*	(Screen.width /	baseScreenSize));
		GUI.Button(new Rect(11.0f 	* (Screen.width /	baseScreenSize) ,4.0f 	* (Screen.height /	baseScreenSize),20.0f * (Screen.width /	baseScreenSize), 20.0f * (Screen.height /	baseScreenSize)), Mathf.Floor(timeS / 60f) + ":" + Mathf.Floor(timeS % 60f),timerNameStyle);
		GUI.Button(new Rect(0.0f	* (Screen.width /	baseScreenSize) ,5.0f 	* (Screen.height /	baseScreenSize),10.0f * (Screen.width /	baseScreenSize), 10.0f * (Screen.height /	baseScreenSize)), "",timerCG_Style);
	}
	
	void continueGUI(){
		
	}
}
