using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AspectRatio : MonoBehaviour
{
	void Start() {
		var camera = GetComponent<Camera>();
		var rect = camera.pixelRect;
		var letterboxWidth = (rect.width - rect.height)/2;
		if (rect.width < rect.height) {
			letterboxWidth = -letterboxWidth;
			rect.y = letterboxWidth;
			rect.height = rect.width;
		} else {
			rect.x = letterboxWidth;
			rect.width = rect.height;
		}
		camera.pixelRect = rect;
	}
}
