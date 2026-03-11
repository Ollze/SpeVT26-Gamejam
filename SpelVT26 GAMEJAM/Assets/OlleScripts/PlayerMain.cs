using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMain : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float moveSpeed = 5;
    public ParticleSystem shootParticles;
    public float MaxMana = 100f;
    public float CurrentMana;
    public UnityEngine.UI.Slider Mana;
    public float Currency = 0;
    bool manaOverheat;
    bool isshooting;
    public float coinGain = 1f;
    public TextMeshProUGUI coinText;
    public Animator anim;
    public SpriteRenderer playerSprite;
    public Image manaSliderImage;
    public float manaRegen = 20f;
    public Animator manaAnimator;

    void Start()
    {
        MaxMana = 100f;
        CurrentMana += MaxMana;
        coinGain = 1f;
        Mana.maxValue = MaxMana;
        Mana.value = CurrentMana;
        coinText.text = ("Stardust: " +Currency.ToString());
       // anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        Mana.value = CurrentMana;
        //print("Current Mana " + CurrentMana);
        if (Keyboard.current.wKey.isPressed) 
        {
            transform.position += new Vector3(0, 1, 0) * moveSpeed * Time.deltaTime; }
        if (Keyboard.current.sKey.isPressed) { transform.position += new Vector3(0, -1, 0)* moveSpeed * Time.deltaTime; }
        if (Keyboard.current.dKey.isPressed)
        {
            transform.position += new Vector3(1, 0, 0)* moveSpeed * Time.deltaTime;
            playerSprite.transform.rotation = new Quaternion(0, 0, 0, 0);
        }
        if (Keyboard.current.aKey.isPressed) 
        {
            transform.position += new Vector3(-1, 0, 0) * moveSpeed * Time.deltaTime;
            playerSprite.transform.rotation = new Quaternion(0, 180, 0, 0);
        }
        if(!Keyboard.current.sKey.isPressed && !Keyboard.current.wKey.isPressed && !Keyboard.current.dKey.isPressed && !Keyboard.current.aKey.isPressed)
        {
            anim.SetBool("isWalking", false);
        }
        else
        {
            anim.SetBool("isWalking", true);
        }
        
        
        if (Mouse.current.leftButton.isPressed && CurrentMana > 0f && !manaOverheat && !shootParticles.isEmitting)        
        {
            float manaDamage = 100f * Time.deltaTime;
            //har testat i en timme for some reason funkar det inte om man gör * time.deltatime men jag förstår inte varför
            //ok det funkade om man satte manadage till typ en kvadriljon

            CurrentMana -= manaDamage;
            isshooting = true;
            Shoot();
            //print("Current Mana = " + CurrentMana);
            //print("Mana going down by " + manaDamage);
            //print("Left click pressed");
            if (CurrentMana <= 0f)
            { manaOverheat = true; CurrentMana = 0f; print("Mana overheat"); }
            shootParticles.Play();
        }
        else
        {
            isshooting = false;
          
        }
        
        if (!Mouse.current.leftButton.isPressed || manaOverheat)//den här är for some reason true även när man inte skuter
        {
            if (CurrentMana < MaxMana)
            {
                //print("Iecreasing mana");

                CurrentMana += manaRegen * Time.deltaTime;
                

                if (CurrentMana >= MaxMana)
                {
                    manaOverheat = false;
                    print("Manaoverheat" + manaOverheat);
                }
            }
        }
        
        if (manaOverheat)
        {
            manaSliderImage.color = new Color(1, 0.3f, 0.3f);

            manaAnimator.SetTrigger("ManaOut");
        }
        else { manaSliderImage.color = new Color(1, 1, 1); }

        coinText.text = ("Stardust :" + Currency.ToString());
        
    }


    public void Shoot()
    {        
        
        
    }
    
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            coinText.text = ("Stardust: " + Currency.ToString());
            Destroy(collision.gameObject);
            Currency += coinGain;

            print("Current points/coins " + Currency);
        }
    }
}
