using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 8f;

    public Transform minXValue;
    public Transform maxXValue;

    public GameObject PlayerBullet;
    public Transform gunEndPosition;

    public float fireRate = 0.5f;
    private float timeSinceLastAction = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();

        if (transform.position.x > maxXValue.position.x)
        {
            transform.position = new Vector2(maxXValue.position.x, transform.position.y);
        }
        if (transform.position.x < minXValue.position.x)
        {
            transform.position = new Vector2(minXValue.position.x, transform.position.y);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            Shoot();
        }

    }

    void PlayerMovement()
    {
        float horizontalInputValue = Input.GetAxis("Horizontal");
        Vector2 movementVector = new Vector2(horizontalInputValue, 0) * moveSpeed * Time.deltaTime;
        transform.Translate(movementVector);
    }

    void Shoot()
    {
        timeSinceLastAction += Time.deltaTime;

        if (timeSinceLastAction >= fireRate)
        {

            Instantiate(PlayerBullet, gunEndPosition.position, Quaternion.identity);
            timeSinceLastAction = 0;
        }
    }

}
