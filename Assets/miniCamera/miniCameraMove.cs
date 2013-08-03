using UnityEngine;
using System.Collections;

public class miniCameraMove : MonoBehaviour {
	
	private GameObject	player;
	private bool		liveFlag		=	true;
	private bool		clearFlag		=	false;
	private Vector2		oldPlayerPos;
	private Vector2		newPlayerPos;
	private float		baseScreenSize	=	100.0f;
	
	public	float		height			=	0.5f;
	public	float		width			=	0.3f;
	public	float		moveSpead		=	0.5f;

	public  GUIStyle	frame;
	
	// Use this for initialization
	void Start () {
		init();
	}
	
	// Update is called once per frame
	void Update () {
		if(liveFlag && clearFlag == false){
			cameraMove();
		}else{
			camera.enabled	=	false;
		}
	}
	
	void cameraMove(){
		newPlayerPos					=	new Vector2(player.transform.position.x,player.transform.position.y);
		oldPlayerPos					=	Vector2.Lerp(oldPlayerPos,newPlayerPos,moveSpead);
		gameObject.transform.position	=	new Vector3(oldPlayerPos.x,oldPlayerPos.y,gameObject.transform.position.z);
	}
	void OnGUI(){
		if(liveFlag && clearFlag == false){
			GUI.Button(new Rect(70.0f * (Screen.width /	baseScreenSize) ,0.0f * (Screen.height /	baseScreenSize),30f * (Screen.width /	baseScreenSize), 30.0f * (Screen.height /	baseScreenSize)),"",frame);	
		}
	}
	
	void DeadChage(){
		liveFlag	=	false;
	}
	
	void replay(){
		init();
		camera.enabled	=	true;
		liveFlag		=	true;
	}
	
	void init(){
		player 							= GameObject.FindWithTag("Player");
		Debug.Log("gamena"+player.name);
		Vector2	startPos				= new Vector2(player.transform.position.x,player.transform.position.y); 
		Vector3 startPos_3				= new Vector3(startPos.x - width,startPos.y + height,gameObject.transform.position.z);
		gameObject.transform.position	= startPos_3;
		oldPlayerPos					= startPos;
		newPlayerPos					= newPlayerPos;
	}
	
	void clearChange(){
		clearFlag	=	true;
	}
}
