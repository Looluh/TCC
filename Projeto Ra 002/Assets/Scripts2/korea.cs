using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class korea : MonoBehaviour
{
    public float moveSpeed = 7f;

    CharacterController cc;

    float gravity = -1f;

    public float yVelocity = 0;

    public float jumpPower;



    // Start is called before the first frame update
    private void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //w, a, s, d 키를 누르면 입력하면 캐릭터를 그 방향으로 이동시키고 싶다.
        //[spacebar] 키를 누르면 캐릭터를 수직으로 점프시키고 싶다.

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v);
        dir = dir.normalized;

        dir = Camera.main.transform.TransformDirection(dir);

        if (Input.GetButtonDown("Jump") && cc.isGrounded)//quite added a literally a timer
        {
            yVelocity = jumpPower;
        }

        yVelocity += gravity * Time.deltaTime;
        dir.y = yVelocity;

        cc.Move(dir * moveSpeed * Time.deltaTime);

        //p = p0 + vt
        //transform.position += dir * moveSpeed * Time.deltaTime;//i completely removed this line
    }

}
