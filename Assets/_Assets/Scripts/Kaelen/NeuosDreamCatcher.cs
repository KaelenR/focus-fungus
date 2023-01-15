using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System;
using UnityEngine;
using UnityEngine.Events;

public class NeuosDreamCatcher : MonoBehaviour
{

    private float enjoyment;
    private float zone;
    private float focus;


    

    [Serializable]
    public class ValueChangedEvent : UnityEvent<float> { }

    public ValueChangedEvent focusChanged;

    public ValueChangedEvent enjoymentChanged;

    public ValueChangedEvent zoneChanged;


    // Start is called before the first frame update
    void Start()
    {
        focus = -1;
        enjoyment = -1;
        zone = -1;

    }

    public void printData(string key, string val)
    {

        

        Debug.Log(key + " : " + val);

        if(key == "focus")
        {

            focus = (float)Convert.ToDouble(val);

            
            if (focus > 0)
            {
                focus = focus / 100;
            }
            focusChanged.Invoke(focus);
        }
        else if(key == "enjoyment")
        {
            enjoyment = (float)Convert.ToDouble(val);
            if (enjoyment > 0)
            {
                enjoyment = enjoyment / 100;
            }
            enjoymentChanged.Invoke(enjoyment);
        }
        else if(key == "zone_state")
        {
            zone = (float)Convert.ToDouble(val);
            if (zone > 0)
            {
                zone = zone / 100;
            }
            zoneChanged.Invoke(zone);
        }


        Debug.Log(focus);
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
