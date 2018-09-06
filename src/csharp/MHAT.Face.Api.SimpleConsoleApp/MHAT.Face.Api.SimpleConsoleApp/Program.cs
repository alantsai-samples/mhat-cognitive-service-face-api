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
        static void Main(string[] args)
        {
            var subscriptionKey = "";
            var enpointUrl = "https://eastasia.api.cognitive.microsoft.com/face/v1.0";

            var client = new FaceServiceClient(subscriptionKey, enpointUrl);
        }
    }
}
