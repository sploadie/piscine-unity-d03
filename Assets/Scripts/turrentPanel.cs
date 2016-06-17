using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class turrentPanel : MonoBehaviour {

	public towerScript tower;
	public RectTransform sprite;
	public Text energy;
	public Text range;
	public Text power;
	public Image flying;
	public Sprite not_flying;
	public Sprite canon_sprite;
	public Sprite rocket_sprite;
	public Sprite gatling_sprite;

	public Vector3 sprite_position { get; private set; }

	public bool can_buy { get; private set; }

	// Use this for initialization
	void Start () {
		can_buy = true;
		Debug.Log ("Size: " + GetComponent<RectTransform> ().rect.size);
		GetComponent<BoxCollider2D> ().size = GetComponent<RectTransform> ().rect.size;
		sprite_position = sprite.transform.position;
		energy.text = "" + tower.energy;
		range.text = "" + tower.range;
		power.text = "" + tower.damage;
		if (tower.type == towerScript.Type.canon) {
			sprite.GetComponent<Image> ().sprite = canon_sprite;
			flying.sprite = not_flying;
		} else if (tower.type == towerScript.Type.rocket) {
			sprite.GetComponent<Image> ().sprite = rocket_sprite;
		} else {
			sprite.GetComponent<Image> ().sprite = gatling_sprite;
		}
	}

	void Update () {
		if (gameManager.gm.playerEnergy < tower.energy) {
			can_buy = false;
			sprite.GetComponent<Image> ().color = Color.red;
		} else {
			can_buy = true;
			sprite.GetComponent<Image> ().color = Color.white;
		}
	}

	void OnDrawGizmos() {
		Gizmos.DrawIcon (transform.position, "death.png", true);
	}
}
