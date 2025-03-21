
namespace SlidingPuzzle.Classes
{

    public class Plate
    {
        public int GameID { get; set; }
        public int[,] CurrentState { get; set; } = new int[3, 3];
        public (int i, int j) EmptyPosition { get; set; }
        public void Shuffle()
        {
            int[] flatArray = new int[9];
            int counter = 1;
            for (int i = 0; i < 8; i++)
            {
                flatArray[i] = counter++;
            }
            flatArray[8] = 0;

            Random random = new Random();
            for (int i = flatArray.Length - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                (flatArray[i], flatArray[j]) = (flatArray[j], flatArray[i]);
            }

            counter = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    CurrentState[i, j] = flatArray[counter++];
                    if (CurrentState[i, j] == 0)
                    {
                        EmptyPosition = (i,j);
                    }
                }
            }

            // CurrentState = new int[3, 3]{
            //     {1, 2, 3},
            //     {4, 5, 6},
            //     {0, 7, 8}
            // };
            // EmptyPosition = (2, 0);
        
        }

        public Plate(int gameID)
        {
            GameID = gameID;
            Shuffle();
        }

        public Plate Move(int Action){
            
            try{
                switch(Action){
                    case (int)ConsoleKey.UpArrow:  //CIMA
                        
                        if(EmptyPosition.i == 0){
                            throw new IndexOutOfRangeException();
                        }

                        int t1 = CurrentState[EmptyPosition.i - 1, EmptyPosition.j];
                        CurrentState[EmptyPosition.i - 1, EmptyPosition.j] = 0;
                        CurrentState[EmptyPosition.i, EmptyPosition.j] = t1;
                        EmptyPosition = (EmptyPosition.i - 1, EmptyPosition.j);

                        return this;

                    case (int)ConsoleKey.DownArrow: //BAIXO

                        if(EmptyPosition.i == 2){
                            throw new IndexOutOfRangeException();
                        }
                        
                        int t2 = CurrentState[EmptyPosition.i + 1, EmptyPosition.j];
                        CurrentState[EmptyPosition.i + 1, EmptyPosition.j] = 0;
                        CurrentState[EmptyPosition.i, EmptyPosition.j] = t2;
                        EmptyPosition = (EmptyPosition.i + 1, EmptyPosition.j);
                        return this;

                    case (int)ConsoleKey.LeftArrow: //ESQUERDA

                        if(EmptyPosition.j == 0){
                            throw new IndexOutOfRangeException();
                        }
                        
                        int t3 = CurrentState[EmptyPosition.i, EmptyPosition.j - 1 ];
                        CurrentState[EmptyPosition.i, EmptyPosition.j - 1] = 0;
                        CurrentState[EmptyPosition.i, EmptyPosition.j] = t3;
                        EmptyPosition = (EmptyPosition.i, EmptyPosition.j - 1);
                        return this;

                    case (int)ConsoleKey.RightArrow:  //DIREITA

                        if(EmptyPosition.j == 2){
                            throw new IndexOutOfRangeException();
                        }

                        int t4 = CurrentState[EmptyPosition.i, EmptyPosition.j + 1 ];
                        CurrentState[EmptyPosition.i, EmptyPosition.j + 1] = 0;
                        CurrentState[EmptyPosition.i, EmptyPosition.j] = t4;
                        EmptyPosition = (EmptyPosition.i, EmptyPosition.j + 1);
                        return this;

                    default:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Tecla inválida");
                        Console.ResetColor();
                        return this;

                }

            }  catch (IndexOutOfRangeException){

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Movimento inválido");
                Console.ResetColor();
                return this;
            } 
        }

        public void Show(){

            //Console.WriteLine("Game ID: " + GameID);

            Console.WriteLine("\n");
            Console.WriteLine(" _______");

            for (int i = 0; i < 3; i++)
            {

                Console.Write("| ");
                for (int j = 0; j < 3; j++)
                {
                    if(CurrentState[i, j] == 0){
                        Console.Write("  ");
                    } else {
                        Console.Write(CurrentState[i, j] + " ");
                    }
                }
                Console.Write("|");
                if (i != 2){
                    Console.WriteLine();
                }
            }
            Console.WriteLine("\n¨¨¨¨¨¨¨¨¨");

        }

        public static bool over(Plate p){
            int[,] finalState = new int[3, 3]{
                {1, 2, 3},
                {4, 5, 6},
                {7, 8, 0}
            };

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if(p.CurrentState[i, j] != finalState[i, j]){
                        return false;
                    }
                }
            }
            return true;
        }

    }
    
}