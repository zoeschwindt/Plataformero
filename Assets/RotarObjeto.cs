using UnityEngine;

public class RotarObjeto : MonoBehaviour
{
    public Vector3 ejeRotacion = new Vector3(0, 1, 0); // Eje Y por defecto
    public float velocidadRotacion = 45f; // Grados por segundo

    void Update()
    {
        transform.Rotate(ejeRotacion * velocidadRotacion * Time.deltaTime);
    }
}