using UnityEngine;
using System.Collections;

public class branch : MonoBehaviour {
	public player _player;
	// Use this for initialization
	void Start () {
		_player = GameObject.Find("player").gameObject.GetComponent<player>();
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			if(_player.slash == false){
				_player.slash = true;
				_player.slashthing = 0;
				Destroy(this.gameObject);
			}
		}
	}
}