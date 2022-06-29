// See https://aka.ms/new-console-template for more information
using System;

public class StockAccountUsingQueueTransactions
{

	public static void Main(string[] args)
	{
		

		TransactionModel model = new TransactionModel();

		model = (TransactionModel)JsonUtil.readMapper(pathOfTransactions, model);

		QueueUsingLL<Transactions> queue = new QueueUsingLL<Transactions>();

		queue.enQueueAll(model.getTransactions());

		Console.WriteLine("Enter password");
		if (OOPsUtility.stringScanner().Equals("admin"))
		{
			int size = queue.size();
			
			Console.WriteLine("Transactions time");
			for (int i = 0; i < size; i++)
			{
				Console.WriteLine(queue.get(0).getDatetime());
				queue.deQueue();
			}
		}
		else
		{
			Console.WriteLine("Invalid password");
		}
	}

}
