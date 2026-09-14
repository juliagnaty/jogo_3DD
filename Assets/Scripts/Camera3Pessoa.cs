using UnityEngine;

public class Camera3Pessoa : MonoBehaviour
{
    public Transform alvo;
    public float distancia = 6;
    public float Sensibilidade = 500f;

    private float angulo;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void LateUpdate()
    {
        angulo += Input.GetAxis("Mouse X") * Sensibilidade * Time.deltaTime;

        Vector3 offset = new Vector3(0f, 2f, -distancia);
        Vector3 pos = alvo.position + Quaternion.Euler(0f, angulo, 0f) * offset;

        transform.position = pos;
        transform.LookAt(alvo);
    }
}