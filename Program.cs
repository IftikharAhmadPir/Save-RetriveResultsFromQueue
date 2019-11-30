using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasheValues
{
    class Program
    {
        static Queue<Calculation> _queue = new Queue<Calculation>(10);
        enum OperationType
        {
            Multiplication, Division
        }

        struct Calculation
        {
            public OperationType Type;
            public double Lhs;
            public double Rhs;
            public double Result;
        
        }

        
        static void Main(string[] args)
        {
            var head = _queue.FirstOrDefault();
            for(int i=0; i<9; i++)
            {
                head.Lhs = i+1;
                head.Rhs = i+2;
                head.Result = head.Lhs * head.Rhs;
                head.Type = OperationType.Multiplication;
                _queue.Enqueue(head);
            }
            Console.WriteLine("Saving Results in Queue:");
            foreach(var s in _queue)
            {
                Console.WriteLine("LHS:{0} , RHS:{1} , Result: {2}", s.Lhs, s.Rhs, s.Result);
            }
            Console.WriteLine("##########################");
            Console.WriteLine("Test Results:");
            for (int i = 0; i < 9; i++)
            {
                Console.WriteLine("LHS:{0} , RHS:{1} , Result: {2}", i+1 , i+2, FromCache(OperationType.Multiplication, i+1, i+2));
            }
            Console.ReadLine();
         }


        private static double? FromCache(OperationType op, double lhs, double rhs)
        {
            foreach (var r in _queue)
            {
                if (r.Type == op && r.Lhs == lhs && r.Rhs == rhs)
                {
                    return r.Result;
                }
            }
            return null;
        }

    }
}
