using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s2_TriggerScript : MonoBehaviour
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
            {
                if (other.GetComponent<Light>().type == LightType.Point)
                    lvCheck.CollisionManager(1, "Object is inside collider");
            }

        }
    }

}
