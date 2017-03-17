using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeDead : MonoBehaviour
{
	public int fadeSpeed = 3;
	private bool isDone = false;
	private Color matCol;
	private Color newColor;
	private float alfa = 0;

	// Use this for initialization
	void Start ()
	{
		Renderer renderer = gameObject.GetComponent<Renderer> ();
		matCol = renderer.material.color;
	}

	// Update is called once per frame
	void Update ()
	{
		Renderer renderer = gameObject.GetComponent<Renderer> ();		
		if (!isDone) {
			alfa = renderer.material.color.a - Time.deltaTime / (fadeSpeed == 0 ? 1 : fadeSpeed);

			if (gameObject.GetComponent<Rigidbody2D>() && alfa < 0.7) {
				gameObject.GetComponent<Collider2D>().enabled = false;
				Destroy(gameObject.GetComponent<Rigidbody2D>());
			}

			newColor = new Color (matCol.r, matCol.g, matCol.b, alfa);
			renderer.material.SetColor ("_Color", newColor);
			isDone = alfa <= 0 ? true : false;
		} else {
			gameObject.SetActive (false);
		}
	}
}
