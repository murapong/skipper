using UnityEngine;
using System.Collections;

public class TitleController : MonoBehaviour {
	
	public	GUIStyle	BaseStyle;
	public	string		nextSceneName	=	"miniMapScene";
	private float		baseScreenSize	=	100.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButton(0)==true){
			Application.LoadLevel(nextSceneName);
		}
	}
	
	void OnGUI(){
		GUI.Button(new Rect(0.0f * (Screen.width /	baseScreenSize) ,0.0f * (Screen.height /	baseScreenSize),100f * (Screen.width /	baseScreenSize), 100.0f * (Screen.height /	baseScreenSize)),"",BaseStyle);
	}
}
