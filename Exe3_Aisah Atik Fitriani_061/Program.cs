using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exe3_Aisah_Atik_Fitriani_061
{
    class Node
    {
        /**/
        public int rollNumber;
        public string name;
        public Node next;
    }

    class CircularList
    {
        Node LAST;

        public CircularList()
        {
            LAST = null;
        }

        public void Insert()
        {
            int nim;
            string nm;
            Console.Write("\nEnter the roll number of the student: ");
            nim = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nEnter the name of the student:");
            nm = Console.ReadLine();
            Node nodeBaru = new Node();
            nodeBaru.rollNumber = nim ;
            nodeBaru.name = nm;

            if (LAST == null || nim <= LAST.rollNumber)
            {
                if((LAST != null) && (nim == LAST.rollNumber))
                {
                    Console.WriteLine("\nDuplicate roll numbers not allowed\n");
                    return;
                }
                LAST.next = nodeBaru;
                nodeBaru.next = LAST.next;
            }
            //LAST.next = nodeBaru;
            //nodeBaru.next = LAST.next;

            Node previous, current;
            previous = LAST;
            current = LAST;

            while((current != null) &&(nim >= current.rollNumber))
            {
                if(nim == current.rollNumber)
                {
                    Console.WriteLine("\nDuplicate roll numbers not allowed\n");
                    return;
                }
                previous = null;
                previous = current;
                current = current.next;
            }

            nodeBaru.next = LAST.next;
            LAST.next = nodeBaru;
            LAST = nodeBaru;
        }
        
        public bool delNode(int nim)
        {
            Node previous, current;
            previous = current = null;
            LAST = null;

            if (Search(nim, ref previous, ref current) == false)
                return false;
            if (previous == LAST)
                previous.next = LAST.next;
            return true;

            LAST.next = current.next;
        }

        public bool Search(int rollNo, ref Node previous, ref Node current)
        {
            for (previous = current = LAST.next;
                current != LAST;
                previous = current,
                current = current.next)
            {
                if (rollNo == current.rollNumber)
                    return (true);

            }
            if (rollNo == LAST.rollNumber)
                return true;
            else
                return (false);
        }

        public bool listEmpty()
        {
            if (LAST == null)
                return true;
            else
                return false;
        }

        public void traverse()
        {
            if (listEmpty())
                Console.WriteLine("\nList is Empty");
            else
            {
                Console.WriteLine("\nRecords in the list are :\n");
                Node currentNode;
                currentNode = LAST.next;
                while (currentNode != LAST)
                {
                    Console.Write(currentNode.rollNumber + " " + currentNode.name + "\n");
                    Console.Write(LAST.rollNumber + " " + LAST.name + "\n");
                }
            }
        }


        public void firstNode()
        {
            if (listEmpty())
                Console.WriteLine("\nList is Empty");
            else
                Console.WriteLine("\nThe first record in the list is:\n\n" + LAST.next.rollNumber + " " + LAST.next.name);
        }

        static void Main(string[] args)
        {
            CircularList obj = new CircularList();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMenu");
                    Console.WriteLine("1. Add a record to the list ");
                    Console.WriteLine("2. Delete a record from the list ");
                    Console.WriteLine("1. View all the records in the list");
                    Console.WriteLine("4. Search for a records in the list");
                    Console.WriteLine("5. Display the first records in the list");
                    Console.WriteLine("6. Exit");
                    Console.Write("\nEnter your choice (1-4) : ");

                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.Insert();
                            }
                            break;
                        case '2':
                            {
                                if (obj.listEmpty())
                                {
                                    Console.WriteLine("\n List is empty");
                                    break;
                                }
                                Console.Write("Enter the rollnumber of the student" +
                                    "Whose record is to be deleted:");
                                int rollNumber = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (obj.delNode(rollNumber) == false)
                                    Console.WriteLine("Record not found");
                                else
                                    Console.WriteLine("Recprd with roll number" + rollNumber + "deleted \n");

                            }
                            break;
                        case '3':
                            {
                                obj.traverse();
                            }
                            break;
                        case '4':
                            {
                                if (obj.listEmpty()== true)
                                {
                                    Console.WriteLine("\nList is empty");
                                    break;
                                }
                                Node prev, curr;
                                prev = curr = null;
                                Console.Write("\nEnter the roll number of the student whose record is to be searched : ");
                                int num = Convert.ToInt32(Console.ReadLine());
                                if (obj.Search(num, ref prev, ref curr) == false)
                                    Console.WriteLine("\nRecord not found");
                                else
                                {
                                    Console.WriteLine("\nRecord found");
                                    Console.WriteLine("\nRoll number: " + curr.rollNumber);
                                    Console.WriteLine("\nName: " + curr.name);
                                }
                            }
                            break;
                        case '5':
                            {
                                obj.firstNode();
                            }
                            break;
                        case '6':
                            return;
                        default:
                            {
                                Console.WriteLine("Invalid option");
                                break;
                            }
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }
    }
}
