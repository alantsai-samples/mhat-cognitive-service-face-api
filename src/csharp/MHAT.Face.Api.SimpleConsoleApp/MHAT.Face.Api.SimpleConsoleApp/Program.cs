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
        }
    }
}
