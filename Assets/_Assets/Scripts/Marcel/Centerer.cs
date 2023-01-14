using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Centerer : MonoBehaviour
{

    /*public OVRCameraRig cameraRig = null;

    //public ovrcon controller;

    // returns a float of the Hand Trigger’s current state on the Oculus Touch controller
    // specified by the controller variable.
    //OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, controller);

    // Start is called before the first frame update

    public bool pressed = false;
    void Start()
    {
        if (cameraRig == null)
        {
            Debug.LogError("no ovr rig bra!");
            enabled = false;
        }
        else
        {
            Debug.Log("yes rig");

            if (cameraRig.leftHandAnchor == null)
            {
                Debug.LogError("no left dudda");
            }
            if (cameraRig.rightHandAnchor == null)
            {
                Debug.LogError("no right dudd0");
            }
        }


    }

    // Update is called once per frame
    void Update()
    {
        //cameraRig.trackingSpace.localPosition = Quaternion.Inverse(cameraRig.leftHandAnchor.rotation) * (-cameraRig.leftHandAnchor.position);
        //cameraRig.trackingSpace.localRotation = Quaternion.Inverse(cameraRig.leftHandAnchor.rotation);

        *//*if (!pressed)
        {
            if (OVRInput.Get(OVRInput.Button.One))
            {
                Debug.Log("A button pressed");
                pressed = true;

                //cameraRig.trackingSpace.localPosition = - cameraRig.leftHandAnchor.position;
                Vector3 rote = Quaternion.Inverse(cameraRig.leftHandAnchor.rotation) * (-cameraRig.leftHandAnchor.position)cameraRig.leftHandAnchor.eulerAngles;
                Quaternion rot = Quaternion.Euler(new Vector3(rote.x, 0, rote.z));
                cameraRig.trackingSpace.localRotation = rot;
            }
        }
        if (pressed)
        {
            if (!OVRInput.Get(OVRInput.Button.One))
            {
                Debug.Log("unpressed");
                pressed = false;
            }
        }*//*
    }
*/

    
}
