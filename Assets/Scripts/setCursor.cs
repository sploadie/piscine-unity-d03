using UnityEngine;
using System.Collections;

public class setCursor : MonoBehaviour {

	public Texture2D cursorTexture;

	// Use this for initialization
	void Start () {
		Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
	}
}
