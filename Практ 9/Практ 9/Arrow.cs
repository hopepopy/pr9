namespace Практ_9
{
    internal class Arrow
    {
        public int current = 0;
        private int max;
        private int min;

        public Arrow(int min, int max)
        {
            this.min = min;
            this.max = max;
            current = this.min;
            Print();
        }
        private void Print(int? previous = null)
        {
            if (previous == current)
            {
                return;
            }

            if (previous != null)
            {
                Console.SetCursorPosition(0, (int)previous);
                Console.WriteLine("  ");
            }
            Console.SetCursorPosition(0, current);
            Console.WriteLine("->");
            int viewPosition = Math.Max(current - min, 0);
            Console.SetCursorPosition(0, viewPosition);
        }
        public void Next()
        {
            int previous = current;
            current += 1;
            current = current > max ? min : current;
            Print(previous);
        }
        public void Back()
        {
            int previous = current;
            current -= 1;
            current = current < min ? max : current;
            Print(previous);
        }
        public int GetIndex()
        {
            return current - min;
        }
    }
}
