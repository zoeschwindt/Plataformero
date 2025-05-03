using UnityEngine;

public class MoverDerechaIzquierda : MonoBehaviour
{
    public float velocidad = 2f;     // Qué tan rápido se mueve
    public float distancia = 2f;     // Cuánto se mueve de un lado a otro

    private Vector3 posicionInicial;

    void Start()
    {
        posicionInicial = transform.position;
    }

    void Update()
    {
        float nuevaX = Mathf.PingPong(Time.time * velocidad, distancia) - (distancia / 2f);
        transform.position = new Vector3(posicionInicial.x + nuevaX, posicionInicial.y, posicionInicial.z);
    }
}
