using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefendZone : MonoBehaviour
{
    MainController mainController;
    private void Awake()
    {
        mainController = GameObject.Find("MainController").GetComponent<MainController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Enemy>() != null)
        {
            mainController.Instance.LoseLive();
            Destroy(other.gameObject);
        }
    }
}
