using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    private Canvas CanvasObject;
    // Start is called before the first frame update
    void Start()
    {
        CanvasObject = GetComponent<Canvas> ();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp("h"))
	{
	    CanvasObject.enabled = !CanvasObject.enabled;
	}
    }
}
