using Microsoft.ProjectOxford.Face;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHAT.Face.Api.SimpleConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var subscriptionKey = "";
            var enpointUrl = "https://eastasia.api.cognitive.microsoft.com/face/v1.0";

            var imageUrl = "https://raw.githubusercontent.com/Microsoft/Cognitive-Face-Windows/master/Data/detection1.jpg";

            var faceAttr = new[] { FaceAttributeType.Age, FaceAttributeType.Gender, FaceAttributeType.Emotion };

            var client = new FaceServiceClient(subscriptionKey, enpointUrl);

            var faces = await client.DetectAsync(imageUrl, returnFaceAttributes: faceAttr);

            Console.WriteLine($"這張圖片有以下幾個人臉被識別出來：");

            foreach (var item in faces)
            {
                Console.WriteLine($"\t 人物：{item.FaceId} \t 開心程度：{item.FaceAttributes.Emotion.Happiness} " +
                    $"\t 年齡：{item.FaceAttributes.Age} \t 性別：{item.FaceAttributes.Gender}");
            }

            var imageUrl2 = "https://raw.githubusercontent.com/Microsoft/" +
                "Cognitive-Face-Windows/master/Data/" +
                "PersonGroup/Family2-Lady/Family2-Lady2.jpg";

            var faces2 = await client.DetectAsync(imageUrl2, returnFaceAttributes: faceAttr);

            Console.WriteLine($"這張圖片2有以下幾個人臉被識別出來：");

            foreach (var item in faces2)
            {
                Console.WriteLine($"\t 人物：{item.FaceId} " +
                    $"\t 開心程度：{item.FaceAttributes.Emotion.Happiness} " +
                    $"\t 年齡：{item.FaceAttributes.Age} " +
                    $"\t 性別：{item.FaceAttributes.Gender}");
            }

            var verifyResult = await client.VerifyAsync(faces.First().FaceId, faces2.First().FaceId);

            Console.WriteLine($"2張圖片的第一個人臉識別結果為：{Environment.NewLine} " +
                $"\n 是否同一人：{verifyResult.IsIdentical} {Environment.NewLine} " +
                $"\n 信心指數：{verifyResult.Confidence}");

            Console.ReadLine();
        }
    }
}
