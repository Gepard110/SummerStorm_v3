using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class joystickdirection : MonoBehaviour {
	[SerializeField] float direction;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float angle = Mathf.Atan2(CrossPlatformInputManager.GetAxis("V"),CrossPlatformInputManager.GetAxis("H"));
		direction = Mathf.RoundToInt (angle / Mathf.PI*180);
		this.gameObject.transform.eulerAngles = new Vector3(0,0,direction - 90);
	}
}
