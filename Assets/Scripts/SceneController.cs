using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // Start is called before the first frame update

    public Button restartButton;

    public Button exitButton;

    void Start()
    {
        restartButton.onClick.AddListener(RestartScene);

        exitButton.onClick.AddListener(ExitScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RestartScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    void ExitScene()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
