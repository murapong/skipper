using UnityEngine;
using System.Collections;

public class StageController : MonoBehaviour
{
    private PlayerController playerController;

    void Awake()
    {
        SoundManager.Instance.PlayMainBgm();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().SendMessage("DoubleJump");
        }
    }
}
