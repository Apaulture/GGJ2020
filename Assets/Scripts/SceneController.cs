using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public Button playButton;
    public Button howToButton;
    public Button creditsButton;

    public float logoMenuWait;
    public float briefingGameWait;

    void Start()
    {
        Button pButton = playButton.GetComponent<Button>();
        Button hwButton = howToButton.GetComponent<Button>();
        Button cButton = creditsButton.GetComponent<Button>();

        pButton.onClick.AddListener(Play);
        hwButton.onClick.AddListener(HowToPlay);
        cButton.onClick.AddListener(Credits);

        StartCoroutine(Wait());
    }

    // Main menu to briefing
    void Play()
    {
        SceneManager.LoadScene(sceneName: "Briefing");
    }

    void HowToPlay()
    {
        SceneManager.LoadScene(sceneName: "Howtoplay");
    }

    void Credits()
    {
        SceneManager.LoadScene(sceneName: "Credits");
    }

    IEnumerator Wait()
    {
        if (SceneManager.GetActiveScene().name == "Briefing")
        {
            yield return new WaitForSeconds(briefingGameWait);
            SceneManager.LoadScene(sceneName: "Game");
        }
        // Logo to main menu scene transition
        else if (SceneManager.GetActiveScene().name == "Logo")
        {
            yield return new WaitForSeconds(logoMenuWait);
            SceneManager.LoadScene(sceneName: "Main Menu");
        }
    }
}
