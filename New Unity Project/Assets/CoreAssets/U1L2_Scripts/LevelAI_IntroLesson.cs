using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelAI_IntroLesson : MonoBehaviour
{
    [HideInInspector]
    public Vector3 objStartPos, objStartRot, objStartScale;
    public List<Vector3> endVectorCheck;
    public List<TextMeshPro> infoText;
    public List<TextMeshPro> helpText;
    public List<GameObject> objCube;
    public List<bool> challengeComplete;
    GameObject s2_lightObj;

    void Awake()
    {
        objStartPos = objCube[0].transform.position;
        objStartRot = objCube[1].transform.eulerAngles;
        objStartScale = objCube[2].transform.localScale;
    }

    // Start is called before the first frame update
    void Start()
    {
        //checks if there's a Point light in the scene
        Light[] allLights = GameObject.FindObjectsOfType<Light>();
        for (var i = 0; i < allLights.Length; i++)
        {
                if (allLights[i].type == LightType.Point)
                    s2_lightObj = allLights[i].gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {

        #region Challenge Text
        if (challengeComplete[0] == false)
            infoText[0].text = "You need to put a 3D object inside of the S1 box";

        if (challengeComplete[1] == false && s2_lightObj == null)
            infoText[1].text = "You need to put a Point light in your scene";
        else if (challengeComplete[1] == false && s2_lightObj != null)
            infoText[1].text = "Make sure the Point light is inside of the S2 box";

        if (challengeComplete[2] == false)
            infoText[2].text = "You need to move the C3_Cube to a new location when the game starts";
        if (challengeComplete[3] == false)
            infoText[3].text = "You need to change the rotation of the C4_Cylinder when the game starts";
        if (challengeComplete[4] == false)
            infoText[4].text = "You need to change the scale of the C5_Tree when the game starts";
        if (challengeComplete[5] == false)
            infoText[5].text = "Get the position value of the 2 boxes (using coding only), then add them together to move the diamond.";
        #endregion


        if (objCube[0].transform.position != objStartPos && objCube[0].transform.position == endVectorCheck[0])
        {
            challengeComplete[2] = true;
            infoText[2].text = "Challenge 3 complete";
        }
        if (objCube[1].transform.eulerAngles != objStartRot && objCube[1].transform.eulerAngles == endVectorCheck[1])
        {
            challengeComplete[3] = true;
            infoText[3].text = "Challenge 4 complete";
        }
        if (objCube[2].transform.localScale != objStartScale && objCube[2].transform.localScale == endVectorCheck[2])
        {
            challengeComplete[4] = true;
            infoText[4].text = "Challenge 5 complete";
        }

    }

    public void CollisionManager(int scenario, string message)
    {
        switch (scenario){
            case 0:
                //Challenge 1: Put a 3D object inside of the playground
                challengeComplete[0] = true;
                Debug.Log(message);
                infoText[0].text = "Challenge 1 complete";
                break;
            case 1:
                challengeComplete[1] = true;
                infoText[1].text = "Challenge 2 complete";
               //Debug.Log(message);
               //Challenge 2 win condition is handled inside of the Update method
                break;
            default:
                break;
        }

    }

  

}
