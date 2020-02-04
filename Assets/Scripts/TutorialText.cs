using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialText : MonoBehaviour
{
	public void SetText(string text) {
		GetComponent<Text>().text = text;
	}
}
