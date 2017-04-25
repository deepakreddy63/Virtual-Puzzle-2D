using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;
using UnityEngine.UI;

public class pinch : MonoBehaviour
{
    Controller controller;
    public Text position;
    public Text handpos;
    public GameObject pic;

    // Use this for initialization
    void Start()
    {
        controller = new Controller();
    }

    // Update is called once per frame
    void Update()
    {
        Frame frame = controller.Frame();

        if (frame.Hands.Count > 0)
        {
            List<Hand> hands = frame.Hands;
            Hand Hand = hands[0];
            position.text = "position = " + Hand.PalmPosition.ToVector3().ToString();

            float pinchstrength = Hand.PinchStrength;
            //velocity.text = "pinchstrength = " + pinchstrength.ToString();

            if (pinchstrength == 1)
            {
                //leftcube.transform.position = Hand.PalmPosition.ToVector3() ;
                Vector3 temp = Hand.PalmPosition.ToVector3();
                Vector3 temp1 = new Vector3(temp.x / 50, temp.y / 50 - 2, -temp.z / 50 + 2);
               pic.transform.position = temp1;
                handpos.text = "p = " + pic.transform.position.ToString();

            }

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("box1"))
        {
            pic.transform.position = other.gameObject.transform.position;
        }
    }
}