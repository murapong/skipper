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
        spriteScript.AnimationFinished = null;
        spriteScript.Play();
    }
}
