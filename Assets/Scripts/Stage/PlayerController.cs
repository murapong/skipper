using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float velocity;
    [SerializeField]
    private float doubleJumpVelocity;
    private Vector3 startPosition;
    private LineRenderer lineRenderer;
    private bool isMoving;
    private bool isDoubleJumped;
    private SoundManager soundManager;
    private PlayerAnimationManager animationManager;
    private bool isUp;

    void Awake()
    {
        startPosition = this.transform.position;

        lineRenderer = GetComponent<LineRenderer>();

        soundManager = SoundManager.Instance;

        animationManager = GetComponent<PlayerAnimationManager>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.rigidbody.velocity.y > 2.0f && !isUp)
        {
            isUp = true;
            animationManager.PlayJumpUpAnimation();
        }

        if (gameObject.rigidbody.velocity.y < -2.0f && isUp)
        {
            isUp = false;
            animationManager.PlayJumpDownAnimation();
        }

        if (Mathf.Abs(gameObject.rigidbody.velocity.x) <= 0.5 && Mathf.Abs(gameObject.rigidbody.velocity.y) <= 0.0f)
        {
            animationManager.PlayIdlingAnimation();
        }
    }

    void OnMouseDown()
    {
        startPosition = this.transform.position;

        soundManager.PlayPullSe();

        animationManager.PlayChargingAnimation();
    }

    void OnMouseDrag()
    {
        this.rigidbody.useGravity = false;

        lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, Camera.main.ScreenToWorldPoint(Input.mousePosition));
        lineRenderer.SetPosition(1, startPosition);
    }

    void OnMouseUp()
    {
        isMoving = true;

        Vector3 direction = this.startPosition - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction *= velocity;
        this.rigidbody.useGravity = true;
        this.rigidbody.AddForce(direction, ForceMode.Impulse);

        lineRenderer.enabled = false;

        soundManager.PlayJumpSe();
        soundManager.StopPullSe();
    }

    void DoubleJump()
    {
        if (this.isDoubleJumped)
        {
            return;
        }

        if (!this.isMoving)
        {
            return;
        }

        this.rigidbody.useGravity = true;
        this.rigidbody.AddForce(Vector3.up * doubleJumpVelocity, ForceMode.Impulse);

        lineRenderer.enabled = false;

        this.isDoubleJumped = true;
    }
}
