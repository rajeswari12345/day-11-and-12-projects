// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
public class InventoryManager
{ 
	public static void Main(string[] args)
	{
		Console.Write("Hello Manager!!!");
		Console.WriteLine(" Lets Add some inventory");
		Console.WriteLine("How much inventory you want to add");
		int num = OOPsUtility.integerScanner();

		int choice;
		string name;
		int weight;
		int pricePerKg;
		int totalPriceOfWeight;
		int inventoryGrandTotal = 0;
		InventoryDetailModel model = new InventoryDetailModel();

		model = (InventoryDetailModel)JsonUtil.readMapper(oldFilePath, model);

		List<Rice> riceList = new List<Rice>();
		List<Pulses> pulsesList = new List<Pulses>();
		List<Wheats> wheatsList = new List<Wheats>();
		model.getRice().get(0).setTotalPriceOfWeight(model.getRice().get(0).getWeight() * model.getRice().get(0).getPrice_per_kg());
		model.getPulses().get(0).setTotalPriceOfWeight(model.getPulses().get(0).getWeight() * model.getPulses().get(0).getPrice_per_kg());
		model.getWheats().get(0).setTotalPriceOfWeight(model.getWheats().get(0).getWeight() * model.getWheats().get(0).getPrice_per_kg());
		int riceSize = model.getRice().size();
		int pulsesSize = model.getPulses().size();
		int wheatsSize = model.getWheats().size();
		for (int i = 0; i <= model.getRice().size() - 1; i++)
		{
			inventoryGrandTotal += model.getRice().get(riceSize - 1).getTotalPriceOfWeight();
			riceSize--;
		}
		for (int i = 0; i <= model.getPulses().size() - 1; i++)
		{
			inventoryGrandTotal += model.getPulses().get(pulsesSize - 1).getTotalPriceOfWeight();
			pulsesSize--;
		}
		for (int i = 0; i <= model.getPulses().size() - 1; i++)
		{
			inventoryGrandTotal += model.getWheats().get(wheatsSize - 1).getTotalPriceOfWeight();
			wheatsSize--;
		}
		riceList.AddRange(model.getRice());
		pulsesList.AddRange(model.getPulses());
		wheatsList.AddRange(model.getWheats());

		for (int i = 0; i < num; i++)
		{
			Console.WriteLine("For adding press \n1. for rice\n2. for pulses\n3. for wheats: ");
			choice = OOPsUtility.integerScanner();

			switch (choice)
			{
				case 1:
					Rice rice = new Rice();
					Console.WriteLine("Enter name of brand: ");
					name = OOPsUtility.stringScanner();
					Console.WriteLine("Enter weight: ");
					weight = OOPsUtility.integerScanner();
					Console.WriteLine("Enter price per kg: ");
					pricePerKg = OOPsUtility.integerScanner();
					totalPriceOfWeight = weight * pricePerKg;

					inventoryGrandTotal += totalPriceOfWeight;

					rice.setName(name);
					rice.setWeight(weight);
					rice.setPrice_per_kg(pricePerKg);
					rice.setTotalPriceOfWeight(totalPriceOfWeight);

					riceList.Add(rice);
					break;
				case 2:
					Pulses pulses = new Pulses();
					Console.WriteLine("Enter name of brand: ");
					name = OOPsUtility.stringScanner();
					Console.WriteLine("Enter weight: ");
					weight = OOPsUtility.integerScanner();
					Console.WriteLine("Enter price per kg: ");
					pricePerKg = OOPsUtility.integerScanner();
					totalPriceOfWeight = weight * pricePerKg;

					inventoryGrandTotal += totalPriceOfWeight;

					pulses.setName(name);
					pulses.setWeight(weight);
					pulses.setPrice_per_kg(pricePerKg);
					pulses.setTotalPriceOfWeight(totalPriceOfWeight);

					pulsesList.Add(pulses);

					break;
				case 3:
					Wheats wheats = new Wheats();
					Console.WriteLine("Enter name of brand: ");
					name = OOPsUtility.stringScanner();
					Console.WriteLine("Enter weight: ");
					weight = OOPsUtility.integerScanner();
					Console.WriteLine("Enter price per kg: ");
					pricePerKg = OOPsUtility.integerScanner();
					totalPriceOfWeight = weight * pricePerKg;

					inventoryGrandTotal += totalPriceOfWeight;

					wheats.setName(name);
					wheats.setWeight(weight);
					wheats.setPrice_per_kg(pricePerKg);
					wheats.setTotalPriceOfWeight(totalPriceOfWeight);

					wheatsList.Add(wheats);

					break;
				default:
					Console.WriteLine("Please select valid option!!");
					continue;
			}

		}

		model.setTotal(inventoryGrandTotal);
		model.setRice(riceList);
		model.setPulses(pulsesList);
		model.setWheats(wheatsList);

		Console.WriteLine(JsonUtil.writeMapper(path, model));
		Console.WriteLine("Inventory is added into new json File");

	}

}
