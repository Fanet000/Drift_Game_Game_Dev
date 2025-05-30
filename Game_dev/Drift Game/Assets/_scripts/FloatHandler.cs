using UnityEngine;
using UnityEngine.UI;

public class FloatHandler : MonoBehaviour
{
    public Image Speedo,  Nitro;
    public float amount, speed = 1.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float target = 0.1f;
        
        if (vertical != 0)
        {
            target = 1;
        }

        amount = Mathf.MoveTowards(amount, target, speed * Time.deltaTime);

        //Image
        Speedo.fillAmount = amount;
        
        Nitro.color = Color.Lerp(Speedo.color, Color.red, amount);        
    }
}
