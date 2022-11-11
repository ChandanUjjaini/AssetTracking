// Program to track assset 
using AssetTracking;
using System.Diagnostics;
using System.Runtime;

int Sel;

List<AssetData> AssetList = new List<AssetData>(); //Creating list for product details  
List<Validation> CurrencyCode = new List<Validation>(); //Creating list for Currency Type Lookup


do
{

    Console.WriteLine("*****************************************");
    Console.WriteLine("* Please Enter your selection from Menu *");
    Console.WriteLine("*****************************************");
    Console.WriteLine("* Add Asset\t- 1\t\t\t*\n* Sort\t\t- 2\t\t\t*\n* Exit\t\t- 3\t\t\t*");
    Console.WriteLine("*****************************************");

    Sel = DataIO.Selchk("selection",3);       
    
    switch (Sel)
    {
        case 1:
            {
                // Code to add asset
                Console.Clear();
                AssetOp.Input(AssetList);
                AssetOp.Output(AssetList);
                break;
            }
        case 2:
            {
                // Code to Display asset
                Console.Clear();
                AssetOp.SortList(AssetList);
               
                break;
            }
    }
} while (Sel != 3);
Console.ReadLine();
