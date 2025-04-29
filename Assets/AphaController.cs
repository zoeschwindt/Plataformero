using UnityEngine;

public class AphaController : MonoBehaviour
{


    public Material myMaterial;

    public float alphaValue;





    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myMaterial = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        myMaterial.SetFloat("_Alpha", alphaValue);
    }
}
