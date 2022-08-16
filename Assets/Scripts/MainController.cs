using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainController : MonoBehaviour
{
    public MainController Instance;
    public int currentGold;
    public int lives = 10;
    public bool gameover = false;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            Instance.currentGold = 100;
            Instance.lives = lives;
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
    }
    public void LoseLive()
    {
        lives--;
        if (lives == 0)
            gameover = true;
    }
}
