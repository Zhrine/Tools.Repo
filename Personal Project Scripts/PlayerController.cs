using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float turnspeed = 30.0f; 
    [SerializeField] float speed = 10.0f;

    [SerializeField] Rigidbody playerRb;
    [SerializeField] float zBound = 6;
    [SerializeField] float rotationZ = 10f;
    [SerializeField] float sensitivityZ = 2f;
 
    void lockedRotation()
    {
        rotationZ += Input.GetAxis("Mouse X") * sensitivityZ;
        rotationZ = Mathf.Clamp (rotationZ, -10, 10);
             
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, -rotationZ);
    }
	
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private Vector2 StartPos;
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        playerRb.AddForce(Vector3.forward * speed * verticalInput);
        playerRb.AddForce(Vector3.right * speed * horizontalInput);

        if (transform.position.z < -zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBound);
        }

        if (transform.position.z > zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBound);
        }
        transform.Rotate(Vector3.down * turnspeed * horizontalInput * Time.deltaTime);
     
    }
	private void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.CompareTag("Enemy"))
			{
				Debug.Log("Player Coollided E.");
			}
	}
	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("Powerup"))
		{
			Destroy(other.gameObject);
		}	
	}

}

 

