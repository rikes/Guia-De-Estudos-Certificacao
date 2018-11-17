using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace _4._4_JSON_serialization
{
    class UpdateJson
    {

        

        public void RemoveCarcter()
        {   
            //Fazer para todo o sudeste
            string jsonES = File.ReadAllText(@"C:\Users\henri\Documents\Power BI Desktop\mg_map.json");
            
            JObject data = JObject.Parse(jsonES);
            //var data = (JObject)JsonConvert.DeserializeObject(jsonES);

            List<string> listCodMun = data.SelectTokens("objects.Export_Output.geometries[*].properties.COD_IBGE").Select(s => (string)s).ToList();//DEU CERTO!!!!

            //Utilizar um replace para gravar no arquivo, 
            //ja que nao encontrei uma solucao que atualizasse as propriedades do meu json
            //Alem disso, removi os acentos
            StringBuilder jsonAux = new StringBuilder(RemoverAcentuacao(jsonES));
            foreach (var item in listCodMun)
            {
                jsonAux = jsonAux.Replace(item, item.Substring(0, item.Length - 1));
            }

            File.WriteAllText(@"C:\Users\henri\Documents\Power BI Desktop\mg_map.json", jsonAux.ToString());
            Console.WriteLine("Gravado com sucesso");
        }


        protected string RemoverAcentuacao(string text)
        {
            return new string(text
                .Normalize(NormalizationForm.FormD)
                .Where(ch => char.GetUnicodeCategory(ch) != UnicodeCategory.NonSpacingMark)
                .ToArray());
        }


    }
}
