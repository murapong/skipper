using UnityEngine;
using System.Collections;

public class TitleController : MonoBehaviour {
	
	public	GUIStyle	BaseStyle;
	public	GUIStyle	pushBotton;
	public  Texture2D	testBotton;
	public  GUITexture	tests;
	public	string		nextSceneName	=	"Stage1";
	private float		baseScreenSize	=	100.0f;
	private bool		R_downFlag		=	true;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButton(0)==true){
			Application.LoadLevel(nextSceneName);
		}
		/*
		if(R_downFlag	==	true){
			pushBotton.normal.textColor = new Color(pushBotton.normal.textColor.r,pushBotton.normal.textColor.g,pushBotton.normal.textColor.b,Mathf.Lerp(pushBotton.normal.textColor.r,0.0f,0.5f));
			if(pushBotton.normal.textColor.r <= 0.0f){
				R_downFlag	= false;	
			}
		}else{
			pushBotton.normal.textColor = new Color(pushBotton.normal.textColor.r,pushBotton.normal.textColor.g,pushBotton.normal.textColor.b,Mathf.Lerp(pushBotton.normal.textColor.r,1.0f,0.5f));
			if(pushBotton.normal.textColor.r >= 1.0f){
				R_downFlag	= true;	
			}
		}*/
	}
	
	void OnGUI(){
		GUI.Button(new Rect(0.0f * (Screen.width /	baseScreenSize) ,0.0f * (Screen.height /	baseScreenSize),100f * (Screen.width /	baseScreenSize), 100.0f * (Screen.height /	baseScreenSize)),"",BaseStyle);
		GUI.Button(new Rect(30.0f * (Screen.width /	baseScreenSize) ,75.0f * (Screen.height /	baseScreenSize),40f * (Screen.width /	baseScreenSize), 10.0f * (Screen.height /	baseScreenSize)),"",pushBotton);
	//	GUI.DrawTexture(new Rect(30.0f * (Screen.width /	baseScreenSize) ,75.0f * (Screen.height /	baseScreenSize),40f * (Screen.width /	baseScreenSize), 10.0f * (Screen.height /	baseScreenSize)),testBotton);
	}
}
