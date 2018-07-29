using UnityEngine;

public class MovePlayer : MonoBehaviour
{
	public float moveSpeed = 5;

	public int currentFloorNumber = 0;
	public float currentFloorY = 0;
	public LayerMask floorLayer;
    
	[SerializeField] private Transform[] floorWaypoints;
	private Transform[] floorWaypointsPath;
	private int currentWaypoint;

	private int destinationFloor;
	private float newfloorX;
	private bool changingFloors;

	private Rigidbody2D rb2d;
	private Vector2 newPosition;
	private bool clickable = true;

	public float moveDir;

	private void Awake()
	{
		rb2d = GetComponent<Rigidbody2D>();
		newPosition = transform.position;
	}

	private void Update()
	{
		if (Input.GetMouseButtonUp(0) && clickable)
		{
			Vector3 clickPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			newPosition = clickPoint;
			newPosition.y = currentFloorY;

			GetFloorPoint();
			newfloorX = clickPoint.x;
		}

		if (changingFloors)
		{
			ChangingFloors();
		}

		Moving();
	}

	private void LateUpdate()
	{
		FloorChecking();

		if (Input.GetMouseButtonUp(1))
		{
			DropStuff();
        }
	}

    private void DropStuff()
	{
		Resource[] A = FindObjectsOfType<Resource>();
        foreach (var a in A)
        {
            a.canUse = false;
            if (a.inUse == true)
                a.DropResource();
        }
	}


	private void ChangingFloorsPlan()
	{
		Transform[] path;

		if (destinationFloor > currentFloorNumber)
		{
			int pointStart = (currentFloorNumber * 2) - 1;
			int pointsNeeded = (destinationFloor - currentFloorNumber) * 2;
			path = new Transform[pointsNeeded];

			for (int i = 0; i < path.Length; i++) // array build
			{
				path.SetValue(floorWaypoints[pointStart], i); //
				pointStart++;
			}
		}
		else
		{
			int pointStart = (currentFloorNumber * 2) - 2;
			int pointsNeeded = (currentFloorNumber - destinationFloor) * 2;
			path = new Transform[pointsNeeded];

			for (int i = 0; i < path.Length; i++) // array build
			{
				path.SetValue(floorWaypoints[pointStart], i); //
				pointStart--;
			}
		}

		floorWaypointsPath = path;
	}

	private void ChangingFloors()
	{
		if (currentWaypoint < floorWaypointsPath.Length)
		{
			if (transform.position != floorWaypointsPath[currentWaypoint].position)
			{
				newPosition = floorWaypointsPath[currentWaypoint].position;
			}
			else
			{
				clickable = false;
				currentWaypoint++;
			}
		}
		else
		{
			clickable = true;
			newPosition = new Vector2(newfloorX, currentFloorY);

			if (transform.position.x == newPosition.x)
			{
				changingFloors = false;
				currentWaypoint = 0;
			}
		}
	}

	private void Moving()
	{
		rb2d.MovePosition(Vector3.MoveTowards(transform.position, newPosition, moveSpeed * Time.deltaTime));

		moveDir = (transform.position.x - newPosition.x);
	}

	private void FloorChecking()
	{
		Collider2D hit = Physics2D.OverlapCircle(transform.position - (Vector3.up * 0.5f), 0.25f, floorLayer);

		if (hit)
		{
			currentFloorNumber = hit.GetComponent<FloorInfo>().floorNumber;
			currentFloorY = hit.GetComponent<FloorInfo>().floorY;
		}
	}

	private void GetFloorPoint()
	{
		var rayStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		var rayDir = Vector2.down;
		float rayDist = 10.0f;

		RaycastHit2D hit = Physics2D.Raycast(rayStart, rayDir, rayDist, floorLayer); //1 << LayerMask.NameToLayer("Enemy"));

		if (hit)
		{
			destinationFloor = hit.collider.GetComponent<FloorInfo>().floorNumber;
			if (currentFloorNumber != destinationFloor)
			{
				changingFloors = true;
				ChangingFloorsPlan();
			}
			else
			{
				changingFloors = false;
			}
		}
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position - (Vector3.up * 0.5f), 0.25f);

		Gizmos.color = Color.white;
		var rayStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Gizmos.DrawRay(rayStart, Vector2.down * 10);
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Obstacle")
		{
			newPosition = transform.position;
			GetComponent<Rigidbody2D>().isKinematic = false;
		}
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Obstacle")
		{
			GetComponent<Rigidbody2D>().isKinematic = true;
		}
	}
}