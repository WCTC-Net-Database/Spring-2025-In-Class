namespace W6_SOLID_DIP.Models
{
    // Interface - defines the blueprint and forces the developer to implement the methods
    public interface IExample
    {
        void ExampleMethod();

        void ExampleMethodMustBeImplemented();
    }

    public class Example : IExample
    {
        public void ExampleMethod()
        {
            Console.WriteLine("Example.ExampleMethod");
        }

        public void ExampleMethodMustBeImplemented()
        {
            Console.WriteLine("Example.ExampleMethodMustBeImplemented");
        }
    }

    // Abstract class - defines properties and methods that can be used or overridden
    public abstract class ExampleBase
    {

        public string Name { get; set; }

        public ExampleBase()
        {
            Console.WriteLine("1. ExampleBase constructor");
        }

        // basic old method - POC - not intended to be changed
        public void ExampleMethod()
        {
            Console.WriteLine("3. ExampleBase.ExampleMethod");
        }

        // virtual method - can be overriden
        public virtual void ExampleMethodCanChange()
        {
            Console.WriteLine("ExampleBase.ExampleMethodCanChange");
        }

        public abstract void ExampleMethodMustBeImplemented();
    }

    public class ExampleDerived : ExampleBase
    {
        public ExampleDerived()
        {
            Console.WriteLine("2. ExampleDerived constructor");
        }

        public new void ExampleMethod()
        {
            Console.WriteLine("Our new method - ExampleDerived.ExampleMethod");
        }

        public override void ExampleMethodCanChange()
        {
            base.ExampleMethodCanChange();
            Console.WriteLine("ExampleDerived.ExampleMethodCanChange");
        }

        public override void ExampleMethodMustBeImplemented()
        {
            Console.WriteLine("ExampleDerived.ExampleMethodMustBeImplemented");
        }
    }

    // Main Program
    public class MainProgram
    {
        public MainProgram()
        {
            //var myVariable1 = new Example();
            //myVariable1.ExampleMethod();

            var myVariable2 = new ExampleDerived();
            myVariable2.ExampleMethod();
            myVariable2.ExampleMethodCanChange();
        }
    }
}
