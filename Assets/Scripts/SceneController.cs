using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public Button yourButton;
    public float waitTime;

    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

        // stay cool
        if (SceneManager.GetActiveScene().name == "Briefing")
        {
            StartCoroutine(Wait());
        }
    }

    // Main menu to briefing
    void TaskOnClick()
    {
        SceneManager.LoadScene(sceneName: "Briefing");
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(sceneName: "Game");
    }
}
