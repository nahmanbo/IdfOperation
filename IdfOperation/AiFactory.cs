using System.Text;
using System.Text.Json;
using IdfOperation;

public static class AiFactory
{
    //==============================================================

    //--------------------------------------------------------------
    public static async Task<string> RequestOpenAI(string prompt)
    {
        HttpClient client = new HttpClient();

        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Secrets.OpenAIKey}");

        var body = new
        {
            model = "gpt-4",
            messages = new[]
            {
                new { role = "user", content = prompt }
            }
        };

        string jsonRequest = JsonSerializer.Serialize(body);
        var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

        HttpResponseMessage response = await client.PostAsync("https://api.openai.com/v1/chat/completions", content);

        string jsonResponse = await response.Content.ReadAsStringAsync();

        using JsonDocument doc = JsonDocument.Parse(jsonResponse);
        string contentText = doc.RootElement.GetProperty("choices")[0].GetProperty("message").GetProperty("content").GetString()!;

        return contentText;
    }
}