using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Task_UI_Collection_Question : MonoBehaviour
{
    public GameObject taskPanel;
    public Player player;
    public TextMeshProUGUI taskTitleText;
    public TextMeshProUGUI taskDetailText;
    public TextMeshProUGUI taskProgressText;
    public int selectedTask = 0;
    public GameObject taskCompleteImage;

    public bool taskUIActive = false;

    private DialogueManager dialoguePanel;
    private Inventory_UI inventoryPanel;
    private Question_UI questionPanel;
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
            taskPanel.SetActive(false);
            taskUIActive = false;
        }
    }

    public bool ToggleTaskCheck()
    {
        dialoguePanel = GameObject.FindObjectOfType<DialogueManager>();
        inventoryPanel = GameObject.FindObjectOfType<Inventory_UI>();
        quitePanel = GameObject.FindObjectOfType<Quite_UI>();
        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            if (!dialoguePanel.dialogueUIActive && !inventoryPanel.inventoryUIActive && !quitePanel.quiteUIActive)
            {
                UnityEngine.Debug.Log("tureeee! can open!");
                return true;
            }
            else
                return false;
        }
        else
        {
            questionPanel = GameObject.FindObjectOfType<Question_UI>();
            if (!dialoguePanel.dialogueUIActive && !inventoryPanel.inventoryUIActive && !questionPanel.questionUIActive && !quitePanel.quiteUIActive)
            {
                UnityEngine.Debug.Log("tureeee! can open!");
                return true;
            }
            else
                return false;
        }
    }

    // Update is called once per frame
    void Setup()
    {
        if (selectedTask == 0)
        {
            taskTitleText.text = "Armour up!";
            taskDetailText.text = "The route to becoming a warrior is not an easy feat! \n\nCombine the knowledge you’ve gained so far and prepare for a witty battle with our warrior!";
            if (SceneManager.GetActiveScene().buildIndex == 5)
            {
                taskProgressText.text = "Completed";
                taskCompleteImage.GetComponent<Image>().enabled = true;
            }
            else
            {
                taskProgressText.text = "In progress";
                taskCompleteImage.GetComponent<Image>().enabled = false;
            }
        }
        else if (selectedTask == 1)
        {
            taskTitleText.text = "Nagaland’s Flower: Rhododendron Arboreum";
            taskDetailText.text = "The Rhododendron Arboreum is Nagaland’s state flower! Not only is it beautiful, it has many properties and uses to it. \n\nAssist the Elder in collecting 10 Rhododendron Arboreum flowers and bring it back to the Elder at the Morung!";
            taskProgressText.text = "Completed";
            taskCompleteImage.GetComponent<Image>().enabled = true;
        }
    }

    public void CurrentTask(int currentTaskNumber)
    {
        selectedTask = currentTaskNumber;
        Setup();
    }
}
