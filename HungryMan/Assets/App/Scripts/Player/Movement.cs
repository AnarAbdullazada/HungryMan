using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SOG.Player
{
  public class Movement : MonoBehaviour
  {
    [SerializeField] private float movementSpeed;

    [SerializeField] private Rigidbody2D playerRb;

    
    /* ************************************************************** */
    private void Start()
    {
      Application.targetFrameRate = 60;
    }
    /* ************************************************************** */


    private void PlayerMovement()
    {
      float InputHorizontal = Input.GetAxis("Horizontal");

      playerRb.velocity = ((Vector2.right * InputHorizontal * movementSpeed) + (Vector2.up * playerRb.velocity.y)) * Time.deltaTime;
      
      if (InputHorizontal != 0)
      {
        transform.localScale = new Vector3(Mathf.Sign(InputHorizontal),1,1);
      }

    }

    private void Update()
    {
      PlayerMovement();
    }

  }
}
