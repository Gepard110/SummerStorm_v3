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
	public GameObject instantiatePos2;
	public GameObject Slash;
	public bool TimeManage = false;
	public float time;
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

	if (TimeManage == true) {
			if (time <= 1) {
				time += Time.deltaTime;
				instantiatePos2.gameObject.transform.rotation = Quaternion.Slerp (Quaternion.Euler (new Vector3 (0, 0, 90)), Quaternion.Euler (new Vector3 (0, 0, 0)), time * 2f);
			}
		}

		if(time * 2  > 1){
			TimeManage = false;
			Destroy(Slash);
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

	public void throwButton(){
		if (canthrow == true) {
			Instantiate (throwthings [throwthing], this.transform.position, instantiatePos.gameObject.transform.rotation);
		}
	}
	public void slashButton(){
		if (slash == true) {
				Slash = Instantiate (slashthings [slashthing], this.transform.position + new Vector3(0,1,0), Quaternion.Euler(new Vector3(0,0,0))) as GameObject;
				Slash.transform.SetParent(instantiatePos2.gameObject.transform);
				time = 0;
				TimeManage = true;
			}
	}
}
