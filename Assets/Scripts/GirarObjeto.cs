using UnityEngine;

public class GirarObjeto : MonoBehaviour
{
    public Vector3 ejeRotacion = new Vector3(0, 0, 1); 
    public float velocidad = 100f;

    void Update()
    {
        transform.Rotate(ejeRotacion * velocidad * Time.deltaTime);
    }
}
