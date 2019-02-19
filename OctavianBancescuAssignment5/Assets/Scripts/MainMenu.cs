using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button StartGame;
    // Start is called before the first frame update
    void Start()
    {
        StartGame.onClick.AddListener(StartGameClick);
    }

    void StartGameClick()
    {
        Debug.Log("Hope this works");
        Application.LoadLevel(1);
    }
}
