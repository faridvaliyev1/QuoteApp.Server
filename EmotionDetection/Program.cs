using Microsoft.Azure.CognitiveServices.Vision.Face;
using Microsoft.Azure.CognitiveServices.Vision.Face.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace EmotionDetection
{
    class Program
    {
        static async Task Main(string[] args)
        {
           await detectEmotion(@"C:\Users\Farid\Desktop\IMG_20210106_003032.jpg");
        }

        static async Task detectEmotion(string filepath)
        {
            List<FaceAttributeType> faces = new List<FaceAttributeType>
            {
                FaceAttributeType.Emotion
            };
            using (var client = new FaceClient(
                new ApiKeyServiceClientCredentials("e579ceeb713f4d058f29a75b7ec3a21c"),
                new System.Net.Http.DelegatingHandler[] { }))
            {
                client.Endpoint = "https://emotiondetection001.cognitiveservices.azure.com/";

                using (var filestream = File.OpenRead(filepath))
                {
                    var detectionResult = await client.Face.DetectWithStreamAsync(filestream, returnFaceId: true, returnFaceAttributes: faces, returnFaceLandmarks: true);
                    foreach (var face in detectionResult)
                    {
                        Console.WriteLine(JsonConvert.SerializeObject(face.FaceAttributes.Emotion));
                        var highestEmotion = getEmotion(face.FaceAttributes.Emotion);
                        Console.WriteLine($"This face has emotional traits of {highestEmotion.Emotion} ({highestEmotion.Value} confidence).");
                    }
                }
            }
        }

        static (string Emotion, double Value) getEmotion(Emotion emotion)
        {
            var emotionProperties = emotion.GetType().GetProperties();
            (string Emotion, double Value) highestEmotion = ("Anger", emotion.Anger);
            foreach (var e in emotionProperties)
            {
                if (((double)e.GetValue(emotion, null)) > highestEmotion.Value)
                {
                    highestEmotion.Emotion = e.Name;
                    highestEmotion.Value = (double)e.GetValue(emotion, null);
                }
            }
            return highestEmotion;
        }
    }
}

