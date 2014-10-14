using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float walkSpeed;
	public float gravity;
	public float groundY;
	public float walkJump;

	public Material runMaterial;
	public Material jumpMaterial;

	private AniSprite aniSprite;
	private CharacterController controller;

	private Vector3 vec = Vector3.zero;
	private bool jumpEnable = false;
	private int dir;

	// Use this for initialization
	void Start () {	
		aniSprite = GetComponent ("AniSprite") as AniSprite;
		controller = GetComponent ("CharacterController") as CharacterController;
	}
	
	// Update is called once per frame
	void Update () {
		float horiVal = Input.GetAxis ("Horizontal");
		if(horiVal != 0){
			dir = horiVal > 0 ? AniSprite.DIR_RIGHT : AniSprite.DIR_LEFT;
		}
		//		Debug.Log (transform.position.y);
		if(transform.position.y > groundY) {
			vec.x = horiVal;
			if(jumpEnable) {
				vec.x *= walkSpeed;
				transform.renderer.material = jumpMaterial;
				aniSprite.PlayMotion(11,dir);
			}
		}else {
			Vector3 pos = transform.position;
			transform.position = new Vector3(pos.x,groundY,pos.z);
			vec = new Vector3(horiVal,0,0);
			jumpEnable = false;
			transform.renderer.material = runMaterial;
			aniSprite.PlayMotion (10, dir);
			vec *= walkSpeed;
			
			if(Input.GetButtonDown("Jump")) {
				jumpEnable = true;
				vec.y = walkJump;
			}
		}

		vec.y -= gravity * Time.deltaTime;
		controller.Move (vec* Time.deltaTime);
	}
}
