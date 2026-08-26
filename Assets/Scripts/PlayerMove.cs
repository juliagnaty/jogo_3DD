using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private bool isGrounded;
    public float jumpForce = 5f;
    public float moveSpeed = 5f;
    private Rigidbody rb;
    public Transform cam;
    private Vector3 direcao; // vector3 guarda 3 "valores" (x,y,z)

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

        direcao = cam.right * x + cam.forward * z; // define os novos valores de x e z baseado na rotação da camera

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
