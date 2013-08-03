using UnityEngine;
using System.Collections;

public class PlayerAnimationManager : MonoBehaviour
{
    [HideInInspector]
    public SsSprite spriteScript;

    #region Animation

    [SerializeField]
    private SsAnimation idlingAnimation;
    [SerializeField]
    private SsAnimation chargingAnimation;
    [SerializeField]
    private SsAnimation chargeEndAnimation;
    [SerializeField]
    private SsAnimation jumpUpAnimation;
    [SerializeField]
    private SsAnimation jumpUpEndAnimation;
    [SerializeField]
    private SsAnimation jumpDownAnimation;
    [SerializeField]
    private SsAnimation jumpDownEndAnimation;

    #endregion

    // loop count (0 is loop)
    [SerializeField]
    private int idlingPlayCount;
    [SerializeField]
    private int chargingCount;
    [SerializeField]
    private int chargeEndCount;
    [SerializeField]
    private int jumpUpCount;
    [SerializeField]
    private int jumpUpEndCount;
    [SerializeField]
    private int jumpDownCount;
    [SerializeField]
    private int jumpDownEndCount;

    void Awake()
    {
        spriteScript = gameObject.GetComponent<SsSprite>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayIdlingAnimation()
    {
        spriteScript.Animation = this.idlingAnimation;
        spriteScript.PlayCount = this.idlingPlayCount;
        spriteScript.AnimationFinished = null;
        spriteScript.Play();
    }

    public void PlayChargingAnimation()
    {
        spriteScript.Animation = this.chargingAnimation;
        spriteScript.PlayCount = this.chargingCount;
        spriteScript.AnimationFinished = PlayChargeEndAnimation;
        spriteScript.Play();
    }

    public void PlayChargeEndAnimation(SsSprite sprite)
    {
        spriteScript.Animation = this.chargeEndAnimation;
        spriteScript.PlayCount = this.chargeEndCount;
        spriteScript.AnimationFinished = null;
        spriteScript.Play();
    }

    public void PlayJumpUpAnimation()
    {
        spriteScript.Animation = this.jumpUpAnimation;
        spriteScript.PlayCount = this.jumpUpCount;
        spriteScript.AnimationFinished = PlayJumpUpEndAnimation;
        spriteScript.Play();
    }

    public void PlayJumpUpEndAnimation(SsSprite sprite)
    {
        spriteScript.Animation = this.jumpUpEndAnimation;
        spriteScript.PlayCount = this.jumpUpEndCount;
        spriteScript.AnimationFinished = null;
        spriteScript.Play();
    }

    public void PlayJumpDownAnimation()
    {
        spriteScript.Animation = this.jumpDownAnimation;
        spriteScript.PlayCount = this.jumpDownCount;
        spriteScript.AnimationFinished = PlayJumpDownEndAnimation;
        spriteScript.Play();
    }

    public void PlayJumpDownEndAnimation(SsSprite sprite)
    {
        spriteScript.Animation = this.jumpDownEndAnimation;
        spriteScript.PlayCount = this.jumpDownEndCount;
        spriteScript.AnimationFinished = null;
        spriteScript.Play();
    }
}
