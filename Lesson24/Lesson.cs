using System;

namespace Lesson24
{
    class Lesson
    {
        public string Name { get; }
        public DateTime Begin { get; private set; }

        public event EventHandler<DateTime> Started;

        public Lesson(string name)
        {
            // Проверка входных аргументов.

            Name = name;
        }

        public void Start()
        {
            Begin = DateTime.Now;
            Started?.Invoke(this, Begin);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
