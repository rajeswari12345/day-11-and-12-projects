// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Linq;

public class StockAccountUsingLinkedListCompanyShares
{
	public static void Main(string[] args)
	{

		CompanysharesModel compModel = new CompanysharesModel();

		// code for fetching json data and put it into models
		File file = new File(pathOfCompanyShares);
		// code for fetching the company shares
		if (file.length() != 0)
		{
			compModel = (CompanysharesModel)JsonUtil.readMapper(pathOfCompanyShares, compModel);
		}

		LinkedList<Companyshares> compList = new LinkedList<Companyshares>();

		compList.addAll(compModel.getCompanyshares());
		bool isExit = false;
		Console.WriteLine("Please enter password to access company data");
		if (OOPsUtility.stringScanner().Equals("admin"))
		{
			while (!isExit)
			{
				Console.WriteLine("Enter company symbol: ");
				int companySymbol = OOPsUtility.integerScanner();
				int indexOfCompany = 0;
				bool isCompanyFound = false;
				for (int i = 0; i < compList.Count; i++)
				{
					if (companySymbol == compList.ToList()[i].getCompany_symbol())
					{
						isCompanyFound = true;
						indexOfCompany = i;
						break;
					}
				}
				if (isCompanyFound)
				{

					Console.WriteLine("The company you selected is: " + compList.ToList()[indexOfCompany].getCompany_name());
					Console.WriteLine("Company shares: " + compList.ToList()[indexOfCompany].getCompany_shares());
					Console.WriteLine("Company share price: " + compList.ToList()[indexOfCompany].getCompany_share_price());
					Console.WriteLine("Company Total value: " + compList.ToList()[indexOfCompany].getCompany_total_value());
					Console.WriteLine("Welcome please select task: ");
					Console.WriteLine("1. for adding shares\n2. for removing shares\n3. for exit");
					int sharesAmount;
					switch (OOPsUtility.integerScanner())
					{
						case 1:
							// for adding shares
							Console.WriteLine("Enter number of shares");
							sharesAmount = OOPsUtility.integerScanner();
							compList.ToList()[indexOfCompany].setCompany_shares(compList.ToList()[indexOfCompany].getCompany_shares() + sharesAmount);
							compList.ToList()[indexOfCompany].setCompany_total_value(compList.ToList()[indexOfCompany].getCompany_shares() * compList.ToList()[indexOfCompany].getCompany_share_price());
							Console.WriteLine("Data saved!!!");
							Console.WriteLine("Company: " + compList.ToList()[indexOfCompany].getCompany_name());
							Console.WriteLine("Company shares: " + compList.ToList()[indexOfCompany].getCompany_shares());
							Console.WriteLine("Company share price: " + compList.ToList()[indexOfCompany].getCompany_share_price());
							Console.WriteLine("Company Total value: " + compList.ToList()[indexOfCompany].getCompany_total_value());

							JsonUtil.readMapper(pathOfCompanyShares, compModel);
							break;
						case 2:
							// for removing shares
							Console.WriteLine("Enter number of shares to remove");
							sharesAmount = OOPsUtility.integerScanner();
							// check whether company have greater shares than sharesto remove
							if (compList.ToList()[indexOfCompany].getCompany_shares() > sharesAmount)
							{
								compList.ToList()[indexOfCompany].setCompany_shares(compList.ToList()[indexOfCompany].getCompany_shares() - sharesAmount);
								compList.ToList()[indexOfCompany].setCompany_total_value(compList.ToList()[indexOfCompany].getCompany_shares() * compList.ToList()[indexOfCompany].getCompany_share_price());

								Console.WriteLine("Data saved!!!");
								Console.WriteLine("Company: " + compList.ToList()[indexOfCompany].getCompany_name());
								Console.WriteLine("Company shares: " + compList.ToList()[indexOfCompany].getCompany_shares());
								Console.WriteLine("Company share price: " + compList.ToList()[indexOfCompany].getCompany_share_price());
								Console.WriteLine("Company Total value: " + compList.ToList()[indexOfCompany].getCompany_total_value());
								JsonUtil.readMapper(pathOfCompanyShares, compModel);
							}
							else
							{
								Console.WriteLine("Company don't have that much shares to remove");
							}

							break;
						case 3:
							isExit = true;
							Console.WriteLine("Thank you for your time");
							break;
						default:
							Console.WriteLine("Invalid Option");
							break;

					}
				}
				else
				{
					Console.WriteLine("Company not found");
				}
			}

		}
		else
		{
			Console.WriteLine("Invalid password");
		}

	}

}
