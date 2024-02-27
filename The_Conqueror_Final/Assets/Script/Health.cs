using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{


    [SerializeField] private int hitPoints = 5;
    [SerializeField] private int currencyWorth= 50;
    
    public void TakeDamage(int damage)
    {
        hitPoints -= damage;
        if(hitPoints <= 0)
        {

            LevelManager.instance.IncreaseIncome(currencyWorth);
            Destroy(gameObject);
        }
    }

}
