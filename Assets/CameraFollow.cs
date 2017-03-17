using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public GameObject cameraTarget;
	public GameObject player;

	public float smoothTime = 0.1f;
	public bool cameraFollowX = true;
	public bool cameraFollowY = true;
	public bool cameraFollowHeight = false;
	public float cameraHeight = 2.5f;
	public float xOffset = 1f;
	public Vector2 velocity;
	private Transform thisTransform;

	// Use this for initialization
	void Start () {
		thisTransform = transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (cameraFollowX) {
			float newPosition = Mathf.SmoothDamp (thisTransform.position.x, cameraTarget.transform.position.x, ref velocity.x, smoothTime);
			
			thisTransform.position = new Vector3(newPosition, thisTransform.position.y, thisTransform.position.z);
		}

		if (cameraFollowY) {

		}

		if (!cameraFollowY && cameraFollowHeight) {

		}
	}
}
