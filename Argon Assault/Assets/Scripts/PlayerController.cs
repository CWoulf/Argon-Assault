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
    [SerializeField] float controlSpeed = 10f;
    [SerializeField] float xRange = 10f;
    [SerializeField] float yRange = 6.5f;

    [SerializeField] float posPitchFactor = -2f;
    [SerializeField] float posYawFactor = 2f;
    [SerializeField] float controlPitchFactor = -10f;
    [SerializeField] float controlRollFactor = -20f;

    float xThrow , yThrow;
   
   
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

        ProcessTranslation();
        ProcessRotation();
    }

    private void ProcessRotation()
    {
        float pitch = transform.localPosition.y * posPitchFactor + yThrow * controlPitchFactor;
        float yaw = transform.localPosition.x * posYawFactor;
        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTranslation()
    {
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * Time.deltaTime * controlSpeed;
        float raWXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(raWXPos, -xRange, xRange);

        float yOffset = yThrow * Time.deltaTime * controlSpeed;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }
}
