using System;
using FirebaseNet;

namespace Consumer
{
    class Program
    {
        static void Main(string[] args)
        {


            // Instanciating with base URL  
            FirebaseDB firebaseDb = new FirebaseDB("https://awesomproject-64cf2.firebaseio.com");

            // Referring to Node with name "Teams"  
            FirebaseDB firebaseDbTeams = firebaseDb.Node();

            var data = @"{  
                            'Team-Awesome': {  
                                'Members': {  
                                    'M1': {  
                                        'City': 'New York',  
                                        'Name': 'Nanny'  
                                        },  
                                    'M2': {  
                                        'City': 'Brussels',  
                                        'Name': 'bossy'  
                                        },  
                                    'M3': {  
                                        'City': 'Stockholm',  
                                        'Name': 'danny'  
                                        }  
                                   }  
                               }  
                          }";

            Console.WriteLine("GET Request");
            FirebaseResponse getResponse = firebaseDbTeams.Get();
            Console.WriteLine(getResponse.Success);
            if (getResponse.Success)
                Console.WriteLine(getResponse.JSONContent);
            Console.WriteLine();

            Console.WriteLine("PUT Request");
            FirebaseResponse putResponse = firebaseDbTeams.Put(data);
            Console.WriteLine(putResponse.Success);
            Console.WriteLine();

            Console.WriteLine("POST Request");
            FirebaseResponse postResponse = firebaseDbTeams.Post(data);
            Console.WriteLine(postResponse.Success);
            Console.WriteLine();

            Console.WriteLine("PATCH Request");
            FirebaseResponse patchResponse = firebaseDbTeams
                // Use of NodePath to refer path lnager than a single Node  
                .NodePath("Team-Awesome/Members/M1")
                .Patch("{\"Designation\":\"CRM Consultant\"}");
            Console.WriteLine(patchResponse.Success);
            Console.WriteLine();

            Console.WriteLine("DELETE Request");
            FirebaseResponse deleteResponse = firebaseDbTeams.Delete();
            Console.WriteLine(deleteResponse.Success);
            Console.WriteLine();

            Console.WriteLine(firebaseDbTeams.ToString());
            Console.WriteLine();
            Console.WriteLine("Hello World!");
            Console.ReadKey();

        }
    }
}
