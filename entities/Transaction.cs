using System;
using System.Collections.Generic;

namespace deadlockDetect.entities
{
    public class Transaction
    {

        public String Id { get; set; }

        public List<Data> Data { get; set; }

        public String State { get; set; }

        public void write(Data data, String content = null)
        {

            if(data.State == "free")
            {
                data.State = "block";
                data.Content = content != null ? content : data.Content;  
                data.usingby = Id;

                this.Data.Add(data);
                this.State = "writing";

                Console.WriteLine("\n" + this.Id + " Escrevendo em " + data.Id + ", o estado atual do dado é " + data.State + "\n e seu valor passou a ser " + data.Content);
            }
            else
            {
                this.Data.Add(data);
                this.State = "waiting";
                Console.WriteLine("\n" + this.Id + " aguardando " + data.Id + " ser liberado por " + data.usingby + ", o estado atual do dado é " + data.State + "\n");
            }
        }

        public void read(Data data)
        {
            if (data.State == "free")
            {
                this.Data.Add(data);
                Console.WriteLine("\n" + this.Id + " lendo o dado " + data.Id + ", o estado atual do dado é " + data.State + "\n e seu valor é " + data.Content);
            }
            else
            {
                Console.WriteLine("\n" + this.Id + " aguardando " + data.Id + " ser liberado por " + data.usingby + ", o estado atual do dado é " + data.State + "\n");
            }
        }

        public void freeDatas()
        {
            List<Data> data = new List<Data>();
            foreach(Data d in this.Data)
            {
                d.State = d.State == "block" ? "free" : d.State;
                data.Add(d);
            }

            this.Data = data;
        }

    }
}
