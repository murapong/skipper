using UnityEngine;
using System.Collections;

public class particleMove : MonoBehaviour {
	
	private GameObject	player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		player = GameObject.FindWithTag("Player");
		gameObject.transform.position = player.transform.position;
	}
}
