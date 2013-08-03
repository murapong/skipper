using UnityEngine;
using System.Collections;

public class miniCameraMove : MonoBehaviour {
	
	private GameObject	player;
	private bool		liveFlag		=	true;
	private Vector2		oldPlayerPos;
	private Vector2		newPlayerPos;
	private float		baseScreenSize	=	100.0f;
	
	public	float		height			=	0.5f;
	public	float		width			=	0.3f;
	public	float		moveSpead		=	0.5f;
	public	float		TimeFontSize	=	5.0f;

	public  GUIStyle	frame;
	
	//Timer
	public	GUIStyle	timerStyle;
	public	float		timerFontSize	=	5.0f;
	public	float		timerPosX		=	0.0f;
	public	float		timerPosY		=	0.0f;
	public	float		timerSize		=	180.0f;
	public	GUIStyle	timerNameStyle;
	public	Vector2		timerNamePos;
	
	public	float		timewideSize	=	5.0f;
	public	float		timeheightSize	=	10.0f;
	
	// Use this for initialization
	void Start () {
		player 							= GameObject.FindWithTag("Player");
		Vector2	startPos				= new Vector2(player.transform.position.x,player.transform.position.y); 
		Vector3 startPos_3				= new Vector3(startPos.x - width,startPos.y + height,gameObject.transform.position.z);
		gameObject.transform.position	= startPos_3;
		oldPlayerPos					= startPos;
		newPlayerPos					= newPlayerPos;
	}
	
	// Update is called once per frame
	void Update () {
		if(liveFlag){
			cameraMove();
		}
	}
	
	void cameraMove(){
		newPlayerPos					=	new Vector2(player.transform.position.x,player.transform.position.y);
		oldPlayerPos					=	Vector2.Lerp(oldPlayerPos,newPlayerPos,moveSpead);
		gameObject.transform.position	=	new Vector3(oldPlayerPos.x,oldPlayerPos.y,gameObject.transform.position.z);
	}
	void OnGUI(){
		GUI.Button(new Rect(70.0f * (Screen.width /	baseScreenSize) ,0.0f * (Screen.height /	baseScreenSize),30f * (Screen.width /	baseScreenSize), 30.0f * (Screen.height /	baseScreenSize)),"",frame);
		timerView();
		
	}
	void timerView(){
		float	time			=	Time.time;
		float	timeS			=	timerSize		-	time;
		timerStyle.fontSize		=	(int)(timerFontSize	*	(Screen.width /	baseScreenSize));
		GUI.Button(new Rect(timerPosX 		* (Screen.width /	baseScreenSize) ,timerPosY 		* (Screen.height /	baseScreenSize),timewideSize * (Screen.width /	baseScreenSize), timeheightSize * (Screen.height /	baseScreenSize)), Mathf.Floor(timeS / 60f) + ":" + Mathf.Floor(timeS % 60f),timerStyle);
		GUI.Button(new Rect(timerNamePos.x	* (Screen.width /	baseScreenSize) ,timerNamePos.y * (Screen.height /	baseScreenSize),timewideSize * (Screen.width /	baseScreenSize), timeheightSize * (Screen.height /	baseScreenSize)), "",timerNameStyle);
	}
}
