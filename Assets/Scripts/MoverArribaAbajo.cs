using UnityEngine;

public class MoverArribaAbajo : MonoBehaviour
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
        float nuevaZ = Mathf.PingPong(Time.time * velocidad, distancia) - (distancia / 2f);
        transform.position = new Vector3(posicionInicial.x, posicionInicial.y, posicionInicial.z + nuevaZ);
    }
}
