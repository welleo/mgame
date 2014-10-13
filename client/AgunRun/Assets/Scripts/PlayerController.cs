using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 10;

	public Material runMaterial;
	public Material jumpMaterial;

	private AniSprite aniSprite;
	private CharacterController controller;

	private Vector3 vec;

	// Use this for initialization
	void Start () {	
		aniSprite = GetComponent ("AniSprite") as AniSprite;
		controller = GetComponent ("CharacterController") as CharacterController;
	}
	
	// Update is called once per frame
	void Update () {
		vec = new Vector3(Input.GetAxis("Horizontal"),0,0);
		transform.renderer.material = runMaterial;
		int dir = Input.GetAxis ("Horizontal") < 0 ? AniSprite.DIR_LEFT : AniSprite.DIR_RIGHT;
		aniSprite.PlayMotion (10, dir);
		vec *= speed;
		controller.Move (vec* Time.deltaTime);
	}
}
