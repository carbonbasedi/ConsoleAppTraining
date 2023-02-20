using Core.Entities;
using Core.Helpers;
using Data.Context;
using Data.Repos.Actual;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Services
{
    internal class GroupService
    {
        private readonly GroupRepos _groupRepos;

        public GroupService()
        {
            _groupRepos = new GroupRepos();
        }
        public void Add(Group group)
        {
            _groupRepos.Add(group);
        }
        public bool Exit()
        {
            Console.Clear();
        ReturnCheck: ConsoleHelper.WriteWithColor("Go back to main menu? y/n", ConsoleColor.Red);
            char dec;
            bool isRightInput = char.TryParse(Console.ReadLine().ToLower(), out dec);
            if (!isRightInput)
            {
                Console.Clear();
                ConsoleHelper.WriteWithColor("Wrong input!\n Press <y> to go back to main menu or press <n> to continue with group menu", ConsoleColor.Red);
                goto ReturnCheck;
            }

            if (!(dec == 'y' || dec == 'n'))
            {
                Console.Clear();
                ConsoleHelper.WriteWithColor(" Press <y> to go back to main menu or press <n> to continue with group menu", ConsoleColor.Red);
                goto ReturnCheck;
            }
            else if (dec == 'y')

            {
                Console.Clear();
                return true;
            }
            else
            {
                Console.Clear();
                return false;
            }
        }
        public void Create()
        {
            Console.Clear();
            ConsoleHelper.WriteWithColor(">> Enter group name >>", ConsoleColor.DarkCyan);
            string name = Console.ReadLine();

            Console.Clear();
            int maxSize;
        MaxSizeCheck: ConsoleHelper.WriteWithColor(">> Enter max capacity of group >>", ConsoleColor.DarkCyan);
            bool isRightInput = int.TryParse(Console.ReadLine(), out maxSize);
            if (!isRightInput)
            {
                Console.Clear();
                ConsoleHelper.WriteWithColor("Wrong input detected!\nPlease try again\n", ConsoleColor.Red);
                goto MaxSizeCheck;
            }
            if (0 > maxSize || maxSize > 18)
            {
                Console.Clear();
                ConsoleHelper.WriteWithColor("Group Size Shouldn't exceed 18 or set lower than 1!\nEnter valid group size\n", ConsoleColor.Red);
                goto MaxSizeCheck;
            }

            Console.Clear();
            DateTime startDate;
        StartDateCheck: ConsoleHelper.WriteWithColor(">> Enter Start Date of Group >>", ConsoleColor.DarkCyan);
            isRightInput = DateTime.TryParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out startDate);
            if (!isRightInput)
            {
                Console.Clear();
                ConsoleHelper.WriteWithColor("Wrong input format!\nEnter date in [dd.MM.yyyy] format\n", ConsoleColor.Red);
                goto StartDateCheck;
            }

            Console.Clear();
            DateTime originDate = new DateTime(1861, 4, 1);
            if (startDate < originDate)
            {
                ConsoleHelper.WriteWithColor("Start date of group cannot be set before establishment date of college!\nPlease enter valid date\n", ConsoleColor.Red);
                goto StartDateCheck;
            }
            Console.Clear();
            DateTime endDate;
        EndDateCheck: ConsoleHelper.WriteWithColor(">> Enter End Date of Group >>", ConsoleColor.DarkCyan);
            isRightInput = DateTime.TryParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out endDate);
            if (!isRightInput)
            {
                Console.Clear();
                ConsoleHelper.WriteWithColor("Wrong input format\nEnter date in [dd.MM.yyyy] format", ConsoleColor.Red);
                goto EndDateCheck;
            }
            if (startDate > endDate)
            {
                Console.Clear();
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
            Console.Clear();
            ConsoleHelper.WriteWithColor($"//// Group created successfully ////\n Name : {group.Name}\n Max Capacity : {group.MaxSize}\n Start Date : {group.StartDate.ToShortDateString()}\n End Date : {group.EndDate.ToShortDateString()}\n\n\n <<< PRESS ANY KEY TO CONTINUE >>>", ConsoleColor.Green);
            Console.ReadKey();
        }
        public void Update()
        {
        UpdateCheck: ConsoleHelper.WriteWithColor("Search Group\n1.(By ID)\n2.(By Name)\n", ConsoleColor.Cyan);

            int num;
            bool isRightInput = int.TryParse(Console.ReadLine(), out num);
            if (!isRightInput)
            {
                ConsoleHelper.WriteWithColor("Wrong input!\n Press <1> to retrieve group by ID or press <2> to to retrieve group by Name.", ConsoleColor.Red);
                goto UpdateCheck;
            }

            if (num == 1)
            {
            IDCheck: ConsoleHelper.WriteWithColor("Enter Group ID", ConsoleColor.Cyan);
                int id;
                isRightInput = int.TryParse(Console.ReadLine(), out id);
                if (!isRightInput)
                {
                    ConsoleHelper.WriteWithColor("Wrong Input!\nEnter Group ID to uptade it's info", ConsoleColor.Red);
                    goto IDCheck;
                }

                var group = _groupRepos.Get(id);
                if (group is null)
                {
                    ConsoleHelper.WriteWithColor("There is no Group with this ID");
                    goto IDCheck;
                }
                else
                {
                    ConsoleHelper.WriteWithColor("Enter New Group name");
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

                    group.Name = name;
                    group.MaxSize = maxSize;
                    group.StartDate = startDate;
                    group.EndDate = endDate;

                    _groupRepos.Update(group);
                    Console.Clear();
                    ConsoleHelper.WriteWithColor($"//// Group updated successfully ////\n Name : {group.Name}\n Max Capacity : {group.MaxSize}\n Start Date : {group.StartDate.ToShortDateString()}\n End Date : {group.EndDate.ToShortDateString()}\n\n\n <<< PRESS ANY KEY TO CONTINUE >>>", ConsoleColor.Green);
                    Console.ReadKey();
                }
            }
            else if (num == 2)
            {
            NameCheck: ConsoleHelper.WriteWithColor("Enter Group Name", ConsoleColor.Cyan);
                string input = Console.ReadLine();
                var group = _groupRepos.GetByName(input);
                if (group is null)
                {
                    ConsoleHelper.WriteWithColor("Wrong Input!\nEnter Group ID to uptade it's info", ConsoleColor.Red);
                    goto NameCheck;
                }

                if (group is null)
                {
                    ConsoleHelper.WriteWithColor("There is no Group with this ID");
                    goto NameCheck;
                }
                else
                {
                    ConsoleHelper.WriteWithColor("Enter New Group name",ConsoleColor.DarkCyan);
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

                    group.Name = name;
                    group.MaxSize = maxSize;
                    group.StartDate = startDate;
                    group.EndDate = endDate;

                    _groupRepos.Update(group);
                }
            }
            else
            {
                ConsoleHelper.WriteWithColor("Wrong Input", ConsoleColor.Red);
                goto UpdateCheck;
            }
        }
        public void Remove()
        {
            var groupCount = _groupRepos.GetAll();
            if (groupCount.Count == 0)
            {
            AddNewCheck: ConsoleHelper.WriteWithColor("There is no group in database!\nWould you like to add new? < y/n >", ConsoleColor.Red);
                char dec;

                bool isRighInput = char.TryParse(Console.ReadLine().ToLower(), out dec);

                if (!isRighInput)
                {
                    ConsoleHelper.WriteWithColor("Wrong input!\n Press <y> to Add new group session or press <n> to return to main menu.", ConsoleColor.Red);
                    goto AddNewCheck;
                }

                if (!(dec == 'y' || dec == 'n'))
                {
                    ConsoleHelper.WriteWithColor("Press <y> to Add new group session or press <n> to return to main menu.", ConsoleColor.Red);
                    goto AddNewCheck;
                }
                else if (dec == 'y')
                {
                    Create();
                    return;
                }
                else
                {
                    return;
                }
            }
            Console.Clear();
            foreach (var group in groupCount)
            {
                ConsoleHelper.WriteWithColor($" ID : {group.Id}\n Name : {group.Name}\n Max Capacity : {group.MaxSize}\n Start Date : {group.StartDate.ToShortDateString()}\n End Date : {group.EndDate.ToShortDateString()}\n", ConsoleColor.Blue);
            }

        IDCheck: ConsoleHelper.WriteWithColor(">> Enter group ID that you want to remove >>", ConsoleColor.DarkCyan);
            int id;
            bool isRightInput = int.TryParse(Console.ReadLine(), out id);
            if (!isRightInput)
            {
                ConsoleHelper.WriteWithColor("Wrong input format!\n Please enter ID again\n", ConsoleColor.Red);
                goto IDCheck;
            }
            var dbGroup = _groupRepos.Get(id);
            if (dbGroup is null)
            {
                ConsoleHelper.WriteWithColor("There is no group with this ID number\n Please enter valid ID number\n", ConsoleColor.Red);
                goto IDCheck;
            }
            else
            {
                _groupRepos.Delete(dbGroup);
                ConsoleHelper.WriteWithColor("Group successfully deleted!\n <<<PRESS ANY KEY TO CONTINUE>>>", ConsoleColor.Green);
                Console.ReadLine();

            }
        }
        public void GetAll()
        {
            var groupCount = _groupRepos.GetAll();
            if (groupCount.Count == 0)
            {
                AddNewCheck: ConsoleHelper.WriteWithColor("There is no group in database!\nWould you like to add new? < y/n >", ConsoleColor.Red);
                char dec;

                bool isRightInput = char.TryParse(Console.ReadLine().ToLower(), out dec);

                if (!isRightInput)
                {
                    ConsoleHelper.WriteWithColor("Wrong input!\n Press <y> to Add new group session or press <n> to return to main menu.", ConsoleColor.Red);
                    goto AddNewCheck;
                }

                if (!(dec == 'y' || dec == 'n'))
                {
                    ConsoleHelper.WriteWithColor("Press <y> to Add new group session or press <n> to return to main menu.", ConsoleColor.Red);
                    goto AddNewCheck;
                }
                else if(dec == 'y')
                {
                    Create();
                    return;
                }
                else
                {
                    return;
                }
            }
            Console.Clear();
            foreach (var group in groupCount)
            {
                ConsoleHelper.WriteWithColor($" ID : {group.Id}\n Name : {group.Name}\n Max Capacity : {group.MaxSize}\n Start Date : {group.StartDate.ToShortDateString()}\n End Date : {group.EndDate.ToShortDateString()}\n", ConsoleColor.Blue);
            }
            ConsoleHelper.WriteWithColor("<<< Press any key to continue >>>", ConsoleColor.Green);
            Console.ReadKey();
        }
        public void GetGroupByName()
        {
            var groupCount = _groupRepos.GetAll();

            if (groupCount.Count == 0)
            {
                ConsoleHelper.WriteWithColor("There is no group in database!\nWould you like to add new? < y/n >", ConsoleColor.Red);


                char dec;

                bool isRightInput = char.TryParse(Console.ReadLine().ToLower(), out dec);

            AddNewCheck1: if (!isRightInput)
                {
                    ConsoleHelper.WriteWithColor("Wrong input!\n Press <y> to Add new group session or press <n> to return to main menu.", ConsoleColor.Red);
                    goto AddNewCheck1;
                }

                if (!(dec == 'y' || dec == 'n'))
                {
                    ConsoleHelper.WriteWithColor("Press <y> to Add new group session or press <n> to return to main menu.", ConsoleColor.Red);
                    goto AddNewCheck1;
                }
                else if (dec == 'y')
                {
                    Create();
                }
                else if (dec == 'n')
                {
                    return;
                }
            }
            else
            {
                ConsoleHelper.WriteWithColor("Enter Group name to retrieve info", ConsoleColor.Cyan);
                string name = Console.ReadLine();
                var group = _groupRepos.GetByName(name);
                if (group == null)
                {
                AddNewCheck: ConsoleHelper.WriteWithColor("There is no group with such Name in database!\nWould you like to add new? < y/n >",ConsoleColor.Red);
                    char dec;

                    bool isRightInput = char.TryParse(Console.ReadLine().ToLower(), out dec);

                    if (!isRightInput)
                    {
                        ConsoleHelper.WriteWithColor("Wrong input!\n Press <y> to Add new group session or press <n> to return to main menu.", ConsoleColor.Red);
                        goto AddNewCheck;
                    }

                    if (!(dec == 'y' || dec == 'n'))
                    {
                        ConsoleHelper.WriteWithColor("Press <y> to Add new group session or press <n> to return to main menu.", ConsoleColor.Red);
                        goto AddNewCheck;
                    }
                    else if (dec == 'y')
                    {
                        Create();
                    }
                }
                else
                {
                    
                    ConsoleHelper.WriteWithColor($" //Group info\n  ID : {group.Id}\n Name : {group.Name}\n Max Capacity : {group.MaxSize}\n Start Date : {group.StartDate.ToShortDateString()}\n End Date : {group.EndDate.ToShortDateString()}\n\n\n <<< PRESS ANY KEY TO CONTINUE >>>",ConsoleColor.Blue);
                    Console.ReadLine();
                }
            }
        }
        public void GetGroupById()
        {
            var groupCount = _groupRepos.GetAll();

            if (groupCount.Count == 0)
            {
                ConsoleHelper.WriteWithColor("There is no group in database!\nWould you like to add new? < y/n >",ConsoleColor.Red);


                char dec;

                bool isRightInput = char.TryParse(Console.ReadLine().ToLower(), out dec);

            AddNewCheck1: if (!isRightInput)
                {
                    ConsoleHelper.WriteWithColor("Wrong input!\n Press <y> to Add new group session or press <n> to return to main menu.", ConsoleColor.Red);
                    goto AddNewCheck1;
                }

                if (!(dec == 'y' || dec == 'n'))
                {
                    ConsoleHelper.WriteWithColor("Press <y> to Add new group session or press <n> to return to main menu.", ConsoleColor.Red);
                    goto AddNewCheck1;
                }
                else if (dec == 'y')
                {
                    Create();
                }
                else if (dec == 'n')
                {
                    return;
                }
            }
            else
            {
                var groupCount1 = _groupRepos.GetAll();
                if (groupCount1.Count == 0)
                {
                AddNewCheck: ConsoleHelper.WriteWithColor("There is no group in database!\nWould you like to add new? < y/n >", ConsoleColor.Red);
                    char dec;

                    bool isRighInput = char.TryParse(Console.ReadLine().ToLower(), out dec);

                    if (!isRighInput)
                    {
                        ConsoleHelper.WriteWithColor("Wrong input!\n Press <y> to Add new group session or press <n> to return to main menu.", ConsoleColor.Red);
                        goto AddNewCheck;
                    }

                    if (!(dec == 'y' || dec == 'n'))
                    {
                        ConsoleHelper.WriteWithColor("Press <y> to Add new group session or press <n> to return to main menu.", ConsoleColor.Red);
                        goto AddNewCheck;
                    }
                    else if (dec == 'y')
                    {
                        Create();
                        return;
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    Console.Clear();
                    foreach (var group in groupCount)
                    {
                        ConsoleHelper.WriteWithColor($" ID : {group.Id}\n Name : {group.Name}\n Max Capacity : {group.MaxSize}\n Start Date : {group.StartDate.ToShortDateString()}\n End Date : {group.EndDate.ToShortDateString()}\n", ConsoleColor.Blue);
                    }

                IDCheck: ConsoleHelper.WriteWithColor(">> Enter group ID that you want to remove >>", ConsoleColor.DarkCyan);
                    int id;
                    bool isRightInput = int.TryParse(Console.ReadLine(), out id);
                    if (!isRightInput)
                    {
                        ConsoleHelper.WriteWithColor("Wrong input format!\n Please enter ID again\n", ConsoleColor.Red);
                        goto IDCheck;
                    }
                    var dbGroup = _groupRepos.Get(id);
                    if (dbGroup is null)
                    {
                        ConsoleHelper.WriteWithColor("There is no group with this ID number\n Please enter valid ID number\n", ConsoleColor.Red);
                        goto IDCheck;
                    }
                IDSearchCheck: ConsoleHelper.WriteWithColor("Enter Group ID to retrieve from list", ConsoleColor.Cyan);
                    int input;
                    isRightInput = int.TryParse(Console.ReadLine(), out input);
                    if (!isRightInput)
                    {
                        ConsoleHelper.WriteWithColor("Wrong input format!\n Please enter ID again\n", ConsoleColor.Red);
                        goto IDSearchCheck;
                    }
                    var groups = _groupRepos.Get(input);
                    if (groups is null)
                    {
                        ConsoleHelper.WriteWithColor("There is no group with this ID number\n Please enter valid ID number\n", ConsoleColor.Red);
                        goto IDSearchCheck;
                    }
                    else
                    {
                        ConsoleHelper.WriteWithColor($" //Group info\n  ID : {groups.Id}\n Name : {groups.Name}\n Max Capacity : {groups.MaxSize}\n Start Date : {groups.StartDate.ToShortDateString()}\n End Date : {groups.EndDate.ToShortDateString()}\n\n\n <<< PRESS ANY KEY TO CONTINUE >>>", ConsoleColor.Blue);
                        Console.ReadLine();
                    }
                }

            }
        }
    }
}
