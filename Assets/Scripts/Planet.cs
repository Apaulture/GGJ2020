using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
	const int NUM_SLICES = 8;

	void Start () {
		for (int i = 0; i < NUM_SLICES; ++i) {
			int broken = Random.Range(0, 3);
			if (broken < 2) {
				Transform layer = gameObject.transform.Find("Layer3");
				Transform block = layer.GetChild(i);
				block.gameObject.SetActive(false);
			}
			if (broken < 1) {
				Transform layer = gameObject.transform.Find("Layer2");
				Transform block = layer.GetChild(i);
				block.gameObject.SetActive(false);
			}
		}
	}

	void Update() {
	}
}
