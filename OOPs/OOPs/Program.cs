using System;

namespace OOPs
{   
    enum type{
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
		private string type;

		public int get_weight() {
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

	public class Rubber: Duck {
		public override string get_type(){
			return "Rubber";
		}
		public override void ShowDetails()
		{
			Console.WriteLine("I am a rubber Duck");
			Console.WriteLine("I have {0} wings, and my weight is {1} kg", this.get_wings(), this.get_weight());
			Console.WriteLine("I neither fly nor squeak");
		}
	}

	public class Mallard: Duck
	{
		public override string get_type()
		{
			return "Mallard";
	   }
		public override void ShowDetails()
		{
			Console.WriteLine("I am a Mallard Duck");
			Console.WriteLine("I have {0} wings, and my weight is {1} kg", this.get_wings(), this.get_weight());
			Console.WriteLine("I fly fast and quack loud");
		}
	}

	public class Redhead: Duck
	{
		public override string get_type()
		{
			return "Redhead";
		}
		public override void ShowDetails()
		{
			Console.WriteLine("I am a Redhead Duck");
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
		public string get_type() { return (this._type == "0"? "Mobile" : "Immobile"); }

		public void set_name(string name) { this._name = name; }
		public string get_name() { return this._name; }

		public void set_description(string desc) { this._description = desc; }
		public virtual string get_description() { return this._description; }

		public void set_distance(int x) { this._distance = this._distance + x; }
		public int get_distance() { return this._distance; }

		public void set_maintainence(int x) { this._maintainence = this._maintainence + x; }
		public int get_maintainence() { return this._maintainence; }

    }

	public class Mobile: Equipment {
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

	public class Immobile: Equipment { 
		private int _weight;

		public void set_weight(int x) { this._weight = x;}
		public int get_weight() { return this._weight;}

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
        static void Main(string[] args)
        {	
			Console.WriteLine("1. Excercise 3 \n2. Excercise 4");
			Console.WriteLine("Enter exercise of your choice(1, 2): ");
			int exerciseChoice = Convert.ToByte(Console.ReadLine());
            switch (exerciseChoice)
            {
				case 1:
					Immobile transport = new Immobile();
					transport.set_name("Refrigerator");
					transport.set_description("Used for storing fodd items at sub zero temperatures");
					transport.set_weight(4);
					transport.set_type(Convert.ToString(equipmentType.immobile));
					transport.MoveBy(12);
					transport.MoveBy(3);
					transport.ShowDetails();
					Console.ReadLine();
					break;
				
				case 2:
					Mallard duck = new Mallard();
					duck.set_weight(3);
					duck.set_wings(100);
					duck.ShowDetails();
					Console.ReadLine();
					break;

				default:
					Console.WriteLine("Please enter correct choice!!!");
					break;

            }
			
        }
    }
}
