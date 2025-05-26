using System.Text.Json;

namespace IdfOperation
{
    public static class TerroristGenerator
    {
        public static string Prompt_terrorist = 
            "החזר לי אובייקט JSON בלבד, ללא טקסט נוסף, שמכיל את השדות הבאים:\r\n" +
            "- Name (string) -שם פרטי ושם משפחה מוסלמים/חמאס מגוונים שלא יהיו רובם עם אותו שם   \r\n" +
            "- Id (int) - מספר רנדומל בן 6 ספרות"+
            "- Rank (int)\r\n" +
            "- IsAlive (true)\r\n" +
            "- Weapons (string[]) בין 1 ל4 מהנשקים הבאים: Knife, Gun, M16, AK47 \r\n\r\n" +
            "דוגמה תקנית של JSON בלבד, כדי שאוכל להמיר אותו ישירות ל־Dictionary בשפת #C. " +
            "אל תכתוב שום דבר נוסף – רק האובייקט עצמו.";

        public static async Task<List<Terrorist>> Generate(int count)
        {
            List<Terrorist> terrorists = new();

            for (int i = 0; i < count; i++)
            {
                string json = await AiFactory.RequestOpenAI(Prompt_terrorist);

                try
                {
                    Console.WriteLine($"📦 Terrorist #{i + 1} JSON:\n{json}");

                    var terrorist = JsonSerializer.Deserialize<Terrorist>(json, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    if (terrorist != null)
                        terrorists.Add(terrorist);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"⚠️ Failed to parse terrorist #{i + 1}: {ex.Message}");
                }
            }

            return terrorists;
        }
    }
}