using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Helpers;
using Data.Repos.Actual;

namespace Presentation.Services
{
    internal class BaseService
    {
        public bool Termin()
        {
            Console.Clear();
        TerminateCheck: ConsoleHelper.WriteWithColor("Are you sure you want to Terminate session? y/n", ConsoleColor.Red);
            char dec;
            bool isRightInput = char.TryParse(Console.ReadLine().ToLower(), out dec);
            if (!isRightInput)
            {
                Console.Clear();
                ConsoleHelper.WriteWithColor("Wrong input!\n Press <y> to Terminate session or press <n> to continue using the app", ConsoleColor.Red);
                goto TerminateCheck;
            }

            if (!(dec == 'y' || dec == 'n'))
            {
                Console.Clear();
                ConsoleHelper.WriteWithColor("Press <y> to Terminate session or press <n> to continue using the app!", ConsoleColor.Red);
                goto TerminateCheck;
            }
            else if (dec == 'y')

            { return true; }
            else
            { return false; }
        }
    }
}
