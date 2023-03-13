using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Health : MonoBehaviour
{
    static public float MAX_HEALTH = 100;
    public float health;
    public float regenerationSpeed = 10;
    public float regenerate;
    public int numHearts = 10;
   
    public Image healthbar;
    public Image healthRadial;

    public Text healthText;
    public string heartPreface;
    public string healthPreface;
    
    public Transform heartContainer;
    public List<GameObject> hearts;
    public GameObject heartPrefab;
    
    public Coroutine regenerationCoroutine; 
    
    //public float regenerationSpeed = 10;
    // Start is called before the first frame update
    void Start() 
    {
        health = MAX_HEALTH;
            if(heartPrefab != null && heartContainer != null) {
                for (int i = 0; i < numHearts; i++)
            {
                Vector3 position = new Vector3(Screen.width * 0.5f / numHearts * i + heartPrefab.GetComponent<RectTransform>().rect.width / 2, heartPrefab.GetComponent<RectTransform>().rect.height / 2);
                GameObject heart = Instantiate(heartPrefab, position, Quaternion.identity, heartContainer);
                hearts.Add(heart);


            }
        }
        
            
            

           
       
    }

    // Update is called once per frame
    void Update()
    {
        // Adds Health
        if(Input.GetKeyDown(KeyCode.Space) && gameObject.tag == "Player") {
            AddHealth(10);
        }
        // subHealth
        if (Input.GetKeyDown(KeyCode.Minus) && gameObject.tag == "Player")
        {
            TakeDamage(10);
        }
        // Regenerate 
        if (Input.GetKeyDown(KeyCode.F) && gameObject.tag == "Player")
        {
           // regenerationCoroutine = StartCoroutine(regenerate());
       
        }
        UpdateHud();
    }

    public void TakeDamage(float damage)
    {
        health = Mathf.Max(health - damage, 0);
 
    }
     
    public void AddHealth(float amount)
    {
        health = Mathf.Min(health + amount, MAX_HEALTH);
    }
    public void UpdateHud()
    {
        float healthPercentage = health / MAX_HEALTH;
        if (healthbar != null)
            healthbar.fillAmount = healthPercentage;
        if (healthRadial != null)
            healthRadial.fillAmount = healthPercentage;
        if (healthText != null)
            healthText.text = healthPreface + (int)health + "/" + MAX_HEALTH; 
        if (hearts != null && heartContainer != null)
        {
            int numActiveHearts = (int)healthPercentage * numHearts;
            for(int i = 0; i < hearts.Count; i++)
            {
                if (i < numActiveHearts) hearts[i].SetActive(true);
                else hearts[i].SetActive(false);
            }
        }
    }
    public IEnumerable Regenrate()
    {
        while (health < MAX_HEALTH)
        {
            AddHealth(regenerationSpeed * Time.deltaTime);
            yield return null;
        }
        if (regenerationCoroutine != null)
            StopCoroutine(regenerationCoroutine);
        regenerationCoroutine = null;
    }

}


