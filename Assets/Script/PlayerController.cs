using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public float speed;
	public bool touchGround = false;


	private Rigidbody2D rb;
	private Animator anim;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		Mouvement ();
		anim.SetFloat ("speed", Mathf.Abs (Input.GetAxis ("Horizontal")));
	}
	
	void Mouvement(){
		Vector2 g = new Vector2 (transform.position.x, transform.position.y - 0.75f);
		Debug.DrawLine (transform.position, g, Color.red);
		touchGround = Physics2D.Linecast(transform.position, g, 1<< LayerMask.NameToLayer("Floor"));

		anim.SetBool ("touchFloor", touchGround);

		if (Input.GetAxisRaw("Horizontal") > 0) {
			transform.Translate(Vector2.right * speed * Time.deltaTime);
			transform.eulerAngles = new Vector2(0,0);
		}
		if (Input.GetAxisRaw("Horizontal") < 0) {
			transform.Translate(Vector2.right * speed * Time.deltaTime);
			transform.eulerAngles = new Vector2(0,180);
		}
		if (Input.GetKey (KeyCode.Space) && touchGround) {
			rb.AddForce(Vector2.up * 100f);
		}
	}
}
