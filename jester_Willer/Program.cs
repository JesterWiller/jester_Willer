using System;

class TicTacToeGame
{
    static void Main(string[] args)
    {
        char[,] arr = new char[,]
        {
            {'*','*','*'},
            {'*','*','*'},
            {'*','*','*'}
        };

        const int SIZE_X = 3;
        const int SIZE_Y = 3;
        const string GAMER_1_NAME = "Игрок 1";
        const string GAMER_2_NAME = "Игрок 2";
        const char X = 'x';
        const char O = 'o';
        const char DEFAULT_FIELD = '*';

        while (true) // внешний цикл для новой игры
        {
            bool game = true;
            string gamer_name = GAMER_2_NAME;
            char current_sym = X;

            while (game)
            {
                Console.WriteLine("  1 2 3");
                for (int i = 0; i < SIZE_Y; i++)
                {
                    for (int j = 0; j < SIZE_X; j++)
                    {
                        if (j == 0) Console.Write(Convert.ToString(i + 1) + " ");
                        Console.Write(arr[i, j] + " ");
                    }
                    Console.WriteLine();
                }

                if (gamer_name == GAMER_1_NAME)
                {
                    gamer_name = GAMER_2_NAME;
                    current_sym = O;
                }
                else
                {
                    gamer_name = GAMER_1_NAME;
                    current_sym = X;
                }

                bool is_not_valid_enter = false;
                do
                {
                    Console.Write(gamer_name + " - Введите координаты поля:");
                    string stroke = Console.ReadLine().ToString();
                    string[] stroke_num = stroke.Split(' ');

                    if (arr[Convert.ToInt16(stroke_num[0]) - 1,
                        Convert.ToInt16(stroke_num[1]) - 1] == DEFAULT_FIELD)
                    {
                        is_not_valid_enter = false;
                        arr[Convert.ToInt16(stroke_num[0]) - 1, Convert.ToInt16(stroke_num[1]) - 1] = current_sym;
                    }
                    else
                    {
                        Console.WriteLine("В данном поле уже присутствует символ");
                        is_not_valid_enter = true;
                    }
                } while (is_not_valid_enter);

                if (CheckWin(arr, current_sym))
                {
                    Console.WriteLine(gamer_name + " выиграл!");
                    game = false;
                }
                else if (CheckDraw(arr))
                {
                    Console.WriteLine("Ничья!");
                    game = false;
                }
            }

            Console.WriteLine("Хотите сыграть еще раз? (y/n)");
            string choice = Console.ReadLine().ToLower();
            if (choice != "y")
            {
                break; // завершаем программу
            }
            // сбрасываем игровое поле
            for (int i = 0; i < SIZE_Y; i++)
            {
                for (int j = 0; j < SIZE_X; j++)
                {
                    arr[i, j] = DEFAULT_FIELD;
                }
            }
        }
    }

    static bool CheckWin(char[,] arr, char currentSym)
    {
        for (int i = 0; i < 3; i++)
        {
            if (arr[i, 0] == currentSym && arr[i, 1] == currentSym && arr[i, 2] == currentSym) return true;
            if (arr[0, i] == currentSym && arr[1, i] == currentSym && arr[2, i] == currentSym) return true;
        }
        if (arr[0, 0] == currentSym && arr[1, 1] == currentSym && arr[2, 2] == currentSym) return true;
        if (arr[0, 2] == currentSym && arr[1, 1] == currentSym && arr[2, 0] == currentSym) return true;
        return false;
    }

    static bool CheckDraw(char[,] arr)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (arr[i, j] == '*') return false;
            }
        }
        return true;
    }
}
