using UnityEngine;
using System.Collections;

public class StageController : MonoBehaviour
{
    private PlayerController playerController;

    void Awake()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

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
            playerController.SendMessage("DoubleJump");
        }
    }
}
