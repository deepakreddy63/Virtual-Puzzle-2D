using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;
using UnityEngine.UI;

public class movepiece : MonoBehaviour {

    Controller controller;
   // public Text timeincr;
    public Text handpos;

    public string pieceStatus = "";

    public Transform edgeparticles;

    //public KeyCode placePiece;

    public string checkPlacement = "";

    public static int i;

    static int number;

    float pinchstrength;
    //public static float time_increment;
    
    static string selected;
    static double[] used = new double[16];

    public Sprite level2Image;

    //public Text gameover;

    // Use this for initialization
    void Start () {
        controller = new Controller();
        i = 0;
        for(int p = 0; p<16; p++)
        {
            used[p] = 0;
        }
        number = 5;
        used[0] = number;

        if(Menu.levelselect == 2)
        {
            GetComponent<SpriteRenderer>().sprite = level2Image;
        }
        //time_increment = 0;
        
    }

    // Update is called once per frame
    void Update() {

        Frame frame = controller.Frame();

  
            if (frame.Hands.Count > 0)
            {
                List<Hand> hands = frame.Hands;
                Hand Hand = hands[0];

            //To show the time increment as score
           // time_increment +=  Time.deltaTime;
           //   timeincr.text = "Time =" + Mathf.RoundToInt(time_increment).ToString();

                Vector3 temp = Hand.PalmPosition.ToVector3();
                Vector3 temp1 = new Vector3(temp.x / 30 - 1, temp.y / 30 - 4, 0);


                pinchstrength = Hand.PinchStrength;
                

            handpos.text = "p = " + temp1.ToString() + number.ToString()+ i.ToString();

                selected = "A" + number.ToString();
                pieceStatus = "";

              if (i == 16) //End selection after the last piece
                selected = "" ;

            string name = gameObject.name;
                if (pinchstrength == 1 && name == selected && i<16)
                {
                    transform.position = temp1;
                    GetComponent<Renderer>().sortingOrder = 10;
                    checkPlacement = "n";
                }

                if (pinchstrength == 0 && name == selected)
                {
                    checkPlacement = "y";
                }
            }
        
    }


    void OnTriggerStay2D(Collider2D collider)       
    {
        if((collider.gameObject.name == gameObject.name) && checkPlacement == "y")
        {
            Debug.Log(selected);
            collider.GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<Renderer>().sortingOrder = 0;
            pieceStatus = "Locked";
           
            transform.position = collider.gameObject.transform.position;
            
            Instantiate(edgeparticles, collider.gameObject.transform.position, edgeparticles.rotation);
            System.Threading.Thread.Sleep(500);

            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            checkPlacement = "n";
            if (i == 15) //for last piece locking
            {
                i = i + 1;
               // gameover.text = "Game Over!!";
            }
                

            int k = 0;
            while (k == 0 && i < 15)
            {
                number = Random.Range(1, 17);
                k = 1;
                for (int p = 0; p <= i; p++)
                {

                    if (number == used[p])
                        k = 0;

                }
                if (k == 1)
                {
                    i = i + 1;
                    used[i] = number;

                }
             
            }
            
            
        }
       
       /* if ((collider.gameObject.name != gameObject.name) && checkPlacement == "y")
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
            checkPlacement = "n";
        }
        */
       
    }
    
    /* void OnTriggerEnter(Collider other)
     {

              if (IsHand(other))
             {
                 Debug.Log("Yay! A hand collided!");
             }

     }
     private bool IsHand(Collider other)
     {
         if (other.transform.parent && other.transform.parent.parent && other.transform.parent.parent.GetComponent<HandModel>())
             return true;
         else
             return false;
     }
     void OnMouseDown()
     {
         pieceStatus = "pickedUp";
         checkPlacement = "n";
         GetComponent<Renderer>().sortingOrder = 10;
     }

 */
}
