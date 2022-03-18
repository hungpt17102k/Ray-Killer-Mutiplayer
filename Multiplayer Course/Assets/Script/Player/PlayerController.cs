using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    float resetSpeed;
    public float dashSpeed;
    public float dashTime;

    PhotonView view;
    Health healthScript;

    LineRenderer rend;

    public float minX, minY, maxX, maxY;

    public Text nameDisplay;

    private void Start()
    {
        // To get the id of the player
        view = GetComponent<PhotonView>();
        healthScript = FindObjectOfType<Health>();
        rend = FindObjectOfType<LineRenderer>();

        resetSpeed = speed; // To store the normal speed

        // Display Nick Name
        if (view.IsMine)
        {
            nameDisplay.text = PhotonNetwork.NickName;
        }
        else
        {
            nameDisplay.text = view.Owner.NickName;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        // To local which player is controlling
        if (view.IsMine)
        {
            // Get vector2 when input keyborad to move
            Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            // Get amount of movement 
            Vector2 moveAmount = moveInput.normalized * speed * Time.deltaTime;

            // Move the player to that position every frame
            transform.position += (Vector3)moveAmount;

            // This method to make the player stay in the scene
            Wrap();

            // When press down space key and it not moving it will dash
            if (Input.GetKeyDown(KeyCode.Space) && moveInput != Vector2.zero)
            {
                StartCoroutine(Dash());
            }

            // To set the point of the ray follow the player
            rend.SetPosition(0, transform.position);
        }
        else
        {
            rend.SetPosition(1, transform.position);
        }
    }

    //Function to keep the player in side the screce
    void Wrap()
    {
        if (transform.position.x < minX)
        {
            transform.position = new Vector2(maxX, transform.position.y);
        }

        if (transform.position.x > maxX)
        {
            transform.position = new Vector2(minX, transform.position.y);
        }

        if (transform.position.y < minY)
        {
            transform.position = new Vector2(transform.position.x, maxY);
        }

        if (transform.position.y > maxY)
        {
            transform.position = new Vector2(transform.position.x, minY);
        }
    }

    IEnumerator Dash()
    {
        speed = dashSpeed;
        yield return new WaitForSeconds(dashTime); // Wait for the dashTime 
        speed = resetSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (view.IsMine)
        {
            if (other.CompareTag("Enemy"))
            {
                healthScript.TakeDamge();
            }
        }
    }
}
