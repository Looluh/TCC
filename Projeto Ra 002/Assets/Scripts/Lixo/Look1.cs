using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look1 : MonoBehaviour
{
    private Camera mainCamera;
   // public CharacterController cctrl;
    public GunController theGun;
    public float moveSpeed;
    private Rigidbody myRigidbody;
    private Vector3 playerAxis;
    private Vector3 moveVelocity;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = FindObjectOfType<Camera>();
    }


    // Update is called once per frame
    void Update()
    {
       // playerAxis = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
       // moveVelocity = playerAxis * moveSpeed;
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLenght;

        if (groundPlane.Raycast(cameraRay, out rayLenght))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLenght);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);

            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }

        if (Input.GetMouseButtonDown(0))
        {
            theGun.isFiring = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            theGun.isFiring = false;
        }

    }
    void FixedUpdate()
    {
        myRigidbody.velocity = moveVelocity;
    }

    //yield return new WaitForSeconds(1);
    //Invoke("Metodo", Random.Range(0.5f, 5));
}

