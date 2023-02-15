using Core.Constants;
using Core.Entities;
using Core.Helpers;
using Data.Repos.Actual;
using System.Globalization;

namespace Pesentation
{
    public static class Program
    {
        static void Main()
        {
            while (true)
            {
                GroupRepos _groupRepos = new GroupRepos();

                ConsoleHelper.WriteWithColor("////---Welocome User---\\\\\\\\\n", ConsoleColor.Yellow);

                ConsoleHelper.WriteWithColor("[1] Create New Group", ConsoleColor.Cyan);
                ConsoleHelper.WriteWithColor("[2] Update Group", ConsoleColor.Cyan);
                ConsoleHelper.WriteWithColor("[3] Delete Group", ConsoleColor.Cyan);
                ConsoleHelper.WriteWithColor("[4] Show All Saved Groups ", ConsoleColor.Cyan);
                ConsoleHelper.WriteWithColor("[5] Find Group By Name", ConsoleColor.Cyan);
                ConsoleHelper.WriteWithColor("[6] Find Group By ID", ConsoleColor.Cyan);
                ConsoleHelper.WriteWithColor("[0] Terminate Session", ConsoleColor.Cyan);

                ConsoleHelper.WriteWithColor("Please Select Operation", ConsoleColor.Yellow);

                int num;
                bool isRightInput = int.TryParse(Console.ReadLine(), out num);
                if (!isRightInput)
                {
                    ConsoleHelper.WriteWithColor("Wrong input!\nPlease select operation type again\n", ConsoleColor.Red);
                }
                else
                {
                    switch (num)
                    {
                        case (int)GroupOptions.AddGroup:
                            ConsoleHelper.WriteWithColor(">> Enter group name >>", ConsoleColor.DarkCyan);
                            string name = Console.ReadLine();

                            int maxSize;
                        MaxSizeCheck: ConsoleHelper.WriteWithColor(">> Enter max capacity of group >>", ConsoleColor.DarkCyan);
                            isRightInput = int.TryParse(Console.ReadLine(), out maxSize);
                            if (!isRightInput)
                            {
                                ConsoleHelper.WriteWithColor("Wrong input detected!\nPlease try again\n", ConsoleColor.Red);
                                goto MaxSizeCheck;
                            }
                            if (maxSize > 18)
                            {
                                ConsoleHelper.WriteWithColor("Group Size Shouldn't exceed 18\nEnter valid group size\n", ConsoleColor.Red);
                                goto MaxSizeCheck;
                            }

                            DateTime startDate;
                        StartDateCheck: ConsoleHelper.WriteWithColor(">> Enter Start Date of Group >>", ConsoleColor.DarkCyan);
                            isRightInput = DateTime.TryParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out startDate);
                            if (!isRightInput)
                            {
                                ConsoleHelper.WriteWithColor("Wrong input format!\nEnter date in [dd.MM.yyyy] format\n", ConsoleColor.Red);
                                goto StartDateCheck;
                            }

                            DateTime originDate = new DateTime(1861, 4, 1);
                            if (startDate < originDate)
                            {
                                ConsoleHelper.WriteWithColor("Start date of group cannot be set before establishment date of college!\nPlease enter valid date\n", ConsoleColor.Red);
                                goto StartDateCheck;
                            }

                            DateTime endDate;
                        EndDateCheck: ConsoleHelper.WriteWithColor(">> Enter End Date of Group >>", ConsoleColor.DarkCyan);
                            isRightInput = DateTime.TryParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out endDate);
                            if (!isRightInput)
                            {
                                ConsoleHelper.WriteWithColor("Wrong input format\nEnter date in [dd.MM.yyyy] format", ConsoleColor.Red);
                                goto EndDateCheck;
                            }
                            if (startDate > endDate)
                            {
                                ConsoleHelper.WriteWithColor("End date cannot be set before start date!\nPlease enter valid date\n", ConsoleColor.Red);
                                goto EndDateCheck;
                            }

                            var group = new Group
                            {
                                Name = name,
                                MaxSize = maxSize,
                                StartDate = startDate,
                                EndDate = endDate,
                            };
                            _groupRepos.Add(group);
                            ConsoleHelper.WriteWithColor($"//// Group created successfully ////\n Name : {group.Name}\n Max Capacity : {group.MaxSize}\n Start Date : {group.StartDate.ToShortDateString()}\n End Date : {group.EndDate.ToShortDateString()}\n", ConsoleColor.Green);

                            break;
                        case (int)GroupOptions.UpdateGroup:
                            break;

                        case (int)GroupOptions.RemoveGroup:

                            var groups = _groupRepos.GetAll();

                            foreach (var group_ in groups)
                            {
                                ConsoleHelper.WriteWithColor($" ID : {group_.Id}\n Name : {group_.Name}\n Max Capacity : {group_.MaxSize}\n Start Date : {group_.StartDate.ToShortDateString()}\n End Date : {group_.EndDate.ToShortDateString()}\n", ConsoleColor.Blue);
                            }

                        IDCheck: ConsoleHelper.WriteWithColor(">> Enter gorup ID that you want to remove >>", ConsoleColor.DarkCyan);
                            int id;
                            isRightInput = int.TryParse(Console.ReadLine(), out id);
                            if(!isRightInput)
                            {
                                ConsoleHelper.WriteWithColor("Wrong input format!\n Please enter ID again\n",ConsoleColor.Red);
                                goto IDCheck;
                            }
                            var dbGroup = _groupRepos.Get(id);
                            if (dbGroup is null)
                            {
                                ConsoleHelper.WriteWithColor("There is no group with this ID number\n Please enter valid ID number\n",ConsoleColor.Red);
                                goto IDCheck;
                            }
                            else
                            {
                                _groupRepos.Delete(dbGroup);
                                ConsoleHelper.WriteWithColor("Group successfully deleted!", ConsoleColor.Green);

                            }
                            break;
                        case (int)GroupOptions.GetAllGroups:
                            var groupss = _groupRepos.GetAll();
                            foreach (var group_ in groupss)
                            {
                                ConsoleHelper.WriteWithColor($" ID : {group_.Id}\n Name : {group_.Name}\n Max Capacity : {group_.MaxSize}\n Start Date : {group_.StartDate.ToShortDateString()}\n End Date : {group_.EndDate.ToShortDateString()}\n", ConsoleColor.Blue);
                            }
                            break;
                        case (int)GroupOptions.FindGroupByName:
                            break;
                        case (int)GroupOptions.FindGroupById:
                            break;
                        case (int)GroupOptions.Terminate:
                            return;

                        default:
                            break;
                    }
                }

            }


        }
    }
}