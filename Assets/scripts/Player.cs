using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player:MonoBehaviour{

	// Pause
	public PauseMenu pauseMenu;

	// Health Bar (Hit)
	public int hitQuantity;

	// PaticleSystem
	public ParticleSystem Dust;
    
	// Ground Check
	public Transform groundCheckCollider;
	public LayerMask groundLayer;
	public bool isGrounded;
	const float groundCheckRadius = 0.2f;


	// Cooldown DASH
	public bool cool = true;
	public float dashCooldown = 0.1f;

	// Level Change
	public bool levelNext;
	public bool levelBack;

	// Dash
	private float dashNow;
	private bool canDash;
	private bool isDashing;
	public float durationDash;
	public float dashSpeed;

	// Respawn
	public Vector3 respawnPoint;
	public GameObject fallDetector;

	// Player Animation
	public Animator animator;
	public float horizontalMove;

	// For Flip Player Sprite
	public bool facingRight = true;

	// Velocidade do personagem
	public float Speed;

	// Jump Status and Velocity
	public float JumpForce;
	public bool isJumping;
	public bool doubleJump;
	private Rigidbody2D fisica_do_personagem;

	//Identificando a direção
	float inputHorizontal;
	float inputVertical;

	//Variaveis para audio
	public AudioClip soundJump;
	public AudioClip soundMove;
	public AudioClip soundHit;

	// Lost Life (Count)
	public LifeCount lifeCount;

	// Inventory
	public Image[] imageSlot = new Image[4];
	public Sprite[] spriteItem = new Sprite[4];

	[SerializeField]
	public List<string> _ItemsInventory= new List<string>();

	public bool pausedGame;

	//Start é chamada antes do primeiro frame
	public void Start(){
		fisica_do_personagem=GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		respawnPoint = transform.position;
	}

	//Update é chamada em cada frame
	public void Update(){
		GroundCheck();
		Move();
		Jump();
		Dash();

		// Get horizontal move to activate animation
		horizontalMove = Input.GetAxisRaw("Horizontal") * Speed;
		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

		fallDetector.transform.position = new Vector2(transform.position.x, fallDetector.transform.position.y);
	
		
	}

	public void addingItem(string nameItem)
	{
		if(!existItem(nameItem))
		{
			_ItemsInventory.Add(nameItem);
		}
		if(!GameController.Instance.existItem(nameItem))
		{
			GameController.Instance._ItemsInventory.Add(nameItem);
		}
	}

	public bool existItem(string nameItem)
	{
		return _ItemsInventory.Contains(nameItem);
	}


	public void FixedUpdate(){
		if(Input.GetAxisRaw("Horizontal") > 0 && !facingRight){ Flip(); }
		if(Input.GetAxisRaw("Horizontal") < 0 && facingRight){ Flip(); }
	}

	void GroundCheck()
	{
		isGrounded = false;
		//Check if the GroundCheckObject is colliding with other
		//2D Colliders that are in the "Ground" Layer
		//If yes (isGrounded true) eles (isGrounded false)

		Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckCollider.position, groundCheckRadius, groundLayer);
		if(colliders.Length > 0)
			isGrounded = true;

		animator.SetBool("isGrounded", isGrounded);
			
	}


	//Metodo de andar
	public void Move(){
		Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
		transform.position+=movement*Time.deltaTime*Speed;

		StartCoroutine(delaySound());
		
	}
	
	// Método para pular
	public void Jump(){
		if(Input.GetButtonDown("Jump") && !pauseMenu.GameIsPause){
			if(isGrounded){
				// Jump Animation
				CreateParticle();
				animator.SetBool("isJumping", true);
				
				//Impulsionando o personagem para cima
				fisica_do_personagem.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
				doubleJump= true;

				//audio
				audioController.instancia.PlayOneShot(soundJump);
			}else{
        		if (!isGrounded)
        		{
            	 	//Jump Animation
            		animator.SetBool("isJumping", false);
            		
       			}

				if(doubleJump){
					CreateParticle();
					fisica_do_personagem.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
					doubleJump=false;
		
					//audio
					audioController.instancia.PlayOneShot(soundJump);
				}
			}
		}
	}	

	// Método Flip (Sprite Player)
	public void Flip(){
		Vector3 currentScale = gameObject.transform.localScale;
		currentScale.x *= -1;
		gameObject.transform.localScale = currentScale;

		facingRight = !facingRight;
	}

	// Método Dash
	public void Dash(){

		if(Input.GetKey(KeyCode.LeftControl) && !isJumping && canDash && cool){
			if(dashNow <= 0){
				StopDash();
				animator.SetBool("isDashing", false);
			}else{
				isDashing = true;
				animator.SetBool("isDashing", true);
				dashNow -= Time.deltaTime;

				CreateParticle();

				if(facingRight)
					fisica_do_personagem.velocity = Vector2.right * dashSpeed;
				else
					fisica_do_personagem.velocity = Vector2.left * dashSpeed;
			}
		}

		if (Input.GetKeyDown(KeyCode.LeftControl)){
			isDashing = false;
			animator.SetBool("isDashing", false);
			canDash = true;
			dashNow = durationDash;
			//CooldownStart();
		}
	}

	private void StopDash(){
		fisica_do_personagem.velocity = Vector2.zero;
		dashNow = durationDash;
		isDashing = false;
		animator.SetBool("isDashing", false); //fds
		canDash = false;
		
	}

	public void CooldownStart()
     {
         StartCoroutine(CooldownCoroutine());
     }
     IEnumerator CooldownCoroutine()
     {
        cool = false;
        yield return new WaitForSeconds(dashCooldown);
        cool = true;
     }

	// Particle Dust
	public void CreateParticle(){
		Dust.Play();
	}

	//Metódo chamado quando o personagem tocar algo
	public void OnCollisionEnter2D(Collision2D collision){
		if(collision.gameObject.layer==8)
		{
			isJumping=false;
			// Jump Animation
        	animator.SetBool("isJumping", false);
			
		}
		else if(collision.gameObject.tag == "Enemy")
		{
			if(hitQuantity < 6){
				hitQuantity += 2;
				audioController.instancia.PlayOneShot(soundHit);
			}else{
				transform.position = respawnPoint;
				hitQuantity = 0;
				lifeCount.LoseLife();
	
			}
		}
		else if(collision.gameObject.tag == "Fireball")
		{
			if(hitQuantity < 6){
				hitQuantity += 4;
				audioController.instancia.PlayOneShot(soundHit);
			}else{
				transform.position = respawnPoint;
				hitQuantity = 0;
				lifeCount.LoseLife();
			}
		}
	}
	
	//Metódo para quando o personagem parar de tocar algo
	public void OnCollisionExit2D(Collision2D collision){
		if(collision.gameObject.layer==8){
			isJumping=true;
			
		}
	}
	
	public void OnTriggerEnter2D(Collider2D collision){

		if(collision.tag == "FallDetector"){
			transform.position = respawnPoint;

			hitQuantity = 0;
			lifeCount.LoseLife();
			transform.position = respawnPoint;
			

		}else if(collision.gameObject.tag == "NextLevel"){
			
			levelNext = true;
			
		}else if (collision.gameObject.tag == "PreviousLevel"){
		
			levelBack = true;
		
		}else if(collision.gameObject.tag == "Hurricane")
		{

			if(hitQuantity < 6){
				hitQuantity += 3;
				//KnockBack Player
				Vector2 difference= transform.position-collision.transform.position;
				transform.position=new Vector3(transform.position.x+difference.x, transform.position.y+difference.y);

				audioController.instancia.PlayOneShot(soundHit);
				
			}else{
				transform.position = respawnPoint;
				hitQuantity = 0;
				lifeCount.LoseLife();	
				audioController.instancia.PlayOneShot(soundHit);
			}
		}
	}
	
	IEnumerator delaySound()
     {

        yield return new WaitForSeconds(2f);
        audioController.instancia.PlayOneShot(soundMove);
     }

	public void InventoryPatch()
	{
		if(GameController.Instance._ItemsInventory.Contains("key"))
		{
			ImageChangeSlot(imageSlot[1], spriteItem[0]);
		}
		else
		{
			imageSlot[0].color = Color.blue;
		}
		
		if(GameController.Instance._ItemsInventory.Contains("paper"))
		{
			ImageChangeSlot(imageSlot[2], spriteItem[1]);
		}
		else
		{
			imageSlot[0].color = Color.blue;
		}
		
		if(GameController.Instance._ItemsInventory.Contains("cellphone"))
		{
			ImageChangeSlot(imageSlot[0], spriteItem[2]);
		}
		else
		{
			imageSlot[0].color = Color.blue;
		}
	}

	public void ImageChangeSlot(Image image, Sprite sprite)
	{
		SetTransparency(image, 100);
        image.color = Color.white;
        image.sprite = sprite;
	}

	public static void SetTransparency(Image p_image, float p_transparency)
    {
        if (p_image != null)
        {
            UnityEngine.Color __alpha = p_image.color;
            __alpha.a = p_transparency;
            p_image.color = __alpha;
        }
    }

}