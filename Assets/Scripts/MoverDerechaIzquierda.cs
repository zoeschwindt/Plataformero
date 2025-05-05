using UnityEngine;

public class MoverDerechaIzquierda : MonoBehaviour
{
    public float velocidad = 2f;    
    public float distancia = 2f;     

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
