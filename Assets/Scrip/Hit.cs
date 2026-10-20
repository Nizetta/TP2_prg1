using UnityEngine;

public class Hit : MonoBehaviour
{
    [SerializeField] private Transform arm;

    private Vector3 origin;
    private Vector3 direction;

    [SerializeField] private float distance;

    private bool isHit;

    private RaycastHit hit;

    [SerializeField] private Vector3 offSet;
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    // Update is called once per frame
    void Update()
    {
        //origin = arm.position + offSet;
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            origin=arm.TransformPoint(offSet);

            direction =arm.forward;

            if(Physics.Raycast(origin,direction,out hit, distance))
            {
                isHit = hit.collider.CompareTag("destruible")? true : false;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = isHit ? Color.green : Color.red;
        Gizmos.DrawRay(origin, direction * distance);
    }
}
