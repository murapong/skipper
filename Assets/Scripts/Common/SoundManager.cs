using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;

    #region AudioClip

    private AudioClip bgmTitle;
    private AudioClip bgmMain;
    private AudioClip seYes;
    private AudioClip seNo;
    private AudioClip seJump;
    private AudioClip sePull;

    #endregion

    #region AudioSource

    private AudioSource audioSourceBgm;
    private AudioSource audioSourceYes;
    private AudioSource audioSourceNo;
    private AudioSource audioSourceJump;
    private AudioSource audioSourcePull;

    #endregion

    #region Volume

    [RangeAttribute(0.0f, 1.0f)]
    public float bgmTitleVolume;
    [RangeAttribute(0.0f, 1.0f)]
    public float bgmMainVolume;
    [RangeAttribute(0.0f, 1.0f)]
    public float seYesVolume;
    [RangeAttribute(0.0f, 1.0f)]
    public float seNoVolume;
    [RangeAttribute(0.0f, 1.0f)]
    public float seJumpVolume;
    [RangeAttribute(0.0f, 1.0f)]
    public float sePullVolume;

    #endregion

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
        // TODO: 不要なBGMを削除
        this.bgmTitle = Resources.Load("Sounds/bgm_opening") as AudioClip;
        this.bgmMain = Resources.Load("Sounds/bgm_main") as AudioClip;
        this.seYes = Resources.Load("Sounds/yes") as AudioClip;
        this.seNo = Resources.Load("Sounds/no") as AudioClip;
        this.seJump = Resources.Load("Sounds/jump") as AudioClip;
        this.sePull = Resources.Load("Sounds/pull") as AudioClip;

        this.audioSourceBgm = this.gameObject.AddComponent<AudioSource>();
        this.audioSourceYes = this.gameObject.AddComponent<AudioSource>();
        this.audioSourceNo = this.gameObject.AddComponent<AudioSource>();
        this.audioSourceJump = this.gameObject.AddComponent<AudioSource>();
        this.audioSourcePull = this.gameObject.AddComponent<AudioSource>();

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

    public void PlayTitleBgm()
    {
        this.audioSourceBgm.clip = this.bgmTitle;
        this.audioSourceBgm.loop = true;
        this.audioSourceBgm.volume = this.bgmTitleVolume;
        this.audioSourceBgm.Play();
    }

    public void PlayMainBgm()
    {
        this.audioSourceBgm.clip = this.bgmMain;
        this.audioSourceBgm.loop = true;
        this.audioSourceBgm.volume = this.bgmMainVolume;
        this.audioSourceBgm.Play();
    }

    public void PlayYesSe()
    {
        this.audioSourceYes.clip = this.seYes;
        this.audioSourceYes.volume = this.seYesVolume;
        this.audioSourceYes.Play();
    }

    public void PlayNoSe()
    {
        this.audioSourceNo.clip = this.seNo;
        this.audioSourceNo.volume = this.seNoVolume;
        this.audioSourceNo.Play();
    }

    public void PlayJumpSe()
    {
        this.audioSourceJump.clip = this.seJump;
        this.audioSourceJump.volume = this.seJumpVolume;
        this.audioSourceJump.Play();
    }

    public void PlayPullSe()
    {
        this.audioSourcePull.clip = this.sePull;
        this.audioSourcePull.volume = this.sePullVolume;
        this.audioSourcePull.Play();
    }

    public void StopPullSe()
    {
        this.audioSourcePull.Stop();
    }
}
