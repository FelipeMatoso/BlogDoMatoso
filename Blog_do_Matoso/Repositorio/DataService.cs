using Blog_do_Matoso.Business;
using Blog_do_Matoso.Models;
using System;
using System.Collections.Generic;

namespace Blog_do_Matoso
{
    public partial class Startup
    {
        public class DataService : IDataService
        {

            private readonly DBcontext dBcontext;

            public DataService(DBcontext dBcontext)
            {
                this.dBcontext=dBcontext;
            }

           

            public object IniciaDB()
            {
                return dBcontext.Depoimentos;
            }

            public Depoimentos SalvaDados(Depoimentos depoimento)
            {
                Console.WriteLine(depoimento);
                dBcontext.Depoimentos.Add(depoimento);
                dBcontext.SaveChanges();
                return depoimento;


            }

            public bool Validacao()
            {
                throw new NotImplementedException();
            }
        }

    }
}
