using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    GameObject player;

    void Awake()
    {
        CreatePlayer();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void CreatePlayer()
    {
        player = Instantiate(Resources.Load("Prefabs/Player"), this.transform.position, Quaternion.identity) as GameObject;
    }
}

//private var remainCheck : PlayerRemainCheck;
//
//function Start () {
// CreatePlayer();
// remainCheck = GetComponent(PlayerRemainCheck);
//}


//function Update() {
// if ( !nowPlayer ) {
//     if ( remainCheck.lastPlayerNum > 0 ) {
//         remainCheck.lastPlayerNum--;
//         CreatePlayer();
//     } else {
//         SendMessage("SetDisp");
//     }
// }
//}
