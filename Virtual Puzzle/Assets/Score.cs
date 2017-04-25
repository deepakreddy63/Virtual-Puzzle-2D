using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour {

    public Text timeincr;
    public Text gameover;
    public float time_increment;

    // Use this for initialization
    void Start () {
        time_increment = 0;
        
    }
	
	// Update is called once per frame
	void Update () {

        if (movepiece.i < 16)
        {
            time_increment += Time.deltaTime;
            timeincr.text = "Time =" + Mathf.RoundToInt(time_increment).ToString();
        }

        if(movepiece.i == 16)
        {
            gameover.text = "Game Over!!";
            
        }
    }
}
