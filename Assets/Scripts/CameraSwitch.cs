using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public Transform cam1;
    public Transform cam3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam1.gameObject.SetActive(true);
        cam3.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && cam1.gameObject.activeSelf)
        {
            cam1.gameObject.SetActive(false);
            cam3.gameObject.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.C) && cam3.gameObject.activeSelf)
        {
            cam1.gameObject.SetActive(true);
            cam3.gameObject.SetActive(false);
        }
    }
}
