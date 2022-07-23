using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Sprite Bite0;
    public Sprite Bite1;
    public Sprite Bite2;
    public Sprite Bite3;

    public GameObject sprinkledBite0;
    public GameObject sprinkledBite1;
    public GameObject sprinkledBite2;
    public GameObject sprinkledBite3;

    public Sprite FrostingBite0;
    public Sprite FrostingBite1;
    public Sprite FrostingBite2;
    public Sprite FrostingBite3;

    public float frostingDuration = 6f;
    public float slowDuration = 2f;
    public float sprinklesDuration = 6f;

    public float sprinklesMultiplier = 5f;

    public static float hits = 0f;
    public static bool Frosted = false;
    public static bool slowed = false;
    public static bool sprinkled = false;
    public static bool alive = true;

    Rigidbody2D body;
    SpriteRenderer spriteRenderer;
    public GameObject crumbEffect;
    public GameObject pinkCrumbEffect;
    private Camera cam;
    GameObject music;

    float horizontal;
    float vertical;

    private float fixedDeltaTime;

    void Start()
    {
        alive = true;
        hits = 0;

        cam = Camera.main;
        body = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        music = GameObject.FindWithTag("Music");
        body.gravityScale = 0f;
    }
    void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && Frosted == false)
        {
            hits++;
            Instantiate(crumbEffect, body.transform.position, Quaternion.identity);
        }
        if (collision.gameObject.tag == "Enemy" && Frosted == true)
        {
            Instantiate(pinkCrumbEffect, body.transform.position, Quaternion.identity);
        }
        if (collision.gameObject.tag == "Frosting")
        {
            Frosted = true;
            StartCoroutine(removeFrosting());
        }
        if(collision.gameObject.tag == "Coffee")
        {
            slowed = true;
            StartCoroutine(slowTime());
        }
        if (collision.gameObject.tag == "Sprinkles")
        {
            sprinkled = true;
            scoreManager.pointsPerSecond = scoreManager.pointsPerSecond * sprinklesMultiplier;
            StartCoroutine(removeSprinkles());
        }
    }
    
    private IEnumerator slowTime()
    {
        if(slowed == true)
        {
            Time.timeScale = 0.5f;
            Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;

            yield return new WaitForSeconds(slowDuration);
            Time.timeScale = 1f;
            slowed = false;
        }
    }
    private IEnumerator removeSprinkles()
    {
        if(sprinkled == true)
        {
            yield return new WaitForSeconds(sprinklesDuration);
            sprinkled = false;
            scoreManager.pointsPerSecond = scoreManager.pointsPerSecond / sprinklesMultiplier;
        }
    }
    private IEnumerator removeFrosting()
    {
        if(Frosted == true)
        {
            yield return new WaitForSeconds(frostingDuration);
            Frosted = false;
        }
    }
    void Awake()
    {
        this.fixedDeltaTime = Time.fixedDeltaTime;
    }

    void FixedUpdate()
    {

        if (sprinkled == true && hits == 0)
        {
            sprinkledBite0.SetActive(true);
        }else if (sprinkled == false && hits == 0)
        {
            sprinkledBite0.SetActive(false);
        }
        if (sprinkled == true && hits == 1)
        {
            sprinkledBite0.SetActive(false);
            sprinkledBite1.SetActive(true);
        }
        else if (sprinkled == false && hits == 1)
        {
            sprinkledBite1.SetActive(false);
        }
        if (sprinkled == true && hits == 2)
        {
            sprinkledBite0.SetActive(false);
            sprinkledBite1.SetActive(false);
            sprinkledBite2.SetActive(true);
        }
        else if (sprinkled == false && hits == 2)
        {
            sprinkledBite2.SetActive(false);
        }
        if (sprinkled == true && hits == 3)
        {
            sprinkledBite0.SetActive(false);
            sprinkledBite1.SetActive(false);
            sprinkledBite2.SetActive(false);
            sprinkledBite3.SetActive(true);
        }
        else if (sprinkled == false && hits == 3)
        {
            sprinkledBite3.SetActive(false);
        }



        if (Frosted == true)
        {
            gameObject.tag = "Frosted";
        }
        if (Frosted == false)
        {
            gameObject.tag = "Player";
        }


        if (hits == 0 && Frosted == true)
        {
            spriteRenderer.sprite = FrostingBite0;
        }
        if(hits == 0 && Frosted == false)
        {
            spriteRenderer.sprite = Bite0;
        }

        if(hits == 1 && Frosted == false)
        {
            spriteRenderer.sprite = Bite1;
        }
        if(hits == 1 && Frosted == true)
        {
            spriteRenderer.sprite = FrostingBite1;
        }

        if (hits == 2 && Frosted == false)
        {
            spriteRenderer.sprite = Bite2;
        }
        if (hits == 2 && Frosted == true)
        {
            spriteRenderer.sprite = FrostingBite2;
        }

        if (hits == 3 && Frosted == false)
        {
            spriteRenderer.sprite = Bite3;
        }
        if (hits == 3 && Frosted == true)
        {
            spriteRenderer.sprite = FrostingBite3;
        }

        if (hits >= 4)
        {
            hits = 4;
            gameObject.SetActive(false);
            music.GetComponent<AudioSource>().Stop();
            alive = false;

            Time.timeScale = 1f;
            Frosted = false;
            slowed = false;
            sprinkled = false;

            FindObjectOfType<gameManager>().GameOver();
        }

            Vector3 mousePos = Input.mousePosition;

            mousePos = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 0));
            mousePos.x = Mathf.Clamp(mousePos.x, -3.15f, 3.15f);

            body.transform.position = new Vector2(mousePos.x, body.transform.position.y);
            

    }
}
