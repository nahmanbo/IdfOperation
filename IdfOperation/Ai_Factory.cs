
using System.Text.Json;
using System.Text;
using IdfOperation;


public static class Ai_Factory
{
   
   public static string Prompt_terrorist = "החזר לי אובייקט JSON בלבד, ללא טקסט נוסף, שמכיל את השדות הבאים:\r\n- Name (string) -שם פרטי ומשפחה מוסלמי אבל לא מוחמד \r\n- Rank (int)\r\n -IsAlive (true)\r\n- Weapons (string[]) בין 1 ל4 מהנשקים הבאים: Rifle, knife, grenade \r\n\r\nדוגמה תקנית של JSON בלבד, כדי שאוכל להמיר אותו ישירות ל־Dictionary בשפת #C. אל תכתוב שום דבר נוסף – רק האובייקט עצמו.\r\n";

    //-------------------------------------------------------------
    public static async Task<string> RequestOpenAI(string Prompt )
    {

        HttpClient client = new HttpClient();

        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Secrets.OpenAIKey}");

        var Body = new
        {
            model = "gpt-4",
            messages = new[]
        {
                new { role = "user", content = Prompt }
            }
        };

        string jsonRequest =JsonSerializer.Serialize(Body);
        var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

        HttpResponseMessage response = await client.PostAsync("https://api.openai.com/v1/chat/completions", content);

        string jsonResponse = await response.Content.ReadAsStringAsync();

        using JsonDocument doc = JsonDocument.Parse(jsonResponse);
        string contentText = doc.RootElement
            .GetProperty("choices")[0]
            .GetProperty("message")
            .GetProperty("content")
            .GetString()!;

        return contentText;
    }
}