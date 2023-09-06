using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// para detectar colisao do mouse com o objeto
// [RequireComponent(typeof(Collider))]


public class MovingPottedPlant : MonoBehaviour
{
    float PotZCoord;
    Vector3 mouseOffset;

    float yRotation = 1;
    [SerializeField] float rotationRate = 0.005f;


    ///// The model is dragged in space when mouse is moved while pressing left button
    // When left button is pressed
    void OnMouseDown()
    {
        PotZCoord = Camera.main.WorldToScreenPoint(transform.position).z; // screen Z pos of object
        mouseOffset = transform.position - GetMouseAsWorldPos(); // world difference between mouse and object
    }
    // Returns mouse position in space
    private Vector3 GetMouseAsWorldPos()
    {
        Vector3 mousePos = Input.mousePosition; // screen pos of mouse (x,y,0)
        mousePos.z = PotZCoord; // screen Z pos of object
        return Camera.main.ScreenToWorldPoint(mousePos); // final world pos of mouse
    }
    // Update when mouse drag
    void OnMouseDrag()
    {
        transform.position = GetMouseAsWorldPos() + mouseOffset; // new position with offset
    }



    ///// The model rotates around one axis when mouse is moved while pressing right button
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            yRotation = Screen.width/2 - Input.mousePosition.x;
            gameObject.transform.Rotate(0,yRotation*rotationRate,0);
        }
    }

}

