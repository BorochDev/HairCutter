using System;
using System.Collections.Generic;
using System.Text;



namespace HairCuter
{
	enum Status
	{
		none = 10,
		bronze = 20,
		silver = 30,
		gold = 40
	}

	class Customer
    {
		public Status Status{ get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public DateTime VisitDate { get; set; }
		public float Price { get; set; }

		public Customer(Status status, string name, string surname, DateTime date, float price)
		{
			Status = status;
			Name = name;
			Surname = surname;
			VisitDate = date;
			Price = ((int)(price*((100 - (int)status))))/100;
		}

	}
}
