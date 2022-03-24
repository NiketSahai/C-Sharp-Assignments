using System;

enum type{
	Rubber,
	Mallard,
	Readhead
};

public abstract class Duck
{
	private int _weight;
	private int _no_of_wings;
	private string _type;

	public int get_weight() {
		return this._weight;
	}
	public void set_weight(int x)
    {
		this._weight = x;
    }
	public int get_wings() { return this._no_of_wings; }
	public void set_wings() { return this._no_of_wings; }
	public abstract get_type();
	public abstract ShowDetails();
	
}

public class Rubber: Duck {
	public override get_type(){
		return type.Rubber;
	}
	public override ShowDetails()
    {
        Console.WriteLine("I am a rubber Duck");
        Console.WriteLine("I have {0} wings, and my weight is {1} kg", this.get_wings(), this.get_weight());
        Console.WriteLine("I neither fly nor squeak");
    }
}

public class Mallard: Duck
{
	public override get_type()
    {
		return type.Mallard;
    }
	public override ShowDetails()
    {
		Console.WriteLine("I am a Mallard Duck");
		Console.WriteLine("I have {0} wings, and my weight is {1} kg", this.get_wings(), this.get_weight());
		Console.WriteLine("I fly fast and quack loud");
	}
}

public class Redhead: Duck
{
	public override get_type()
	{
		return type.Readhead;
	}
	public override ShowDetails()
	{
		Console.WriteLine("I am a Redhead Duck");
		Console.WriteLine("I have {0} wings, and my weight is {1} kg", this.get_wings(), this.get_weight());
		Console.WriteLine("I fly slow and quack mild");
	}
}
