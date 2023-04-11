using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToScene : MonoBehaviour
{
    private Inventory_UI inventoryPanel;
    private Task_UI_Empty taskPanel;
    private Task_UI taskPanel2;
    private Task_UI_Collection_Question taskPanel3;
    private DialogueManager dialoguePanel;
    private Question_UI questionPanel;

    public void GoScene(int sceneNumber)
    {
        if (GoToSceneCheck())
        {
            SceneManager.LoadScene(sceneNumber, LoadSceneMode.Single);
        }
    }

    public bool GoToSceneCheck()
    {
        dialoguePanel = GameObject.FindObjectOfType<DialogueManager>();
        inventoryPanel = GameObject.FindObjectOfType<Inventory_UI>();
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
            if (!dialoguePanel.dialogueUIActive && !taskUIStatus && !questionPanel.questionUIActive && !inventoryPanel.inventoryUIActive)
            {
                return true;
            }
            else
                return false;
        }
        else
        {
            if (!dialoguePanel.dialogueUIActive && !taskUIStatus&& !inventoryPanel.inventoryUIActive)
            {
                return true;
            }
            else
                return false;
        }
    }
}
