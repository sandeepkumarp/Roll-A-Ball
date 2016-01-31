using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	public Text countText;
	public Text winText;
	private Rigidbody rb;
	public float speed = 10;
	private int count = 0;

	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
		SetCountText ();
		winText.text = " ";
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.CompareTag ("Pick Up")) {
			count++;
			SetCountText ();
			other.gameObject.SetActive (false);
		}
	}

	void SetCountText ()
	{
		countText.text = "Count: = " + count.ToString ();
		if (count >= 12) {
			winText.text = "You Win";
		}
	}

}
