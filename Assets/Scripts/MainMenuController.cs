using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // Start is called before the first frame update

    public Button play;

    public Button exit;

    void Start()
    {
        play.onClick.AddListener(PlayGame);

        exit.onClick.AddListener(ExitGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ExitGame()
    {

    }

    void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
