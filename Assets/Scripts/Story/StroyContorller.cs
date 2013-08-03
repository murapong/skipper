using UnityEngine;
using System.Collections;

public class StroyContorller : MonoBehaviour {
	
	private int		pictureNowCount		=	0;
	private float	baseScreenSize		=	100.0f;
	public	int		pictureCount		=	0;
	public	string	nextSceneName;
	public	GUIStyle[]	pictures;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)){
			if(pictureNowCount == pictureCount - 1){
				Application.LoadLevel(nextSceneName);
			}else{
				pictureNowCount	+=	1;
			}
		}
	}
	
	void OnGUI(){
		GUI.Button(new Rect(0.0f 	* (Screen.width /	baseScreenSize) ,0.0f 	* (Screen.height /	baseScreenSize),100.0f * (Screen.width /	baseScreenSize), 100.0f * (Screen.height /	baseScreenSize)), "",pictures[pictureNowCount]);
	}
}
