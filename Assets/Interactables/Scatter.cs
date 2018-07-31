using UnityEngine;

public class Scatter : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float forceSize = 10f;
    public float stopTime = 1f;
    
	private void Start()
    {
		rb2d = GetComponent<Rigidbody2D>();

		Vector2 randDir = new Vector2(Random.Range(-1.5f, 1.5f), Random.Range(1, 1.5f));

        forceSize *= Random.Range(.75f, 1f);

        rb2d.AddForce(randDir * forceSize, ForceMode2D.Impulse);

        stopTime *= Random.Range(.5f, 1.5f);
        Invoke("StopMoving", stopTime);
    }

    private void StopMoving()
    {
		rb2d.velocity = rb2d.velocity / 3;
        //rb2d.isKinematic = true;
    }

    public void SetToActive()
    {
        this.gameObject.SetActive(true);
    }
}