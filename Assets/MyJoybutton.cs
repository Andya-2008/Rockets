using UnityEngine;
using UnityEngine.EventSystems;

public class MyJoybutton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField] GameObject OrigImage;
    public bool Pressed;
    [SerializeField] bool PowerField1;
    [SerializeField] bool PowerField2;
    [SerializeField] bool PowerField3;
    [SerializeField] bool PowerField4;
    bool upPressed;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (PowerField1)
        {
            Debug.Log(upPressed);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (OrigImage.GetComponent<MyJoybutton>().Pressed)
        {
            upPressed = true;
        }
        Pressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("Here");
        Pressed = false;
        if (PowerField1 || PowerField2 || PowerField3 || PowerField4)
        {
            if (upPressed)
            {
                upPressed = false;
            }
            else
            {
                
                if (PowerField1)
                {
                    GameObject.Find("PowerupHandler").GetComponent<ActivatePowerupScript>().Powerup1 = true;
                }
                if (PowerField2)
                {
                    GameObject.Find("PowerupHandler").GetComponent<ActivatePowerupScript>().Powerup2 = true;
                }
                if (PowerField3)
                {
                    GameObject.Find("PowerupHandler").GetComponent<ActivatePowerupScript>().Powerup3 = true;
                }
                if (PowerField4)
                {
                    GameObject.Find("PowerupHandler").GetComponent<ActivatePowerupScript>().Powerup4 = true;
                }
            }
        }
    }
}