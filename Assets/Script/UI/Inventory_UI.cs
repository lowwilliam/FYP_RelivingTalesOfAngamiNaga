using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inventory_UI : MonoBehaviour
{
    public GameObject inventoryPanel;
    public Player player;
    public List<Slot_UI> slots = new List<Slot_UI>();

    public bool inventoryUIActive = false;

    private DialogueManager dialoguePanel;
    private Task_UI_Empty taskPanel;
    private Task_UI taskPanel2;
    private Task_UI_Collection_Question taskPanel3;
    private Question_UI questionPanel;
    private Quite_UI quitePanel;

    void Start()
    {
        inventoryPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            ToggleInventory();
        }
    }

    public void ToggleInventory()
    {
        // dialoguePanel = GameObject.FindObjectOfType<DialogueManager>();
        if (!inventoryPanel.activeSelf && ToggleInventoryCheck())
        {
            inventoryPanel.SetActive(true);
            inventoryUIActive = true;
            Setup();
        }
        else
        {
            inventoryUIActive = false;
            inventoryPanel.SetActive(false);
        }
    }

    public bool ToggleInventoryCheck()
    {
        dialoguePanel = GameObject.FindObjectOfType<DialogueManager>();
        quitePanel = GameObject.FindObjectOfType<Quite_UI>();
        bool taskUIStatus;
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            taskPanel2 = GameObject.FindObjectOfType<Task_UI>();
            taskUIStatus = taskPanel2.taskUIActive;
        }
        else if (
            SceneManager.GetActiveScene().buildIndex == 4
            || SceneManager.GetActiveScene().buildIndex == 5
            || SceneManager.GetActiveScene().buildIndex == 6
        )
        {
            taskPanel3 = GameObject.FindObjectOfType<Task_UI_Collection_Question>();
            taskUIStatus = taskPanel3.taskUIActive;
        }
        else
        {
            taskPanel = GameObject.FindObjectOfType<Task_UI_Empty>();
            taskUIStatus = taskPanel.taskUIActive;
        }
        if (
            SceneManager.GetActiveScene().buildIndex == 4
            || SceneManager.GetActiveScene().buildIndex == 6
        )
        {
            questionPanel = GameObject.FindObjectOfType<Question_UI>();
            if (!dialoguePanel.dialogueUIActive && !taskUIStatus && !questionPanel.questionUIActive && !quitePanel.quiteUIActive)
            {
                return true;
            }
            else
                return false;
        }
        else
        {
            if (!dialoguePanel.dialogueUIActive && !taskUIStatus && !quitePanel.quiteUIActive)
            {
                return true;
            }
            else
                return false;
        }
    }

    public void Setup()
    {
        if (slots.Count == player.inventory.slots.Count)
        {
            for (int i = 0; i < slots.Count; i++)
            {
                if (player.inventory.slots[i].type != CollectableType.NONE)
                {
                    slots[i].SetItem(player.inventory.slots[i]);
                }
                else
                {
                    slots[i].SetEmpty();
                }
            }
        }
    }
}
