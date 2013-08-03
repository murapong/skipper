using UnityEngine;
using System.Collections;

public class PlayerDrag : MonoBehaviour
{
    [SerializeField]
    private float velocity;
    private Vector3 startPosition;
    private LineRenderer lineRenderer;

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
        Vector3 direction = this.startPosition - this.transform.position;
        direction *= velocity;
        this.rigidbody.useGravity = true;
        this.rigidbody.AddForce(direction, ForceMode.Impulse);

        lineRenderer.enabled = false;
    }
}
