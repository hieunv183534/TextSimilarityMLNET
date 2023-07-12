// See https://aka.ms/new-console-template for more information
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Transforms.Text;
using testmlnetsimilar;


// Tạo một instance của MLContext
var mlContext = new MLContext();

// Dữ liệu câu mẫu
string sentence1 = "Chuyên nghiệp, Hòa đồng, Tỉ mỉ, Tốt bụng, Trung thực";
string sentence2 = "Tỉ bụng , Chăm đồng , Chỉnh chu, Dễ gần, Nghiêm túc";

// Tạo một IDataView chứa dữ liệu mẫu
var dataView = mlContext.Data.LoadFromEnumerable(new[] { new SentenceData { Sentence = sentence1 }, new SentenceData { Sentence = sentence2 } });

// Định nghĩa TextFeaturizingEstimator
var textFeaturizer = mlContext.Transforms.Text.FeaturizeText("Features", new TextFeaturizingEstimator.Options
{
    OutputTokensColumnName = "Tokens"
}, "Sentence");

// Fit và transform dữ liệu
var transformedData = textFeaturizer.Fit(dataView).Transform(dataView);

// Lấy giá trị đặc trưng của các câu
var features = mlContext.Data.CreateEnumerable<FeatureData>(transformedData, reuseRowObject: false);

// Lấy đặc trưng của câu 1 và câu 2
var feature1 = features.ElementAt(0).Features;
var feature2 = features.ElementAt(1).Features;

// Tính toán độ tương đồng sử dụng Cosine Similarity
var cosineSimilarity = Test.CalculateCosineSimilarity(feature1, feature2);

Console.WriteLine($"Cosine Similarity: {cosineSimilarity}");

public class SentenceData
{
    public string Sentence { get; set; }
}

public class FeatureData
{
    public float[] Features { get; set; }
}

