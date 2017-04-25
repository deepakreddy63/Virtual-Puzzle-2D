using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Support : MonoBehaviour {

    public GameObject view;
    public Button viewimage;
    public Button back;
    public Button mainmenu;

    public Sprite level1Image;
    public Sprite level2Image;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

   public void viewimage_click()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        if(Menu.levelselect == 1)
        {
            GetComponent<Renderer>().sortingOrder = 12;
            GetComponent<SpriteRenderer>().sprite = level1Image;
            
        }
        if (Menu.levelselect == 2)
        {
            GetComponent<Renderer>().sortingOrder = 12;
            GetComponent<SpriteRenderer>().sprite = level2Image;
            
        }
    }

   public void back_click()
    {
        GetComponent<Renderer>().sortingOrder = 0;
        GetComponent<SpriteRenderer>().enabled = false;
    }

    public void mainmenu_click()
    {

        SceneManager.LoadScene("Main menu");
    }
}
