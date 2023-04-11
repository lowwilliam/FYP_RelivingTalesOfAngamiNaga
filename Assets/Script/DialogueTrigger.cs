using System.Security.AccessControl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;
using System.Net.Http;
using UnityEngine.SceneManagement;

public class DialogueTrigger : MonoBehaviour
{
    public Message[] messages;
    public Message[] messages2;
    public Actor[] actors;
    private GameManage gameManage;
    public Player player;
    public List<Slot_UI> slots = new List<Slot_UI>();
    public Animator animator;

    public void StartDialogue()
    {
        Message[] messagesSend = messages;
        Actor[] actorsSend = actors;
        gameManage = GameObject.FindObjectOfType<GameManage>();
        UnityEngine.Debug.Log(actors[1].name);
        if (actors[1].name == "Tribal Elder")
        {
            if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                if (gameManage.GetGame() == 7)
                {
                    messagesSend = messages2;
                    gameManage.UpdateGame(2);
                }
            }
            else if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                gameManage.UpdateGame(1);
            }
            else if (SceneManager.GetActiveScene().buildIndex == 3)
            {
                // UnityEngine.Debug.Log("print slot count" + player.inventory.slots[0].count);
                if (
                    player.inventory.slots[0].type == CollectableType.FLOWER
                    && player.inventory.slots[0].count >= 10
                )
                {
                    messagesSend = messages2;
                    gameManage.UpdateGame(8);
                }
            }
        }
        if (actors[1].name == "Warrior")
        {
            if (
                SceneManager.GetActiveScene().buildIndex == 4
                || SceneManager.GetActiveScene().buildIndex == 6
            )
            {
                gameManage.UpdateGame(3);
            }
        }
        if (actors[1].name == "Vihounuo")
        {
            if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                if (gameManage.GetGame() == 3 || gameManage.GetGame() == 2)
                {
                    gameManage.UpdateGame(7);
                }
                else if (gameManage.GetGame() == 0)
                {
                    gameManage.UpdateGame(4);
                }
            }
        }
        if (actors[1].name == "Hielie")
        {
            if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                if (gameManage.GetGame() == 4 || gameManage.GetGame() == 2)
                {
                    gameManage.UpdateGame(7);
                }
                else if (gameManage.GetGame() == 0)
                {
                    gameManage.UpdateGame(3);
                }
            }
        }
        OpenDialogue(messagesSend, actorsSend, gameManage.GetGame());
    }

    private void OpenDialogue(Message[] messages, Actor[] actors, int gameNumber)
    {
        FindObjectOfType<DialogueManager>().OpenDialogue(messages, actors, gameNumber);
    }
}

[System.Serializable]
public class Message
{
    public int actorId;
    public string message;
}

[System.Serializable]
public class Actor
{
    public string name;
    public Sprite sprite;
}
