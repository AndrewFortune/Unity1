using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s1_TriggerScript : MonoBehaviour
{
    private LevelAI_IntroLesson lvCheck;

    void Start()
    {
        lvCheck = transform.parent.GetComponent<LevelAI_IntroLesson>();
    }

 

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject != null)
        {
            if(other.gameObject.tag != "Player")
                lvCheck.CollisionManager(0,"Object is inside collider");
        }
    }

}
