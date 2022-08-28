using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 10.0f;
    public float xRange = 10;

    public GameObject projectilePrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Keep the player inbounds
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);  
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        //Get input from the player when they press left or right arrow keys or 'a' and 'd' keys
        horizontalInput = Input.GetAxis("Horizontal");
        //Move the player object either left or right at a constant speed
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        //When the space key is pressed Lauch a projectile from the position of the player
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);

        }
    }
}
