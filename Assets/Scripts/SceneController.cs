using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // Start is called before the first frame update

    public Button restartButton;

    void Start()
    {
        restartButton.onClick.AddListener(RestartScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RestartScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
