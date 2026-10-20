using UnityEngine;

public class Camera : MonoBehaviour
{
    public float Velocidad = 2.5f;
    private float rotationX;

    public Transform Jugador;

    private void Awake()
    {
        if (Jugador == null)
        {
            Jugador = transform.parent;
        }
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * Velocidad;
        float mouseY = Input.GetAxis("Mouse Y") * Velocidad;

        rotationX = Mathf.Clamp(rotationX - mouseY, -90f, 90f);
        transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);

        if (Jugador != null)
        {
            Jugador.Rotate(Vector3.up * mouseX);
        }
    }
}
