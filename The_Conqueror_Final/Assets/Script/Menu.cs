using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI currencyUI;
    [SerializeField] TextMeshProUGUI HPUI;


    private void OnGUI()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if(currentScene.name == "Game")
        {
            currencyUI.text = LevelManager.instance.currency.ToString();
            HPUI.text = LevelManager.instance.levelHP.ToString();
        }
        else
        {
            currencyUI.text = "100";
            HPUI.text = "5";
        }
        
    }

    

}
