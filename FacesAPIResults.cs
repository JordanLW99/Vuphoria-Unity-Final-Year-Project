using System.Collections.Generic;

[System.Serializable]
public class FacesAPIResults
{
    public string faceId;
    public FaceRectangle faceRectangle;
    public FaceAttributes faceAttributes;

    override
    public string ToString()
    {
        string text = "Age: " + faceAttributes.age + ", Gender: " + faceAttributes.gender +
                        ", Emotion: (Anger: " + faceAttributes.emotion.anger +
                        ", Contempt: " + faceAttributes.emotion.contempt +
                        ", Disgust: " + faceAttributes.emotion.disgust +
                        ", Fear: " + faceAttributes.emotion.fear +
                        ", Happiness: " + faceAttributes.emotion.happiness +
                        ", Neutral: " + faceAttributes.emotion.neutral +
                        ", Sadness: " + faceAttributes.emotion.sadness +
                        ", Surprise: " + faceAttributes.emotion.surprise + ")";
        return text;
    }
}

[System.Serializable]
public class FaceRectangle
{
    public float top;
    public float left;
    public float width;
    public float height;
}

[System.Serializable]
public class FaceAttributes
{
    public string gender;
    public float age;
    public Emotion emotion;
}

[System.Serializable]
public class Emotion
{
    public float anger;
    public float contempt;
    public float disgust;
    public float fear;
    public float happiness;
    public float neutral;
    public float sadness;
    public float surprise;
}