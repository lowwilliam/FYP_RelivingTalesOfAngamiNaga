using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task_UI_Empty : MonoBehaviour
{
    public GameObject taskPanel;
    private DialogueManager dialoguePanel;
    private Inventory_UI inventoryPanel;
    public bool taskUIActive = false;
    private Quite_UI quitePanel;

    void Start()
    {
        taskPanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            UnityEngine.Debug.Log("Input.GetKeyDown(KeyCode.T)");
            ToggleTask();
        }
    }

    public void ToggleTask()
    {
        if (!taskPanel.activeSelf && ToggleTaskCheck())
        {
            taskUIActive = true;
            taskPanel.SetActive(true);
            //Setup();
        }
        else
        {
            // UnityEngine.Debug.Log("taskUIActive false");
            taskUIActive = false;
            taskPanel.SetActive(false);
        }
    }

    public bool ToggleTaskCheck()
    {
        dialoguePanel = GameObject.FindObjectOfType<DialogueManager>();
        inventoryPanel = GameObject.FindObjectOfType<Inventory_UI>();
        quitePanel = GameObject.FindObjectOfType<Quite_UI>();
        if (!dialoguePanel.dialogueUIActive && !inventoryPanel.inventoryUIActive && !quitePanel.quiteUIActive)
        {
            return true;
        }
        else
            return false;
    }

    // Update is called once per frame
    void Setup() { }
}
