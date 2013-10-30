using System;

namespace ZombieTD
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (ZombieTDGame game = new ZombieTDGame())
            {
              game.Run();

              
            }
        }
    }
#endif
}

