using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

    public static int levelselect;

    public Dropdown dropdown;
    public Button startgame;

	// Use this for initialization
	void Start () {
        levelselect = 1;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

   /* private void OnMouseDown()
    {
        if (gameObject.name == "Level 1 text")
        {
            levelselect = 1;
        }

        if (gameObject.name == "Level 2 text")
        {
            levelselect = 2;
        }
       SceneManager.LoadScene("picture puzzle");
    }*/

    public void Dropdown_Indexchanged(int index)
    {
        levelselect = index+1;
        
    }

    public void button_clicked()
    {
        SceneManager.LoadScene("picture puzzle");
    }
   }
