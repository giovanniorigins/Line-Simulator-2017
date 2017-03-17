using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateNPCs : MonoBehaviour {
	
	public int maxLineCharacters = 20;

	//Array of objects to spawn from
	public GameObject[] lineCharacters;
	// array of objects to spawn to
	public LinkedList<GameObject> line = new LinkedList<GameObject> ();

	//Time it takes to spawn lineCharacters
	[Space(3)]

	// the range of X
	[Header ("X Spawn")]
	public float xPos = 0;
	public float xSpacing = 1;

	// the range of y
	[Header ("Y Spawn Range")]
	public float y = 0;

	// Use this for initialization
	void Start () {
		// Initialize size of array
		lineCharacters = new GameObject[maxLineCharacters];

		// Find all line NPCs with 'Respawn' tag and add the to array
		lineCharacters = GameObject.FindGameObjectsWithTag ("Respawn");
		for (int i = 0; i <= maxLineCharacters; i++) {
			// Generate character and keep track of their position in line.
			line.AddLast (SpawnLineCharacter ());
		}
	
	}
	
	// Update is called once per frame
	public void Update () {
		//Debug.Log (line.First.Value.gameObject.name);
		//Debug.Log (line.First.Value.gameObject.activeSelf);
		//Debug.Log(line.Count + " <-> " + maxLineCharacters);
		// if the line has shortened since last update, add another NPC
		if (!line.First.Value.gameObject.activeSelf) {
			line.RemoveFirst ();
			line.AddLast (SpawnLineCharacter ());
		}

		if (line.Count < maxLineCharacters) {
			// To keep track of the characters as they are removed, we need to shift the array left

			line.RemoveFirst();
			line.AddLast (SpawnLineCharacter ());
		}
	}

	GameObject SpawnLineCharacter()
	{
		// Defines the next x and y positions
		xPos += xSpacing;
		Vector2 pos = new Vector2 (xPos, y);

		// Choose a new goods to spawn from the array (note I specifically call it a 'prefab' to avoid confusing myself!)
		GameObject lineCharacter = SelectLineCharacter();

		// Creates the random object at the next 2D position.
		GameObject newCharacter = Instantiate (lineCharacter, pos, transform.rotation);

		// Randomize initial animation starting point
		Animator anim = newCharacter.GetComponent<Animator>();
		anim.Play ("Idle", -1, Random.Range (0.0f, 3.5f));
		//Debug.Log(anim.GetTime());

		// If I wanted to get the result of instantiate and fiddle with it, I might do this instead:
		//GameObject newGoods = (GameObject)Instantiate(goodsPrefab, pos)
		//newgoods.something = somethingelse;

		return newCharacter;
	}

	GameObject SelectLineCharacter()
	{
		GameObject newLineCharacter = lineCharacters[Random.Range (0, lineCharacters.Length)];
		return line.Count > 0 && line.Last.Value.name == newLineCharacter.name ? SelectLineCharacter() : newLineCharacter;
	}

	void OnMouseDown() {
		Debug.Log ("mouse clicked");
	}
}
