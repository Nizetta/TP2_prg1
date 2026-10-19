using UnityEngine;

public class MovmientoPlayer : MonoBehaviour
{

    [SerializeField] private float velocidad = 5.0f;

    void Update()
    {

        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");
        float upDown = Input.GetAxis("Jump");

        Vector3 movimiento = new Vector3(movimientoHorizontal, upDown, movimientoVertical);

        transform.Translate(movimiento * velocidad * Time.deltaTime);
        
        Debug.Log("Movimiento Horizontal: " + movimientoHorizontal);
        Debug.Log("Movimiento Vertical: " + movimientoVertical);
        Debug.Log("Movimiento Up/Down: " + upDown);
    }
}