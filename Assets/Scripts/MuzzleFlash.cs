using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleFlash : MonoBehaviour
{
    [SerializeField] int counter = 0;
    [SerializeField] int lifeTime;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        counter++;
        if (counter >= lifeTime)
        {
            gameObject.SetActive(false);
            counter = 0;
        }
    }
}
