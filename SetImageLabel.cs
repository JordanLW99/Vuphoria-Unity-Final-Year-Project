using UnityEngine;
using UnityEngine.UI;

public class SetImageLabel : MonoBehaviour
{
    public byte[] image = null;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (image != null)
        {
            byte[] bytes = image;
            image = null;

            Dropdown ddAction = GameObject.Find("ddAction").GetComponent<Dropdown>();
            int selectedAction = ddAction.value;
            switch (selectedAction)
            {
                //case 0: // identify
                  //  StartCoroutine(VisionAPIUtils.MakeAnalysisRequest(bytes, "image info", typeof(Text)));
                    //break;
                case 0: // Face
                    StartCoroutine(VisionAPIUtils.MakeFaceRequest(bytes, "image info", typeof(Text)));
                    break;
            }
        }
    }
}