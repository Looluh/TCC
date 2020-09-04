using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;
    public GunController theGun;
    public bool controller;
    //public Camera shootCam;

    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        if (!controller)//mouse n keyboard
        {

            Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
            float rayLenght;

            if (groundPlane.Raycast(cameraRay, out rayLenght))
            {
                Vector3 pointToLook = cameraRay.GetPoint(rayLenght);
                Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);

                transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
            }

            if (Input.GetMouseButtonDown(1))
            {
                theGun.isFiring = true;
            }

            /*if (Input.GetMouseButtonUp(1))
            {
                theGun.isFiring = false;
            }*/
        }

        if (controller)
        {
            Vector3 playerDirection = Vector3.right * Input.GetAxisRaw("RHorizontal") + Vector3.forward * -Input.GetAxisRaw("RVertical");

            if (playerDirection.sqrMagnitude > 0f)
            {
                transform.rotation = Quaternion.LookRotation(playerDirection, Vector3.up);
            }

            if (Input.GetKeyDown(KeyCode.Joystick1Button5))//right bumper on xbox controller - can also use the fire1 stuff
            {
                theGun.isFiring = true;
            }

            if (Input.GetKeyUp(KeyCode.Joystick1Button5))
            {
                theGun.isFiring = false;
            }

        }
    }

    //yield return new WaitForSeconds(1);
    //Invoke("Metodo", Random.Range(0.5f, 5));
}

