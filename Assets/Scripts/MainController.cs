using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainController : MonoBehaviour
{
    public MainController Instance;
    public int currentGold;    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            Instance.currentGold = 100;            
            DontDestroyOnLoad(Instance);
        }
        else
        {
            Destroy(gameObject);
        }
    } 
    public void ChangeGold(int gold)
    {
        currentGold += gold;
        Debug.Log(currentGold);
    }
}
