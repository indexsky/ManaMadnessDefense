﻿using UnityEngine;
using System.Collections;

public class Feelers : MonoBehaviour
{
    // the origin gem
    public Gems source;

    // if the other object is identified as a gem, then immediately check and add it into the list.
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Gem")
        {
            source.AddToList(other.GetComponent<Gems>());
        }
    }


    // if the other object is identified as a gem, then immediately check and remove them from the list.
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Gem")
        {
            source.RemoveFromList(other.GetComponent<Gems>());
        }
    }
}
