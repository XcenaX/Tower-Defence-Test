using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    
public static int Lives;
[SerializeField]
private int MaxLives;
public static int Money;
public static int CurrentWave;
[SerializeField]
private int startMoney;

    void Start()
    {
     Money = startMoney;   
     Lives = MaxLives;
     CurrentWave = 1;
    }

    
    void Update()
    {
        
    }
}
