using Core.Constants;
using Core.Entities;
using Core.Helpers;
using Data.Repos.Actual;
using Presentation.Services;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Presentation
{
    public static class Program
    {
        private readonly static GroupService _groupService;

        static Program()
        {
            _groupService = new GroupService();
        }

        static void Main()
        {
            while (true)
            {
               MainMenuCheck: ConsoleHelper.WriteWithColor(" __        __   _                          \r\n \\ \\      / /__| | ___ ___  _ __ ___   ___ \r\n  \\ \\ /\\ / / _ \\ |/ __/ _ \\| '_ ` _ \\ / _ \\\r\n   \\ V  V /  __/ | (_| (_) | | | | | |  __/\r\n    \\_/\\_/ \\___|_|\\___\\___/|_| |_| |_|\\___|\r\n                                           ", ConsoleColor.Yellow);
                ConsoleHelper.WriteWithColor("[1] Personnel", ConsoleColor.Cyan);
                ConsoleHelper.WriteWithColor("[2] Students", ConsoleColor.Cyan);
                ConsoleHelper.WriteWithColor("[3] Groups", ConsoleColor.Cyan);
                ConsoleHelper.WriteWithColor("[0] Terminate Session", ConsoleColor.Cyan);

                int num;
                bool isRightInput = int.TryParse(Console.ReadLine(), out num);
                if (!isRightInput || 0 > num || num > 3)
                {
                    Console.Clear();
                    ConsoleHelper.WriteWithColor("Wrong input!\nPlease select valid operation type.\n From 0 to 3", ConsoleColor.Red);
                }
                else
                {
                    switch (num)
                    {
                        case (int)BaseOptions.Teminate:
                            Console.Clear();
                        TerminateCheck: ConsoleHelper.WriteWithColor("Are you sure you want to Terminate session? y/n", ConsoleColor.Red);
                            char dec;
                            isRightInput = char.TryParse(Console.ReadLine().ToLower(), out dec);
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
                            {
                                return;
                            }
                            else
                            {
                                break;
                            }
                        case (int)BaseOptions.Personnel:
                            break;
                        case (int)BaseOptions.Students:
                            break;
                        case (int)BaseOptions.Groups:
                            while (true)
                            {
                                GroupRepos _groupRepos = new GroupRepos();
                                Console.Clear();

                                ConsoleHelper.WriteWithColor("", ConsoleColor.Yellow);
                                ConsoleHelper.WriteWithColor("[1] Create New Group", ConsoleColor.Cyan);
                                ConsoleHelper.WriteWithColor("[2] Update Group", ConsoleColor.Cyan);
                                ConsoleHelper.WriteWithColor("[3] Delete Group", ConsoleColor.Cyan);
                                ConsoleHelper.WriteWithColor("[4] Show All Saved Groups ", ConsoleColor.Cyan);
                                ConsoleHelper.WriteWithColor("[5] Find Group By Name", ConsoleColor.Cyan);
                                ConsoleHelper.WriteWithColor("[6] Find Group By ID", ConsoleColor.Cyan);
                                ConsoleHelper.WriteWithColor("[0] Terminate Session", ConsoleColor.Cyan);
                                ConsoleHelper.WriteWithColor("Please Select Operation", ConsoleColor.Yellow);

                                int input;
                                isRightInput = int.TryParse(Console.ReadLine(), out input);
                                if (!isRightInput || 0 > input || input > 6)
                                {
                                    Console.Clear();
                                    ConsoleHelper.WriteWithColor("Wrong input!\nPlease select valid operation type.\n From 0 to 6", ConsoleColor.Red);
                                }
                                else
                                {
                                    switch (input)
                                    {
                                        case (int)GroupOptions.MainMenu:

                                            if (_groupService.Exit() == true)
                                            {
                                                goto MainMenuCheck;
                                            }
                                            else
                                            {
                                                break;

                                            }
                                        case (int)GroupOptions.AddGroup:
                                            _groupService.Create();
                                            break;

                                        case (int)GroupOptions.UpdateGroup:
                                            _groupService.Update();
                                            break;

                                        case (int)GroupOptions.RemoveGroup:
                                            _groupService.Remove();
                                            break;

                                        case (int)GroupOptions.GetAllGroups:
                                            _groupService.GetAll();
                                            break;

                                        case (int)GroupOptions.FindGroupByName:
                                            _groupService.GetGroupByName();
                                            break;

                                        case (int)GroupOptions.FindGroupById:
                                            _groupService.GetGroupById();
                                            break;

                                        default:
                                            break;
                                    }
                                }

                            }
                        default:
                            break;
                    }
                }

            }
        }
    }
}