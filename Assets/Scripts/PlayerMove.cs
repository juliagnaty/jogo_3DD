using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private bool isGrounded;
    public float jumpForce = 5f;
    public float moveSpeed = 5f;
    private Rigidbody rb;
    private Vector3 direcao; // vector3 guarda 3 "valores" (x,y,z)

    public Transform cam1;
    public Transform cam3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        if(cam1.gameObject.activeSelf)
        {
            direcao = cam1.right * x + cam1.forward * z; // define os novos valores de x e z baseado na rotação da camera
        }
        else
        {
            direcao = cam3.right * x + cam3.forward * z; // define os novos valores de x e z baseado na rotação da camera
        }

        rb.linearVelocity = new Vector3(direcao.x * moveSpeed, rb.linearVelocity.y, direcao.z * moveSpeed);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
