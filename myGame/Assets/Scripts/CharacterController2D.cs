using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour
{


    [SerializeField] public float m_JumpForce = 400f;							
	[Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .36f;			
	[Range(0, 1)] [SerializeField] public float m_MovementSmoothing = .05f;
	[SerializeField] public bool m_AirControl = false;							
	[SerializeField] private LayerMask m_WhatIsGround;							
	[SerializeField] private Transform m_GroundCheck;							
	[SerializeField] private Transform m_CeilingCheck;							
	[SerializeField] private Collider2D m_CrouchDisableCollider;				

	const float k_GroundedRadius = .2f; 
	public bool m_Grounded;            
	const float k_CeilingRadius = .2f; 
	private Rigidbody2D m_Rigidbody2D;
	private bool m_FacingRight = true;  
	private Vector3 m_Velocity = Vector3.zero;

	[Header("Events")]
	[Space]

	public UnityEvent OnLandEvent;

	[System.Serializable]
	public class BoolEvent : UnityEvent<bool> { }

	public BoolEvent OnCrouchEvent;
	private bool m_wasCrouching = false;

    //dash
    float doubleTaptime;
    KeyCode lastKeyCode;
    private bool podeDash = true;
    
    public float dashSpeed;
    public float dashCount;
    public float startDashcount;
    private int side;
    public float delayfordash;
    public bool dash = false;

    public bool podeVirar = false;

    private void Start()
    {
        dashCount = startDashcount;
    }

    private void Awake()
	{
		m_Rigidbody2D = GetComponent<Rigidbody2D>();

		if (OnLandEvent == null)
			OnLandEvent = new UnityEvent();

		if (OnCrouchEvent == null)
			OnCrouchEvent = new BoolEvent();
	}

    private void Update()
    {

        
        //dash
        if (dash == true) { 
            if (side == 0)
            {
                if (Input.GetKeyDown(KeyCode.A))
                {
                    if (doubleTaptime > Time.time && lastKeyCode == KeyCode.A)
                    {
                    
                        side = 1;
                    }
                    else
                    {
                    doubleTaptime = Time.time + 0.5f;
                    }

                lastKeyCode = KeyCode.A;

                }

                else if (Input.GetKeyDown(KeyCode.D))
                {
                    if (doubleTaptime > Time.time && lastKeyCode == KeyCode.D)
                    {
                    
                        side = 2;
                    }
                    else
                    {
                    
                        doubleTaptime = Time.time + 0.5f;
                    }

                lastKeyCode = KeyCode.D;
                }
            }
            else
            {
                if (dashCount <= 0)
                {
                
                    side = 0;
                    dashCount = startDashcount;
                    m_Rigidbody2D.velocity = Vector2.zero;
                }
                else
                {
                    dashCount -= Time.deltaTime;

                        if (podeDash == true) { 
                    if (side == 1)
                    {
                            
                            m_Rigidbody2D.velocity = Vector2.left * dashSpeed;
                            StartCoroutine(dashDelay());
                    }
                    else if (side == 2)
                    {
                            
                            m_Rigidbody2D.velocity = Vector2.right * dashSpeed;
                            StartCoroutine(dashDelay());
                    }
                                               }
                }

            }
        }
    }

    IEnumerator dashDelay()
    {
        
        podeDash = false;
        yield return new WaitForSeconds(delayfordash);
        podeDash = true;
        
    }

    
    

    private void FixedUpdate()
	{
		bool wasGrounded = m_Grounded;
		m_Grounded = false;

		
		Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
				m_Grounded = true;
				if (!wasGrounded)
					OnLandEvent.Invoke();
			}
		}
	}


	public void Move(float move, bool crouch, bool jump)
	{
		
		if (!crouch)
		{
			
			if (Physics2D.OverlapCircle(m_CeilingCheck.position, k_CeilingRadius, m_WhatIsGround))
			{
				crouch = true;
			}
		}

		
		if (m_Grounded || m_AirControl)
		{

			
			if (crouch)
			{
				if (!m_wasCrouching)
				{
					m_wasCrouching = true;
					OnCrouchEvent.Invoke(true);
				}

				
				move *= m_CrouchSpeed;

				// Disable one of the colliders when crouching
				if (m_CrouchDisableCollider != null)
					m_CrouchDisableCollider.enabled = false;
			} else
			{
				// Enable the collider when not crouching
				if (m_CrouchDisableCollider != null)
					m_CrouchDisableCollider.enabled = true;

				if (m_wasCrouching)
				{
					m_wasCrouching = false;
					OnCrouchEvent.Invoke(false);
				}
			}

			// Move the character by finding the target velocity
			Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
			// And then smoothing it out and applying it to the character
			m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

            if(podeVirar == false) { 

			// If the input is moving the player right and the player is facing left...
			if (move > 0 && !m_FacingRight)
			{
				// ... flip the player.
				Flip();
			}
			// Otherwise if the input is moving the player left and the player is facing right...
			else if (move < 0 && m_FacingRight)
			{
				// ... flip the player.
				Flip();
			}

            }else if(podeVirar == true)
            {
                if (move < 0 && !m_FacingRight)
                {
                    // ... flip the player.
                    Flip();
                }
                // Otherwise if the input is moving the player left and the player is facing right...
                else if (move > 0 && m_FacingRight)
                {
                    // ... flip the player.
                    Flip();
                }
            }
        }
		// If the player should jump...
		if (m_Grounded && jump)
		{
			// Add a vertical force to the player.
			m_Grounded = false;
			m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
            
		}
	}


	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
