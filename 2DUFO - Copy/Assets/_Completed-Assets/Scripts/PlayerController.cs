using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text winText;
    public Text livesText;
    public Text loseText;
    public int scoreWinAmount;
    public Vector2 teleportLocation;

    private Rigidbody2D rb2d;
    private int count;
    private int lives;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        lives = 3;
        loseText.text = ""; 
        winText.text = "";
        SetCountText();
        SetLivesText();
        
    }
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("PickUp"))
        {

            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
            TeleportPLayer();
        }
        if (other.gameObject.CompareTag("RedEnemy"))
        {

            other.gameObject.SetActive(false);
            lives = lives - 1;
            SetLivesText();
        }
    }


    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= scoreWinAmount)
        { 
            winText.text = "WIN! Game by Jamie";

        }
    }
    void SetLivesText()
    {
        livesText.text = "Lives: " + lives.ToString();
        if (lives < 1)
        {
            loseText.text = "YOU LOSE! Game by Jamie";
            Destroy(gameObject);
        }
    }

    void TeleportPLayer()
    {
        if (count == 13)
        {
            this.gameObject.transform.position = teleportLocation; //teleportLocation;

        }

    }
}
