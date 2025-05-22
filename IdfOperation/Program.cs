namespace IdfOperation; 
class Program
{
    static void Main(string[] args)
    {
        Hamas hamas = new Hamas("Yahya Sinwar");
        hamas.PrintInfo();
        
        IDF idf = new IDF("Eyal Zamir");
        idf.PrintInfo();
    }
}