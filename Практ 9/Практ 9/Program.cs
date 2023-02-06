using System.Diagnostics;

namespace Практ_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Process? process = Processes.SelectProcess();
                if (process == null)
                {
                    break;
                }
                Processes.Info(process);
            }
        }
    }
}