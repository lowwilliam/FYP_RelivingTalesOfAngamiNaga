using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Task_UI : MonoBehaviour
{
    public GameObject taskPanel;
    public Player player;
    public TextMeshProUGUI quantityText;
    public GameObject taskCompleteImage;
    public bool findFlower = false;
    public bool taskUIActive = false;

    private DialogueManager dialoguePanel;
    private Inventory_UI inventoryPanel;
    private Quite_UI quitePanel;

    void Start()
    {
        taskPanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            ToggleTask();
        }
    }

    public void ToggleTask()
    {
        if (!taskPanel.activeSelf && ToggleTaskCheck())
        {
            taskPanel.SetActive(true);
            taskUIActive = true;
            Setup();
        }
        else
        {
            taskUIActive = false;
            taskPanel.SetActive(false);
        }
    }

    public bool ToggleTaskCheck()
    {
        dialoguePanel = GameObject.FindObjectOfType<DialogueManager>();
        inventoryPanel = GameObject.FindObjectOfType<Inventory_UI>();
        quitePanel = GameObject.FindObjectOfType<Quite_UI>();
        if (!dialoguePanel.dialogueUIActive && !inventoryPanel.inventoryUIActive  && !quitePanel.quiteUIActive)
        {
            UnityEngine.Debug.Log("tureeee! can open!");
            return true;
        }
        else
            return false;
    }

    // Update is called once per frame
    void Setup()
    {
        for (int i = 0; i < 33; i++)
        {
            if (player.inventory.slots[i].type == CollectableType.FLOWER)
            {
                quantityText.text = player.inventory.slots[i].count.ToString() + "/10";
                if (player.inventory.slots[i].count >= 10)
                {
                    findFlower = true;
                    UnityEngine.Debug.Log("completed");
                }
                else
                {
                    UnityEngine.Debug.Log("not completed");
                }
            }
        }
        if (findFlower == true)
        {
            taskCompleteImage.GetComponent<Image>().enabled = true;
        }
        else
        {
            taskCompleteImage.GetComponent<Image>().enabled = false;
        }
    }
}
