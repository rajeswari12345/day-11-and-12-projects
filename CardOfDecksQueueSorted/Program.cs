// See https://aka.ms/new-console-template for more information
using System;
public class CardOfDecksQueueSorted
{

	public static void Main(string[] args)
	{
		string[] cardType = new string[] { "Clubs", "Diamonds", "Hearts", "Spades" };
		string[] cardNumb = new string[] { "201", "302", "403", "504", "605", "706", "807", "908", "1009", "Jack10", "Queen11", "King12", "Ace13" };
		string[] cardDeck = new string[52];
		QueueImplementedUsingLinkedList<string> queue = new QueueImplementedUsingLinkedList<string>();
		int j2 = 0;
		for (int i = 0; i < cardType.Length; i++)
		{
			for (int j = 0; j < cardNumb.Length; j++)
			{
				cardDeck[j2] = cardType[i] + " " + cardNumb[j];
				j2++;
			}
		}

		cardDeck = OOPsUtility.shuffleCardsDeck(cardDeck);
		Console.WriteLine(Arrays.toString(cardDeck));
		string[] arr = new string[9];
		char[] last1 = new char[2];
		char[] last2 = new char[2];
		j2 = 0;
		string temp1, temp2, temp3, temp4;
		for (int p = 0; p < 4; p++)
		{
			for (int j = 0; j < 9; j++)
			{
				arr[j] = cardDeck[j2];
				j2++;

			}
			
			for (int i = 0; i < arr.Length - 1; i++)
			{
				for (int j = 0; j < arr.Length - i - 1; j++)
				{
					temp1 = arr[j];
					temp2 = arr[j + 1];

					last1[0] = temp1[temp1.Length - 2];
					last1[1] = temp1[temp1.Length - 1];
					last2[0] = temp2[temp2.Length - 2];
					last2[1] = temp2[temp2.Length - 1];
					if (java.util.Arrays.compare(last1, last2) > 0)
					{
						temp3 = arr[j];
						arr[j] = arr[j + 1];
						arr[j + 1] = temp3;

					}

				}

			}
		       Console.WriteLine(Arrays.toString(arr));
				Console.WriteLine();
			queue.enQueue("For Player " + p + " : \n");
			for (int j = 0; j < 9; j++)
			{
				temp4 = arr[j].Substring(0, arr[j].Length - 2);
				Console.WriteLine(temp4+"-->");
				queue.enQueue(temp4 + "-->");
			}
			 Console.WriteLine();
			queue.enQueue("\n");
		}
		// printing the queue
		Console.WriteLine(queue.showQueueWithoutSpace());

	}

}
