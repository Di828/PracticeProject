using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TowerManager : MonoBehaviour
{
    bool fireTowerCreating = false;
    [SerializeField] List<Tower> towersToBuild = new List<Tower>();
    private MainController mainController;
    [SerializeField] private TextMeshProUGUI currentGoldText;
    [SerializeField] private TextMeshProUGUI notEnoughGoldText;
    [SerializeField] private TextMeshProUGUI towerCostText;
    int towerIndex = 0;
    RaycastHit hit;
    Ray ray;
    private void Awake()
    {        
        mainController = GameObject.Find("MainController").GetComponent<MainController>();
        currentGoldText.text = "Current gold : " + mainController.Instance.currentGold;
    }

    private void Update()
    {
        if (fireTowerCreating)
        {
            if (Input.GetMouseButtonDown(0))
                CreateTower();
        }
        currentGoldText.text = "Current gold : " + mainController.Instance.currentGold;
    }
    public void FireTowerCreating()
    {
        towerIndex = 0;
        if (mainController.Instance.currentGold >= towersToBuild[towerIndex].Cost)
            fireTowerCreating = true;   
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
            fireTowerCreating = false;
            mainController.Instance.currentGold -= towersToBuild[towerIndex].Cost;
            Debug.Log(towersToBuild[towerIndex].Cost);
            currentGoldText.text = "Current gold : " + mainController.Instance.currentGold;
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
