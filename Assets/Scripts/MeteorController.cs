using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeteorController : MonoBehaviour
{
	public GameObject meteor;
	public int meteorNum;
	public int velocityMultiplier;
	public float waitTime;

	GameObject spawnedMeteor;
	public bool started = false;

	public void StartMeteors()
	{
		if (!started) {
			started = true;
			StartCoroutine(TimeBetweenMeteors());
			var tutorialText = GameObject.FindObjectOfType<TutorialText>();
			if (tutorialText) {
				tutorialText.SetText("");
			}
		}
	}

	IEnumerator TimeBetweenMeteors()
	{
		while (transform.childCount < meteorNum)
		{
			float randomTheta = Random.value * Mathf.PI * 2;
			float randomX = Mathf.Cos(randomTheta) * 15;
			float randomZ = Mathf.Sin(randomTheta) * 15;

			Vector3 randomPosition = new Vector3(randomX, 0, randomZ);
			spawnedMeteor = Instantiate(meteor, randomPosition, Quaternion.identity, transform);

			Vector3 velocity = (-randomPosition).normalized;
			spawnedMeteor.GetComponent<Rigidbody>().velocity = velocity * velocityMultiplier;

			waitTime -= .015f;

			yield return new WaitForSeconds(waitTime);
		}
	}
}
