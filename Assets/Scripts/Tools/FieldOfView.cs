using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    [SerializeField] Transform root;
    [SerializeField] Transform target;
    [SerializeField] LayerMask visibleMask;
    [SerializeField] LayerMask targetMask;
    [SerializeField] float minAngle = 45f;
    [SerializeField] float minDist = 2f;
    float angle = 0f;
    float mag = 0f;
    Vector3 dir;
    RaycastHit hit;

    bool cansee = false;

    public bool Query()
    {
        if (root == null) return false;
        if (target == null) return false;

        dir = target.position - root.position;
        mag = dir.magnitude;


        /// 1° esta en rango?
        if ( mag < minDist)
        {

            Debug.Log("<color=red>Esta en Rango");
            angle = Vector3.Angle(root.forward, dir);

            // 2° esta en Angulo??
            if (angle < minAngle / 2)
            {

                Debug.Log("<color=blue>Esta en Angulo");
                // sobrecarga 15 ideal
                // 3° Lo veo directamente || Line of Sight
                if (Physics.Raycast(root.position, dir, out hit, mag, visibleMask))
                {

                    ///  Corremos el 1 x veces a la izquierda
                    var layer = 1 << hit.collider.gameObject.layer; // buffer del objeto colisionado

                    if ((layer & targetMask) != 0)
                    {
                        Debug.Log("<color=magenta>Lo estoy viendo || LOS");

                        // puedo ver al objetivo directamente
                        cansee = true;
                        return true;
                    }
                }
            }
        }

        cansee = false;
        return false;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = cansee ? Color.green : Color.red;
        Gizmos.DrawLine(root.position, target.position);

        Gizmos.color = Color.grey;
        Gizmos.DrawWireSphere(root.position, minDist);

        Vector3 left = Quaternion.Euler(0, -minAngle / 2f, 0) * root.forward;
        Vector3 right = Quaternion.Euler(0, minAngle / 2f, 0) * root.forward;

        Gizmos.color = Color.yellow;

        Gizmos.DrawRay(root.position, left * minDist);
        Gizmos.DrawRay(root.position, right * minDist);
    }
}
