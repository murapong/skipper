using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    private AudioClip bgm;
    private AudioClip seYes;
    private AudioClip seNo;
    private AudioSource audioSourceBgm;
    private AudioSource audioSourceYes;
    private AudioSource audioSourceNo;

    public static SoundManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject go = GameObject.Instantiate(Resources.Load("Prefabs/Common/SoundManager", typeof(GameObject))) as GameObject;
                instance = go.GetComponent<SoundManager>();
            }

            return instance;
        }
    }

    void Awake()
    {
        this.bgm = Resources.Load("Sounds/bgm") as AudioClip;
        this.seYes = Resources.Load("Sounds/yes") as AudioClip;
        this.seNo = Resources.Load("Sounds/no") as AudioClip;

        this.audioSourceBgm = this.gameObject.AddComponent<AudioSource>();
        this.audioSourceYes = this.gameObject.AddComponent<AudioSource>();
        this.audioSourceNo = this.gameObject.AddComponent<AudioSource>();

        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayBgm()
    {
        this.audioSourceBgm.clip = this.bgm;
        this.audioSourceBgm.loop = true;
        this.audioSourceBgm.Play();
    }

    public void PlayYesSe()
    {
        this.audioSourceYes.clip = this.seYes;
        this.audioSourceYes.Play();
    }

    public void PlayNoSe()
    {
        this.audioSourceNo.clip = this.seNo;
        this.audioSourceNo.Play();
    }
}
