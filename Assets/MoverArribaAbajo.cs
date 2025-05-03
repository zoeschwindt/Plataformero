using UnityEngine;

public class MoverArribaAbajo : MonoBehaviour
{
    public float velocidad = 2f;     // Velocidad del movimiento
    public float distancia = 2f;     // Distancia total de ida y vuelta

    private Vector3 posicionInicial;

    void Start()
    {
        posicionInicial = transform.position;
    }

    void Update()
    {
        float nuevaZ = Mathf.PingPong(Time.time * velocidad, distancia) - (distancia / 2f);
        transform.position = new Vector3(posicionInicial.x, posicionInicial.y, posicionInicial.z + nuevaZ);
    }
}
