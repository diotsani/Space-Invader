using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour {

    public int score;
    public string username;

    public void add( string username, int score)
    {
        this.score = score;
        this.username = username;
    }
}
