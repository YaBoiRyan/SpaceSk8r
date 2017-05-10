using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffScreenDestroy : MonoBehaviour {

    // Update is called once per frame
    void Start()
    {

    }

    void Update ()
    {
		if (!GetComponent<Renderer>().isVisible)
			{
				Destroy(gameObject);
			}
    }
}
