using System.Text.Json;
using IdfOperation.Factory;
using IdfOperation;


namespace IdfOperation.BadGuys
{
    public static class TerroristGenerator
    {
        

        //==============================================================
        public static async Task<List<Terrorist>> Generate(int count)
        {
            Console.WriteLine("📡 Requesting terrorist data from OpenAI...");

            try
            {

                string prompt = Constants.Prompts.Terrorist + count;
                
                string json = await AiFactory.RequestOpenAi(prompt);
                Console.WriteLine(json);
                
                var terrorists = JsonSerializer.Deserialize<List<Terrorist>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (terrorists == null)
                    throw new Exception("OpenAI returned null or empty array.");

                return terrorists;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"⚠️ Failed to parse terrorists: {ex.Message}");
                return new List<Terrorist>();
            }
        }



    }
}