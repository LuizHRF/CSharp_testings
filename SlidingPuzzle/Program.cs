using SlidingPuzzle.Classes;

// Corrijir o contador de movimentos
// Adicionar uma opçao de resetar o jogo
// Adicionar uma opçao de sair do jogo
// Adicionar salvamento de jogos antigos
// Adicionar uma opçao de escolher o tamanho do tabuleiro
namespace SlidingPuzzle
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            List<Plate> plates = new();
            Plate plate = new(1);
            

            plates.Add(plate);
        
            Console.WriteLine("Bem vindo ao puzzle de deslizar!");
            Console.WriteLine("Use as setas do seu teclado para mover o espaço vazio");
            Console.WriteLine("Pressione ESPAÇO para começar");
            Console.ResetColor();

            while(true){
                ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);
                if (keyInfo.Key == ConsoleKey.Spacebar)
                {
                    Console.Clear();
                    break;
                }
            }

            plate.Show();

            while(true){
                
                
                ConsoleKeyInfo movement = Console.ReadKey(intercept: true);
                Console.Clear();
                
                Plate p2 = plate.Move((int)movement.Key);

                if (p2 != plate){
                    plates.Add(p2);
                    plate = p2;
                }

                if (Plate.over(plate)){
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Você venceu!");
                    Console.ResetColor();
                    plates.Last().Show();
                    Console.WriteLine("With " + (plates.Count - 1) + " movements");
                    break;
                }

                plates.Last().Show();
                
            }
        }

    }
}