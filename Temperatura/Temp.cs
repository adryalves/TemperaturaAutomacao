using EasyAutomationFramework;
using org.junit.experimental.theories.suppliers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temperatura
{
    public class Temp : WebPersonalizado
    {

        public Temp()
        {

            StartBrowser();
        }


        public void Teste()
        {
            Navigate("https://portal.inmet.gov.br/");


            var cidades = new List<string> { "Caaporã", "Caatiba", "Viana", "Belágua", "Leopoldina" };


            foreach (var cidade in cidades)
            {
                Click(TypeElement.Id, "search");
                AssignValue(TypeElement.Id, "search", cidade);
                Thread.Sleep(7000);
                SelecionaItem(TypeElement.Id, "ui-id-1", cidade);
            }

            


        }

    }


}
