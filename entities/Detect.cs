using System;
using System.Collections.Generic;
using System.Linq;


namespace deadlockDetect.entities
{
    public class Detect
    {
        public Detect(List<Data> datas, List<Transaction> transactions)
        {
            this.Datas = datas;
            this.transactions = transactions;
        }

        public List<Data> Datas { get; set; }
        public List<Transaction> transactions { get; set; }

        public void detect()
        {

            Data d = null;

            List<Transaction> tranWr = this.transactions.FindAll(t => t.State == "writing");
            List<Transaction> tranWa = this.transactions.FindAll(t => t.State == "waiting");

           foreach(Transaction twr in tranWr)
            {
                foreach(Data dt in twr.Data)
                {
                    d = dt.State == "block" ? dt : d;

                    Console.WriteLine(tranWa.FindAll(t => t.Data.Contains(d)));
                }
            }

            //return result;
        }
    }
}
