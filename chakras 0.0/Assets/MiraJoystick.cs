using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiraJoystick : MonoBehaviour
{
   private PlayerMoves playerMoves;
   public Transform twistpoint;

   public float returnTime = 0.8f;
    void Start()
    {
        playerMoves = GameObject.FindObjectOfType<PlayerMoves>();
    }

    // Update is called once per frame
    void Update()
    {
        Aim();
    }

    private void Aim() 
    {
        float HorizontalAxis = Input.GetAxis("HorizontalRightStick");
        float VerticalAxis = Input.GetAxis("VerticalRightStick");

        twistpoint.transform.localEulerAngles = new Vector3(0f, 0f, Mathf.Atan2(HorizontalAxis, VerticalAxis) * -180 / Mathf.PI + 90f);
    }
    

}
