using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerHandler : MonoBehaviour {

	public static playerHandler instance { get; private set; }

	public Text  energy_display;
	public Text  hp_display;
	public Text  score_display;

	private turrentPanel turret;

	private bool pause = false;

	// Use this for initialization
	void Start () {
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		energy_display.text = "" + gameManager.gm.playerEnergy;
		hp_display.text = "" + gameManager.gm.playerHp;
		score_display.text = "" + gameManager.gm.score;
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (!pause) {
				pause = true;
				gameManager.gm.pause(true);
			} else {
				pause = false;
				gameManager.gm.pause(false);
			}
		}
		if (!pause) {
			if (Input.GetMouseButtonDown (0)) {
				RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);
				if (hit.collider != null) {
					Debug.Log ("Clicked on " + hit.collider.gameObject.tag);
					turrentPanel new_turret = hit.collider.gameObject.GetComponent<turrentPanel> ();
					if (turret == null && new_turret != null && new_turret.can_buy) {
						turret = new_turret;
					}
				}
			}
			if (!Input.GetMouseButton (0) && turret) {
				RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);
				if (hit.collider != null && hit.collider.gameObject.tag == "empty") {
					gameManager.gm.playerEnergy -= turret.tower.energy;
					GameObject.Instantiate (turret.tower, hit.collider.transform.position, hit.collider.transform.rotation);
				}
				turret.sprite.transform.position = turret.sprite_position;
				turret = null;
			}
			if (turret) {
				Vector3 mouse_position = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				mouse_position.z = turret.sprite_position.z;
				turret.sprite.transform.position = mouse_position;
			}
		} else if (turret) {
			turret.sprite.transform.position = turret.sprite_position;
			turret = null;
		}
	}
}
