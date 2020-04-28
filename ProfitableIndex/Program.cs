using System;

namespace ProfitableIndex
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What you want?");
            Console.WriteLine("1.Profitability Index");
            Console.WriteLine("2.Discounted Profitability Index");
            Console.WriteLine("What you choice?");
            int z = Convert.ToInt32(Console.ReadLine());
            switch (z){
                case 1: Console.Clear();
                    ProfitableIndex();
                    break;
                case 2: Console.Clear();
                    DiscountedProfitableIndex();
                    break;
                default:
                    Console.WriteLine("Wrong choice");
                    break;
            }
            void ProfitableIndex()
            {
                // CF_0 - Первоначальные инвестиции
                // N - срок жизни проекта
                // CF_i - чистый денежный поток в i-м периоде
                // r - ставка дисконтирования
                // 
                Console.WriteLine("Enter N: ");

                int N = Convert.ToInt32(Console.ReadLine());
                double[] CF = new double[N];
                double NPV = 0;
                Console.Clear();
                Console.WriteLine("Your N: " + N);
                Console.WriteLine("Enter your r (in %):");
                double r = Convert.ToDouble(Console.ReadLine());
                r /= 100;
                Console.WriteLine("Enter CashFlows");
                Console.WriteLine(" ");

                for (int i = 0; i < N; i++)
                {
                    Console.WriteLine("CashFlow_" + (i+1) + "= ");
                    CF[i] = Convert.ToDouble(Console.ReadLine());
                    NPV += CF[i] / Math.Pow((1 + r), Convert.ToDouble(i+1));
                }

                Console.WriteLine();
                Console.WriteLine("Enter CF_0: ");
                double CF_0 = Convert.ToDouble(Console.ReadLine());

                double PI = NPV / CF_0;
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("NPV = " + NPV);
                Console.WriteLine("Profitable index = " + PI);
                if (PI < 1) Console.WriteLine("Profitable Index < 1 ===> Reject the project");
                else if (PI > 1) Console.WriteLine("Profitable Index > 1 ===> Accept the Project");
                else Console.WriteLine("Profitable Index = 1 ===> Modify the project");
                Console.ReadKey();
            }       
            
            void DiscountedProfitableIndex()
            {
                Console.WriteLine("Enter N: ");

                int N = Convert.ToInt32(Console.ReadLine());
                double[] CF = new double[N];
                double NPV = 0;
                Console.Clear();
                Console.WriteLine("Your N: " + N);
                Console.WriteLine("Enter your r (in %):");
                double r = Convert.ToDouble(Console.ReadLine());
                r /= 100;
                Console.WriteLine("Enter CashFlows");
                Console.WriteLine(" ");

                for (int i = 0; i < N; i++)
                {
                    Console.WriteLine("CashFlow_" + (i + 1) + "= ");
                    CF[i] = Convert.ToDouble(Console.ReadLine());
                    NPV += CF[i] / Math.Pow((1 + r), Convert.ToDouble(i + 1));
                }

                double allIt = 0;

                double[] It = new double[N];
                Console.WriteLine("Enter investments: ");
                Console.WriteLine("");
                for(int i = 0; i < N; i++)
                {
                    Console.WriteLine("InvestFlow_" + (i + 1) + "= ");
                    It[i] = Convert.ToDouble(Console.ReadLine());
                    allIt += It[i] / Math.Pow((1 + r), Convert.ToDouble(i + 1));
                }


                

                double DPI = NPV / allIt;
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("NPV = " + NPV);
                Console.WriteLine("Discounted Profitability index = " + DPI);
                if (DPI < 1) Console.WriteLine("Discounted Profitability Index < 1 ===> Reject the project");
                else if (DPI > 1) Console.WriteLine("Discounted Profitability Index > 1 ===> Accept the Project");
                else Console.WriteLine("Discounted Profitability Index = 1 ===> Modify the project");
                Console.ReadKey();
            }
        }
    }
}
