using UnityEngine;
using UnityEngine.InputSystem;

public class FukasawaPlayer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Keyboard.current.rightArrowKey.IsPressed())
        {
            transform.Translate(new Vector2(4.0f, 0.0f) * Time.deltaTime);
        }
        if (Keyboard.current.leftArrowKey.IsPressed())
        {
            transform.Translate(new Vector2(-4.0f, 0.0f) * Time.deltaTime);
        }
    }
}
