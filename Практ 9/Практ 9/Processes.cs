using System.Diagnostics;

namespace Практ_9
{
    internal class Processes
    {
        public static Process? SelectProcess()
        {
            Console.Clear();
            Console.WriteLine("Список процессов");
            Console.WriteLine();

            Process[] processes = Process.GetProcesses();

            
            
            foreach (Process process in processes)
            {
                double memory = Math.Round(process.PrivateMemorySize64 / 1000000d, 2);
                Console.WriteLine($"  {process.Id}\t| {process.ProcessName}\t\t| {memory}MB");
            }

            Arrow arrow = new Arrow(2, processes.Length + 1);
            ConsoleKeyInfo key = Console.ReadKey(true);
            while (key.Key != ConsoleKey.Escape)
            {
                switch (key.Key)
                {
                    case ConsoleKey.DownArrow:
                        arrow.Next();
                        break;
                    case ConsoleKey.UpArrow:
                        arrow.Back();
                        break;
                    case ConsoleKey.Enter:
                        int index = arrow.GetIndex();
                        return processes[index];
                }
                key = Console.ReadKey(true);
            }
            return null;
        }
        public static void Info(Process process)
        {
            Console.Clear();
            Console.WriteLine($"Информация о процессе {process.ProcessName}");
            Console.WriteLine();
        
            try
            {
                TimeSpan time = DateTime.Now - process.StartTime;
                Console.WriteLine($"Время с запуска: {time}");
                Console.WriteLine($"Время процессора: {process.TotalProcessorTime}");
                Console.WriteLine($"Приоритет: {process.BasePriority}");
                Console.WriteLine($"Класс приоритета: {process.PriorityClass}");
            }
            catch
            {
                Console.WriteLine("Ошибка получения информации. Отказано в доступе.");
            }
            finally
            {
                Console.WriteLine();
                Console.WriteLine("D - завершить процесс");
                Console.WriteLine("Del - завершить все процессы с этим именем");
            }


            ConsoleKeyInfo key = Console.ReadKey(true);
            while (key.Key != ConsoleKey.Backspace)
            {
                switch (key.Key)
                {
                    case ConsoleKey.D:
                        try
                        {
                            process.Kill();
                            return;
                        } 
                        catch
                        {
                            int line = Console.CursorTop;
                            Console.SetCursorPosition(0, line + 1);
                            Console.WriteLine("D   Отказано в доступе.");
                            Console.SetCursorPosition(0, line);
                        }
                        break;
                    case ConsoleKey.Delete:
                        Process[] processes = Process.GetProcessesByName(process.ProcessName);
                        try
                        {
                            foreach (Process proc in processes)
                            {
                                proc.Kill();
                            }
                            return;
                        }
                        catch
                        {
                            int line = Console.CursorTop;
                            Console.SetCursorPosition(0, line + 1);
                            Console.WriteLine("Del Отказано в доступе.");
                            Console.SetCursorPosition(0, line);
                        }
                        break;
                }
                key = Console.ReadKey(true);
            }
        }
    }
}
