using UnityEngine;

public class RotarObjeto : MonoBehaviour
{
    public Vector3 ejeRotacion = new Vector3(0, 1, 0); 
    public float velocidadRotacion = 45f; 

    void Update()
    {
        transform.Rotate(ejeRotacion * velocidadRotacion * Time.deltaTime);
    }
}