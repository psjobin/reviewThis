using System;
using System.Collections.Generic;
using System.Text;

// https://www.google.com/search?q=setting+a+reference+type+to+null+in+a+method+c%23&rlz=1C1ONGR_enUS948US948&oq=setting+a+reference+type+to+null+in+a+method+c%23&aqs=chrome..69i57j33i160.5779j0j7&sourceid=chrome&ie=UTF-8


namespace combine_two_sorted_lists
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Animal animal =  new Animal(){ Age = 1, Name = "Charlie" };

            ChangeAnimalName(animal);




            List<int> list1 = new List<int>() { 3, 4, 5, 6, 7 };
            List<int> list2 = new List<int>() { 1, 1, 3, 6, 9 };

            ListNode node = new ListNode();

            foreach(var x in list1){
                BuildNode(node,x);
            }

            List<int> resultA = MergeTwoLists(list1, list2);

            StringBuilder sb = new StringBuilder();
            foreach (var x in resultA)
            {
                sb.Append(x + ", ");
            }
            sb.Remove(sb.Length - 2, 1);
            Console.WriteLine(sb.ToString());

        }

        public static void ChangeAnimalName(Animal animal){
            if(animal == null){
                animal = new Animal(){ Age = 21, Name="Jobins"};
            }else{
                animal = null;
                //animal.Name = "Changed Name here";
            }
        }

        static List<int> MergeTwoLists(List<int> l1, List<int> l2)
        {

            List<int> result = new List<int>();

            int a = 0;
            int b = 0;
            for (int i = 0; i < (l1.Count + l2.Count); i++)
            {
                try
                {
                    if (l1[a] == l2[b])
                    {
                        result.Add(l1[a]);
                        result.Add(l2[b]);
                        a++;
                        b++;
                        continue;
                    }
                    if (l1[a] < l2[b])
                    {
                        result.Add(l1[a]);
                        a++;
                    }
                    else
                    {
                        result.Add(l2[b]);
                        b++;
                    }

                }
                catch (Exception ex)
                {
                    if (a < l1.Count)
                    {
                        // add the rest of l1 to the result.
                        for (int j = a; j < l1.Count; j++)
                        {
                            result.Add(l1[j]);
                        }
                    }
                    else
                    {
                        for (int j = b; j < l2.Count; j++)
                        {
                            result.Add(l2[j]);
                        }
                    }
                    break;

                }

            }


            return result;
        }

        static int GetLen(ListNode node)
        {
            int len = 0;

            while (node.next != null)
            {
                len++;
                node = node.next;
            }

            return len + 1;
        }



        static void BuildNode(ListNode node, int newVal)
        {
            ListNode newNode = new ListNode(newVal);
            newNode.next = null;
            if (node == null)
            {
                node = newNode;
            }
            else
            {
                ListNode temp = new ListNode();
                temp = node;
                while (temp.next != null)
                    temp = temp.next;

                //6. Change the next of last node to new node
                temp.next = newNode;

            }
        }
    }


        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }

        class Animal{
            public int Age { get; set; }
            public string Name { get; set; }
        }

    }
