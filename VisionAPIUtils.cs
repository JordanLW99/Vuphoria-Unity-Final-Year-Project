using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class VisionAPIUtils
{
    public static bool filedone;
    //static FacesAPIResults results;
    static string filename = Application.streamingAssetsPath + "/jsonresults.txt";

    const string VISION_API_SUBSCRIPTION_KEY = "7b51acd6dc3b44379871fe92b112e45a";
    const string VISION_API_BASE_URL = "YOUR_BASE_URL";

    const string FACES_API_SUBSCRIPTION_KEY = "7b51acd6dc3b44379871fe92b112e45a";
    const string FACES_API_BASE_URL = "https://uksouth.api.cognitive.microsoft.com/face/v1.0/";

    public static IEnumerator MakeAnalysisRequest(string imageFilePath, string textComponent, Type type)
    {
        byte[] bytes = ImageUtils.GetImageAsByteArray(imageFilePath);
        return MakeAnalysisRequest(bytes, textComponent, type);
    }

    public static IEnumerator MakeAnalysisRequest(byte[] bytes, string textComponent, Type type)
    {
        var headers = new Dictionary<string, string>() {
            {"Ocp-Apim-Subscription-Key", VISION_API_SUBSCRIPTION_KEY },
            {"Content-Type","application/octet-stream"}
        };
        string requestParameters = "visualFeatures=Description&language=en";
        string uri = VISION_API_BASE_URL + "/vision/v1.0/analyze?" + requestParameters;
        if ((bytes != null) && (bytes.Length > 0))
        {
            WWW www = new WWW(uri, bytes, headers);
            yield return www;

            if (www.error != null)
            {
                TextUtils.setText(www.error, textComponent, type);
            }
            else
            {
                VisionAPIResults results = JsonUtility.FromJson<VisionAPIResults>(www.text);
                TextUtils.setText(results.ToString(), textComponent, type);
            }
        }
    }

    public static IEnumerator MakeFaceRequest(byte[] bytes, string textComponent, Type type)
    {
        var headers = new Dictionary<string, string>() {
         {"Ocp-Apim-Subscription-Key", FACES_API_SUBSCRIPTION_KEY },
         {"Content-Type","application/octet-stream"}
     };
        string requestParameters = "returnFaceAttributes=age,gender,emotion";
        string uri = FACES_API_BASE_URL + "/detect?" + requestParameters;

        if ((bytes != null) && (bytes.Length > 0))
        {
            WWW www = new WWW(uri, bytes, headers);
            yield return www;

            if (www.error != null)
            {
                TextUtils.setText(www.error, textComponent, type);
            }
            else
            {
                string json = www.text.TrimStart('[').TrimEnd(']');
                FacesAPIResults results = JsonUtility.FromJson<FacesAPIResults>(json);
                //TextUtils.setText(results.ToString(), textComponent, type);
                string jsonData = JsonUtility.ToJson(results, true);
                File.AppendAllText(filename, jsonData);
                filedone = true;
            }
        }
    }
}