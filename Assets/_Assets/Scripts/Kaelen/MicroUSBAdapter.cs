using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
