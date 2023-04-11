using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManage : MonoBehaviour
{
    public int game=0;
    public void UpdateGame(int gameNumber){
        game = gameNumber;
        UnityEngine.Debug.Log(game+"your game number from game manager");
    }

    public int GetGame(){
        return game;
    }
}
