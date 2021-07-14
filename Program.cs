using System;

namespace Integracao
{
    class Program
    {
        static void Main()
        {
            var service = new org.oorsprong.webservices.CountryInfoService();
                
            foreach (var country in service.ListOfCountryNamesByName())
            {
                Console.WriteLine(country.sName.ToString());
            }

            while(true)
            {
                Console.WriteLine("\nInforme um dos países acima para receber informações sobre ele.");

                string typedCountry = Console.ReadLine();

                if (!string.IsNullOrEmpty(typedCountry))
                {
                    typedCountry = char.ToUpper(typedCountry[0]) + typedCountry.Substring(1).ToLower();
                    string countryCode = service.CountryISOCode(typedCountry);

                    if (countryCode == "No country found by that name")
                    {
                        Console.WriteLine("Nenhum país encontrado!");
                    }
                    else
                    {
                        var currency = service.CountryCurrency(countryCode);
                        Console.WriteLine("Moeda: " + currency.sName + "(" + currency.sISOCode + ")");
                        Console.WriteLine("Código Telefônico: +" + service.CountryIntPhoneCode(countryCode));
                    }
                }
            }
        }
    }
}