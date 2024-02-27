using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public Transform[] path;
    public Transform startPoint;
    public Transform EndPoint;


    public int levelHP;
    public int currency;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        currency = 100;
        levelHP = 5;

    }
    

    public void IncreaseIncome(int amount)
    {
        currency += amount;
    }

    public bool SpendIncome(int amount)
    {
        if(amount<= currency)
        {
            currency -= amount;
            return true;
        }
        else
        {
            return false;
        }
    }



}
