using UnityEngine;

public class cactusVictor : MonoBehaviour
{

    public float horizontalInput;
    public float fowardInput;

    public float forwardSpeed = 5f;
    public float sideSpeed = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        fowardInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * forwardSpeed * fowardInput);
        transform.Translate(Vector3.right * Time.deltaTime * sideSpeed * horizontalInput);
    }
}
