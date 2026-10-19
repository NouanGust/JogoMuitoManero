using UnityEngine;

public class ScrptAndante : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0.5f, 0, 0) * Time.deltaTime;
        Debug.Log(transform.position);
        transform.rotation *= Quaternion.Euler(0f,0f, 45f * Time.deltaTime);
        transform.localScale += new Vector3(0.3f, 0.3f, 0.3f) * Time.deltaTime;
    }
}
