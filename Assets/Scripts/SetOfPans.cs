using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetOfPans : MonoBehaviour
{
    Pan[] m_Pans;

    // Start is called before the first frame update
    void Start()
    {
        m_Pans = GetComponentsInChildren<Pan>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Invoke()
    {
        foreach(var pan in m_Pans)
        {
            if(pan.Status == PanStatus.Empty)
            {
                pan.PutMeat();
                break;
            }
        }
    }
}
