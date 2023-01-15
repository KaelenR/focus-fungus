using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicroUSBAdapter : MonoBehaviour
{


    [SerializeField]
    private GameController playerA;

    [SerializeField]
    private GameController playerB;

    bool pressedA = false;


    // Update is called once per frame
    void Update()
    {

        if (!pressedA)
        {

            if (OVRInput.Get(OVRInput.Button.One))
            {
                SwapIP();
                pressedA = true;

            }
        }
        else
        {
            if (!OVRInput.Get(OVRInput.Button.One))
            {
                pressedA = false;
            }


        }

    }


    void SwapIP()
    {

        string temp = playerA.ipField;

        playerA.ipField = playerB.ipField;

        playerB.ipField = temp;



    }

    void Connect()
    {

        playerA.ConnectToServer();
        playerB.ConnectToServer();

        Destroy(this);

    }

}
