using deadlockDetect.entities;
using System.Collections.Generic;

namespace deadlockDetect
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //datas
            List<Data> datas = new List<Data>
            {
                new Data{ Id = 1, Content="azul", State = "free" },
                new Data{ Id = 2, Content="vermelho", State = "free" },
                new Data{ Id = 3, Content="preto", State = "free" }
            };

            List<Transaction> transactions = new List<Transaction>
            {
                new Transaction{ Id = "T1", Data = new List<Data>() },
                new Transaction{ Id = "T2", Data = new List<Data>() },
                new Transaction{ Id = "T3", Data = new List<Data>() },
                new Transaction{ Id = "T4", Data = new List<Data>() },
                new Transaction{ Id = "T5", Data = new List<Data>() },
                new Transaction{ Id = "T6", Data = new List<Data>() }
            };

            transactions[0].write(datas[0]);
            transactions[1].read(datas[0]);
            transactions[2].write(datas[0]);
            transactions[3].write(datas[1]);
            transactions[4].read(datas[2]);
            transactions[5].write(datas[2], "branco");


            //var deadlock = new Detect(datas, transactions);
            //deadlock.detect();

        }

    }
}
