// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
public class CardOfDecks
{

	public static void Main(string[] args)
	{

		string[] cardType = new string[] { "Clubs", "Diamonds", "Hearts", "Spades" };
		string[] cardNumbers = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };
		string[] cardsArray = new string[52];
		int start = 0, end = 12, j1 = 0;
		// for combination of cardType and cardNumbers
		for (int i = 0; i < 4; i++)
		{
			for (int j = start; j <= end; j++)
			{
				cardsArray[j] = cardType[i] + " " + cardNumbers[j1];
				j1++;
			}
			j1 = 0;
			start = end + 1;
			end += 13;
		}

		// printing all cards
		//		for (int i = 0; i < cardsArray.length; i++) {
		//			System.out.print(cardsArray[i] + " ");
		//		}
		// code for shuffle all the cards
		OOPsUtility.shuffleCardsDeck(cardsArray);
		Console.WriteLine("**************************************");

		// printing cards for 4 player

		int j2 = 0;
		for (int i = 0; i < 4; i++)
		{
			Console.Write("For Player " + i + ": \n");
			for (int j = 0; j < 9; j++)
			{

				Console.Write(cardsArray[j2] + "-->");
				j2++;
			}
			Console.WriteLine();
		}

	}

}
