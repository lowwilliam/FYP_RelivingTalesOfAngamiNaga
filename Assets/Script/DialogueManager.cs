using System.Net.Http;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public Image actorImage;
    public TextMeshProUGUI actorName;
    public TextMeshProUGUI messageText;
    public RectTransform backgroundBox;
    public Question_UI question_UI;
    public RainController rain_controller;

    Message[] currentMessages;
    Actor[] currentActors;
    public static int activeMessage = 0;
    public static bool isActive = false;
    public int gameNumberInternal = 0;

    public Animator animator;
    public bool dialogueUIActive = false;

    public Animator animatorRain;

    public void OpenDialogue(Message[] messages, Actor[] actors, int gameNumber)
    {
        dialogueUIActive = true;
        currentMessages = messages;
        currentActors = actors;
        activeMessage = 0;
        isActive = true;
        gameNumberInternal = gameNumber;
        DisplayMessages();
        // UnityEngine.Debug.Log("DialogueManager.isActive");
        animator.SetBool("IsOpen", true);
        // UnityEngine.Debug.Log("Open dialog");
    }

    void DisplayMessages()
    {
        Message messageToDisplay = currentMessages[activeMessage];
        messageText.text = messageToDisplay.message;

        Actor actorToDisplay = currentActors[messageToDisplay.actorId];
        actorName.text = actorToDisplay.name;
        actorImage.sprite = actorToDisplay.sprite;
    }

    public void NextMessage()
    {
        activeMessage++;
        if (activeMessage < currentMessages.Length)
        {
            DisplayMessages();
            DisplayRain();
        }
        else
        {
            dialogueUIActive = false;
            // UnityEngine.Debug.Log("player.inventory.slots[i].type");
            EndMessage();
            TriggerEndEvent();
        }
    }

    public void TriggerEndEvent()
    {
        if (gameNumberInternal == 2 && SceneManager.GetActiveScene().buildIndex == 2)
        {
            UnityEngine.Debug.Log("Trigger gate entering, switch scene to" + 3);
            SceneManager.LoadScene(3, LoadSceneMode.Single);
        }
        if (gameNumberInternal == 8 && SceneManager.GetActiveScene().buildIndex == 3)
        {
            UnityEngine.Debug.Log("Trigger gate entering, switch scene to" + 4);
            SceneManager.LoadScene(4, LoadSceneMode.Single);
        }
        if (
            gameNumberInternal == 3
            && (
                SceneManager.GetActiveScene().buildIndex == 4
                || SceneManager.GetActiveScene().buildIndex == 6
            )
        )
        {
            UnityEngine.Debug.Log("Start Quiz");
            question_UI.ToggleQuestion();
        }
    }

    public void EndMessage()
    {
        UnityEngine.Debug.Log("End!");
        isActive = false;
        animator.SetBool("IsOpen", false);
    }

    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool("IsOpen", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isActive == true)
        {
            NextMessage();
        }
    }

    public void OnClick()
    {
        if (isActive == true)
        {
            NextMessage();
        }
    }

    public void DisplayRain()
    {
        if (
            gameNumberInternal == 2
            && SceneManager.GetActiveScene().buildIndex == 2
            && activeMessage == 11
        )
        {
            rain_controller = GameObject.FindObjectOfType<RainController>();
            rain_controller.ToggleRain();
        }
    }

    public void SkipDialogueClick()
    {
        dialogueUIActive = false;
        EndMessage();
    }
}
