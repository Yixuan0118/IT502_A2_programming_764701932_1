using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace LANGHAM_HOTEL_MANAGEMENT_SYSTEM
{
    public class TheRoom
    {
        public int RoomNumbers { get; set; }
        public bool isAllocated { get; set; }
    }
    public class TheCustomer
    {
        public int CustomerNo { get; set; }
        public string CustomerName { get; set; }
    }
    public class RoomAllocation
    {
        public int AllocationRoomNumber { get; set; } 
        public TheCustomer AllocatedCustomer{ get; set; }
    }



    internal class Program
    {
        public static TheRoom[] listofRooms;
        public static List<RoomAllocation> listofRoomAllocations = new List<RoomAllocation>();
        public static string FolderPath;
        public static string filepath;
        public static string backupfilePath;

        static void Main(string[] args)
        {
            try {
                bool shouldBackToMenu = true;
                while(shouldBackToMenu)
                {
                    shouldBackToMenu = ShowMenu();
                }
            } catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }

        private static bool ShowMenu()
        {
            Console.WriteLine("LANGHAM_HOTEL_MANAGEMENT_SYSTEM");
            Console.WriteLine("1.Add Rooms");
            Console.WriteLine("2.Display Rooms");
            Console.WriteLine("3.Allocate Rooms");
            Console.WriteLine("4.De-Allocate Rooms");
            Console.WriteLine("5.Display Room Allocation Details");
            Console.WriteLine("6.Billing");
            Console.WriteLine("7.Save the Room Allocations To a File");
            Console.WriteLine("8.Show the Room Allocations From a File");
            Console.WriteLine("9.Exit");
            Console.WriteLine("0.Backup");
            Console.WriteLine("Enter Yoour Choice Number Here:");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.Clear();
                    AddRooms();
                    break;
                case 2:
                    Console.Clear();
                    DisplayRooms();
                    break;
                case 3:
                    Console.Clear();
                    AllocateRooms();
                    break;
                case 4:
                    Console.Clear();
                    DeAllocateRooms();
                    break;
                case 5:
                    Console.Clear();
                    DisplayRoomAllocationDetails();
                    break;
                case 6:
                    Console.Clear();
                    ShowBillingDetails();
                    break;
                case 7:
                    Console.Clear();
                    SavetheRoomAllocationsToaFile();
                    break;
                case 8:
                    Console.Clear();
                    ShowtheRoomAllocationsToaFile();
                    break;
                case 9:
                    Console.Clear();
                    return false;
                    break;
                case 0:
                    Console.Clear();
                    Backup();
                    break;
            }
            return true;
        }

        private static void ShowBillingDetails()
        {
            Console.WriteLine("Billing Feature is Under Construction and will be added soon...!!!");
        }

        private static void DisplayRooms()
        {
            try
            {
                foreach (TheRoom room in listofRooms)
                {
                    Console.WriteLine(room.RoomNumbers);
                }
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }

        private static void AddRooms()
        {
            try
            {
                Console.WriteLine("Please enter how many room you wants");
                int num = Convert.ToInt32(Console.ReadLine());
                listofRooms = new TheRoom[num];
                for (int i = 0; i < listofRooms.Length; i++)
                {
                    TheRoom room = new TheRoom();
                    Console.Write("Please enter the Room numbers: ");
                    room.RoomNumbers = Convert.ToInt32(Console.ReadLine());
                    listofRooms[i] = room;
                }
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }

        }
        private static void AllocateRooms()
        {
            try
            {
                TheCustomer customer = new TheCustomer();
                Console.WriteLine("Allocate the Room Function has been called");
                Console.Write("Please enter Customer Number: ");
                customer.CustomerNo = Convert.ToInt32(Console.ReadLine());
                Console.Write("Please Enter Customer Name: ");
                customer.CustomerName = Console.ReadLine();
                Console.Write("Please Enter Room Numbers");
                int roomNumber = Convert.ToInt32(Console.ReadLine());
                bool IsAllocated = false;
                for (int i = 0; i < listofRooms.Length; i++)
                {
                    if (IsAllocated == listofRooms[i].isAllocated)
                    {
                        if (listofRooms[i].RoomNumbers == roomNumber)
                        {
                            IsAllocated = true;
                            listofRooms[i].isAllocated = true;

                        }

                    }
                }
                if (IsAllocated)
                {
                    RoomAllocation roomallocation = new RoomAllocation();
                    roomallocation.AllocationRoomNumber = roomNumber;
                    roomallocation.AllocatedCustomer = customer;
                    listofRoomAllocations.Add(roomallocation);

                }
                else
                {
                    Console.Write("Wrong Room Number");
                }
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }

        }
        private static void DeAllocateRooms()
        {
            try {
                Console.WriteLine("DeAllocation Room Function is called from main Function Switch");
                Console.WriteLine("Please Enter The Room Number: ");
                int Roomno = Convert.ToInt32(Console.ReadLine());
                bool Avaliable = true;
                for (int i = 0; i < listofRooms.Length; i++)
                {
                    if (Roomno == listofRooms[i].RoomNumbers)
                    { 
                        if (Avaliable == listofRooms[i].isAllocated) 
                        {
                            listofRooms[i].isAllocated = false;
                            Avaliable = false;

                        } 
                    }
                    
                }
                if (Avaliable == false) {
                    RoomAllocation roomallocation = listofRoomAllocations.Find(x => x.AllocationRoomNumber == Roomno);
                    listofRoomAllocations.Remove(roomallocation);
                }
                else
                {
                    Console.Write("Wrong Room Number...");
                }
            
            
            
            
            
            
            
            
            
            }catch(Exception e) { Console.WriteLine(e.Message); }

        }
        private static void DisplayRoomAllocationDetails()
        {
            try
            {
                Console.WriteLine("DisplayRoomAllocationDetails() function is called from Main function switch");
                Console.WriteLine("**************************************************************************************************");
                Console.WriteLine("---------------------------------------------------------------------------------");
                Console.WriteLine("Custmer Number\t RoomNumber \t Custmer Name");
                Console.WriteLine("---------------------------------------------------------------------------------");
                foreach (RoomAllocation item in listofRoomAllocations)
                {
                    Console.WriteLine(item.AllocatedCustomer.CustomerNo+"\t\t"+item.AllocationRoomNumber+"\t\t"+ item.AllocatedCustomer.CustomerName);                

                }
            }
            catch (Exception e) { Console.WriteLine(e.Message); }

        }
        private static void SavetheRoomAllocationsToaFile()
        {
            try
            {DateTime DT=new DateTime();
                DT=System.DateTime.Now;
                string Time = DT.ToString("dd-mm-yyyy HH:mm:ss");
                StreamWriter SW = new StreamWriter(filepath);
                { foreach (RoomAllocation item in listofRoomAllocations) {
                        Console.WriteLine(item.AllocatedCustomer.CustomerNo + "\t\t" + item.AllocationRoomNumber + "\t\t" + item.AllocatedCustomer.CustomerName+ "\t\t"+Time);
                    SW.WriteLine(item.AllocatedCustomer.CustomerNo + "\t\t" + item.AllocationRoomNumber + "\t\t" + item.AllocatedCustomer.CustomerName + "\t\t" + Time);
                    
                    
                    
                    } }
                
            } catch (Exception e) { Console.WriteLine(e.Message); }

        }
        private static void ShowtheRoomAllocationsToaFile()
        {
            try
            {
                Console.WriteLine("Please enter how many room you wants");
            }catch (Exception e) { Console.WriteLine(e.Message); }
        }
        private static void Backup()
        {
            Console.WriteLine("Please enter how many room you wants");

        }
    }
}
