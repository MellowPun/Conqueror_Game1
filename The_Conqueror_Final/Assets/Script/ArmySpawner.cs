using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using Unity.VisualScripting;
using JetBrains.Annotations;

public class ArmySpawner : MonoBehaviour
{
    [SerializeField] private Army[] armyPrefabs;

    public void SetSelectedArmy(int _selectedArmy)
    {
        if(LevelManager.instance.currency >= armyPrefabs[_selectedArmy].Cost)
        {
            Instantiate(armyPrefabs[_selectedArmy].Prefab, LevelManager.instance.startPoint.position, Quaternion.identity);
            LevelManager.instance.SpendIncome(armyPrefabs[_selectedArmy].Cost);


        }
        


    }
    

}
