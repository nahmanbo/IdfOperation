using IdfOperation.BadGuys;
using IdfOperation.GoodGuys;

namespace IdfOperation
{
    class Program
    {
        static void Main()
        {
            Hamas hamas = new Hamas("Yahya Sinwar");
            Idf idf = new Idf("Eyal Zamir");
            OperationManager operation = new OperationManager(idf, hamas);
        }
    }
}