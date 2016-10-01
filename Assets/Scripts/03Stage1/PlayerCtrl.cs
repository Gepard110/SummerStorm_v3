using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
public class PlayerCtrl : MonoBehaviour {
	int JoystickMoveRange = 50;
	public int speed;
	Animator anim;
	// Use this for initialization
	void Awake () {
		anim = this.gameObject.GetComponent<Animator> ();
	}
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (CrossPlatformInputManager.GetAxis ("H") == 0f && CrossPlatformInputManager.GetAxis ("V") == 0f) {
			anim.SetBool("moving",false);
		} else {
			CalAngle();
			anim.SetBool("moving",true);
			transform.position += new Vector3(CrossPlatformInputManager.GetAxis("H") * speed / JoystickMoveRange, CrossPlatformInputManager.GetAxis("V") * speed/ JoystickMoveRange, 0);
		}
	}
	void CalAngle(){
		float angle = 0;
		angle = Mathf.Atan2(CrossPlatformInputManager.GetAxis("V"),CrossPlatformInputManager.GetAxis("H"));
		int t = Mathf.RoundToInt (angle * 2 / Mathf.PI);
		if (t == -2) {
			t = t + 4;
		}
		anim.SetInteger ("angle", t);
	}
}