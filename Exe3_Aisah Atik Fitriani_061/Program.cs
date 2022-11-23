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
            Console.Write("\nMasukkan nomor Mahasiswa : ");
            nim = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nMasukkan nama Mahasiswa : ");
            nm = Console.ReadLine();
            Node nodeBaru = new Node();
            nodeBaru.rollNumber = nim ;
            nodeBaru.name = nm;

            if (LAST == null || nim <= LAST.rollNumber)
            {
                if((LAST != null) && (nim == LAST.rollNumber))
                {
                    Console.WriteLine("\nNomer Mahasiswa sama tidak diijinkan\n");
                    return;
                }
                LAST.next = nodeBaru;
                nodeBaru.next = LAST.next;
            }

            Node previous, current;
            previous = LAST;
            current = LAST;

            while((current != null) &&(nim >= current.rollNumber))
            {
                if(nim == current.rollNumber)
                {
                    Console.WriteLine("\nNomer Mahasiswa sama tidak diijinkan\n");
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
                    Console.WriteLine("1. View all the records in the list");
                    Console.WriteLine("2. Search for a records in the list");
                    Console.WriteLine("3. Display the first records in the list");
                    Console.WriteLine("4. Exit");
                    Console.Write("\nEnter your choice (1-4) : ");

                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.traverse();
                            }
                            break;
                        case '2':
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
                        case '3':
                            {
                                obj.firstNode();
                            }
                            break;
                        case '4':
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
