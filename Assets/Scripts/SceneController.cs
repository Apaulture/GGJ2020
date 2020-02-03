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
    public Button logoButton;
    public Button gameButton;

    public float logoMenuWait;
    public float briefingGameWait;

    void Start()
    {
        Button pButton = playButton.GetComponent<Button>();
        Button hwButton = howToButton.GetComponent<Button>();
        Button cButton = creditsButton.GetComponent<Button>();
        Button lButton = logoButton.GetComponent<Button>();
        Button gButton = gameButton.GetComponent<Button>();

        pButton.onClick.AddListener(Play);
        hwButton.onClick.AddListener(HowToPlay);
        cButton.onClick.AddListener(Credits);
        lButton.onClick.AddListener(Logo);
        gButton.onClick.AddListener(Game);

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

    void Logo()
    {
        SceneManager.LoadScene(sceneName: "Main Menu");
    }

    void Game()
    {
        SceneManager.LoadScene(sceneName: "Game");
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
