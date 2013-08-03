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
        player = Instantiate(Resources.Load("Prefabs/Stage/Player"), this.transform.position, Quaternion.identity) as GameObject;
    }
}