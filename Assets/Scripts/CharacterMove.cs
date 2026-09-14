using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    private CharacterController controlador;
    public float velocidade = 6f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controlador = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 direcao = new Vector3(x, 0, z);
        controlador.SimpleMove(direcao * velocidade);
    }
}
