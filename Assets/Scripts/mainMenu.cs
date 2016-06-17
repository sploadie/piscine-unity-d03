using UnityEngine;
using System.Collections;

public class mainMenu : MonoBehaviour {

	// Use this for initialization
	public void Play () {
		Application.LoadLevel (1);
	}
	
	// Update is called once per frame
	public void Quit () {
		Application.Quit ();
	}
}
