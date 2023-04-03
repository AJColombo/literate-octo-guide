using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMovement : MonoBehaviour
{
	
	public float playerSpeed = 10.0f;
	private float horizonalMove;
	public Rigidbody2D  ObjectsRidigdbody;
	private Vector2 moveDirection;
	private float jumpingPower = 16f;
	public enum PlayerMovementStyle {
		TopDown = 0,
		SideScroll = 1
	}
	private bool redDoorAccess = false;
	private bool greenDoorAccess = false;
	private bool isFacingRight = true;
	[SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
	public PlayerMovementStyle PlayerControlStyle;


    // Start is called before the first frame update
    void Start()
    {
        PlayerControlStyle = PlayerMovementStyle.TopDown;
		redDoorAccess = false;
		greenDoorAccess = false;
		
    }

    // Update is called once per frame
	void Update() {
		if (PlayerControlStyle == PlayerMovementStyle.TopDown) {
			ProcessTopDownInputs();
		} else {
			ProcessSideScrollInput();
		}
		Debug.Log(ObjectsRidigdbody.velocity.y);
		
	}
    void FixedUpdate() {
		if (PlayerControlStyle == PlayerMovementStyle.TopDown) {
			TopDownMove();
		} else {
			SideScrollMove();
		}
		
    }
	
	void ProcessTopDownInputs() {
		float moveX = Input.GetAxisRaw("Horizontal");
		float moveY = Input.GetAxisRaw("Vertical");
		moveDirection =  new Vector2(moveX,moveY);
	}

	void ProcessSideScrollInput() {
		horizonalMove = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && (ObjectsRidigdbody.velocity.y < 1.0f && ObjectsRidigdbody.velocity.y > -1.0f) )
        {
			Debug.Log("WAS GROUNDED");
            ObjectsRidigdbody.velocity = new Vector2(ObjectsRidigdbody.velocity.x, jumpingPower);
        }

        if (Input.GetButtonUp("Jump") && ObjectsRidigdbody.velocity.y > 0f)
        {
            ObjectsRidigdbody.velocity = new Vector2(ObjectsRidigdbody.velocity.x, ObjectsRidigdbody.velocity.y * 0.5f);
        }

        Flip();
	}
	
	void TopDownMove(){
		ObjectsRidigdbody.velocity = new Vector2(moveDirection.x * playerSpeed, moveDirection.y * playerSpeed);
	}

	void SideScrollMove(){ 
		ObjectsRidigdbody.velocity = new Vector2(horizonalMove * playerSpeed, ObjectsRidigdbody.velocity.y);
	}

	private bool IsGrounded()
    {
		
        return Physics2D.OverlapCircle(groundCheck.position, 0.00005f, groundLayer);
		
    }



	private void Flip()
    {
        if (isFacingRight && horizonalMove < 0f || !isFacingRight && horizonalMove > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
	
	public void setRedDoorToTrue() {
		redDoorAccess = true;
	}
	
	public bool getRedDoorAccess() {
		return redDoorAccess;
	}
	public void setGreenDoorToTrue() {
		greenDoorAccess = true;
	}
	
	public bool getGreenDoorAccess() {
		return greenDoorAccess;
	}

	public void SwapPlayerPerspective() {
		if (PlayerControlStyle == PlayerMovementStyle.TopDown) {
			PlayerControlStyle = PlayerMovementStyle.SideScroll;
			ObjectsRidigdbody.gravityScale = 1.0f;
		} else if (PlayerControlStyle == PlayerMovementStyle.SideScroll) {
			PlayerControlStyle = PlayerMovementStyle.TopDown;
			ObjectsRidigdbody.gravityScale = 0.0f;
		}
	}
}
