using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endLevel : MonoBehaviour
{
    private GameObject endLevelUI;
    private void Start()
    {
        endLevelUI = GameObject.FindGameObjectWithTag("EndLevelUI");
        endLevelUI.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        endLevelUI.SetActive(true);
        GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<lookAround>().enabled=false;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
    }
}
