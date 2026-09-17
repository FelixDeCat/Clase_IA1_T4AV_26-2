using System.Collections.Generic;
using UnityEngine;

public class Flocker : BoidBase
{
    [Header("Radius")]
    [Range(0.1f, 5f)][SerializeField] float separationRadius = 5f;
    [Range(0.1f, 5f)][SerializeField] float aligmentRadius = 5f;
    [Range(0.1f, 5f)][SerializeField] float cohesionRadius = 5f;

    [Header("Forces")]
    [Range(0.1f, 5f)][SerializeField] float separationForce = 1f;
    [Range(0.1f, 5f)][SerializeField] float aligmentForce = 1f;
    [Range(0.1f, 5f)][SerializeField] float cohesionForce = 1f;

    float Offset = 5f;
    float OffsetZ = 3f;

    void Start()
    {
        FlockerManager.instance.SetFlocker(this);

        velocity = (RandomV() - transform.position).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        List<Flocker> contextSeparacion = FlockerManager.instance.GetFlockers(transform.position, separationRadius);
        List<Flocker> contextAlignment = FlockerManager.instance.GetFlockers(transform.position, aligmentRadius, except: this);
        List<Flocker> contextCohesion = FlockerManager.instance.GetFlockers(transform.position, cohesionRadius, except: this);

        desired += 
            Separation(contextSeparacion) * separationForce + 
            Aligment(contextAlignment) * aligmentForce + 
            Cohesion(contextCohesion) * cohesionForce;


        desired = desired.normalized * moveSpeed;

        steering = desired - velocity;
        steering = Vector3.ClampMagnitude(steering, steeringForce);

        velocity = Vector3.ClampMagnitude(velocity + steering, moveSpeed);

        transform.position += velocity * Time.deltaTime;
        transform.forward = velocity;


        // Harcodeadita para que se teletransporten en los bounds
        if (transform.position.x > 23) transform.position = new Vector3(-23 + Offset, 0, transform.position.z);
        if (transform.position.x < -23) transform.position = new Vector3(23 - Offset, 0, transform.position.z);
        if (transform.position.z > 12) transform.position = new Vector3(transform.position.x, 0, -12 + OffsetZ);
        if (transform.position.z < -12) transform.position = new Vector3(transform.position.x, 0, 12 - OffsetZ);

    }

    Vector3 diff = Vector3.zero;
    Vector3 Separation(List<Flocker> context)
    {
        diff = Vector3.zero;

        foreach (var b in context)
        {
            Vector3 dir = transform.position - b.transform.position;

            if (dir.magnitude > 0)
            {
                diff += dir.normalized / dir.magnitude;
            }
        }

        if (context.Count == 0) return Vector3.zero;

        return diff.normalized;
    }
    Vector3 align;
    Vector3 Aligment(List<Flocker> context)
    {
        align = Vector3.zero;
        foreach (var b in context)
        {
            align += b.Velocity;
        }

        if (context.Count == 0) return Vector3.zero;

        align = align / context.Count;

        return align.normalized;

    }

    Vector3 center = Vector3.zero;
    Vector3 Cohesion(List<Flocker> context)
    {
        center = Vector3.zero;

        foreach (var b in context)
        {
            center += b.transform.position;
        }

        if (context.Count == 0) return Vector3.zero;
        
        center = center / context.Count;

        // convertir el punto central (POSICION) a direccion para movimiento (DIRECTION)
        Vector3 dir = center - transform.position;

        return dir.normalized;

    }



    Vector3 RandomV()
    {
        return new Vector3(Random.Range(-23, 24), 0, Random.Range(-12, 12)) - transform.position;
    }


    [SerializeField] Color orange;
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = orange;
        Gizmos.DrawWireSphere(transform.position, separationRadius);
        Gizmos.DrawWireSphere(transform.position, aligmentRadius);
        Gizmos.DrawWireSphere(transform.position, cohesionRadius);
    }
}
