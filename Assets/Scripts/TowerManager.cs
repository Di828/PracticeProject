using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TowerManager : MonoBehaviour
{
    bool towerCreating = false;    
    [SerializeField] List<Tower> towersToBuild = new List<Tower>();
    private MainController mainController;
    [SerializeField] private TextMeshProUGUI currentGoldText;
    [SerializeField] private TextMeshProUGUI notEnoughGoldText;
    [SerializeField] private TextMeshProUGUI towerCostText;
    [SerializeField] private TextMeshProUGUI gameOverText;
    int towerIndex;
    RaycastHit hit;
    Ray ray;
    private void Awake()
    {        
        mainController = GameObject.Find("MainController").GetComponent<MainController>();
        currentGoldText.text = "Current gold : " + mainController.Instance.currentGold + " Lives : " + mainController.Instance.lives;
    }

    private void Update()
    {
        if (mainController.Instance.gameover)
        {
            gameOverText.enabled = true;
            return;
        }
        if (towerCreating)
        {
            if (Input.GetMouseButtonDown(0))
                CreateTower();
        }
        currentGoldText.text = "Current gold : " + mainController.Instance.currentGold + " Lives : " + mainController.Instance.lives;
    }
    public void FrostTowerCreating()
    {
        towerIndex = 1;
        towersToBuild[towerIndex].cost = 60;
        TowerCreating();
    }
    public void FireTowerCreating()
    {
        towerIndex = 0;
        towersToBuild[towerIndex].cost = 80;
        TowerCreating();
    }
    void TowerCreating()
    {
        if (mainController.Instance.currentGold >= towersToBuild[towerIndex].cost)
            towerCreating = true;
        else
            StartCoroutine(NotEnoughGoldCoroutine());
    }
    IEnumerator NotEnoughGoldCoroutine()
    {
        notEnoughGoldText.enabled = true;
        yield return new WaitForSeconds(3);
        notEnoughGoldText.enabled = false;
    }
    void CreateTower()
    {
        if (IsItPlaceForTower())
        {
            Instantiate(towersToBuild[towerIndex], hit.point, Quaternion.identity);
            towerCreating = false;
            mainController.Instance.currentGold -= towersToBuild[towerIndex].cost;
            Debug.Log(towersToBuild[towerIndex].cost);
            currentGoldText.text = "Current gold : " + mainController.Instance.currentGold + " Lives : " + mainController.Instance.lives;
        }
    }
    bool IsItPlaceForTower()
    {        
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);           
        if (Physics.Raycast(ray, out hit, 1000))       
        {                        
            if (hit.collider.gameObject.CompareTag("Wall"))
                return true;            
        }
        return false;

    }
}
