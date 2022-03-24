using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
	enum type
	{
		Rubber,
		Mallard,
		Readhead
	};

	enum equipmentType
	{
		mobile,
		immobile
	};

	public abstract class Duck
	{
		private int weight;
		private int no_of_wings;
		private string _type;

		public int get_weight()
		{
			return this.weight;
		}
		public void set_weight(int x)
		{
			this.weight = x;
		}
		public int get_wings() { return this.no_of_wings; }
		public void set_wings(int x) { this.no_of_wings = x; }
		public abstract string get_type();
		public abstract void ShowDetails();

	}

	public class Rubber : Duck
	{
		public override string get_type()
		{
			return "Rubber";
		}
		public override void ShowDetails()
		{
			Console.WriteLine("I am a {0} Duck", this.get_type());
			Console.WriteLine("I have {0} wings, and my weight is {1} kg", this.get_wings(), this.get_weight());
			Console.WriteLine("I neither fly nor squeak");
		}
	}

	public class Mallard : Duck
	{
		public override string get_type()
		{
			return "Mallard";
		}
		public override void ShowDetails()
		{
			Console.WriteLine("I am a {0} Duck", this.get_type());
			Console.WriteLine("I have {0} wings, and my weight is {1} kg", this.get_wings(), this.get_weight());
			Console.WriteLine("I fly fast and quack loud");
		}
	}

	public class Redhead : Duck
	{
		public override string get_type()
		{
			return "Redhead";
		}
		public override void ShowDetails()
		{
			Console.WriteLine("I am a {0} Duck", this.get_type());
			Console.WriteLine("I have {0} wings, and my weight is {1} kg", this.get_wings(), this.get_weight());
			Console.WriteLine("I fly slow and quack mild");
		}
	}

	public class Equipment
	{
		private string _name;
		private string _description;
		private int _distance;
		private int _maintainence;
		private string _type;

		public Equipment()
		{
			_distance = 0;
			_maintainence = 0;
		}

		public virtual void MoveBy(int x) { }
		public virtual void ShowDetails() { }

		public void set_type(string typeName) { this._type = typeName; }
		public string get_type() { return (this._type == "0" ? "Mobile" : "Immobile"); }

		public void set_name(string name) { this._name = name; }
		public string get_name() { return this._name; }

		public void set_description(string desc) { this._description = desc; }
		public virtual string get_description() { return this._description; }

		public void set_distance(int x) { this._distance = this._distance + x; }
		public int get_distance() { return this._distance; }

		public void set_maintainence(int x) { this._maintainence = this._maintainence + x; }
		public int get_maintainence() { return this._maintainence; }

	}

	public class Mobile : Equipment
	{
		private int _wheels;

		public void set_wheels(int x) { this._wheels = x; }
		public int get_wheels() { return this._wheels; }

		public override void MoveBy(int x)
		{
			this.set_distance(x);
			int newMaintainence = this.get_wheels() * this.get_distance();
			this.set_maintainence(newMaintainence);
		}

		public override void ShowDetails()
		{
			Console.WriteLine("This is a {0}", this.get_name());
			Console.WriteLine(this.get_description());
			Console.WriteLine("This is a {0} type of Equipment", this.get_type());
			Console.WriteLine("It has {0} wheels, and it has travelled a total distance of {1} km", this.get_wheels(), this.get_distance());
			Console.WriteLine("It has a total maintainence cost of Rs.{0}", this.get_maintainence());
		}
	}

	public class Immobile : Equipment
	{
		private int _weight;

		public void set_weight(int x) { this._weight = x; }
		public int get_weight() { return this._weight; }

		public override void MoveBy(int x)
		{
			this.set_distance(x);
			int newMaintainence = this.get_distance() * this.get_weight();
			this.set_maintainence(newMaintainence);
		}

		public override void ShowDetails()
		{
			Console.WriteLine("This is a {0}", this.get_name());
			Console.WriteLine(this.get_description());
			Console.WriteLine("This is a {0} type of Equipment", this.get_type());
			Console.WriteLine("It has {0} wheels, and it has travelled a total distance of {1} km", this.get_weight(), this.get_distance());
			Console.WriteLine("It has a total maintainence cost of Rs.{0}", this.get_maintainence());
		}
	}

	class Program
    {
		static void IterateDucks(List<Redhead> duckList)
		{
			duckList.Sort((duck1, duck2) => duck1.get_wings().CompareTo(duck2.get_wings()));

			for(int i=0; i<5; i++)
			{
				duckList[i].ShowDetails();
				Console.WriteLine("\n");
			}
		}

        static void Main(string[] args)
        {
			Console.WriteLine("1. Exercise 6 \n2. Exercise 7");
			Console.WriteLine("Enter Exercise of your choice");
			int exerciseChoice = Convert.ToInt16(Console.ReadLine());

            switch (exerciseChoice)
            {
                #region exercise 6
                case 1:
					Console.Clear();
                    List<Mobile> mobileEquipmentList = new List<Mobile>();
					List<Immobile> immobileEquipmentList = new List<Immobile>();

					// Creating equipments
					for(int i=0; i<4; i++)
                    {
						Console.Clear();
                        Console.WriteLine("1. Mobile \n2. Immobile");
                        Console.WriteLine("Enter type of Equipment: ");
						int equipmentChoice = Convert.ToInt16(Console.ReadLine());

                        switch (equipmentChoice)
                        {
                            #region mobile equipment
                            case 1:
								Mobile mobileEquipment = new Mobile();

                                Console.WriteLine("Enter name of equipment: ");
								string mobileName = Console.ReadLine();

                                Console.WriteLine("Enter Description of Equipment: ");
								string mobileDesc = Console.ReadLine();

                                Console.WriteLine("Enter Number of wheels: ");
								int mobileWheels = Convert.ToInt16(Console.ReadLine());

								mobileEquipment.set_name(mobileName);
								mobileEquipment.set_description(mobileDesc);
								mobileEquipment.set_type(Convert.ToString(equipmentType.mobile));
								mobileEquipment.set_wheels(mobileWheels);

								mobileEquipmentList.Add(mobileEquipment);

								break;
                            #endregion

                            #region immobile equipment
                            case 2:
								Immobile immobileEquipment = new Immobile();

								Console.WriteLine("Enter name of equipment: ");
								string immobileName = Console.ReadLine();

								Console.WriteLine("Enter Description of Equipment: ");
								string immobileDesc = Console.ReadLine();

                                Console.WriteLine("Enter weight of Equipment: ");
								int immobileWeight = Convert.ToInt32(Console.ReadLine());

								immobileEquipment.set_name(immobileName);
								immobileEquipment.set_description(immobileDesc);
								immobileEquipment.set_type(Convert.ToString(equipmentType.immobile));
								immobileEquipment.set_weight(immobileWeight);

								immobileEquipmentList.Add(immobileEquipment);

								break;
                            #endregion

                            default:
                                Console.WriteLine("Enter correct choice!!!");
								break;
						}
					}

					Console.WriteLine("Moving first mobile equipment...\n");
					mobileEquipmentList[0].MoveBy(3);

                    Console.WriteLine("Moving Second mobile equipment...\n");
					immobileEquipmentList[0].MoveBy(4);

					for (int i= 0; i<2; i++) { 
						Console.WriteLine("Name: {0} \nDescription: {1}\n", mobileEquipmentList[i].get_name(), mobileEquipmentList[i].get_description()); 
					}

					for (int i = 0; i < 2; i++)
					{
						Console.WriteLine("Name: {0} \nDescription: {1}\n", immobileEquipmentList[i].get_name(), immobileEquipmentList[i].get_description());
					}

                    Console.WriteLine("\nShowing complete details of an equipment");
                    Console.WriteLine("Name: {0}", immobileEquipmentList[0].get_name());
                    Console.WriteLine("Description: {0}", immobileEquipmentList[0].get_description());
                    Console.WriteLine("Type: {0}", immobileEquipmentList[0].get_type());
                    Console.WriteLine("Weight: ", immobileEquipmentList[0].get_weight());
                    Console.WriteLine("Distance Travelled: {0}km", immobileEquipmentList[0].get_distance());
                    Console.WriteLine("Maintainence cost: Rs{0}", immobileEquipmentList[0].get_maintainence());

                    Console.WriteLine("\nDeleting all equipments...");
					mobileEquipmentList.Clear();
					immobileEquipmentList.Clear();

					break;
                #endregion

				#region exercise 7
                case 2:
					Console.Clear();
                    Console.WriteLine("Adding a few ducks...");

					List<Redhead> duckList = new List<Redhead>();

					#region creating ducks
					Redhead duck1 = new Redhead();
					duck1.set_weight(14);
					duck1.set_wings(50);
					duckList.Add(duck1);

					Redhead duck2 = new Redhead();
					duck2.set_weight(18);
					duck2.set_wings(48);
					duckList.Add(duck2);

					Redhead duck3 = new Redhead();
					duck3.set_weight(12);
					duck3.set_wings(45);
					duckList.Add(duck3);

					Redhead duck4 = new Redhead();
					duck4.set_weight(16);
					duck4.set_wings(65);
					duckList.Add(duck4);

					Redhead duck5 = new Redhead();
					duck5.set_weight(20);
					duck5.set_wings(60);
					duckList.Add(duck5);
					#endregion

					// Default iteration of ducks in increasing order of wings
					Console.WriteLine("Iterating in increasing order of Wings\n");
					IterateDucks(duckList);

					// Iterating ducks in increasing order of weights
					Console.WriteLine("Iterating in increasing order of weights");
					duckList.Sort((d1, d2) => d1.get_weight().CompareTo(d2.get_weight()));
					for(int i=0; i<5; i++)
					{
						duckList[i].ShowDetails();
						Console.WriteLine("\n");
					}
					
					Console.ReadLine();

					break;
					#endregion

				default:
                    Console.WriteLine("Please enter a valid choice!!!");
					break;
            }
        }
    }
}
