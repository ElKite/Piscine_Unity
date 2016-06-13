using UnityEngine;
using System.Collections;

public class Cube : MonoBehaviour {

	float speed;
	float positionInitiale;
	string type;

	// Use this for initialization
	void Start () {
		speed = 1;
		positionInitiale = 0;

		type = "A";
		transform.position = new Vector3 (positionInitiale, 5, 0);
	}
	
	// Update is called once per frame
	void Update () {

		transform.Translate(new Vector3 (0, -0.1f * speed, 0));

		if (transform.localScale.y < -2.0f)
			destroy ();
		if (Input.GetKeyDown (KeyCode.A)) {
			if (type == "A")
				Debug.Log("precision: " + (transform.localPosition.y - (-2)));
		}
	}

	void destroy() {
		GameObject.Destroy(gameObject);
		Debug.Log (transform.localPosition);
	}

	public void setSpeed(float mySpeed)
	{
		 speed = mySpeed;
	}

	public void setPositionInitiale(float position)
	{
		positionInitiale = position;
	}

}
