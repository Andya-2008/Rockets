using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bomb : MonoBehaviour
{
    [SerializeField] GameObject BombBlowUpRadius;
    [SerializeField] TextMeshProUGUI BombText;
    bool hit;
    [SerializeField] float BombTime;
    float startTime;
    // Start is called before the first frame update
    void Start()
    {
        startTime=Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        BombText.text = (BombTime-Mathf.Round(Time.time-startTime)).ToString();
        if((Time.time-startTime)>=BombTime)
        {
            Explode();
        }
    }
    void Explode()
    {
        BombText.gameObject.SetActive(false);
        this.GetComponent<Rigidbody>().isKinematic=true;
        this.GetComponent<MeshRenderer>().enabled=false;
        BombBlowUpRadius.SetActive(true);
        this.gameObject.tag="Untagged";
        BombBlowUpRadius.transform.localScale+= new Vector3(.05f, 0,.05f);
    }
}
