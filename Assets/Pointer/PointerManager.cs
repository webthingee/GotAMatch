using UnityEngine;
using UnityEngine.UI;

public class PointerManager : MonoBehaviour
{
    public string pointerText;
	public LayerMask floorLayer;

	LineRenderer lineRenderer;

	private void Awake()
	{
		lineRenderer = GetComponent<LineRenderer>();
	}

	private void Update()
    {
        // center on mouse
        var pos = Input.mousePosition;
        pos.z = 10;
        pos = Camera.main.ScreenToWorldPoint(pos);
        transform.position = pos;

        UpdatePointerDisplay();

		DisplayFloorLine(transform.position, GetFloorPoint(transform.position));
    }

    public void UpdatePointerDisplay()
    {
		GetComponentInChildren<Text>().text = pointerText;
    }

	void DisplayFloorLine (Vector3 _startingPoint, Vector3 _floorPoint)
    {
        Vector3[] positions = new Vector3[3];
        positions[0] = _startingPoint;
        positions[1] = _floorPoint;
        lineRenderer.positionCount = positions.Length - 1;
        lineRenderer.SetPositions(positions);
		lineRenderer.startWidth = 0.05f;

        if (_startingPoint != _floorPoint)
        {
            lineRenderer.enabled = true;
        }
        else
        {
            lineRenderer.enabled = false;
        }
    }

	Vector3 GetFloorPoint(Vector3 _startingPoint)
    {
        var rayStart = _startingPoint;
        var rayDir = Vector2.down;
        float rayDist = 10.0f;

        RaycastHit2D hit = Physics2D.Raycast(rayStart, rayDir, rayDist, floorLayer); //1 << LayerMask.NameToLayer("Enemy"));
        if (!hit)
        {
            return _startingPoint;
        }
        return hit.point;
    }
}