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

    void Awake()
    {
        startPosition = this.transform.position;
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        startPosition = this.transform.position;
    }

    void OnMouseDrag()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
        {
            transform.position = new Vector3(hit.point.x, hit.point.y, 0.0f);
        }

        this.rigidbody.useGravity = false;

        lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, this.transform.position);
        lineRenderer.SetPosition(1, startPosition);
    }

    void OnMouseUp()
    {
        isMoving = true;

        Vector3 direction = this.startPosition - this.transform.position;
        direction *= velocity;
        this.rigidbody.useGravity = true;
        this.rigidbody.AddForce(direction, ForceMode.Impulse);

        lineRenderer.enabled = false;

        SoundManager.Instance.PlayJumpSe();
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
