using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script allows us to switch between 2 IPs for our bci connection in game using the controller.
/// This way we could build 1 project and have 2 devices each have bcis correctly set.
/// It also toggles the visualization of 2 gameobjects so that we know what state we are in during setup.
/// We can then Manually connect to the bcis when we know we have the right ones setup.
/// 
/// Without setting up this script mushrooms will still form around you and the Left Controller but just at the minimum amount.
/// </summary>
public class MicroUSBAdapter : MonoBehaviour
{


    [SerializeField]
    private GameController playerA;

    [SerializeField]
    private GameController playerB;


    public GameObject setA;
    public GameObject setB;


    bool pressedA = false;
    bool pressedB = false;

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

        if (!pressedB)
        {

            if (OVRInput.Get(OVRInput.Button.Two))
            {
                Connect();
                pressedB = true;

            }
        }
        else
        {
            if (!OVRInput.Get(OVRInput.Button.Two))
            {
                pressedB = false;
            }


        }

    }


    void SwapIP()
    {

        string temp = playerA.ipField;

        playerA.ipField = playerB.ipField;

        playerB.ipField = temp;

        if (setA.activeSelf)
        {
            setA.SetActive(false);
            setB.SetActive(true);
        }
        else
        {
            setA.SetActive(true);
            setB.SetActive(false);
        }

    }

    void Connect()
    {

        playerA.ConnectToServer();
        playerB.ConnectToServer();

        Destroy(this);

    }

}
