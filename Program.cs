using System;

namespace Mafia
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var app = new MafiaApplication(new string[0]))
            {
                app.Run();
            }
        }
    }
}
