using System.Collections;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [Header ("Sword Settings")]
    [SerializeField] private Transform arm;
    [SerializeField] private float radius;
   [SerializeField] private float damage=10f;
    private Vector3 origin;
    private Vector3 direction;
    [SerializeField] private float distance;
    private bool isHit;
    private RaycastHit hit;
    [SerializeField] private Vector3 offSet;
   
    [SerializeField]private bool isPlayer;
   [SerializeField] private bool isMelee;

   private bool canAttack;

   private bool isCharacter; 

    
    void Update()
    {
        if (isPlayer){
            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (isMelee)
                {
                    Melee();
                } else
                {
                    Gun();
                }
            }
        }
    }

    private void Gun()
    {
        if(Physics.Raycast(origin,direction,out hit, distance))
            {
                isHit = hit.collider.CompareTag("destruible")? true : false;
            }
    }

    public void Melee()
    {
        RaycastInfo(offSet);
        Collider[] colliders = Physics.OverlapSphere(origin, radius);

        if (colliders.Length > 0)
        {
            foreach (Collider col in colliders)
            {
                if (col.CompareTag("enemy") || col.CompareTag("Player"))
                {
                     ApplyDamage(col.gameObject);
                }
            }
            
        }
        else
        {
            isCharacter = false;
        }
        StartCoroutine(AttackColldown());
    }

    private IEnumerator AttackColldown()
    {
        float currentSpeed=0f;
        if (isPlayer)
        {
            currentSpeed = GetComponentInParent<MovmientoPlayer>().velocidad;
            GetComponentInParent<MovmientoPlayer>().velocidad = 0f;
            canAttack = false;
            yield return new WaitForSeconds(0.5f);

            GetComponentInParent<MovmientoPlayer>().velocidad=currentSpeed;
            canAttack = true;

        }
        
    }

    private void ApplyDamage(GameObject obj)
    {
        if (obj.CompareTag("Player") || obj.CompareTag("enemy") && obj!=null)
        {
            Debug.Log($"<color=red> aplico daño<>");
            obj.GetComponent<HealthSystem>().TakeDamage(damage);
            isCharacter = true;
        }
        else
        {
            isCharacter = false;
        }
        
    }

    private void RaycastInfo(Vector3 offSet )
    {
        origin=arm.TransformPoint(offSet);

        direction =arm.forward;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = isCharacter ? Color.green : Color.red;
        if (isMelee)
        {
            if (hit.collider != null) return;
            Gizmos.DrawWireSphere(origin, radius);
        }
        else
        {
            
        Gizmos.DrawRay(origin, direction * distance);
        }
        
    }
}
