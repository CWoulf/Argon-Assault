using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * New Input System
using UnityEngine.InputSystem;
*/

public class PlayerController : MonoBehaviour
{

    /* [SerializeField] InputAction movement;  New Input System*/
   
    void Start()
    {
        
    }
    /*
     * New Input System
    private void OnEnable()
    {
        movement.Enable();
    }

    private void OnDisable()
    {
        movement.Disable();
    }*/

    void Update()
    {
        /*
         * New Input System
        float horizontalThrow = movement.ReadValue<Vector2>().x;
        float verticalThrow = movement.ReadValue<Vector2>().y;
        */

        float xThrow = Input.GetAxis("Horizontal");
        Debug.Log(xThrow);

        float yThrow = Input.GetAxis("Vertical");
        Debug.Log(yThrow);
    }
}
