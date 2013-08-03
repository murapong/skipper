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

    #endregion

    // loop count (0 is loop)
    [SerializeField]
    public int idlingPlayCount;
    public int chargingCount;

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
        spriteScript.AnimationFinished = null;
        spriteScript.Play();
    }
}
