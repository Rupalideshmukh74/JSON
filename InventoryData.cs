using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;

namespace JSON
{
        class InventoryData
        {
            public InventoryData()
            {
                //variables
                int userOption;

                //Display Messsages
                Console.WriteLine("Choose An Option to Perform an Action :");
                Console.WriteLine("Press 1 : Add Details In Inventory ");
                Console.WriteLine("Press 2 : Display Inventory Details ");
                Console.WriteLine("----------------------------------------");
                userOption = int.Parse(Console.ReadLine());

                switch (userOption)
                {
                    case 1: //Add Details
                            //Create List
                        List<Inventory> inventoryList = new List<Inventory>();

                        Inventory inventory = new Inventory("Rice", 500, 60);
                        Inventory inventory1 = new Inventory("Pulses", 300, 80);
                        Inventory inventory2 = new Inventory("Wheats", 1000, 100);

                        //Adding to List
                        inventoryList.Add(inventory);
                        inventoryList.Add(inventory1);
                        inventoryList.Add(inventory2);

                        //Serialize JSON 
                        string json = JsonConvert.SerializeObject(inventoryList);
                        File.WriteAllText(@"C:\Users\DELL\source\repos\JSONInventoryDataManagement\InventoryDetails.json", json);

                        Console.WriteLine("Inventory Details Added SuccessFully in File.");
                        break;

                    case 2:// Display Inventory Items

                        //Display Messages
                        Console.WriteLine("Dispaly Inventory Items");
                        Console.WriteLine("-----------------------");

                        //Deserialize Data of JSON file
                        string datafile = File.ReadAllText(@"C:\Users\DELL\source\repos\JSONInventoryDataManagement\InventoryDetails.json");
                        List<Inventory> returnDataObj = JsonConvert.DeserializeObject<List<Inventory>>(datafile);

                        //Display JSON file Data
                        foreach (var form in returnDataObj)
                        {

                            Console.WriteLine("Name : " + form.Name);
                            Console.WriteLine("Weight : " + form.Weight);
                            Console.WriteLine("Price : " + form.Price);

                            //Calulation
                            Console.WriteLine("Total Value of {0} =  {1}: ", form.Name, (form.Weight * form.Price));
                            Console.WriteLine("---------------------------------");
                        }
                        break;

                    default:
                        Console.WriteLine("Invalid Input !!!");
                        break;
                }
            }
        }
    }
