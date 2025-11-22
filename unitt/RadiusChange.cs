using UnityEngine;

public class RadiusChange : MonoBehaviour
{
    SphereCollider mySphereCollider;
    
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody myRigidbody = GetComponent<Rigidbody>();
        Debug.Log("UseGravity: " + myRigidbody.useGravity);
        mySphereCollider = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        mySphereCollider.radius = mySphereCollider.radius + 0.01f;
    }
}