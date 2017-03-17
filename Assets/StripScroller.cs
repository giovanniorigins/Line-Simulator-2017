using UnityEngine;
using System.Collections;

public class StripScroller : MonoBehaviour
{
	public float speed = 0f;
	public static StripScroller current;

	float pos = 0;

	void Start ()
	{
		current = this;
	}

	public void Go ()
	{
		pos -= speed;
		if (pos < -1.0f)
			pos += 1.0f;

		gameObject.GetComponent<Renderer> ().material.mainTextureOffset = new Vector2 (pos, 0);
	}
} 