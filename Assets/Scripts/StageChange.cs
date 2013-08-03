using UnityEngine;
using System.Collections;

public class StageChange : MonoBehaviour {
	
	public	string		nextStage;
	public	GUIStyle	Clear_CG;
	public	GUIStyle	Point_CG;
	public	GUIStyle	Time_CG;
	public  GUIStyle	nextStage_CG;
	public	GUIStyle	font;
	private	float		baseScreenSize	=	100.0f;
	
	private bool		nextFlag		=	false;
	private float		baseFontSize	=	5.0f;
	
	private float		clearTime		=	0.0f;
	private float		score			=	0.0f;
	public	float		timerSize		=	180.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(nextFlag){
			nextScene();
		}
	}
	
	void nextScene(){
		//Application.LoadLevel(nextStage);
	}
	
	void OnGUI(){
		if(nextFlag){
			float	timeS			=	timerSize		-	clearTime;
			GUI.Button(new Rect(20.0f 		* (Screen.width /	baseScreenSize) , 5.0f 	* (Screen.height /	baseScreenSize),60.0f * (Screen.width /	baseScreenSize), 30.0f * (Screen.height /	baseScreenSize)),"",Clear_CG);
			GUI.Button(new Rect(30.0f 		* (Screen.width /	baseScreenSize) , 40.0f 	* (Screen.height /	baseScreenSize),15.0f * (Screen.width /	baseScreenSize), 15.0f * (Screen.height /	baseScreenSize)),"",Point_CG);
			GUI.Button(new Rect(30.0f 		* (Screen.width /	baseScreenSize) , 60.0f 	* (Screen.height /	baseScreenSize),15.0f * (Screen.width /	baseScreenSize), 15.0f * (Screen.height /	baseScreenSize)),"",Time_CG);
			GUI.Button(new Rect(20.0f 		* (Screen.width /	baseScreenSize) , 80.0f 	* (Screen.height /	baseScreenSize),60.0f * (Screen.width /	baseScreenSize), 10.0f * (Screen.height /	baseScreenSize)),"",nextStage_CG);
			
			
			font.fontSize		=	(int)(baseFontSize	*	(Screen.width /	baseScreenSize)); 
			GUI.Button(new Rect(50.0f * (Screen.width /	baseScreenSize) ,40.0f 		* (Screen.height /	baseScreenSize),40.0f * (Screen.width /	baseScreenSize), 15.0f * (Screen.height /	baseScreenSize)), Mathf.Floor(timeS / 60f) + ":" + Mathf.Floor(timeS % 60f),font);
			GUI.Button(new Rect(50.0f * (Screen.width /	baseScreenSize) ,60.0f 		* (Screen.height /	baseScreenSize),40.0f * (Screen.width /	baseScreenSize), 15.0f * (Screen.height /	baseScreenSize)), ""+score,font);
		}
		//	GUI.Button(new Rect(timerNamePos.x	* (Screen.width /	baseScreenSize) ,timerNamePos.y * (Screen.height /	baseScreenSize),timewideSize * (Screen.width /	baseScreenSize), timeheightSize * (Screen.height /	baseScreenSize)), "",timerNameStyle);
	
	
	//	GUI.Button(new Rect(timerPosX 		* (Screen.width /	baseScreenSize) ,timerPosY 		* (Screen.height /	baseScreenSize),timewideSize * (Screen.width /	baseScreenSize), timeheightSize * (Screen.height /	baseScreenSize)), Mathf.Floor(timeS / 60f) + ":" + Mathf.Floor(timeS % 60f),timerStyle);
	}
	
	void OnCollisionEnter(Collision coinfor) {
		Debug.Log("test");
		if(coinfor.gameObject.tag	==	"Player"){
			nextFlag	=	true;
			clearTime	=	Time.time;
		}
	}
}
