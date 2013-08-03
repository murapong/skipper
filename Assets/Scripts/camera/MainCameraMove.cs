using UnityEngine;
using System.Collections;

public class MainCameraMove : MonoBehaviour {
	
	private GameObject	player;
	private bool		liveFlag		=	true;
	public	float		height			=	0.5f;
	public	float		width			=	0.3f;
	
	// Use this for initialization
	void Start () {
		init();
	}
	
	// Update is called once per frame
	void Update () {
		if(liveFlag){
			cameraMove();
		}
	}
	
	void cameraMove(){
		gameObject.transform.position	= new Vector3(player.transform.position.x - width,player.transform.position.y + height,gameObject.transform.position.z);
	}
	
	void DeadChage(){
		liveFlag	=	false;
	}
	
	void replay(){
		liveFlag	=	true;
		init();
	}
	
	void init(){
		player 							= GameObject.FindWithTag("Player");
		Debug.Log("gamena"+player.name);
		Vector2	startPos				= new Vector2(player.transform.position.x,player.transform.position.y); 
		Vector3 startPos_3				= new Vector3(startPos.x - width,startPos.y + height,gameObject.transform.position.z);
		gameObject.transform.position	= startPos_3;
	}

}
