using UnityEngine;
using System.Collections;

public class testPlyarMove : MonoBehaviour {
	
	private GameObject	player;
	public 	float		moveSpead	=	5.0f;
	// Use this for initialization
	void Start () {
		player 							= GameObject.FindWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.A)==true){
			player.transform.position	=	new Vector3(player.transform.position.x + moveSpead * Time.deltaTime,player.transform.position.y,player.transform.position.z);
		}
		if(Input.GetKey(KeyCode.S)==true){
			player.transform.position   =	new Vector3(player.transform.position.x - moveSpead * Time.deltaTime,player.transform.position.y,player.transform.position.z);
		}
		if(Input.GetKey(KeyCode.D)==true){
			player.transform.position	=	new Vector3(player.transform.position.x,player.transform.position.y+moveSpead*Time.deltaTime,player.transform.position.z);
		}
		if(Input.GetKey(KeyCode.F)==true){
			player.transform.position	=	new Vector3(player.transform.position.x,player.transform.position.y-moveSpead*Time.deltaTime,player.transform.position.z);
		}
	}
}
