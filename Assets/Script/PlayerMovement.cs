using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 5f;
    public float jumpForce = 6f;
    public float gravity = -20f;

    [Header("Mouse Look")]
    public float mouseSensitivity = 200f;
    public Transform cameraTransform;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundDistance = 0.3f;
    public LayerMask groundMask;

    [Header("Dash")]
    public float dashSpeed = 10f;
    public float dashDuration = 0.3f;
    public float dashCooldown = 2f;

    float xRotation;
    Vector3 velocity;
    bool isGrounded;
    bool isDashing = false;
    bool CanSprint = true;

    CharacterController controller;

    [Header("Hp")]
    public float PlayerHp = 5f;
    public float StaticPlayerHp = 5f;
    public Image hpBar;

    

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        GroundCheck();
        Move();
        MouseLook();
        
    }

    void GroundCheck()
    {
        isGrounded = Physics.CheckSphere(
            groundCheck.position,
            groundDistance,
            groundMask
        );

        if (isGrounded && velocity.y < 0)
            velocity.y = -2f;
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        // DASH
        if (Input.GetKeyDown(KeyCode.Q) && CanSprint && !isDashing)
        {
            StartCoroutine(Dash());
        }

        // JUMP
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            velocity.y = jumpForce;
        }

        // GRAVITY
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    IEnumerator Dash()
    {
        isDashing = true;
        CanSprint = false;

        float originalSpeed = speed;
        speed += dashSpeed;

        yield return new WaitForSeconds(dashDuration);

        speed = originalSpeed;
        isDashing = false;

        yield return new WaitForSeconds(dashCooldown);
        CanSprint = true;
    }

    void MouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }


    void OnCollisionEnter(Collision collision)
    {
       if(collision.gameObject.CompareTag("MagmaHead"))
       {
            int NegativeHp = 2;
            HpSystem(NegativeHp);
            Destroy(collision.gameObject);

       }

       else if(collision.gameObject.CompareTag("NormalHead"))
       {
            int NegativeHp = 1;
            HpSystem(NegativeHp);
            Destroy(collision.gameObject);
        }

    }


    void HpSystem(int NegativeHp)
    {
        PlayerHp -= NegativeHp;
        hpBar.fillAmount = PlayerHp / StaticPlayerHp;

    }
}
