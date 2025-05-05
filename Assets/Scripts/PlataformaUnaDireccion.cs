using UnityEngine;

public class PlataformaUnaDireccion : MonoBehaviour
{
    public Transform puntoA;
    public Transform puntoB; 
    public float velocidad = 2f;

    private Vector3 objetivoActual;

    void Start()
    {
        objetivoActual = puntoB.position;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, objetivoActual, velocidad * Time.deltaTime);

        if (Vector3.Distance(transform.position, objetivoActual) < 0.01f)
        {
            
            objetivoActual = (objetivoActual == puntoA.position) ? puntoB.position : puntoA.position;
        }
    }
}
