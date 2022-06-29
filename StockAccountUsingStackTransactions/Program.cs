// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
using System;
using System.Collections.Generic;

public class StockAccountUsingStackTransactions
{
     public static void Main(string[] args)
	{
		

		TransactionModel model = new TransactionModel();

		model = (TransactionModel)JsonUtil.readMapper(pathOfTransactions, model);

		Stack<Transactions> stack = new Stack<Transactions>();

		stack.pushAll(model.getTransactions());

		Console.WriteLine("Enter password");
		if (OOPsUtility.stringScanner().Equals("admin"))
		{
			Console.WriteLine("Enter company symbol to see transactions of that company: ");
			int companySymbol = OOPsUtility.integerScanner();
			bool isPrint = false;

			Console.WriteLine("Validating...");
			int size = stack.Count;
			for (int i = 0; i < size; i++)
			{

				if (companySymbol == int.Parse(stack.Peek().getTransaction_id().Substring(7, 4).ToString()))
				{
					if (!isPrint)
					{
						if (i == 0)
						{
							Console.Write("Transaction_ID\t");
							Console.Write("Buyer\t\t");
							Console.Write("Seller\t\t\t");
							Console.Write("Trans_Amt\t");
							Console.WriteLine("DateTime\t");
						}
						isPrint = true;
					}
					Console.Write(stack.Peek().getTransaction_id() + "\t");
					Console.Write(stack.Peek().getBuyer() + "\t\t");
					Console.Write(stack.Peek().getSeller() + "\t\t");
					Console.Write(stack.Peek().getTransaction_amount() + "\t");
					Console.WriteLine(stack.Peek().getDatetime() + "\t");
				}

				stack.Pop();
			}
			if (!isPrint)
			{
				Console.WriteLine("No transaction for this company");
			}
		}
		else
		{
			Console.WriteLine("Password incorrect");
		}

	}

}
