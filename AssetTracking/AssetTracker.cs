// Program to track assset 
using AssetTracking;
using System.Runtime;

int Sel;

List<AssetData> AssetList = new List<AssetData>(); //Creating list for product details


do
{

    Console.WriteLine("*****************************************");
    Console.WriteLine("* Please Enter your selection from Menu *");
    Console.WriteLine("*****************************************");
    Console.WriteLine("* Add Asset\t- 1\t\t\t*\n* Search Asset\t- 2\t\t\t*\n* Exit\t\t- 3\t\t\t*");
    Console.WriteLine("*****************************************");
    Console.Write("Please Select An Operation : ");
    string inp = Console.ReadLine();
    Sel = Convert.ToInt32(inp);

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
                // Code to Search asset
                Console.Clear();
                Console.WriteLine("Search Asset");
                break;
            }

    }
} while (Sel != 3);



Console.ReadLine();
