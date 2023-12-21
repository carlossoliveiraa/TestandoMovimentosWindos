internal class Program
{
    private static void Main(string[] args)
    {
        double num = 0;
        Random randNum = new Random();
        while (true)
        {
            num++;
            Thread.Sleep(25000);
         
            Console.WriteLine($"Verificando PC... Analise número: {num}");
            MouseOperations.SetCursorPosition(randNum.Next(100), randNum.Next(100));
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown | MouseOperations.MouseEventFlags.LeftUp);
        }
    }
}