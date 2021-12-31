using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;

            Console.WriteLine("please enter the number of processes ");

            n = (Int32.Parse(Console.ReadLine()));
            int[,] a = new int[n, 4];
            //    { { 2,3,2,1},
            //            { 3,4,3,5},
            //            {1,24,1,7},
            //            {4,6,3,8}
            //};
            Console.WriteLine("will you enter the arrival time press (y/n) : ");
            
            string yes_or_no =Console.ReadLine();
            if (yes_or_no == "y")
            {
                Console.WriteLine("process      duration      order     arrival time");
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine("enter the number of process ");
                    for (int j = 0; j < 4; j++)
                    {
                        a[i, j] = Int32.Parse(Console.ReadLine());
                    }
                }
            }
            else
            {
                Console.WriteLine("process      duration      order");
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine("enter the number of process ");
                    for (int j = 0; j < 3; j++)
                    {
                        a[i, j] = Int32.Parse(Console.ReadLine());
                    }
                }
            }
            sort_arrival_time(a);
            array_of_giant_chart(a);
            


            //for (int i = 0; i < 3; i++)
            //{
            //    for (int j = 0; j < 2; j++)
            //    {
            //        Console.Write(a[i, j]);
            //    }
            //    Console.WriteLine();
            //}
            //for (int i = 0; i < a.GetLength(0); i++)
            //{
            //    for (int j = 0; j < a.GetLength(1); j++)
            //    {
            //        Console.Write(a[i, j] + "  ");
            //    }
            //    Console.WriteLine();
            //}
            //sort_arrival_time(3, a);


            Console.Read();

        }

        static void sort_arrival_time(int[,] a)
        {
            int col = a.GetLength(1) - 1;
            int min = 0;
            for (int i = 0; i < a.GetLength(0) - 1; i++)
            {
                min = i;
                for (int j = i + 1; j < a.GetLength(0); j++)
                {
                    if (a[min, col] > a[j, col])
                    {
                        min = j;
                    }
                }
                if (min != i)
                {
                    for (int d = 0; d < a.GetLength(1); d++)
                    {
                        int temp2 = 0;
                        temp2 = a[i, d];
                        a[i, d] = a[min, d];
                        a[min, d] = temp2;
                    }
                }
            }
            Console.WriteLine("the sorted array by arrival time\n");
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write(a[i, j] + "  ");
                }
                Console.WriteLine();
            }



        }

        

        static int size_of_tims = 0;
        static void array_of_giant_chart(int[,] a)
        {
            int[] idel_or_no = new int[10];
            int[] wating_time = new int[a.GetLength(0)];
            int[] tims_above_giant = new int[20];
            int var = 0;
            tims_above_giant[0] = var;
            int t = a.GetLength(0);
            for (int i = 0, u = 0; i < t; i++)
            {
                if (a[u, 3] > var)
                {
                    idel_or_no[i] = -1;
                    var = a[u, 3];
                    tims_above_giant[i+1] = var;
                    t++;
                }
                else
                {
                    idel_or_no[i] = a[u, 0];
                    wating_time[u] = var - a[u, 3];
                    var = var + a[u, 1];
                    tims_above_giant[i+1] = var;
                    u++;
                }
                size_of_tims = i;
            }
            Console.WriteLine("idel or no    -1 is idel  else is a process number\n");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(idel_or_no[i]);
            }
            for (int i = 0; i < 40; i++)
            {
                Console.Write("==");
            }

            //int aw = 0;
            //for (int i = 0; i < a.GetLength(0); i++)
            //{
            //    Console.WriteLine(wating_time[i]);
            //    aw += wating_time[i];
            //}
            print_wating_time_and_avarage_wating_time(wating_time, idel_or_no, size_of_tims);
            for (int i = 0; i < 40; i++)
            {
                Console.Write("==");
            }
            //Console.WriteLine("\n" + (Double)aw / a.GetLength(0));
            for (int i = 0; i < 40; i++)
            {
                Console.Write("==");
            }
            Console.WriteLine();
            draw_giantchart(tims_above_giant, size_of_tims,idel_or_no);

        }

        static void draw_giantchart(int []a,int size,int []idel)
        {
            for (int i=0;i<size+2;i++)
            {
                Console.Write(a[i] + "------");
            }
            Console.WriteLine();
            for (int i = 0; i < size+1 ; i++)
            {
                if (idel[i]==-1)
                    Console.Write("| idel ");
                else 
                Console.Write( "| p["+idel[i]+"] ");
            }
            Console.Write(" |");

          Console.WriteLine();
            for (int i = 0; i < size + 2; i++)
            {
                Console.Write(" "+"------");
            }
        }

        static void print_wating_time_and_avarage_wating_time(int []wating_time,int [] idel,int size)
        {
            int aw = 0;
            Console.WriteLine("");
            Console.WriteLine("wating time of the processes is ");
            for (int i = 0,o=0; i < size+1; i++)
            {
                if (idel[i] == -1)
                    continue;
                else
                {
                    Console.Write(" p[" + idel[i] + "] = ");
                    Console.WriteLine(wating_time[o]);
                    aw += wating_time[o];
                    o++;
                }
            }
            Console.WriteLine("\nthe avrage wating time is " + (Double)aw / wating_time.Length);
        }


    }
} 