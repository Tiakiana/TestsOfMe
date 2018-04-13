using UnityEngine;
using System.Collections;

public class Waypoint : MonoBehaviour {

    private string description = null;


    public string GetDescription()
    {
        if (description == null)
        {
            description = "" + this.gameObject.transform.position.x + "," + this.gameObject.transform.position.z;
        }
        return description;
    }
}
