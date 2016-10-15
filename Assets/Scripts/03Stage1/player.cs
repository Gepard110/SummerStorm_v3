using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class player : MonoBehaviour {
	public float lifepoint = 100;
	Slider hpslider;
	Slider btslider;
	public bool temperature = true;
	public bool canthrow = false;
	public bool slash = false;
	public int throwthing;
	public int slashthing;
	public GameObject[] throwthings = new GameObject[3];
	public GameObject[] slashthings = new GameObject[3];
	public GameObject instantiatePos;
	// Use this for initialization
	void Start () {
		hpslider = GameObject.Find ("Canvas").transform.FindChild("HPSlider").gameObject.GetComponent<Slider> ();
		btslider = GameObject.Find ("Canvas").transform.FindChild("BTSlider").gameObject.GetComponent<Slider> ();
	}

	// Update is called once per frame
	void Update () {
		hpslider.value = lifepoint;

	if (lifepoint > 100) {
			lifepoint = 100;
		}

	if (lifepoint <= 0) {
			Application.LoadLevel(0);
		}

	if (temperature == true) {
			btslider.value += 0.025f;
		} else {
			btslider.value -= 0.025f;
		}

	if (btslider.value >= 50 || btslider.value <= 30 ) {
			lifepoint -= 0.03f;
		}

	if (canthrow == true) {
			if(Input.GetKeyUp("space")){
				Instantiate(throwthings[throwthing],this.transform.position,instantiatePos.gameObject.transform.rotation);
			}
		}

	if (slash == true) {
			int count = 0;
			GameObject Slash;
			if (Input.GetKeyUp ("b")) {
				if(count == 0){
				Slash = Instantiate (slashthings [slashthing], this.transform.position + new Vector3(0,1,0), instantiatePos.gameObject.transform.rotation) as GameObject;
				}else{
					//Slash.transform.rotation 
				}
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		int damage = Random.Range (0, 5);
		if (other.gameObject.CompareTag ("Enemy")) {
			lifepoint -= damage;
		}

		if (other.gameObject.CompareTag ("ice")) {
			btslider.value -= 19;
		}

		if (other.gameObject.CompareTag ("heal")) {
			lifepoint += 20;
		}
	}

}
