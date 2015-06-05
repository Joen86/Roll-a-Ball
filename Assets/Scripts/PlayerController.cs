using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public float speed;
	public GUIText countText;
	public GUIText winText;
	public GUIText loseText;

	private Rigidbody rb;
	private int count;
	
	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
		count = 0;
		SetCountText ();
		winText.text = "";
		loseText.text = "";
	
	}
	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);

		if (count >= 10) 
		{
			speed = 30;
		}
		if (count >= 12)
		{
			speed = 2;
		}

	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Pick Up")) 
		{
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText ();
		}
	}
	 
	void SetCountText ()
	{
	
		countText.text = "Count: " + count.ToString ();
		if (count >= 16) 
		{
			winText.text = "You Win!";
		}

	}
	void Update ()
	{
				float position = transform.position.y;
	
				if (position <= 0) {
						loseText.text = "YOU LOSE...hahahahahahahahahaha!";
				}
		}

}
