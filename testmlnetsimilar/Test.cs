using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testmlnetsimilar
{
    public class Test
    {
        public static double CalculateCosineSimilarity(float[] vector1, float[] vector2)
        {
            double dotProduct = 0.0;
            double magnitude1 = 0.0;
            double magnitude2 = 0.0;
            for (int i = 0; i < vector1.Length; i++)
            {
                dotProduct += vector1[i] * vector2[i];
                magnitude1 += Math.Pow(vector1[i], 2);
                magnitude2 += Math.Pow(vector2[i], 2);
            }
            magnitude1 = Math.Sqrt(magnitude1);
            magnitude2 = Math.Sqrt(magnitude2);
            if (magnitude1 == 0.0 || magnitude2 == 0.0)
                return 0.0;
            else
                return dotProduct / (magnitude1 * magnitude2);
        }
    }
}
