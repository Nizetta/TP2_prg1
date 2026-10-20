using UnityEngine;

public class MovmientoPlayer : MonoBehaviour
{
    [Header("Velocidad de movimiento")]
    [SerializeField] private float velocidad = 5.0f;
    private float movimientoHorizontal;
    private float movimientoVertical;
    private float upDown;
    private Rigidbody rb;

    [Header ("raycast")]
    [SerializeField] private float distanciaRaycast;
    [SerializeField] private bool isGrounded;
    [SerializeField] private LayerMask groundLayer;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

        movimientoHorizontal = Input.GetAxis("Horizontal");
        movimientoVertical = Input.GetAxis("Vertical");
        CheckGround();
        upDown = Input.GetAxis("Jump");
        Vector3 movimiento = new Vector3(movimientoHorizontal, upDown, movimientoVertical);

        transform.Translate(movimiento * velocidad * Time.deltaTime);
    }

    // private void FixedUpdate()
    // {
    //     Vector3 movement = new Vector3(movimientoHorizontal*-1, 0f, movimientoVertical*-1).normalized;
    //     rb.linearVelocity= new Vector3(movement.x * velocidad, rb.linearVelocity.y, movement.z * velocidad);
    // }

    private void CheckGround()
    {
        Vector3 origen = transform.position;
        isGrounded = Physics.Raycast(origen, Vector3.down, distanciaRaycast, groundLayer);

        Color ColorRay =isGrounded ? Color.green : Color.red;
        Debug.DrawRay(origen, Vector3.down * distanciaRaycast, ColorRay);
    }
}