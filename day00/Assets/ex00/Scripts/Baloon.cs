using UnityEngine;
using System.Collections;

public class Baloon : MonoBehaviour {

	public Vector3 startSize = new Vector3(3, 3, 3);
	public Vector3 maxSize = new Vector3(8, 8, 8);
	public Vector3 minSize = new Vector3(1, 1, 1);
	public Vector3 inflateOnInput = new Vector3(0.5f, 0.5f, 0.5f);
	public Vector3 deflateOnXTime = new Vector3(1.0f, 1.0f, 1.0f);

	public float timeBeforeDeflate = 0.5f;
	public int maxBreathPerSec = 3;
	
	
	private float time;
	private float tmpTime;
	private int Breath;
	private int frame;

	void Start () {

		time = Time.time;
		tmpTime = 0;
		Breath = 0;
		transform.localScale = startSize;
	}
	
	
	void Update () {
	
		time += Time.deltaTime;
		tmpTime += Time.deltaTime;
		if (tmpTime > timeBeforeDeflate) 
		{
			tmpTime = 0;
			transform.localScale -= deflateOnXTime;
			Breath = 0;
		}

		if (transform.localScale.x >= maxSize.x && transform.localScale.y >= maxSize.y && transform.localScale.z >= maxSize.z) {
			Debug.Log("Baloon has exploded, it's over");
			Debug.Log("Balloon life time: " + Mathf.RoundToInt(time));
			GameObject.Destroy(gameObject);
		}
		else if (transform.localScale.x <= minSize.x && transform.localScale.y <= minSize.y && transform.localScale.z <= minSize.z) {
			Debug.Log ("Baloon is too small, it's over");
			Debug.Log("Balloon life time: " + Mathf.RoundToInt(time));
			GameObject.Destroy(gameObject);
		}

		else if (Input.GetKeyDown("space"))
		{
			if (Breath < maxBreathPerSec)
			{
				transform.localScale += inflateOnInput;
				Breath++;
			}
		}

	}
}
