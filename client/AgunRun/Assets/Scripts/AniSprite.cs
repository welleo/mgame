using UnityEngine;
using System.Collections;

public class AniSprite : MonoBehaviour {

	public static int DIR_LEFT = 0;
	public static int DIR_RIGHT = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PlayMotion(int frameCnt,int direction) {
		int index = (int)(Time.time * frameCnt);
		index = index % frameCnt;

		int dirVal = 1;
		if(direction == AniSprite.DIR_RIGHT) {
			dirVal = -1;
		}

		float scaleX = dirVal * 1.0f / frameCnt;
		Vector2 size = new Vector2(scaleX,1);
		Vector2 offset = new Vector2(dirVal * index*scaleX,0);
//		Debug.Log (scaleX);
		renderer.material.mainTextureScale = size;
		renderer.material.mainTextureOffset = offset;
	}
}
