using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffScreenDestroy : MonoBehaviour {

    private Camera mainCamera;
    Vector2 cameraWidth;
    Vector2 cameraHeight;
    // Update is called once per frame
    void Start()
    {
        

    }

    void Update ()
    {
        Vector2 screenPosition = mainCamera.WorldToScreenPoint(transform.position);
        if (screenPosition.x < cameraWidth.x || screenPosition.x > cameraWidth.y || screenPosition.y < cameraHeight.x || screenPosition.y > cameraHeight.y)
        Destroy(gameObject);

    }
}
